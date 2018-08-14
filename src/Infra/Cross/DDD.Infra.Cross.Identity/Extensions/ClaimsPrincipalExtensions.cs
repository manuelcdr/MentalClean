using DDD.Infra.Cross.Common.Enums;
using DDD.Infra.Cross.Identity.Models;
using System;
using System.Security.Claims;

namespace DDD.Infra.Cross.Identity.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst(ClaimTypes.NameIdentifier);
            return claim?.Value;
        }

        public static string GetClaimValue(this ClaimsPrincipal principal, string claimName)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst(claimName);
            return claim?.Value;
        }

        public static Sexo ObterSexoPessoa(this ClaimsPrincipal principal)
        {
            return Enum.Parse<Sexo>(GetClaimValue(principal, AppClaimsTypes.PessoaSexo));
        }

        public static string ObterNomeDaPessoa(this ClaimsPrincipal principal)
        {
            return GetClaimValue(principal, AppClaimsTypes.PessoaNome);
        }

        public static bool VerificarSeUsuarioDeveTrocarSenha(this ClaimsPrincipal principal)
        {
            return Convert.ToBoolean(GetClaimValue(principal, AppClaimsTypes.TrocarSenha));
        }
    }
}
