using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Base.Data.Postgre.Dto;
using Base.Data.Postgre.Dao.Interfaces;
using Microsoft.EntityFrameworkCore;
using Base.Data.Postgre;
using System.Data;
using Dapper;

namespace Base.Data.Postgre.Dao
{
    public abstract class BasePostgreDao<TDto> : IPostgreDao<TDto> where TDto : BaseDto
    {
        protected DbContext DbContext { get; set; }
        protected DbSet<TDto> DbSet { get; set; }
        private IDbConnection connection;

        public BasePostgreDao(IDatabaseSelector dbSelector)
        {
            this.DbContext = dbSelector.GetDbContext<TDto>();
            this.DbSet = DbContext.Set<TDto>();
            this.connection = DbContext.Database.GetDbConnection();
        }

        #region sync method
        public TDto GetById(object[] keyValues)
        {
            var entity = DbSet.Find(keyValues);
            return entity;
        }
        public void Add(TDto entity)
        {
            DbSet.Add(entity);
            SaveChanges();
        }

        public void AddRange(List<TDto> entities)
        {
            DbSet.AddRange(entities);
            SaveChanges();
        }       

        public void Update(TDto entity)
        {
            DbContext.Entry(entity).CurrentValues.SetValues(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }

        public void UpdateBulk(List<TDto> entities)
        {
            foreach(var entity in entities)
                DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.UpdateRange(entities);
            SaveChanges();
        }

        public void Delete(TDto entity)
        {
            DbSet.Remove(entity);
            SaveChanges();
        }

        public int ExecuteRawSql(string sql, params object[] parameters)
        {
            var result = DbContext.Database.ExecuteSqlRaw(sql, parameters);
            return result;
        }
        public int ExecuteSp(string spName, object param)
        {
            var executeResult = DbContext.Database.GetDbConnection().Execute(
                    spName,
                    param,
                    null,
                    null,
                    CommandType.StoredProcedure
                );
            return executeResult;
        }

        public virtual List<V> QueryRawSql<V>(string statement, object param)
        {
            var queryResult = DbContext.Database.GetDbConnection().Query<V>(
                    statement,
                    param,
                    null,
                    commandTimeout: null,
                    commandType: CommandType.Text
                );
            var result = queryResult.ToList();
            return result;
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public List<TDto> Filter(params Expression<Func<TDto, bool>>[] conditions)
        {
            var query = DbSet.AsNoTracking();

            if(conditions != null && conditions.Length > 0)
                foreach(var condition in conditions)
                {
                    query = query.Where(condition);
                }

            var result = query.ToList();
            return result;
        }

        #endregion

        #region async method
        public async Task<TDto> GetByIdAsync(object[] keyValues)
        {
            var entity = await DbSet.FindAsync(keyValues);
            return entity;
        }

        public async Task AddAsync(TDto entity)
        {
            await DbSet.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task AddRangeAsync(List<TDto> entities)
        {
            await DbSet.AddRangeAsync(entities);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(TDto entity)
        {
            DbContext.Entry(entity).CurrentValues.SetValues(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        public async Task UpdateBulkAsync(List<TDto> entities)
        {
            foreach (var entity in entities)
                DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.UpdateRange(entities);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(TDto entity)
        {
            DbSet.Remove(entity);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await DbContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task<List<TDto>> FilterAsync(params Expression<Func<TDto, bool>>[] conditions)
        {
            var query = DbSet.AsNoTracking();
            foreach (var condition in conditions)
            {
                query = query.Where(condition);
            }
            var result = await query.ToListAsync();
            return result;
        }

        public virtual async Task<List<V>> QueryRawSqlAsync<V>(string statement, object param = null)
        {
            var queryResult = await DbContext.Database.GetDbConnection().QueryAsync<V>(
                    statement,
                    param,
                    null,
                    commandTimeout: null,
                    commandType: CommandType.Text
                );
            var result = queryResult.ToList();
            return result;
        }

        public virtual async Task<List<V>> QuerySpAsync<V>(string spName, object param = null)
        {
            var queryResult = await DbContext.Database.GetDbConnection().QueryAsync<V>(
                    spName,
                    param,
                    null,
                    commandTimeout: null,
                    commandType: CommandType.StoredProcedure
                );
            var result = queryResult.ToList();
            return result;
        }

        public async Task<object> QueryScalarSPAsync(string spName, object param)
        {
            var queryResult = await DbContext.Database.GetDbConnection().ExecuteScalarAsync(
                    spName,
                    param,
                    null,
                    commandTimeout: null,
                    commandType: CommandType.StoredProcedure
                );

            return queryResult;
        }

        #endregion
    }
}
