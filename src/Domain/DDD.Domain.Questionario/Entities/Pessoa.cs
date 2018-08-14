using DDD.Domain.Core.Abstracties.Entities;

namespace MentalClean.Domain.Questionario.Entities
{
    public class Pessoa : DefaultEntity<Pessoa>
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Sexo { get; set; }
        public string Profissao { get; set; }
    }
}
