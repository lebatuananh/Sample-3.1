using System;
using System.Collections.Generic;
using System.Text;
using Base.Domain.Entities;
using Base.Web.Exceptions;

namespace Api.Modules.Customer.Domain
{
    public class CustomerDomain : AggregateRoot
    {
        public int Id { get; set; }
        public List<PhoneContactDomain> PhoneContacts { get; set; }
        public List<NoteDomain> Notes { get; set; }

        public void AddPhoneContact(
            string phoneNumber, 
            string phoneAlias, 
            string name, 
            string email, 
            string createdBy
            )
        {
            var phoneContact = new PhoneContactDomain(phoneNumber, phoneAlias, name, email, createdBy);

            this.PhoneContacts = PhoneContacts ?? new List<PhoneContactDomain>();

            var existPhoneNumber = PhoneContacts.Exists(pc => pc.PhoneNumber.Equals(phoneNumber));

            if (existPhoneNumber)
                throw new BadRequestException();

            PhoneContacts.Add(phoneContact);
        }
    }
}
