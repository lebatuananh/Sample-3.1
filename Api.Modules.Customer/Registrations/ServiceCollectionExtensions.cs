using System;
using System.Collections.Generic;
using System.Text;
using Api.Modules.Customer.Domain;
using Api.Modules.Customer.Infrastructure;
using Api.Modules.Customer.Infrastructure.Repositories;
using Api.Modules.Customer.Models.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Modules.Customer.Registrations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomerModule(this IServiceCollection services)
        {
            services.AddSingleton<ICustomerQueryService, CustomerQueryService>();
            services.AddScoped<CustomerDbContext>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
