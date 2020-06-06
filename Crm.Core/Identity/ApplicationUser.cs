using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using Crm.Core.Enumerations;

namespace Crm.Core.Identity
{
    public class ApplicationUser : IIdentity
    {
        public ActorType Type { get; set; }
        public string Id { get; set; }
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string HashedPassword { get; set; }
        public List<ApplicationUserRole> Roles { get; set; }
    }
}
