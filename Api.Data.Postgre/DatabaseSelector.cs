using System;
using System.Collections.Generic;
using System.Text;
using Base.Data.Postgre;
using Base.Data.Postgre.Dto;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Postgre
{
    public class DatabaseSelector : IDatabaseSelector
    {
        private readonly CRMDbContext dbContext;

        public DatabaseSelector(
            CRMDbContext dbContext
            )
        {
            this.dbContext = dbContext;
        }
        public DbContext GetDbContext<TDto>() where TDto : BaseDto
        {
            return dbContext;
        }
    }
}
