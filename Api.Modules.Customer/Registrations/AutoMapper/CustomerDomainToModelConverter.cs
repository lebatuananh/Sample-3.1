using System;
using System.Collections.Generic;
using System.Text;
using Api.Modules.Customer.Domain;
using Api.Modules.Customer.Models;
using AutoMapper;

namespace Api.Modules.Customer.Registrations.AutoMapper
{
    public class CustomerDomainToModelConverter : ITypeConverter<CustomerDomain, CustomerModel>
    {
        public CustomerModel Convert(CustomerDomain source, CustomerModel destination, ResolutionContext context)
        {
            if (source == null)
                return null;

            throw new NotImplementedException();
        }
    }
}
