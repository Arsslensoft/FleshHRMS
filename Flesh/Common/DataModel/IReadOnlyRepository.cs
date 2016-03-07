using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;

namespace DevExpress.DevAV.Common.DataModel {
    /// <summary>
    /// The IReadOnlyRepository interface represents the read-only implementation of the Repository pattern 
    /// such that it can be used to query entities of a given type. 
    /// </summary>
    /// <typeparam name="TEntity">Repository entity type.</typeparam>
    public interface IReadOnlyRepository<TEntity> where TEntity : class {
        /// <summary>
        /// Returns an IQueryable object that can be used to query entities of a given type. 
        /// </summary>
        IQueryable<TEntity> GetEntities();

        /// <summary>
        /// The owner unit of work.
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Gets an ObservableCollection that represents a local view of all Added, Unchanged, and Modified entities in this repository. 
        /// This local view will stay in sync as entities are added or removed from the unit of work. 
        /// Likewise, entities that are added to or removed from the local view will automatically be added to or removed from the unit of work.
        /// </summary>
        ObservableCollection<TEntity> Local { get; }
    }
    public static class ReadOnlyRepositoryExtensions {
        public static IQueryable<TEntity> GetFilteredEntities<TEntity>(this IReadOnlyRepository<TEntity> repository, Expression<Func<TEntity, bool>> filterExpression) where TEntity : class {
            var queryable = repository.GetEntities();
            if(filterExpression != null)
                queryable = queryable.Where(filterExpression);
            return queryable;
        }
    }
}
