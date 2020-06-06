using System;
using System.Collections.Generic;
using System.Text;
using Crm.Core.Identity;
using Microsoft.AspNetCore.Identity;

namespace Api.Identity.Services
{
    public class CustomPasswordHashser : IPasswordHasher<ApplicationUser>
    {
        public string HashPassword(ApplicationUser user, string password)
        {
            throw new NotImplementedException();
        }

        public PasswordVerificationResult VerifyHashedPassword(ApplicationUser user, string hashedPassword, string providedPassword)
        {
            var proviedHasedPassword = HashPassword(user, providedPassword);
            if (proviedHasedPassword.Equals(hashedPassword))
                return PasswordVerificationResult.Success;
            return PasswordVerificationResult.Failed;
        }
    }
}
