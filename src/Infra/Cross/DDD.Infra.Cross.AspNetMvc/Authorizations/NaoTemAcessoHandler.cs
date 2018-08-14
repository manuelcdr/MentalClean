using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace DDD.Infra.Cross.AspNetMvc.Authorizations
{
    public class NaoTemAcessoHandler : AuthorizationHandler<AutorizacaoPorUrl>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AutorizacaoPorUrl requirement)
        {
            if (context.HasSucceeded)
                return Task.CompletedTask;

            context.Fail();

            return Task.CompletedTask;
        }
    }
}
