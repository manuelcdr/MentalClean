using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using DDD.Infra.Cross.Identity.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Infra.Cross.AspNetMvc.Authorizations
{
    public class TemAcessoUrlHandler : AuthorizationHandler<AutorizacaoPorUrl>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AutorizacaoPorUrl requirement)
        {
            if (context.HasSucceeded)
                return Task.CompletedTask;

            var authFilterCtx = context.Resource as AuthorizationFilterContext;
            var httpContext = authFilterCtx.HttpContext;

            if (Run(httpContext))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }

        public bool Run(HttpContext context)
        {
            var claims = context.User.Claims;
            var menusDeAcesso = claims
                .Where(x => x.Type == AppClaimsTypes.MenuDeAcessoUrl)
                .Select(x => x.Value.ToLower()).ToArray();

            if (!context.Request.Path.HasValue)
                return true;

            var path = context.Request.Path.Value.ToLower();

            if (path.Trim() == "/")
                return true;

            if (path.StartsWith("/"))
                path = path.Remove(0, 1);

            string[] pathSeparado;

            if (path.Contains("/"))
                pathSeparado = path.Split("/");
            else
                pathSeparado = new string[] { path };

            var pathPorPartes = "";

            foreach (var parteUrl in pathSeparado)
            {
                pathPorPartes += "/" + parteUrl;
                if (ContemAcesso(pathPorPartes, menusDeAcesso))
                    return true;
            }

            return false;
        }

        private bool ContemAcesso(string url, string[] menusDeAcesso)
        {
            return menusDeAcesso.Any(menu => menu == url);
        }

        private string ObterUrlRaiz(string url)
        {
            return $"/{url.Split('/')[1]}";
        }
    }
}
