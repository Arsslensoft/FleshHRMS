using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
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
    /// The base class for POCO view models exposing a single entity of a given type and CRUD operations against this entity. 
    /// This is a partial class that provides the extension point to add custom properties, commands and override methods without modifying the auto-generated code.
    /// </summary>
    /// <typeparam name="TEntity">An entity type.</typeparam>
    /// <typeparam name="TPrimaryKey">A primary key value type.</typeparam>
    /// <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    public abstract partial class SingleObjectViewModel<TEntity, TPrimaryKey, TUnitOfWork> : SingleObjectViewModelBase<TEntity, TPrimaryKey, TUnitOfWork>
        where TEntity : class
        where TUnitOfWork : IUnitOfWork {

        /// <summary>
        /// Initializes a new instance of the SingleObjectViewModel class.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create the unit of work instance.</param>
        /// <param name="getRepositoryFunc">A function that returns the repository representing entities of a given type.</param>
        /// <param name="getEntityDisplayNameFunc">An optional parameter that provides a function to obtain the display text for a given entity. If ommited, the primary key value is used as a display text.</param>
        protected SingleObjectViewModel(IUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory, Func<TUnitOfWork, IRepository<TEntity, TPrimaryKey>> getRepositoryFunc, Func<TEntity, object> getEntityDisplayNameFunc = null)
            : base(unitOfWorkFactory, getRepositoryFunc, getEntityDisplayNameFunc) {
        }
    }

    /// <summary>
    /// The base class for POCO view models exposing a single entity of a given type and CRUD operations against this entity. 
    /// It is not recommended to inherit directly from this class. Use the SingleObjectViewModel class instead.
    /// </summary>
    /// <typeparam name="TEntity">An entity type.</typeparam>
    /// <typeparam name="TPrimaryKey">A primary key value type.</typeparam>
    /// <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    [POCOViewModel]
    public abstract class SingleObjectViewModelBase<TEntity, TPrimaryKey, TUnitOfWork> : ISingleObjectViewModel<TEntity, TPrimaryKey>, ISupportParameter, IDocumentContent
        where TEntity : class
        where TUnitOfWork : IUnitOfWork {

        object title;
        protected readonly Func<TUnitOfWork, IRepository<TEntity, TPrimaryKey>> getRepositoryFunc;
        protected readonly Func<TEntity, object> getEntityDisplayNameFunc;

        /// <summary>
        /// Initializes a new instance of the SingleObjectViewModelBase class.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create the unit of work instance.</param>
        /// <param name="getRepositoryFunc">A function that returns repository representing entities of a given type.</param>
        /// <param name="getEntityDisplayNameFunc">An optional parameter that provides a function to obtain the display text for a given entity. If ommited, the primary key value is used as a display text.</param>
        protected SingleObjectViewModelBase(IUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory, Func<TUnitOfWork, IRepository<TEntity, TPrimaryKey>> getRepositoryFunc, Func<TEntity, object> getEntityDisplayNameFunc) {
            UnitOfWorkFactory = unitOfWorkFactory;
            this.getRepositoryFunc = getRepositoryFunc;
            this.getEntityDisplayNameFunc = getEntityDisplayNameFunc;
   UnitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            if(this.IsInDesignMode())
                this.Entity = this.Repository.Local.FirstOrDefault();
            else
                OnInitializeInRuntime();
        }

        protected IUnitOfWorkFactory<TUnitOfWork> UnitOfWorkFactory { get; private set; }

        protected TUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// The display text for a given entity used as a title in the corresponding view.
        /// </summary>
        /// <returns></returns>
        public object Title { get { return title; } }

        /// <summary>
        /// An entity represented by this view model.
        /// Since SingleObjectViewModelBase is a POCO view model, this property will raise INotifyPropertyChanged.PropertyEvent when modified so it can be used as a binding source in views.
        /// </summary>
        /// <returns></returns>
        public virtual TEntity Entity { get; set; }

        /// <summary>
        /// Updates the Title property value and raises CanExecute changed for relevant commands.
        /// Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the UpdateCommand property that can be used as a binding source in views.
        /// </summary>
        [Display(AutoGenerateField = false)]
        public void Update() {
            UpdateTitle();
            UpdateCommands();
        }

        /// <summary>
        /// Saves changes in the underlying unit of work.
        /// Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the SaveCommand property that can be used as a binding source in views.
        /// </summary>
        [Command]
        public virtual bool Save() {
            try {
                bool isNewEntity = IsNew();
                if(!isNewEntity) {
                    Repository.SetPrimaryKey(Entity, PrimaryKey);
                    UnitOfWork.Update(Entity);
                }
                UnitOfWork.SaveChanges();
                Messenger.Default.Send(new EntityMessage<TEntity>(Entity, isNewEntity ? EntityMessageType.Added : EntityMessageType.Changed));
                Reload();
                OnAfterEntitySaved(Entity);
                return true;
            } catch(DbException e) {
                MessageBoxService.Show(e.ErrorMessage, e.ErrorCaption, MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Saves changes in the underlying unit of work and closes the corresponding view.
        /// Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the SaveAndCloseCommand property that can be used as a binding source in views.
        /// </summary>
        [Command(CanExecuteMethodName = "CanSave")]
        public void SaveAndClose() {
            if(Save())
                Close();
        }

        /// <summary>
        /// Determines whether entity local changes can be saved.
        /// Since SingleObjectViewModelBase is a POCO view model, this method will be used as a CanExecute callback for SaveCommand.
        /// </summary>
        public virtual bool CanSave() {
            return Entity != null && !HasValidationErrors() && NeedSave(); ;
        }

        /// <summary>
        /// Deletes the entity, save changes and closes the corresponding view if confirmed by a user.
        /// Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the DeleteCommand property that can be used as a binding source in views.
        /// </summary>
        public virtual void Delete() {
            if(MessageBoxService.Show(string.Format(CommonResources.Confirmation_Delete, typeof(TEntity).Name), CommonResources.Confirmation_Caption, MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                return;
            try {
                OnBeforeEntityDeleted(Entity);
                Repository.Remove(Entity);
                UnitOfWork.SaveChanges();
                TEntity toMessage = Entity;
                Entity = null;
                Messenger.Default.Send(new EntityMessage<TEntity>(toMessage, EntityMessageType.Deleted));
                Close();
            } catch (DbException e) {
                MessageBoxService.Show(e.ErrorMessage, e.ErrorCaption, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Determines whether the entity can be deleted.
        /// Since SingleObjectViewModelBase is a POCO view model, this method will be used as a CanExecute callback for DeleteCommand.
        /// </summary>
        public virtual bool CanDelete() {
            return Entity != null && !IsNew();
        }

        /// <summary>
        /// Reset entity local changes.
        /// Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the ResetCommand property that can be used as a binding source in views.
        /// </summary>
        public void Reset() {
            MessageBoxResult confirmationResult = MessageBoxService.Show(CommonResources.Confirmation_Reset, CommonResources.Confirmation_Caption, MessageBoxButton.OKCancel);
            if(confirmationResult == MessageBoxResult.OK)
                Reload();
        }
        /// Determines whether entity has local changes.
        /// Since SingleObjectViewModelBase is a POCO view model, this method will be used as a CanExecute callback for ResetCommand.
        /// </summary>
        public bool CanReset() {
            return NeedSave();
        }

        /// <summary>
        /// Closes the corresponding view.
        /// Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the CloseCommand property that can be used as a binding source in views.
        /// </summary>
        public void Close() {
            if(!TryClose())
                return;
            if(DocumentOwner != null)
                DocumentOwner.Close(this);
        }

        protected virtual void OnInitializeInRuntime() {
            Messenger.Default.Register<EntityMessage<TEntity>>(this, x => OnEntityMessage(x));
        }

        protected virtual void OnEntityMessage(EntityMessage<TEntity> x) {
            if(Entity == null) return;
            if(x.MessageType == EntityMessageType.Deleted && object.Equals(Repository.GetPrimaryKey(x.Entity), PrimaryKey))
                Close();
        }

        protected virtual void OnEntityChanged() {
            if(Entity != null && Repository.HasPrimaryKey(Entity)) {
                PrimaryKey = Repository.GetPrimaryKey(Entity);
                RefreshLookUpCollections(PrimaryKey);
            }
            Update();
        }

        protected virtual void RefreshLookUpCollections(TPrimaryKey key) {
        }

        protected IRepository<TEntity, TPrimaryKey> Repository { get { return getRepositoryFunc(UnitOfWork); } }

        protected TPrimaryKey PrimaryKey { get; private set; }

        protected IMessageBoxService MessageBoxService { get { return this.GetRequiredService<IMessageBoxService>(); } }

        protected virtual void OnParameterChanged(object parameter) {
            IEntityInitializer<TEntity, TUnitOfWork> initializer = parameter as IEntityInitializer<TEntity, TUnitOfWork>;
            if(initializer != null) {
                Entity = CreateEntity();
                InitializeEntity(initializer);
            } else if(parameter is TPrimaryKey) {
                Entity = Repository.Find((TPrimaryKey)parameter);
            } else {
                Entity = null;
            }
        }

        protected virtual TEntity CreateEntity() {
            return Repository.Create();
        }

        void UpdateTitle() {
            if(Entity == null)
                title = null;
            else if(IsNew())
                title = GetTitleForNewEntity();
            else
                title = GetTitle(GetState() == EntityState.Modified);
            this.RaisePropertyChanged(x => x.Title);
        }

        protected virtual void UpdateCommands() {
            this.RaiseCanExecuteChanged(x => x.Save());
            this.RaiseCanExecuteChanged(x => x.SaveAndClose());
            this.RaiseCanExecuteChanged(x => x.Delete());
            this.RaiseCanExecuteChanged(x => x.Reset());
        }

        protected virtual void OnAfterEntitySaved(TEntity entity) { }

        protected void Reload() {
            Entity = Repository.Reload(Entity);
            OnEntityChanged();
            this.RaisePropertyChanged(x => x.Entity);
        }

        protected virtual void OnBeforeEntityDeleted(TEntity entity) { }

        protected IDocumentOwner DocumentOwner { get; private set; }

        protected virtual void OnDestroy() {
            Messenger.Default.Unregister(this);
        }

        protected virtual bool TryClose() {
            if(HasValidationErrors()) {
                MessageBoxResult warningResult = MessageBoxService.Show(CommonResources.Warning_SomeFieldsContainInvalidData, CommonResources.Warning_Caption, MessageBoxButton.OKCancel);
                return warningResult == MessageBoxResult.OK;
            }
            if(!NeedSave()) return true;
            MessageBoxResult result = MessageBoxService.Show(CommonResources.Confirmation_Save, CommonResources.Confirmation_Caption, MessageBoxButton.YesNoCancel);
            if(result == MessageBoxResult.Yes)
                return Save();
            return result != MessageBoxResult.Cancel;
        }

        protected bool IsNew() {
            return GetState() == EntityState.Added;
        }

        protected virtual bool NeedSave() {
            if(Entity == null)
                return false;
            EntityState state = GetState();
            return state == EntityState.Modified || state == EntityState.Added;
        }

        protected virtual bool HasValidationErrors() { return false; }

        string GetTitle(bool entityModified) {
            if(entityModified)
                return GetTitle() + CommonResources.Entity_Changed;
            else
                return GetTitle();
        }

        protected virtual string GetTitleForNewEntity() {
            return typeof(TEntity).Name + CommonResources.Entity_New;
        }

        protected virtual string GetTitle() {
            return typeof(TEntity).Name + " - " + Convert.ToString(getEntityDisplayNameFunc != null ? getEntityDisplayNameFunc(Entity) : PrimaryKey);
        }

        void InitializeEntity(IEntityInitializer<TEntity, TUnitOfWork> entityInitializer) {
            entityInitializer.InitializeEntity(UnitOfWork, Entity);
            this.RaisePropertyChanged(x => x.Entity);
        }

        protected EntityState GetState() {
            try {
                return UnitOfWork.GetState(Entity);
            } catch(InvalidOperationException) {
                Repository.SetPrimaryKey(Entity, PrimaryKey);
                return UnitOfWork.GetState(Entity);
            }
        }

        protected void DestroyDocument(IDocument document) {
            if(document != null)
                document.Close();
        }

        protected virtual CollectionViewModel<TDetailEntity, TDetailPrimaryKey, TUnitOfWork> CreateLookUpCollectionViewModel<TDetailEntity, TDetailPrimaryKey, TForeignKey>(
                Func<TUnitOfWork, IRepository<TDetailEntity, TDetailPrimaryKey>> getRepositoryFunc, Expression<Func<TDetailEntity, TForeignKey>> foreignKeyExpression, Action<TDetailEntity, TEntity> setMasterEntityAction, TForeignKey masterEntityKey) where TDetailEntity : class {
            var lookUpViewModel = ViewModelSource.Create(() => new CollectionViewModel<TDetailEntity, TDetailPrimaryKey, TUnitOfWork>(UnitOfWorkFactory, getRepositoryFunc, () => CreateNavigationPropertyInitializer(setMasterEntityAction, masterEntityKey)));
            lookUpViewModel.SetParentViewModel(this);
            lookUpViewModel.FilterExpression = ExpressionHelper.GetValueEqualsExpression(foreignKeyExpression, masterEntityKey);
            return lookUpViewModel;
        }

        protected virtual ReadOnlyCollectionViewModel<TDetailEntity, TUnitOfWork> CreateReadOnlyLookUpCollectionViewModel<TDetailEntity, TForeignKey>(
                Func<TUnitOfWork, IReadOnlyRepository<TDetailEntity>> getRepositoryFunc, Expression<Func<TDetailEntity, TForeignKey>> foreignKeyExpression, TForeignKey masterEntityKey) where TDetailEntity : class {
            var lookUpViewModel = ViewModelSource.Create(() => new ReadOnlyCollectionViewModel<TDetailEntity, TUnitOfWork>(UnitOfWorkFactory, getRepositoryFunc));
            lookUpViewModel.SetParentViewModel(this);
            lookUpViewModel.FilterExpression = ExpressionHelper.GetValueEqualsExpression(foreignKeyExpression, masterEntityKey);
            return lookUpViewModel;
        }

        IEntityInitializer<TDetailEntity, TUnitOfWork> CreateNavigationPropertyInitializer<TDetailEntity, TForeignKey>(Action<TDetailEntity, TEntity> setMasterEntityAction, TForeignKey masterEntityKey) where TDetailEntity : class {
            return new EntityNavigationPropertyInitializer<TDetailEntity, TEntity, TPrimaryKey, TUnitOfWork>((TPrimaryKey)((object)masterEntityKey), setMasterEntityAction, this.getRepositoryFunc);
        }

        protected virtual IList<TLookUpEntity> GetLookUpEntities<TLookUpEntity>(Func<TUnitOfWork, IReadOnlyRepository<TLookUpEntity>> getRepositoryFunc) where TLookUpEntity : class {
            var repository = getRepositoryFunc(UnitOfWork);
            repository.GetEntities().Load();
            return repository.Local;
        }

        #region ISupportParameter

        object ISupportParameter.Parameter {
            get { return null; }
            set { OnParameterChanged(value); }
        }
        #endregion

        #region IDocumentContent
        object IDocumentContent.Title { get { return Title; } }

        void IDocumentContent.OnClose(CancelEventArgs e) {
            e.Cancel = !TryClose();
        }

        void IDocumentContent.OnDestroy() {
            OnDestroy();
        }

        IDocumentOwner IDocumentContent.DocumentOwner {
            get { return DocumentOwner; }
            set { DocumentOwner = value; }
        }
        #endregion

        #region ISingleObjectViewModel
        TEntity ISingleObjectViewModel<TEntity, TPrimaryKey>.Entity { get { return Entity; } }

        TPrimaryKey ISingleObjectViewModel<TEntity, TPrimaryKey>.PrimaryKey { get { return PrimaryKey; } }
        #endregion
    }
}
