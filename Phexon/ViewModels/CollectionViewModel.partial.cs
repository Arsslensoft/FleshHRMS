using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using DevExpress.Data.Filtering;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using PHRMS.Data;

namespace PHRMS.ViewModels
{
    partial class CollectionViewModel<TEntity, TPrimaryKey, TUnitOfWork> : ISupportParameter, IDocumentContent
        where TEntity : class
        where TUnitOfWork : IUnitOfWork
    {
        public TPrimaryKey SelectedEntityKey
        {
            get { return SelectedEntity != null ? GetPrimaryKey(SelectedEntity) : default(TPrimaryKey); }
        }

        #region IDocumentContent

        object IDocumentContent.Title
        {
            get { return GetTitle(); }
        }

        #endregion

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
            Messenger.Default.Register<SelectedItemSynchronizationMessage<TEntity>>(this,
                x => OnSelectedItemSynchronizationMessage(x));
        }

        public event EventHandler EntityAdded;

        protected override TEntity OnEntityAdded(TPrimaryKey key)
        {
            var handler = EntityAdded;
            if (handler != null)
                handler(this, EventArgs.Empty);
            return base.OnEntityAdded(key);
        }

        public event EventHandler EntityDeleted;

        protected override void OnEntityDeleted(TPrimaryKey key)
        {
            base.OnEntityDeleted(key);
            var handler = EntityDeleted;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public event EventHandler EntityUpdated;

        protected override TEntity OnEntityChanged(TPrimaryKey key)
        {
            var entity = base.OnEntityChanged(key);
            var handler = EntityUpdated;
            if (handler != null)
                handler(this, EventArgs.Empty);
            return entity;
        }

        [Command, Display(AutoGenerateField = false)]
        public virtual void OnLoaded()
        {
            SelectedEntity = Parameter == null ? Entities.FirstOrDefault() : FindEntity((TPrimaryKey) Parameter);
        }

        public event EventHandler SelectedEntityChanged;

        protected override void OnSelectedEntityChanged()
        {
            Parameter = SelectedEntity == null ? (object) null : GetPrimaryKey(SelectedEntity);
            base.OnSelectedEntityChanged();
            Messenger.Default.Send(new SelectedItemSynchronizationMessage<TEntity>(SelectedEntity));
            if (SelectedEntityChanged != null)
                SelectedEntityChanged(this, EventArgs.Empty);
        }

        private void OnSelectedItemSynchronizationMessage(SelectedItemSynchronizationMessage<TEntity> message)
        {
            SelectedEntity = message.Entity == null ? null : FindEntity(GetPrimaryKey(message.Entity));
        }

        public event EventHandler ParameterChanged;

        protected virtual object GetTitle()
        {
            return null;
        }

        protected IDocument FindEntityDocument<TViewModel>()
        {
            if (DocumentManagerService == null) return null;
            return DocumentManagerService.Documents.FirstOrDefault(d => d.Content is TViewModel);
        }

        protected IDocument FindEntityDocument<TViewModel>(TPrimaryKey key)
        {
            if (DocumentManagerService == null) return null;
            foreach (var document in DocumentManagerService.Documents)
            {
                var entityViewModel = document.Content as ISingleObjectViewModel<TEntity, TPrimaryKey>;
                if (entityViewModel != null && entityViewModel is TViewModel && Equals(entityViewModel.PrimaryKey, key))
                    return document;
            }
            return null;
        }

        public IQueryable<TEntity> GetEntities(Expression<Func<TEntity, bool>> filter = null)
        {
            return getRepositoryFunc(unitOfWorkFactory.CreateUnitOfWork()).GetFilteredEntities(filter);
        }

        public CriteriaOperator GetInOperator(IEnumerable<TEntity> entities)
        {
            var keyName = ((MemberExpression) Repository.GetPrimaryKeyExpression.Body).Member.Name;
            return new InOperator(keyName, entities.Select(e => GetPrimaryKey(e)));
        }

        [Command]
        public void Close()
        {
            if (DocumentOwner != null)
                DocumentOwner.Close(this);
        }

        #region ISupportParameter

        private object parameterCore;

        protected object Parameter
        {
            get { return parameterCore; }
            private set
            {
                parameterCore = value;
                var handler = ParameterChanged;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }
        }

        object ISupportParameter.Parameter
        {
            get { return Parameter; }
            set { Parameter = value; }
        }

        #endregion
    }
}