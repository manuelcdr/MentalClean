using Microsoft.AspNetCore.Authorization;

namespace DDD.Infra.Cross.AspNetMvc.Authorizations
{
    public class AutorizacaoPorUrl : IAuthorizationRequirement
    {
        public bool TrocarSenha { get; set; }
    }
}
