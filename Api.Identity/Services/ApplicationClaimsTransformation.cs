using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Crm.Core.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Api.Identity.Services
{
    public class ApplicationClaimsTransformation : IClaimsTransformation
    {
        private readonly IUserStore<ApplicationUser> store;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ApplicationClaimsTransformation(
            IHttpContextAccessor httpContextAccessor,
            IUserStore<ApplicationUser> store

            )
        {
            this.store = store;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (!principal.Identity.IsAuthenticated)
                return principal;
            var userId = principal.GetSpecificClaim("id");

            var cancellationToken = new CancellationToken();
            var applicationUser = await store.FindByIdAsync(userId, cancellationToken);

            var claims = new List<Claim>()
            {
                new Claim("id", applicationUser.Id.ToString()),
                new Claim("user_name", applicationUser.UserName),
                new Claim("roles", "")
            };
            var identity = new ClaimsIdentity(claims, "jwt");
            var customPrincipal = new ApplicationClaimsPrincipal(identity);

            return customPrincipal;
        }
    }
}
