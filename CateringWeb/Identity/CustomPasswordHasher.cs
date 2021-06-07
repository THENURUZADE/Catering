using Catering.Core.Domain.Entities;
using Catering.Core.Security;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.Web.Identity
{
    public class CustomPasswordHasher : IPasswordHasher<User>
    {
        public string HashPassword(User user, string password)
        {
            return HashPassword(user.Password);
        }

        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
        {
            if(hashedPassword == HashPassword(providedPassword))
            {
                return PasswordVerificationResult.Success;
            }

            return PasswordVerificationResult.Failed;
        }

        private string HashPassword(string unHashedPassword)
        {
            return MySecurityHelper.ComputeSha256Hash(unHashedPassword);
        }
    }
}
