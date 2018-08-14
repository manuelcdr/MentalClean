namespace DDD.Domain.Core.Interfaces.Entities
{
    public interface IDeactivated
    {
        bool Active { get; }

        void Deactivate();

        void Activate();
    }
}
