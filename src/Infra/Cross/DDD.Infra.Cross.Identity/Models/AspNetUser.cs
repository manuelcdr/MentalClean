using Microsoft.AspNetCore.Http;
using DDD.Infra.Cross.Common.Enums;
using DDD.Infra.Cross.Common.Utils;
using DDD.Infra.Cross.Identity.Extensions;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace DDD.Infra.Cross.Identity.Models
{
    public class AspNetUser : Interfaces.IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }

        private Guid GetUserId()
        {
            return IsAuthenticated() ? Guid.Parse(_accessor.HttpContext.User.GetUserId()) : SequentialGuidGenerator.Generate();
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public Guid Id => GetUserId();

        public bool TrocarSenha => Convert.ToBoolean(_accessor.HttpContext.User.GetClaimValue(AppClaimsTypes.TrocarSenha));

        public bool Ativo => Convert.ToBoolean(_accessor.HttpContext.User.GetClaimValue(AppClaimsTypes.Ativo));

        public DiasDaSemana AcessoDiasDaSemana { get; set; }
    }
}
