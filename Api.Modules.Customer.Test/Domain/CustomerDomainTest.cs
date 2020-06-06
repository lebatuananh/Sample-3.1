using System;
using Api.Modules.Customer.Domain;
using Base.Web.Exceptions;
using Xunit;

namespace Api.Modules.Customer.Test.Domain
{
    public class CustomerDomainTest
    {
        [Fact]
        public void AddPhoneContact_Invalid_DupplicatePhoneNumber()
        {
            var customerDomain = new CustomerDomain();

            customerDomain.AddPhoneContact(
                "0123456789",
                "0123456789",
                "hoinx01",
                "hoinx01@gmail.com",
                "hoinx"
            );

            Assert.Throws<BadRequestException>(
                () => customerDomain.AddPhoneContact(
                "0123456789",
                "0123456789",
                "hoinx01",
                "hoinx01@gmail.com",
                "hoinx"
                )
            );
        }
        [Fact]
        public void AddPhoneContact_Valid()
        {
            var customerDomain = new CustomerDomain();

            customerDomain.AddPhoneContact(
                "0123456789",
                "0123456789",
                "hoinx01",
                "hoinx01@gmail.com",
                "hoinx"
            );

            customerDomain.AddPhoneContact(
                "0123456780",
                "0123456789",
                "hoinx01",
                "hoinx01@gmail.com",
                "hoinx"
            );

            Assert.True(customerDomain.PhoneContacts.Count == 2);
        }
    }
}
