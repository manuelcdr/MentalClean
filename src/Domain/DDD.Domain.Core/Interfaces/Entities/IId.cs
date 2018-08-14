namespace DDD.Domain.Core.Interfaces.Entities
{
    public interface IId
    {
        object GetId();
    }

    public interface IId<TId> : IId
    {
        TId Id { get; set; }
    }
}
