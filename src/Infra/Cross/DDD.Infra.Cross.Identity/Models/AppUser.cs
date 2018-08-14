using Microsoft.AspNetCore.Identity;
using DDD.Infra.Cross.Common.Enums;
using DDD.Infra.Cross.Common.Extensions;
using System;

namespace DDD.Infra.Cross.Identity.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
        {
        }

        public AppUser(Guid id, string email, DiasDaSemana acessoDiasDaSemana, bool ativo, bool trocarSenha)
        {
            Id = id;
            Email = email;
            UserName = email;
            AtribuirAcessoDiasDaSemana(acessoDiasDaSemana);

            if (ativo) Ativar(); else Inativar();

            if (trocarSenha) TrocarSenhaNoProximoAcesso();
        }

        public bool TrocarSenha { get; private set; }
        public bool Ativo { get; private set; }
        public DiasDaSemana AcessoDiasDaSemana { get; private set; }

        public bool PodeSeLogar()
        {
            return Ativo && PodeAcessarHoje();
        }

        public bool PodeAcessarHoje()
        {
            var hoje = DateTime.Today.DayOfWeek.ConverterParaDiasDaSemana();
            return AcessoDiasDaSemana.HasFlag(hoje);
        }

        public void AtribuirAcessoDiasDaSemana(DiasDaSemana diasDaSemana)
        {
            AcessoDiasDaSemana = diasDaSemana;
        }

        public void DesabilitarAcessoFinalDeSemana()
        {
            AcessoDiasDaSemana &= ~(DiasDaSemana.Sabado & ~DiasDaSemana.Domingo);
        }

        public void HabilitarAcessoDiasUteisSemana()
        {
            AcessoDiasDaSemana = DiasDaSemana.Segunda | DiasDaSemana.Terca | DiasDaSemana.Quarta | DiasDaSemana.Quinta | DiasDaSemana.Sexta;
        }

        public void SenhaAlterada()
        {
            TrocarSenha = false;
        }

        public void TrocarSenhaNoProximoAcesso()
        {
            TrocarSenha = true;
        }

        public void Ativar()
        {
            Ativo = true;
        }

        public void Inativar()
        {
            Ativo = false;
        }
    }
}
