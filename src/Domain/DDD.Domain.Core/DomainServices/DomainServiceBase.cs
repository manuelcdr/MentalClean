using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PGLaw.Domain.Core.Interfaces.DomainServices;
using PGLaw.Domain.Core.Interfaces.Repositories;

namespace PGLaw.Domain.Core.DomainServices
{
    public abstract class DomainServicesBase<T> : IDomainServicesFull<T>
    {
        protected readonly IRepositoryRead<T> RepositoryRead;
        protected readonly IRepositoryWrite<T> RepositoryWrite;

        public DomainServicesBase(IRepositoryRead<T> repositoryRead, IRepositoryWrite<T> repositoryWrite)
        {
            RepositoryRead = repositoryRead;
            RepositoryWrite = repositoryWrite;
        }

        public virtual void Adicionar(T entity)
        {
            RepositoryWrite.Adicionar(entity);
        }

        public virtual void Atualizar(T entity)
        {
            RepositoryWrite.Atualizar(entity);
        }

        public virtual IEnumerable<T> Buscar(Expression<Func<T, bool>> expression)
        {
            return RepositoryRead.Buscar(expression);
        }

        public virtual void Excluir(Guid id)
        {
            RepositoryWrite.Excluir(id);
        }

        public virtual T ObterPorId(Guid id)
        {
            return RepositoryRead.ObterPorId(id);
        }

        public virtual IEnumerable<T> ObterTodos()
        {
            return RepositoryRead.ObterTodos();
        }
    }
}
