using System;

namespace PGLaw.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryWrite<T>
    {
        void Adicionar(T entity);
        void Atualizar(T entity);
        void Excluir(Guid id);
    }
}
