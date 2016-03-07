using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DevExpress.DevAV.Common.DataModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;

namespace DevExpress.DevAV.Common.ViewModel {
    partial class SingleObjectViewModel<TEntity, TPrimaryKey, TUnitOfWork>
        where TEntity : class
        where TUnitOfWork : IUnitOfWork {
        public TPrimaryKey EntityKey { get { return PrimaryKey; } }
        protected override bool HasValidationErrors() {
            return ValidationErrors;
        }
        public virtual bool ValidationErrors { get; set; }
        protected virtual void OnValidationErrorsChanged() {
            UpdateCommands();
        }
        protected virtual bool EnableSelectedItemSynchronization {
            get { return false; }
        }
        protected override void OnInitializeInRuntime() {
            base.OnInitializeInRuntime();
            if(EnableSelectedItemSynchronization)
                SubscribeSelectedItemSynchronizationMessage();
        }
        protected void SubscribeSelectedItemSynchronizationMessage() {
            Messenger.Default.Register<SelectedItemSynchronizationMessage<TEntity>>(this, x => OnSelectedItemSynchronizationMessage(x));
        }
        protected virtual void OnSelectedItemSynchronizationMessage(SelectedItemSynchronizationMessage<TEntity> m) {
            if(m.Entity == null) Entity = null;
            else OnParameterChanged(Repository.GetPrimaryKey(m.Entity));
        }
        protected virtual bool EnableEntityChangedSynchronization {
            get { return false; }
        }
        protected override void OnEntityMessage(EntityMessage<TEntity> msg) {
            if(EnableEntityChangedSynchronization && msg.MessageType == EntityMessageType.Changed) {
                if(object.Equals(Repository.GetPrimaryKey(msg.Entity), PrimaryKey))
                    Reload();
            }
            base.OnEntityMessage(msg);
        }
    }
}
