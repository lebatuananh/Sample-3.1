using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Modules.Customer.Models.Services
{
    public interface ICustomerQueryService
    {
        Task<CustomerFilterResult> FilterAsync(CustomerFilterRequest filterModel);
    }
}
