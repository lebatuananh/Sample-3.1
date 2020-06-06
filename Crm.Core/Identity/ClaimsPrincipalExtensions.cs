using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Crm.Core.Identity
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetSpecificClaim(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var claim = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == claimType);
            return claim != null ? claim.Value : string.Empty;
        }

        public static ApplicationUser CurrentUser(this ApplicationClaimsPrincipal user)
        {
            ApplicationUser appUser = null;
            if (user.Identity.IsAuthenticated && user != null)
            {
                appUser = new ApplicationUser
                {
                    Id = user.GetSpecificClaim("id"),
                    AuthenticationType = "jwt",
                    IsAuthenticated = true,
                    UserName = user.GetSpecificClaim("user_name")
                };

                return appUser;
            }
            return appUser;
        }
    }
}
