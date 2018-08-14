using DDD.Domain.Core.Interfaces.Entities;
using DDD.Domain.Core.Interfaces.Repositories;
using DDD.Domain.Core.Interfaces.Services;
using System;

namespace DDD.Domain.Test.Processos.Services
{
    public class GenericService : IGenericDomainService
    {
        private readonly IGenericRepository repository;

        public GenericService(IGenericRepository repository)
        {
            this.repository = repository;
        }

        public void Add(IDefaultEntity entity)
        {
            var type = entity.GetType();
            var id = entity.GetId();

            if (repository.GetSingle(type, id) != null)
                return;

            repository.Add(entity);
        }

        public void Update(IDefaultEntity entity)
        {
            var type = entity.GetType();
            var id = entity.GetId();

            if (repository.GetSingle(type, id) == null)
                return;

            repository.DeepUpdate(entity);
        }

        public void Delete(Type type, object id)
        {
            repository.Delete(type, id);
        }
    }
}
