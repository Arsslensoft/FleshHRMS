using System;
using System.Data.Entity;
using DevExpress.Mvvm;

namespace PHRMS.Data
{
    public class DbUnitOfWorkFactory : IUnitOfWorkFactory<IPhexonDbUnitOfWork>
    {
        public static readonly IUnitOfWorkFactory<IPhexonDbUnitOfWork> Instance = new DbUnitOfWorkFactory();

        private DbUnitOfWorkFactory()
        {
        }

        IPhexonDbUnitOfWork IUnitOfWorkFactory<IPhexonDbUnitOfWork>.CreateUnitOfWork()
        {
            Database.SetInitializer<PhexonDb>(null);
            return new PhexonDbUnitOfWork(new PhexonDb());
        }
    }

    #region UnitOfWorkSourceBase

    public static class UnitOfWorkSourceBase
    {
        /// <summary>
        ///     Returns the given factory (if it is not null) or creates an appropriate factory based on the current mode (run-time
        ///     or design-time).
        /// </summary>
        /// <param name="defaultFactory">An IUnitOfWork factory.</param>
        public static IUnitOfWorkFactory<IPhexonDbUnitOfWork> GetUnitOfWorkFactory(
            IUnitOfWorkFactory<IPhexonDbUnitOfWork> defaultFactory = null)
        {
            return defaultFactory ?? GetUnitOfWorkFactory(ViewModelBase.IsInDesignMode);
        }

        /// <summary>
        ///     Returns the IUnitOfWorkFactory implementation based on the given mode (run-time or design-time).
        /// </summary>
        /// <param name="isInDesignTime">Used to determine which implementation of IUnitOfWorkFactory should be returned.</param>
        public static IUnitOfWorkFactory<IPhexonDbUnitOfWork> GetUnitOfWorkFactory(bool isInDesignTime)
        {
            if (isInDesignTime)
                throw new NotSupportedException();
            return DbUnitOfWorkFactory.Instance;
        }
    }

    #endregion
}