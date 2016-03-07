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
    public class EntityMultiInitializer<TEntity, TUnitOfWork> : IEntityInitializer<TEntity, TUnitOfWork>
        where TEntity : class
        where TUnitOfWork : IUnitOfWork {

        IEntityInitializer<TEntity, TUnitOfWork>[] initilaizers;

        public EntityMultiInitializer(params IEntityInitializer<TEntity, TUnitOfWork>[] initilaizers) {
            this.initilaizers = initilaizers;
        }
        void IEntityInitializer<TEntity, TUnitOfWork>.InitializeEntity(TUnitOfWork unitOfWork, TEntity entity) {
            foreach(var initializer in initilaizers)
                initializer.InitializeEntity(unitOfWork, entity);
        }
    }
}
