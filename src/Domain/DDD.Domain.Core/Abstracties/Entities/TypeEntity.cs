using DDD.Domain.Core.Interfaces.Entities;
using System;

namespace DDD.Domain.Core.Abstracties.Entities
{
    public abstract class TypeEntity<T, TKey> : DefaultEntity<T, TKey>, IType where T : class
    {
        protected TypeEntity() { }

        public TypeEntity(TKey id, string descricao)
        {
            Id = id;
            Description = descricao;
        }

        public string Description { get; set; }
    }

    public abstract class TipoDesativavelEntity<T, TKey> : TypeEntity<T, TKey>, IType, IDeactivated where T : class
    {
        protected TipoDesativavelEntity() { }

        public TipoDesativavelEntity(TKey id, string descricao, bool ativo = true)
            :base(id, descricao)
        {
            Id = id;
            Description = descricao;
            Active = ativo;
        }

        public bool Active { get; protected set; }

        public void Activate()
        {
            Active = true;
        }

        public void Deactivate()
        {
            Active = false;
        }
    }

    public abstract class TypeEntity<T> : TypeEntity<T, Guid> where T : class
    {
        public TypeEntity(){ }

        public TypeEntity(Guid id, string descricao)
            :base(id, descricao) { }
    }

    public abstract class TipoDesativavelEntity<T> : TipoDesativavelEntity<T, Guid> where T : class
    {
        public TipoDesativavelEntity() { }

        public TipoDesativavelEntity(Guid id, string descricao, bool ativo = true)
            : base(id, descricao, ativo) { }
    }
}
