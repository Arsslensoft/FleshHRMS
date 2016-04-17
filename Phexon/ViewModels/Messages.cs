namespace PHRMS.ViewModels
{
    public class SelectedItemSynchronizationMessage<TEntity> where TEntity : class
    {
        public SelectedItemSynchronizationMessage(TEntity entity)
        {
            Entity = entity;
        }

        public TEntity Entity { get; private set; }
    }
}