using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Modules.Customer.Models
{
    public class CreateCustomerRequest
    {
        public string Name { get; set; }
        public List<CreatePhoneContactRequest> PhoneContacts { get; set; }
    }
    public class CreatePhoneContactRequest
    {

    }
}
