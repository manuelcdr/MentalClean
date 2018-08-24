using DDD.Domain.Core.Abstracties.Entities;
using DDD.Infra.Cross.DomainDriver.Abstractions;
using DDD.Infra.Cross.DomainDriver.Attributes;
using MentalClean.Domain.Questionario.Entities;
using System;

namespace MentalClean.UI.Questionario.Models
{
    [EntityReference(typeof(Fruta), typeof(Animal))]
    [AcceptDriverActions]
    public class TestVM : DefaultModel<Guid>, IDDRef<Fruta>
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
    }
}
