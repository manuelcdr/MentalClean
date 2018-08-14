using DDD.Domain.Core.Abstracties.Entities;

namespace DDD.Domain.Test.Processos.Entities
{
    public class Animal : DefaultEntity<Animal>
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
    }
}
