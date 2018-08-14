using DDD.Domain.Core.Interfaces.Entities;
using DDD.Infra.Cross.Common.Utils;
using System;

namespace DDD.Domain.Core.Abstracties.Entities
{
    public abstract class DefaultEntity<T, TKey> : DefaultModel<TKey>, IDefaultEntity<TKey> where T : class
    {
        protected DefaultEntity() : base() { }

        protected DefaultEntity(TKey id) : base(id) { }

        public override bool Equals(object obj)
        {
            var compareTo = obj as DefaultEntity<T, TKey>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public static bool operator ==(DefaultEntity<T, TKey> a, DefaultEntity<T, TKey> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(DefaultEntity<T, TKey> a, DefaultEntity<T, TKey> b)
        {
            return !(a == b);
        }
    }

    public abstract class DefaultEntity<T> : DefaultEntity<T, Guid>, IDefaultEntity<Guid> where T : class
    {
        protected DefaultEntity()
            : base(SequentialGuidGenerator.Generate())
        {
        }

        public DefaultEntity(Guid id)
            : base(id)
        {
        }
    }
}
