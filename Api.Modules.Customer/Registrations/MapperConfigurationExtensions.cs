using System;
using System.Collections.Generic;
using System.Text;
using Api.Modules.Customer.Domain;
using Api.Modules.Customer.Models;
using Api.Modules.Customer.Registrations.AutoMapper;
using AutoMapper;

namespace Api.Modules.Customer.Registrations
{
    public static class MapperConfigurationExtensions
    {
        public static void RegisterCustomerModule(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CustomerDomain, CustomerModel>().ConvertUsing<CustomerDomainToModelConverter>();
        }
    }
}
