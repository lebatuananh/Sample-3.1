using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Postgre;
using Api.Data.Postgre.Dao;
using Api.Data.Postgre.Dao.Interfaces;
using Api.Modules.Customer.Registrations;
using Base.Data.Postgre;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Api.Registrations
{
    public static class DependencyRegistrar
    {
        public static void Register(IServiceCollection services)
        {
            services.AddPostgreData();
            services.AddCustomerModule();
        }
    }
}
