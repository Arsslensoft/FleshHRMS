using DevExpress.Mvvm;
using PHRMS.Data;

namespace PHRMS.ViewModels
{
    partial class SingleObjectViewModel<TEntity, TPrimaryKey, TUnitOfWork>
        where TEntity : class
        where TUnitOfWork : IUnitOfWork
    {
        public TPrimaryKey EntityKey
        {
            get { return PrimaryKey; }
        }

        public virtual bool ValidationErrors { get; set; }

        protected virtual bool EnableSelectedItemSynchronization
        {
            get { return false; }
        }

        protected virtual bool EnableEntityChangedSynchronization
        {
            get { return false; }
        }

        protected override bool HasValidationErrors()
        {
            return ValidationErrors;
        }

        protected virtual void OnValidationErrorsChanged()
        {
            UpdateCommands();
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
            if (EnableSelectedItemSynchronization)
                SubscribeSelectedItemSynchronizationMessage();
        }

        protected void SubscribeSelectedItemSynchronizationMessage()
        {
            Messenger.Default.Register<SelectedItemSynchronizationMessage<TEntity>>(this,
                x => OnSelectedItemSynchronizationMessage(x));
        }

        protected virtual void OnSelectedItemSynchronizationMessage(SelectedItemSynchronizationMessage<TEntity> m)
        {
            if (m.Entity == null) Entity = null;
            else OnParameterChanged(Repository.GetPrimaryKey(m.Entity));
        }

        protected override void OnEntityMessage(EntityMessage<TEntity> msg)
        {
            if (EnableEntityChangedSynchronization && msg.MessageType == EntityMessageType.Changed)
            {
                if (Equals(Repository.GetPrimaryKey(msg.Entity), PrimaryKey))
                    Reload();
            }
            base.OnEntityMessage(msg);
        }
    }
}