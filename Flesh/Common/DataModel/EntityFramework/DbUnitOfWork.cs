using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace DevExpress.DevAV.Common.DataModel.EntityFramework {
    /// <summary>
    /// A DbUnitOfWork instance represents the implementation of the Unit Of Work pattern 
    /// such that it can be used to query from a database and group together changes that will then be written back to the store as a unit. 
    /// </summary>
    /// <typeparam name="TContext">DbContext type.</typeparam>
    public abstract class DbUnitOfWork<TContext> : UnitOfWorkBase, IUnitOfWork where TContext : DbContext {

        /// <summary>
        /// Initializes a new instance of DbUnitOfWork class using specified DbContext.
        /// </summary>
        /// <param name="context">Instance of TContext that will be used as a context for this unit of work.</param>
        public DbUnitOfWork(TContext context) {
            Context = context;
        }

        /// <summary>
        /// Instance of underlying DbContext.
        /// </summary>
        public TContext Context { get; private set; }

        void IUnitOfWork.SaveChanges() {
            try {
                Context.SaveChanges();
            } catch(DbEntityValidationException ex) {
                throw DbExceptionsConverter.Convert(ex);
            } catch(DbUpdateException ex) {
                throw DbExceptionsConverter.Convert(ex);
            }
        }

        EntityState IUnitOfWork.GetState(object entity) {
            return GetEntityState(Context.Entry(entity).State);
        }

        void IUnitOfWork.Update(object entity) { }

        void IUnitOfWork.Detach(object entity) {
            Context.Entry(entity).State = System.Data.Entity.EntityState.Detached;
        }

        EntityState GetEntityState(System.Data.Entity.EntityState entityStates) {
            switch(entityStates) {
                case System.Data.Entity.EntityState.Added:
                    return EntityState.Added;
                case System.Data.Entity.EntityState.Deleted:
                    return EntityState.Deleted;
                case System.Data.Entity.EntityState.Detached:
                    return EntityState.Detached;
                case System.Data.Entity.EntityState.Modified:
                    return EntityState.Modified;
                case System.Data.Entity.EntityState.Unchanged:
                    return EntityState.Unchanged;
                default:
                    throw new NotImplementedException();
            }
        }

        bool IUnitOfWork.HasChanges() {
            return Context.ChangeTracker.HasChanges();
        }

        protected IRepository<TEntity, TPrimaryKey>
            GetRepository<TEntity, TPrimaryKey>(Func<TContext, DbSet<TEntity>> dbSetAccessor, Expression<Func<TEntity, TPrimaryKey>> getPrimaryKeyExpression, Action<TEntity, TPrimaryKey> setPrimaryKeyAction = null)
            where TEntity : class {
            return GetRepositoryCore<IRepository<TEntity, TPrimaryKey>, TEntity>(() => new DbRepository<TEntity, TPrimaryKey, TContext>(this, dbSetAccessor, getPrimaryKeyExpression, setPrimaryKeyAction));
        }

        protected IReadOnlyRepository<TEntity>
            GetReadOnlyRepository<TEntity>(Func<TContext, DbSet<TEntity>> dbSetAccessor)
            where TEntity : class {
            return GetRepositoryCore<IReadOnlyRepository<TEntity>, TEntity>(() => new DbReadOnlyRepository<TEntity, TContext>(this, dbSetAccessor));
        }
    }
}
