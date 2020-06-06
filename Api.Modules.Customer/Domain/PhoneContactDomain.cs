using System;
using System.Collections.Generic;
using System.Text;
using Base.Domain.Entities;

namespace Api.Modules.Customer.Domain
{
    public class PhoneContactDomain : BaseEntity
    {
        public PhoneContactDomain(string phoneNumber, string phoneAlias, string name, string email, string createdBy)
        {
            this.Id = 0;
            this.PhoneNumber = phoneNumber;
            this.PhoneAlias = phoneAlias;
            this.Name = name;
            this.Email = email;
            this.CreatedBy = createdBy;
        }
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneAlias { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreatedBy { get; set; }
    }
}
