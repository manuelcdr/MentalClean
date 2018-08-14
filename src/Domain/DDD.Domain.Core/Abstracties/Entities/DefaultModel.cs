using DDD.Domain.Core.Interfaces.Entities;

namespace DDD.Domain.Core.Abstracties.Entities
{
    public abstract class DefaultModel<TKey> : IId<TKey>
    {
        protected DefaultModel() { }

        protected DefaultModel(TKey id)
        {
            Id = id;
        }

        public TKey Id { get; set; }

        public object GetId() => Id;
    }
}
