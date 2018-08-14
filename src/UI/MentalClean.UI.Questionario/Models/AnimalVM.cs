using DDD.Infra.Cross.DomainDriver.Attributes;
using MentalClean.Domain.Questionario.Entities;
using System.ComponentModel.DataAnnotations;

namespace DDD.Api.Test.Models
{
    [EntityReference(typeof(Animal))]
    [AcceptDriverActions(DriverAction.Insert, DriverAction.Update, DriverAction.Delete)]
    public class AnimalVM
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [MinLength(5)]
        public string Tipo { get; set; }
    }
}
