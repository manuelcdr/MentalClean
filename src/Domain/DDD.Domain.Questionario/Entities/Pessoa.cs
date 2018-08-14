using DDD.Domain.Core.Abstracties.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.Test.Processos.Entities
{
    public class Pessoa : DefaultEntity<Pessoa>
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Sexo { get; set; }
        public string Profissao { get; set; }
    }
}
