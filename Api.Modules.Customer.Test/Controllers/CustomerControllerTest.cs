using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Api.Modules.Customer.Controllers;
using Api.Modules.Customer.Domain;
using Api.Modules.Customer.Models;
using Api.Modules.Customer.Models.Services;
using Moq;
using Xunit;

namespace Api.Modules.Customer.Test.Controllers
{
    public class CustomerControllerTest
    {
        private readonly Mock<ICustomerQueryService> customerQueryService;
        private readonly Mock<ICustomerRepository> customerRepository;

        public CustomerControllerTest(
            )
        {
            this.customerQueryService = new Mock<ICustomerQueryService>();
            this.customerRepository = new Mock<ICustomerRepository>();
        }
        [Fact]
        public async Task FilterCustomer_Valid_Input()
        {
            customerQueryService.Setup(service => service.FilterAsync(It.IsAny<CustomerFilterRequest>()))
                .ReturnsAsync(GetFakeServiceResult());

            var controller = new CustomerController(
                customerQueryService.Object,
                customerRepository.Object
                );

            var filterRequest = new CustomerFilterRequest();

            try
            {
                var filterResult = await controller.Filter(filterRequest);

                Assert.True(true);
            }
            catch(Exception e)
            {
                Assert.False(true);
            }
                
        }
        public CustomerFilterResult GetFakeServiceResult()
        {
            return new CustomerFilterResult();
        }
    }
}
