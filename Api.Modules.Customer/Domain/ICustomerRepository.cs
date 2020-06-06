using System;
using System.Collections.Generic;
using System.Text;
using Base.Domain.Repository;

namespace Api.Modules.Customer.Domain
{
    public interface ICustomerRepository : IRepository<CustomerDomain>
    {
        void Save(CustomerDomain root);
    }
}
