using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using DDD.Infra.Cross.Identity.Models;
using System.Threading.Tasks;

namespace DDD.Infra.Cross.AspNetMvc.Authorizations
{
    public class TrocarSenhaHandler : AuthorizationHandler<AutorizacaoPorUrl>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AutorizacaoPorUrl requirement)
        {
            if (context.HasSucceeded)
                return Task.CompletedTask;

            requirement.TrocarSenha = context.User.HasClaim(AppClaimsTypes.TrocarSenha, "True");

            if (requirement.TrocarSenha)
            {
                var redirectContext = context.Resource as AuthorizationFilterContext;
                redirectContext.Result = 
                    new RedirectToActionResult(
                        "AlterarSenha", 
                        "Usuario", 
                        new { mensagem = "Altere a senha de acesso antes de prosseguir" });

                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
