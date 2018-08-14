namespace DDD.Domain.Core.Interfaces.Entities
{
    public interface IDefaultEntity : IEntity, IId
    {
    }

    public interface IDefaultEntity<TKey> : IDefaultEntity, IId<TKey>
    { 
    }
}
