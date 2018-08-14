using DDD.Data.EF.Context;
using DDD.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DDD.Data.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DefaultContext context;

        public UnitOfWork(DefaultContext context)
        {
            this.context = context;
        }

        public void BeginTransaction()
        {
            context.Database.BeginTransaction();
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public void Commit()
        {
            context.Database.CommitTransaction();
        }

        public void Rollback()
        {
            context.Database.RollbackTransaction();
        }
    }
}
