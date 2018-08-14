using Microsoft.AspNetCore.Identity;
using DDD.Infra.Cross.Identity.Models;

namespace DDD.Infra.Cross.Identity.Extensions
{
    public static class ApplicationSignManagerExtensions
    {
        public static SignInResult ApplicationSigIn(this SignInManager<AppUser> signInManager, AppUser user, string password, bool rememberMe)
        {
            var result = signInManager.ValidarUsuario(user);

            if (!result.Succeeded)
                return result;

            return signInManager.PasswordSignInAsync(user, password, rememberMe, false).Result;
        }

        public static SignInResult ApplicationSigIn(this SignInManager<AppUser> signInManager, AppUser user, bool rememberMe)
        {
            var result = signInManager.ValidarUsuario(user);

            if (!result.Succeeded)
                return result;

            signInManager.SignInAsync(user, rememberMe).Wait();

            return SignInResult.Success;
        }

        private static SignInResult ValidarUsuario(this SignInManager<AppUser> signInManager, AppUser user)
        {
            if (!user.PodeSeLogar())
            {
                if (!user.Ativo)
                    return SignInResult.Failed;

                if (user.PodeAcessarHoje())
                    return SignInResult.NotAllowed;
            }

            return SignInResult.Success;
        }
    }
}
