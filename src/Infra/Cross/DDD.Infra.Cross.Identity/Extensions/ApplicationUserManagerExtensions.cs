using Microsoft.AspNetCore.Identity;
using DDD.Infra.Cross.Identity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace DDD.Infra.Cross.Identity.Extensions
{
    public static class ApplicationUserManagerExtensions
    {
        public static bool UsuarioPodeSeLogar(this UserManager<AppUser> userManager, AppUser user)
        {
            return user.PodeSeLogar();
        }

        public static AppUser ObterUsuarioPorEmail(this UserManager<AppUser> userManager, string email)
        {
            return userManager.Users.Where(u => u.Email == email).FirstOrDefault();
        }

        public static IdentityResult AddSimpleClaims(this UserManager<AppUser> userManager, AppUser user, params string[] claimsName)
        {
            var claims = new List<Claim>();

            foreach(var claimName in claimsName)
            {
                var claim = new Claim(claimName, claimName);
                claims.Add(claim);
            }

            var result = userManager.AddClaimsAsync(user, claims).Result;

            return result;
        }
    }
}
