using System;
using System.Linq;

namespace DevExpress.DevAV.Common.DataModel {
    /// <summary>
    /// The IUnitOfWork interface represents the Unit Of Work pattern 
    /// such that it can be used to query from a database and group together changes that will then be written back to the store as a unit. 
    /// </summary>
    public interface IUnitOfWork {
        /// <summary>
        /// Saves all changes made in this unit of work to the underlying store.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Returns the state of the given entity.
        /// </summary>
        /// <param name="entity">An entity to get state from</param>
        EntityState GetState(object entity);

        /// <summary>
        /// Changes the state of the specified entity to Modified if changes are not automatically tracked by the implementation.
        /// </summary>
        /// <param name="entity">An entity which state should be updated/</param>
        void Update(object entity);

        /// <summary>
        /// Detaches the entity from the unit of work so that it will not be tracked.
        /// </summary>
        /// <param name="entity">An entity to detach.</param>
        void Detach(object entity);

        /// <summary>
        /// Checks if the unit of work is tracking any new, deleted, or changed entities or relationships that will be sent to the store if SaveChanges() is called.
        /// </summary>
        bool HasChanges();
    }

    /// <summary>
    /// Provides the method to create a unit of work of a given type.
    /// </summary>
    /// <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    public interface IUnitOfWorkFactory<TUnitOfWork> where TUnitOfWork : IUnitOfWork {

        /// <summary>
        /// Creates a new unit of work.
        /// </summary>
        TUnitOfWork CreateUnitOfWork();
    }
}
