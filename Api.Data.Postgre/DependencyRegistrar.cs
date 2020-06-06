using System;
using System.Collections.Generic;
using System.Text;
using Api.Data.Postgre.Dao;
using Api.Data.Postgre.Dao.Interfaces;
using Base.Data.Postgre;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Postgre
{
    public static class DependencyRegistrar
    {
        public static void AddPostgreData(this IServiceCollection services)
        {
            services.AddSingleton<CRMDbContext>();
            services.AddSingleton<IDatabaseSelector, DatabaseSelector>();

            services.AddSingleton<ICustomerDao, CustomerDao>();
            services.AddSingleton<IRegionDao, RegionDao>();
        }
    }
}
