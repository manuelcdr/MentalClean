using DDD.Data.EF.Context;
using DDD.Domain.Core.Interfaces.Entities;
using DDD.Domain.Core.Interfaces.Repositories;
using DDD.Infra.Cross.Common.Utils;
using DDD.Infra.Cross.DomainDriver;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DDD.Data.EF.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        protected readonly DefaultContext Context;

        public GenericRepository(DefaultContext context)
        {
            this.Context = context;
        }

        protected DbSet<T> Set<T>() where T : class
        {
            return Context.Set<T>();
        }

        public async Task<int> SaveChanges()
        {
            return await Context.SaveChangesAsync();
        }

        #region generic

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return Set<T>().AsNoTracking();
        }

        public T GetSingle<T>(object id) where T : class
        {
            var entity = Set<T>().Find(id);

            if (entity != null)
                Context.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public IEnumerable<T> Search<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return Set<T>()
                .Where(predicate)
                .Distinct()
                .AsNoTracking();
        }

        public IEnumerable<T> GetActives<T>() where T : class, IDeactivated
        {
            return Set<T>()
                .Where(x => x.Active)
                .AsNoTracking();
        }

        public void Add<T>(T entity) where T : class
        {
            Set<T>().Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            var entry = Context.Entry(entity);
            entry.State = EntityState.Modified;
            Set<T>().Update(entity);
        }

        public void DeepUpdate<T>(T entity) where T : class
        {
            var entry = Context.Entry(entity);
            foreach (var refi in entry.References)
            {
                UpdateChildren(refi);
            }
            entry.State = EntityState.Modified;
            Set<T>().Update(entity);
        }

        public void Delete<T>(object id) where T : class
        {
            var entity = Set<T>().Find(id);
            Set<T>().Remove(entity);
        }

        #endregion

        #region generic param
        public void Delete(Type type, object id)
        {
            ChamadorMetodo.ChamarMetodoGenerico(this, GetCurrentMethod(), new Type[] { type }, id);
        }

        public object GetSingle(Type type, object id)
        {
            return ChamadorMetodo.ChamarMetodoGenerico(this, GetCurrentMethod(), new Type[] { type }, id);
        }

        public IEnumerable<object> GetAll(Type type)
        {
            return ChamadorMetodo.ChamarMetodoGenerico(this, GetCurrentMethod(), new Type[] { type }) as IEnumerable<object>;
        }

        public IEnumerable<object> GetActives(Type type)
        {
            return ChamadorMetodo.ChamarMetodoGenerico(this, GetCurrentMethod(), new Type[] { type }) as IEnumerable<object>;
        }

        public void Add(Type type, object entity)
        {
            ChamadorMetodo.ChamarMetodoGenerico(this, GetCurrentMethod(), new Type[] { type }, entity);
        }

        public void Update(Type type, object entity)
        {
            ChamadorMetodo.ChamarMetodoGenerico(this, GetCurrentMethod(), new Type[] { type }, entity);
        }

        public void DeepUpdate(Type type, object entity)
        {
            ChamadorMetodo.ChamarMetodoGenerico(this, GetCurrentMethod(), new Type[] { type }, entity);
        }

        #endregion

        #region generic name

        public object GetSingle(string typeName, object id)
        {
            var objectType = Driver.GetDomainType(typeName);
            return GetSingle(objectType, id);
        }

        public IEnumerable<object> GetAll(string typeName)
        {
            var objectType = Driver.GetDomainType(typeName);
            return GetAll(objectType);
        }

        public IEnumerable<object> GetActives(string typeName)
        {
            var objectType = Driver.GetDomainType(typeName);
            return GetActives(objectType);
        }

        public void Add(string typeName, object entity)
        {
            var objectType = Driver.GetDomainType(typeName);
            Add(objectType);
        }

        public void Update(string typeName, object entity)
        {
            var objectType = Driver.GetDomainType(typeName);
            Update(objectType);
        }

        public void DeepUpdate(string typeName, object entity)
        {
            var objectType = Driver.GetDomainType(typeName);
            DeepUpdate(objectType);
        }

        public void Delete(string typeName, object id)
        {
            var objectType = Driver.GetDomainType(typeName);
            Delete(objectType, id);
        }

        #endregion

        #region private methods

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

        private void UpdateChildren(ReferenceEntry refi)
        {
            if (refi.TargetEntry != null)
            {
                refi.TargetEntry.State = EntityState.Modified;
                foreach (var refii in refi.TargetEntry.References)
                {
                    UpdateChildren(refii);
                }
            }
        }

        #endregion
    }
}
