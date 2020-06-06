using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Postgre.Dao.Interfaces;
using Api.Data.Postgre.Dto;
using AutoMapper;

namespace Api.Modules.Customer.Models.Services
{
    public class CustomerQueryService : ICustomerQueryService
    {
        private readonly ICustomerDao customerDao;

        public CustomerQueryService(
            ICustomerDao customerDao
            )
        {
            this.customerDao = customerDao;
        }

        public async Task<CustomerFilterResult> FilterAsync(CustomerFilterRequest filterModel)
        {
            var sql = "select * from customer limit 10";
            var customerDtoes = await customerDao.QueryRawSqlAsync<CustomerDto>(sql);

            var customers = customerDtoes
                .Select(c => Mapper.Map<CustomerModel>(c))
                .ToList();

            var result = new CustomerFilterResult()
            {
                Customers = customers,
                Pagination = new Base.Web.Models.PaginationModel()
            };

            return result;
        }
    }
}
