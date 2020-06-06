using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Crm.Core.Identity
{
    public class ApplicationClaimsPrincipal : ClaimsPrincipal
    {
        public ApplicationClaimsPrincipal(IIdentity identity) : base(identity)
        {

        }
        public override bool IsInRole(string role)
        {
            return true;

        }
    }
}
