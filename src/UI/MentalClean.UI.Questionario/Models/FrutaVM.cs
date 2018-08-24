using DDD.Infra.Cross.DomainDriver.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using MentalClean.Domain.Questionario.Entities;

namespace MentalClean.UI.Questionario.Models
{
    [EntityReference(typeof(Fruta))]
    [AcceptDriverActions(DriverAction.GetSingle, DriverAction.GetAll, DriverAction.GetActives, DriverAction.Insert)]
    public class FrutaVM
    {
        public FrutaVM()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Tipo { get; set; }
    }

    [EntityReference(typeof(Fruta))]
    [AcceptDriverActions(DriverAction.Update)]
    public class FrutaUpdateVM
    {
        public FrutaUpdateVM()
        {
        }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Tipo { get; set; }
    }
}
