using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DevExpress.DevAV.Common.DataModel.EntityFramework {
    /// <summary>
    /// A DbReadOnlyRepository is a IReadOnlyRepository interface implementation representing the collection of all entities in the unit of work, or that can be queried from the database, of a given type. 
    /// DbReadOnlyRepository objects are created from a DbUnitOfWork using the GetReadOnlyRepository method. 
    /// DbReadOnlyRepository provides only read-only operations against entities of a given type.
    /// </summary>
    /// <typeparam name="TEntity">Repository entity type.</typeparam>
    /// <typeparam name="TDbContext">DbContext type.</typeparam>
    public class DbReadOnlyRepository<TEntity, TDbContext> : IReadOnlyRepository<TEntity>
        where TEntity : class
        where TDbContext : DbContext {

        readonly Func<TDbContext, DbSet<TEntity>> dbSetAccessor;
        readonly DbUnitOfWork<TDbContext> unitOfWork;
        DbSet<TEntity> dbSet;

        /// <summary>
        /// Initializes a new instance of DbReadOnlyRepository class.
        /// </summary>
        /// <param name="unitOfWork">Owner unit of work that provides context for repository entities.</param>
        /// <param name="dbSetAccessor">Function that returns DbSet entities from Entity Framework DbContext.</param>
        public DbReadOnlyRepository(DbUnitOfWork<TDbContext> unitOfWork, Func<TDbContext, DbSet<TEntity>> dbSetAccessor) {
            this.dbSetAccessor = dbSetAccessor;
            this.unitOfWork = unitOfWork;
        }

        protected DbSet<TEntity> DbSet {
            get {
                if(dbSet == null) {
                    dbSet = dbSetAccessor(unitOfWork.Context);
                }
                return dbSet;
            }
        }

        protected TDbContext Context {
            get { return unitOfWork.Context; }
        }

        protected virtual IQueryable<TEntity> GetEntities() {
            return DbSet;
        }

        #region IReadOnlyRepository
        IQueryable<TEntity> IReadOnlyRepository<TEntity>.GetEntities() {
            return GetEntities();
        }

        IUnitOfWork IReadOnlyRepository<TEntity>.UnitOfWork {
            get { return unitOfWork; }
        }

        ObservableCollection<TEntity> IReadOnlyRepository<TEntity>.Local {
            get { return DbSet.Local; }
        }
        #endregion
    }
}
