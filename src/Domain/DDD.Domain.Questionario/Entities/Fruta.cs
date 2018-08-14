using DDD.Domain.Core.Abstracties.Entities;
using DDD.Infra.Cross.DomainDriver.Abstractions;
using System;

namespace DDD.Domain.Test.Processos.Entities
{
    public class Fruta : DefaultEntity<Fruta>, IDDEntity<Fruta>
    {
        public Fruta() : base() { }

        public Fruta(Guid id, string nome, string tipo)
            :base(id)
        {
            Nome = nome;
            Tipo = tipo;
        }

        public string Nome { get; set; }
        public string Tipo { get; set; }
    }
}
