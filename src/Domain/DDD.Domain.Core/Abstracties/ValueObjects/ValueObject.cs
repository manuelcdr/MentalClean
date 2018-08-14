using DDD.Domain.Core.Interfaces.ValueObjects;

namespace DDD.Domain.Core.Abstracties.ValueObjects
{
    public abstract class ValueObject<T> : IValueObject where T : class
    {
    }
}
