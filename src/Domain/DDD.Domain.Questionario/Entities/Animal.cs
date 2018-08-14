using DDD.Domain.Core.Abstracties.Entities;

namespace MentalClean.Domain.Questionario.Entities
{
    public class Animal : DefaultEntity<Animal>
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
    }
}
