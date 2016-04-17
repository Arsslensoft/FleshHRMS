using PHRMS.Data;

namespace PHRMS.ViewModels
{
    public class EntityMultiInitializer<TEntity, TUnitOfWork> : IEntityInitializer<TEntity, TUnitOfWork>
        where TEntity : class
        where TUnitOfWork : IUnitOfWork
    {
        private readonly IEntityInitializer<TEntity, TUnitOfWork>[] initilaizers;

        public EntityMultiInitializer(params IEntityInitializer<TEntity, TUnitOfWork>[] initilaizers)
        {
            this.initilaizers = initilaizers;
        }

        void IEntityInitializer<TEntity, TUnitOfWork>.InitializeEntity(TUnitOfWork unitOfWork, TEntity entity)
        {
            foreach (var initializer in initilaizers)
                initializer.InitializeEntity(unitOfWork, entity);
        }
    }
}