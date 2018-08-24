using DDD.Infra.Cross.DomainDriver.Attributes;
using MentalClean.Domain.Questionario.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace MentalClean.UI.Questionario.Models
{
    [EntityReference(typeof(Animal))]
    [AcceptDriverActions(DriverAction.GetSingle, DriverAction.GetAll, DriverAction.GetActives, DriverAction.Insert)]
    public class AnimalVM
    {
        public AnimalVM()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [MaxLength(10)]
        public string Tipo { get; set; }
    }

    [EntityReference(typeof(Animal))]
    [AcceptDriverActions(DriverAction.Update)]
    public class AnimalUpdateVM
    {

        [Required]
        public string Nome { get; set; }

        [Required]
        [MaxLength(10)]
        public string Tipo { get; set; }
    }
}
