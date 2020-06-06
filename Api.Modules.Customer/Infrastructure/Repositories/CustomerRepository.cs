using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Api.Modules.Customer.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.Modules.Customer.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext dbContext;
        public CustomerRepository(
            CustomerDbContext dbContext
            )
        {
            this.dbContext = dbContext;
        }

        public async Task<CustomerDomain> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(CustomerDomain root)
        {
            ///Bắn domain event
            ///Lưu vào db
            ///Bắn IntegrationEvent

            
        }

    }
}
