using System;
using System.ComponentModel;
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
using DevExpress.DevAV.Common;

namespace DevExpress.DevAV.Common.ViewModel {
    /// <summary>
    /// The base class for a POCO view models exposing a collection of entities of a given type and CRUD operations against these entities. 
    /// This is a partial class that provides extension point to add custom properties, commands and override methods without modifying the auto-generated code.
    /// </summary>
    /// <typeparam name="TEntity">An entity type.</typeparam>
    /// <typeparam name="TPrimaryKey">A primary key value type.</typeparam>
    /// <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    public partial class CollectionViewModel<TEntity, TPrimaryKey, TUnitOfWork> : CollectionViewModelBase<TEntity, TPrimaryKey, TUnitOfWork>
        where TEntity : class
        where TUnitOfWork : IUnitOfWork {

        /// <summary>
        /// Initializes a new instance of the CollectionViewModel class.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        /// <param name="getRepositoryFunc">A function that returns a repository representing entities of a given type.</param>
        /// <param name="newEntityInitializerFactory">An optional parameter that provides a function to create an entity initializer. This parameter is used in the detail collection view models when creating a single object view model for a new entity.</param>
        public CollectionViewModel(IUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory, Func<TUnitOfWork, IRepository<TEntity, TPrimaryKey>> getRepositoryFunc, Func<IEntityInitializer<TEntity, TUnitOfWork>> newEntityInitializerFactory = null)
            : base(unitOfWorkFactory, getRepositoryFunc, newEntityInitializerFactory) {
        }
    }

    /// <summary>
    /// The base class for POCO view models exposing a collection of entities of a given type and CRUD operations against these entities.
    /// It is not recommended to inherit directly from this class. Use the CollectionViewModel class instead.
    /// </summary>
    /// <typeparam name="TEntity">An entity type.</typeparam>
    /// <typeparam name="TPrimaryKey">A primary key value type.</typeparam>
    /// <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    public abstract class CollectionViewModelBase<TEntity, TPrimaryKey, TUnitOfWork> : ReadOnlyCollectionViewModel<TEntity, TUnitOfWork>, IDocumentContent
        where TEntity : class
        where TUnitOfWork : IUnitOfWork {

        readonly Func<IEntityInitializer<TEntity, TUnitOfWork>> newEntityInitializerFactory;

        /// <summary>
        /// Initializes a new instance of the CollectionViewModelBase class.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        /// <param name="getRepositoryFunc">A function that returns a repository representing entities of a given type.</param>
        /// <param name="newEntityInitializerFactory">An optional parameter that provides a function to create an entity initializer. This parameter is used in detail collection view models when creating a single object view model for a new entity.</param>
        protected CollectionViewModelBase(IUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory, Func<TUnitOfWork, IRepository<TEntity, TPrimaryKey>> getRepositoryFunc, Func<IEntityInitializer<TEntity, TUnitOfWork>> newEntityInitializerFactory)
            : base(unitOfWorkFactory, getRepositoryFunc) {
            this.newEntityInitializerFactory = newEntityInitializerFactory;
        }

        protected new IRepository<TEntity, TPrimaryKey> Repository { get { return (IRepository<TEntity, TPrimaryKey>)base.Repository; } }

        protected IMessageBoxService MessageBoxService { get { return this.GetRequiredService<IMessageBoxService>(); } }

        protected IDocumentManagerService DocumentManagerService { get { return this.GetService<IDocumentManagerService>(); } }

        /// <summary>
        /// Creates and shows a document containing a single object view model for new entity.
        /// Since CollectionViewModelBase is a POCO view model, an instance of this class will also expose the NewCommand property that can be used as a binding source in views.
        /// </summary>
        public virtual void New() {
            IDocument document = CreateDocument(newEntityInitializerFactory != null ? newEntityInitializerFactory() : new DefaultEntityInitializer<TEntity, TUnitOfWork>());
            if(document != null)
                document.Show();
        }

        /// <summary>
        /// Creates and shows a document containing a single object view model for the existing entity.
        /// Since CollectionViewModelBase is a POCO view model, an instance of this class will also expose the EditCommand property that can be used as a binding source in views.
        /// </summary>
        /// <param name="entity">Entity to edit.</param>
        public virtual void Edit(TEntity entity) {
            TPrimaryKey primaryKey = GetPrimaryKey(entity);
            entity = Repository.Reload(entity);
            if(entity == null || Repository.UnitOfWork.GetState(entity) == EntityState.Detached) {
                DestroyDocument(FindEntityDocument(primaryKey));
                return;
            }
            ShowDocument(GetPrimaryKey(entity));
        }

        /// <summary>
        /// Determines whether an entity can be edited.
        /// Since CollectionViewModelBase is a POCO view model, this method will be used as a CanExecute callback for EditCommand.
        /// </summary>
        /// <param name="entity">An entity to edit.</param>
        public bool CanEdit(TEntity entity) {
            return entity != null;
        }

        /// <summary>
        /// Deletes a given entity from the unit of work and saves changes if confirmed by a user.
        /// Since CollectionViewModelBase is a POCO view model, an instance of this class will also expose the DeleteCommand property that can be used as a binding source in views.
        /// </summary>
        /// <param name="entity">An entity to edit.</param>
        public virtual void Delete(TEntity entity) {
            if(MessageBoxService.Show(string.Format(CommonResources.Confirmation_Delete, typeof(TEntity).Name), CommonResources.Confirmation_Caption, MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                return;
            try {
                Entities.Remove(entity);
                Repository.Remove(entity);
                Repository.UnitOfWork.SaveChanges();
                Messenger.Default.Send(new EntityMessage<TEntity>(entity, EntityMessageType.Deleted));
            } catch(DbException e) {
                Refresh();
                MessageBoxService.Show(e.ErrorMessage, e.ErrorCaption, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Determines whether an entity can be deleted.
        /// Since CollectionViewModelBase is a POCO view model, this method will be used as a CanExecute callback for DeleteCommand.
        /// </summary>
        /// <param name="entity">An entity to edit.</param>
        public virtual bool CanDelete(TEntity entity) {
            return entity != null;
        }

        /// <summary>
        /// Recreates unit of work and reloads entities.
        /// Since CollectionViewModelBase is a POCO view model, an instance of this class will also expose the RefreshCommand property that can be used as a binding source in views.
        /// </summary>
        public override void Refresh() {
            TEntity entity = SelectedEntity;
            base.Refresh();
            if(entity != null && Repository.HasPrimaryKey(entity))
                SelectedEntity = FindNewEntity(GetPrimaryKey(entity));
        }


        /// <summary>
        /// Updates a given entity state and saves changes.
        /// Since CollectionViewModelBase is a POCO view model, instance of this class will also expose the SaveCommand property that can be used as a binding source in views.
        /// </summary>
        /// <param name="entity">Entity to update and save.</param>
        [Display(AutoGenerateField = false)]
        public virtual void Save(TEntity entity) {
            try {
                Repository.UnitOfWork.Update(entity);
                Repository.UnitOfWork.SaveChanges();
                Messenger.Default.Send(new EntityMessage<TEntity>(entity, EntityMessageType.Changed));
            } catch(DbException e) {
                MessageBoxService.Show(e.ErrorMessage, e.ErrorCaption, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Determines whether entity local changes can be saved.
        /// Since CollectionViewModelBase is a POCO view model, this method will be used as a CanExecute callback for SaveCommand.
        /// </summary>
        /// <param name="entity">Entity to edit.</param>
        public virtual bool CanSave(TEntity entity) {
            return entity != null;
        }

        /// <summary>
        /// Notifies that SelectedEntity has been changed by raising the PropertyChanged event.
        /// Since CollectionViewModelBase is a POCO view model, an instance of this class will also expose the UpdateSelectedEntityCommand property that can be used as a binding source in views.
        /// </summary>
        [Display(AutoGenerateField = false)]
        public virtual void UpdateSelectedEntity() {
            this.RaisePropertyChanged(x => x.SelectedEntity);
        }

        protected override void OnInitializeInRuntime() {
            base.OnInitializeInRuntime();
            Messenger.Default.Register<EntityMessage<TEntity>>(this, x => OnMessage(x));
        }

        void OnMessage(EntityMessage<TEntity> message) {
            if(!Repository.HasPrimaryKey(message.Entity))
                return;
            TPrimaryKey key = GetPrimaryKey(message.Entity);
            switch(message.MessageType) {
                case EntityMessageType.Added:
                    OnEntityAdded(key);
                    break;
                case EntityMessageType.Changed:
                    OnEntityChanged(key);
                    break;
                case EntityMessageType.Deleted:
                    OnEntityDeleted(key);
                    break;
            }
        }

        protected virtual TEntity OnEntityAdded(TPrimaryKey key) {
            return FindNewEntity(key);
        }

        protected virtual TEntity OnEntityChanged(TPrimaryKey key) {
            TEntity entity = FindEntity(key);
            if(entity == null) return null;
            entity = Repository.Reload(entity);
            if(FilterExpression != null && !(new TEntity[] { entity }.AsQueryable().Any(FilterExpression))) {
                Repository.UnitOfWork.Detach(entity);
            } else {
                int index = Repository.Local.IndexOf(entity);
                if(index >= 0)
                    Repository.Local.Move(index, index);
            }
            if(object.ReferenceEquals(entity, SelectedEntity))
                UpdateSelectedEntity();
            return entity;
        }

        protected virtual void OnEntityDeleted(TPrimaryKey key) {
            TEntity entity = Repository.Local.FirstOrDefault(x => object.Equals(Repository.GetPrimaryKey(x), key));
            if(entity != null) {
                Repository.Remove(entity);
                Repository.UnitOfWork.Detach(entity);
            }
        }

        protected TEntity FindNewEntity(TPrimaryKey key) {
            var entities = GetFilteredQueryableEntities();
            return entities.Where(ExpressionHelper.GetValueEqualsExpression(Repository.GetPrimaryKeyExpression, key)).FirstOrDefault();
        }

        protected TEntity FindEntity(TPrimaryKey key) {
            if(FilterExpression == null)
                return Repository.Find(key);
            return Repository.Local.AsQueryable().FirstOrDefault(ExpressionHelper.GetValueEqualsExpression(Repository.GetPrimaryKeyExpression, key)) ?? FindNewEntity(key);
        }

        protected override void OnSelectedEntityChanged() {
            base.OnSelectedEntityChanged();
            this.RaiseCanExecuteChanged(x => x.Edit(SelectedEntity));
            this.RaiseCanExecuteChanged(x => x.Delete(SelectedEntity));
            this.RaiseCanExecuteChanged(x => x.Save(SelectedEntity));
        }

        protected virtual TPrimaryKey GetPrimaryKey(TEntity entity) {
            return Repository.GetPrimaryKey(entity);
        }

        protected IDocumentOwner DocumentOwner { get; private set; }

        protected virtual void OnDestroy() {
            Messenger.Default.Unregister(this);
        }

        void ShowDocument(TPrimaryKey key) {
            IDocument document = FindEntityDocument(key) ?? CreateDocument(key);
            if(document != null)
                document.Show();
        }

        protected virtual IDocument CreateDocument(object parameter) {
            if(DocumentManagerService == null) return null;
            return DocumentManagerService.CreateDocument(typeof(TEntity).Name + "View", parameter, this);
        }

        protected void DestroyDocument(IDocument document) {
            if(document != null)
                document.Close();
        }

        protected IDocument FindEntityDocument(TPrimaryKey key) {
            if(DocumentManagerService == null) return null;
            foreach(IDocument document in DocumentManagerService.Documents) {
                ISingleObjectViewModel<TEntity, TPrimaryKey> entityViewModel = document.Content as ISingleObjectViewModel<TEntity, TPrimaryKey>;
                if(entityViewModel != null && object.Equals(entityViewModel.PrimaryKey, key))
                    return document;
            }
            return null;
        }

        #region IDocumentContent
        object IDocumentContent.Title { get { return null; } }

        void IDocumentContent.OnClose(CancelEventArgs e) { }

        void IDocumentContent.OnDestroy() {
            OnDestroy();
        }

        IDocumentOwner IDocumentContent.DocumentOwner {
            get { return DocumentOwner; }
            set { DocumentOwner = value; }
        }
        #endregion
    }
}
