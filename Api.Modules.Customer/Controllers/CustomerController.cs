using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Modules.Customer.Domain;
using Api.Modules.Customer.Models;
using Api.Modules.Customer.Models.Services;
using Base.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Modules.Customer.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : BaseRestController
    {
        private readonly ICustomerQueryService customerQueryService;
        private readonly ICustomerRepository customerRepository;

        public CustomerController(
            ICustomerQueryService customerService,
            ICustomerRepository customerRepository
            )
        {
            this.customerQueryService = customerService;
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<CustomerFilterResult> Filter([FromQuery] CustomerFilterRequest filterModel)
        {
            var result = await customerQueryService.FilterAsync(filterModel);
            return result;
        }

        public async Task<CustomerModel> CreateCustomer(
            [FromBody] CreateCustomerRequest model
            )
        {
            var domain = new CustomerDomain();
            customerRepository.Save(domain);

            return null;

        }
    }
}
