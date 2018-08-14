using DDD.Domain.Core.Interfaces.Entities;

namespace DDD.Domain.Core.Abstracties.Entities
{
    public abstract class DeactivatedEntity<T, TKey> : DefaultEntity<T, TKey>, IDeactivated where T : class
    {
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
}
