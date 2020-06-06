using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Modules.User.Models
{
    public class AccessTokenRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
