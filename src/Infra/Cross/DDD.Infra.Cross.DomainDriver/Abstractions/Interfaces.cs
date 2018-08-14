namespace DDD.Infra.Cross.DomainDriver.Abstractions
{
    public interface IDDEntity { }
    public interface IDDRef { }
    public interface IDDRef<TEntity> : IDDRef where TEntity : IDDEntity { }
    public interface IDDEntity<TEntity> : IDDEntity where TEntity : class { }
}
