using DDD.Domain.Core.Abstracties.Entities;
using DDD.Infra.Cross.DomainDriver.Attributes;
using MentalClean.Domain.Questionario.Entities;
using System;

namespace DDD.Api.Test.Models
{
    [EntityReference(typeof(Pessoa))]
    [AcceptDriverActions(DriverAction.Insert, DriverAction.Update)]
    public class PessoaVM : DefaultModel<Guid>
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Sexo { get; set; }
        public string Profissao { get; set; }
    }
}
