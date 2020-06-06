using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Api.Modules.User.Models;
using Base.Web.Controllers;
using Crm.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Modules.User.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : BaseRestController
    {
        private readonly IUserStore<ApplicationUser> userStore;
        private readonly IPasswordHasher<ApplicationUser> passwordHasher;

        public AuthenticationController(
            IUserStore<ApplicationUser> userStore,
            IPasswordHasher<ApplicationUser> passwordHasher
            )
        {
            this.userStore = userStore;
            this.passwordHasher = passwordHasher;
        }

        [Route("access_token")]
        public async Task<AccessTokenResponse> GetAccessToken(
            [FromBody] AccessTokenRequest model
            )
        {
            var cancellationToken = new CancellationToken();
            var user = await userStore.FindByNameAsync(model.UserName, cancellationToken);

            var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.HashedPassword, model.Password);

            throw new NotImplementedException();
        }

        [Route("refresh_token")]
        public async Task<AccessTokenResponse> RefreshAccessToken()
        {
            throw new NotImplementedException();
        }
    }
}
