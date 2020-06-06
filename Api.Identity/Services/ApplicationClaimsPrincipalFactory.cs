using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Crm.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Api.Identity.Services
{
    public class ApplicationClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>, IUserClaimsPrincipalFactory<ApplicationUser>
    {
        public ApplicationClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            IOptions<IdentityOptions> optionsAccessor
            ) : base(userManager, optionsAccessor)
        {
        }

        public override async Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            //var principal = await base.CreateAsync(user);
            var claimsIdentity = await GenerateClaimsAsync(user);
            var principal = new ClaimsPrincipal(claimsIdentity);
            return principal;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var claimsIdentity = await base.GenerateClaimsAsync(user);

            claimsIdentity.AddClaim(new Claim("id", user.Id.ToString()));
            claimsIdentity.AddClaim(new Claim("user_name", user.UserName));
            return claimsIdentity;
        }
    }
}
