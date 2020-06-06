using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data.Postgre.Dao.Interfaces
{
    public interface IPostgreDao<TDto>
    {
        TDto GetById(object[] keyValues);
        void Add(TDto entity);
        void Update(TDto entity);
        void Delete(TDto entity);
        void AddRange(List<TDto> entities);
        void UpdateBulk(List<TDto> entities);
        List<TDto> Filter(params Expression<Func<TDto, bool>>[] conditions);

        Task<TDto> GetByIdAsync(object[] keyValues);
        Task AddAsync(TDto entity);
        Task UpdateAsync(TDto entity);
        Task DeleteAsync(TDto entity);
        Task AddRangeAsync(List<TDto> entities);
        Task UpdateBulkAsync(List<TDto> entities);
        Task<List<TDto>> FilterAsync(params Expression<Func<TDto, bool>>[] conditions);
        Task<List<V>> QueryRawSqlAsync<V>(string statement, object param = null);
        Task<List<V>> QuerySpAsync<V>(string spName, object param = null);
        Task<object> QueryScalarSPAsync(string spName, object param);
    }
}
