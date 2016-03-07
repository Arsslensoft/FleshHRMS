using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.DevAV.Common.Utils;
using DevExpress.DevAV.Common.DataModel;
using MessageBoxButton = System.Windows.MessageBoxButton;
using MessageBoxImage = System.Windows.MessageBoxImage;
using MessageBoxResult = System.Windows.MessageBoxResult;

namespace DevExpress.DevAV.Common.ViewModel {
    /// <summary>
    /// The base interface for objects passed as a parameter to a single object view model and used to initialize its entity.
    /// </summary>
    /// <typeparam name="TEntity">A type of the entity that will be initialized.</typeparam>
    /// <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    public interface IEntityInitializer<TEntity, TUnitOfWork>
        where TEntity : class
        where TUnitOfWork : IUnitOfWork {

        /// <summary>
        /// Initializes the given entity.
        /// </summary>
        /// <param name="unitOfWork">A unit of work that owns the given entity.</param>
        /// <param name="entity">An entity to initialize.</param>
        void InitializeEntity(TUnitOfWork unitOfWork, TEntity entity);
    }

    /// <summary>
    /// The class for objects passed a parameter to a single object view model and used to create entity with default property values.
    /// </summary>
    /// <typeparam name="TEntity">A type of the entity that will be created.</typeparam>
    /// <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    public class DefaultEntityInitializer<TEntity, TUnitOfWork> : IEntityInitializer<TEntity, TUnitOfWork>
        where TEntity : class
        where TUnitOfWork : IUnitOfWork {

        void IEntityInitializer<TEntity, TUnitOfWork>.InitializeEntity(TUnitOfWork unitOfWork, TEntity entity) { }
    }

    /// <summary>
    /// The base class for objects passed as a parameter to a single object view model and used to set the value of a certain property of its entity.
    /// </summary>
    /// <typeparam name="TEntity">A type of entity that will be initialized.</typeparam>
    /// <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    /// <typeparam name="TProperty">A type of property that will be set.</typeparam>
    public abstract class EntityPropertyInitializerBase<TEntity, TUnitOfWork, TProperty> : IEntityInitializer<TEntity, TUnitOfWork>
        where TEntity : class
        where TUnitOfWork : IUnitOfWork {

        readonly Action<TEntity, TProperty> setPropertyAction;

        /// <summary>
        /// Initializes a new instance of the EntityPropertyInitializerBase class.
        /// </summary>
        /// <param name="setPropertyAction">An action that assigns the property value to the entity.</param>
        public EntityPropertyInitializerBase(Action<TEntity, TProperty> setPropertyAction) {
            this.setPropertyAction = setPropertyAction;
        }

        protected abstract bool TryGetPropertyValue(TUnitOfWork unitOfWork, TEntity entity, out TProperty propertyValue);

        void IEntityInitializer<TEntity, TUnitOfWork>.InitializeEntity(TUnitOfWork unitOfWork, TEntity entity) {
            TProperty propertyValue;
            if(TryGetPropertyValue(unitOfWork, entity, out propertyValue))
                setPropertyAction(entity, propertyValue);
        }
    }

    /// <summary>
    /// The class for objects passed a parameter to a single object view model and used to set the value of the entity navigation property.
    /// </summary>
    /// <typeparam name="TEntity">A type of the entity that will be initialized.</typeparam>
    /// <typeparam name="TRelatedEntity">A type of the related entity.</typeparam>
    /// <typeparam name="TRelatedEntityKey">A related entity primary key type.</typeparam>
    /// <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    public class EntityNavigationPropertyInitializer<TEntity, TRelatedEntity, TRelatedEntityKey, TUnitOfWork> : EntityPropertyInitializerBase<TEntity, TUnitOfWork, TRelatedEntity>
        where TEntity : class
        where TRelatedEntity : class
        where TUnitOfWork : IUnitOfWork {

        readonly TRelatedEntityKey relatedEntityKey;
        readonly Func<TUnitOfWork, IRepository<TRelatedEntity, TRelatedEntityKey>> getRepositoryFunc;

        /// <summary>
        /// Initializes a new instance of the EntityNavigationPropertyInitializer class.
        /// </summary>
        /// <param name="relatedEntityKey">>A related entity primary key value.</param>
        /// <param name="setRelatedEntityAction">An action that assigns the navigation property value to the entity.</param>
        /// <param name="getRepositoryFunc">A function that returns the repository representing navigation entities.</param>
        public EntityNavigationPropertyInitializer(TRelatedEntityKey relatedEntityKey, Action<TEntity, TRelatedEntity> setRelatedEntityAction, Func<TUnitOfWork, IRepository<TRelatedEntity, TRelatedEntityKey>> getRepositoryFunc)
            : base(setRelatedEntityAction) {
            this.relatedEntityKey = relatedEntityKey;
            this.getRepositoryFunc = getRepositoryFunc;
        }

        protected override bool TryGetPropertyValue(TUnitOfWork unitOfWork, TEntity entity, out TRelatedEntity propertyValue) {
            IRepository<TRelatedEntity, TRelatedEntityKey> relatedEntityRepository = getRepositoryFunc(unitOfWork);
            propertyValue = relatedEntityRepository.GetEntities().Where(ExpressionHelper.GetValueEqualsExpression(relatedEntityRepository.GetPrimaryKeyExpression, relatedEntityKey)).FirstOrDefault();
            return propertyValue != null;
        }
    }
}
