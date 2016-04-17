using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using PHRMS.Data;
using PHRMS.Utils;

namespace PHRMS.ViewModels
{
    /// <summary>
    ///     The base class for POCO view models exposing a read-only collection of entities of a given type.
    ///     This is a partial class that provides the extension point to add custom properties, commands and override methods
    ///     without modifying the auto-generated code.
    /// </summary>
    /// <typeparam name="TEntity">An entity type.</typeparam>
    /// <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    public class ReadOnlyCollectionViewModel<TEntity, TUnitOfWork> :
        ReadOnlyCollectionViewModelBase<TEntity, TUnitOfWork>
        where TEntity : class
        where TUnitOfWork : IUnitOfWork
    {
        /// <summary>
        ///     Initializes a new instance of the ReadOnlyCollectionViewModel class.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        /// <param name="getRepositoryFunc">A function that returns the repository representing entities of a given type.</param>
        public ReadOnlyCollectionViewModel(IUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory,
            Func<TUnitOfWork, IReadOnlyRepository<TEntity>> getRepositoryFunc)
            : base(unitOfWorkFactory, getRepositoryFunc)
        {
        }
    }

    /// <summary>
    ///     The base class for POCO view models exposing a read-only collection of entities of a given type.
    ///     It is not recommended to inherit directly from this class. Use the ReadOnlyCollectionViewModel class instead.
    /// </summary>
    /// <typeparam name="TEntity">An entity type.</typeparam>
    /// <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    [POCOViewModel]
    public abstract class ReadOnlyCollectionViewModelBase<TEntity, TUnitOfWork>
        where TEntity : class
        where TUnitOfWork : IUnitOfWork
    {
        protected readonly Func<TUnitOfWork, IReadOnlyRepository<TEntity>> getRepositoryFunc;

        protected readonly IUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory;
        private bool entitiesLoaded;

        /// <summary>
        ///     Initializes a new instance of the ReadOnlyCollectionViewModelBase class.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        /// <param name="getRepositoryFunc">A function that returns the repository representing entities of a given type.</param>
        public ReadOnlyCollectionViewModelBase(IUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory,
            Func<TUnitOfWork, IReadOnlyRepository<TEntity>> getRepositoryFunc)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
            RecreateUnitOfWork();
            this.getRepositoryFunc = getRepositoryFunc;
            if (!this.IsInDesignMode())
                OnInitializeInRuntime();
        }

        protected TUnitOfWork UnitOfWork { get; private set; }

        /// <summary>
        ///     The collection of entities loaded from the unit of work.
        /// </summary>
        public IList<TEntity> Entities
        {
            get
            {
                if (!entitiesLoaded)
                {
                    GetFilteredQueryableEntities().Load();
                    entitiesLoaded = true;
                }
                return Repository.Local;
            }
        }

        /// <summary>
        ///     The selected enity.
        ///     Since ReadOnlyCollectionViewModelBase is a POCO view model, this property will raise
        ///     INotifyPropertyChanged.PropertyEvent when modified so it can be used as a binding source in views.
        /// </summary>
        public virtual TEntity SelectedEntity { get; set; }

        /// <summary>
        ///     The lambda expression used to filter which entities will be loaded locally from the unit of work.
        /// </summary>
        public virtual Expression<Func<TEntity, bool>> FilterExpression { get; set; }

        protected IReadOnlyRepository<TEntity> Repository
        {
            get { return getRepositoryFunc(UnitOfWork); }
        }

        /// <summary>
        ///     Recreates the unit of work and reloads entities.
        ///     Since CollectionViewModelBase is a POCO view model, an instance of this class will also expose the RefreshCommand
        ///     property that can be used as a binding source in views.
        /// </summary>
        public virtual void Refresh()
        {
            RecreateUnitOfWork();
            this.RaisePropertyChanged(x => Entities);
        }

        private void RecreateUnitOfWork()
        {
            UnitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            entitiesLoaded = false;
        }

        protected virtual void OnInitializeInRuntime()
        {
        }

        protected virtual void OnSelectedEntityChanged()
        {
        }

        protected virtual void OnFilterExpressionChanged()
        {
            Refresh();
        }

        protected IQueryable<TEntity> GetFilteredQueryableEntities()
        {
            return Repository.GetFilteredEntities(FilterExpression);
        }
    }
}