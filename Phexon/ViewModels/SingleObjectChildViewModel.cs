using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace PHRMS.ViewModels
{
    public class SingleObjectChildViewModel<TEntity> : ISupportParameter where TEntity : class
    {
        protected SingleObjectChildViewModel()
        {
        }

        public virtual TEntity Entity { get; set; }
        public virtual bool IsEnabled { get; protected set; }

        #region ISupportParameter

        object ISupportParameter.Parameter
        {
            get { return Entity; }
            set { Entity = (TEntity) value; }
        }

        #endregion

        public static SingleObjectChildViewModel<TEntity> Create()
        {
            return ViewModelSource.Create(() => new SingleObjectChildViewModel<TEntity>());
        }

        protected virtual void OnEntityChanged()
        {
            IsEnabled = Entity != null;
        }
    }
}