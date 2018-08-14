using DDD.Domain.Core.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DDD.Domain.Core.Interfaces.Repositories
{
    public interface IGenericRepositoryReadDefault
    {
        T GetSingle<T>(object id) where T : class;
        IEnumerable<T> GetAll<T>() where T : class;
        IEnumerable<T> GetActives<T>() where T : class, IDeactivated;
        IEnumerable<T> Search<T>(Expression<Func<T, bool>> predicate) where T : class;
    }

    public interface IGenericRepositoryReadByParam
    {
        object GetSingle(Type type, object id);
        IEnumerable<object> GetAll(Type type);
        IEnumerable<object> GetActives(Type type);
    }

    public interface IGenericRepositoryReadByName
    {
        object GetSingle(string type, object id);
        IEnumerable<object> GetAll(string typeName);
        IEnumerable<object> GetActives(string typeName);
    }

    public interface IGenericRepositoryWriteDefault
    {
        void Add<T>(T entidade) where T : class;
        void Update<T>(T entidade) where T : class;
        void DeepUpdate<T>(T entidade) where T : class;
        void Delete<T>(object id) where T : class;
    }

    public interface IGenericRepositoryWriteByParam
    {
        void Add(Type type, object entity);
        void Update(Type type, object entity);
        void DeepUpdate(Type type, object entity);
        void Delete(Type type, object id);
    }

    public interface IGenericRepositoryWriteByName
    {
        void Add(string typeName, object entity);
        void Update(string typeName, object entity);
        void DeepUpdate(string typeName, object entity);
        void Delete(string typeName, object id);
    }

    public interface IGenericRepositoryRead :
        IGenericRepositoryReadDefault,
        IGenericRepositoryReadByParam,
        IGenericRepositoryReadByName
    { }

    public interface IGenericRepositoryWrite :
        IGenericRepositoryWriteDefault,
        IGenericRepositoryWriteByParam,
        IGenericRepositoryWriteByName
    { }

    public interface IGenericRepository :
        IGenericRepositoryRead,
        IGenericRepositoryWrite
    { }
}
