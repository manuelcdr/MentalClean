using DDD.Domain.Core.Interfaces.Entities;
using System;

namespace DDD.Domain.Core.Interfaces.Services
{
    public interface IGenericDomainService
    {
        void Add(IDefaultEntity entity);
        void Update(IDefaultEntity entity);
        void Delete(Type type, object id);
    }
}
