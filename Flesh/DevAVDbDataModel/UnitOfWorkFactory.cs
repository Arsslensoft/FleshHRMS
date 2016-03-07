using System;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Collections.Generic;
using DevExpress.DevAV.Common.Utils;
using DevExpress.DevAV.Common.DataModel;
using DevExpress.DevAV.Common.DataModel.EntityFramework;
using DevExpress.DevAV;
using DevExpress.Mvvm;

namespace DevExpress.DevAV.DevAVDbDataModel {
    public class DbUnitOfWorkFactory : IUnitOfWorkFactory<IDevAVDbUnitOfWork> {
        public static readonly IUnitOfWorkFactory<IDevAVDbUnitOfWork> Instance = new DbUnitOfWorkFactory();
        DbUnitOfWorkFactory() { }
        IDevAVDbUnitOfWork IUnitOfWorkFactory<IDevAVDbUnitOfWork>.CreateUnitOfWork() {
            Database.SetInitializer<DevAVDb>(null);
            return new DevAVDbUnitOfWork(new DevAVDb());
        }
    }
    #region UnitOfWorkSourceBase
    public static class UnitOfWorkSourceBase {
        /// <summary>
        /// Returns the given factory (if it is not null) or creates an appropriate factory based on the current mode (run-time or design-time).
        /// </summary>
        /// <param name="defaultFactory">An IUnitOfWork factory.</param>
        public static IUnitOfWorkFactory<IDevAVDbUnitOfWork> GetUnitOfWorkFactory(IUnitOfWorkFactory<IDevAVDbUnitOfWork> defaultFactory = null) {
            return defaultFactory ?? GetUnitOfWorkFactory(ViewModelBase.IsInDesignMode);
        }

        /// <summary>
        /// Returns the IUnitOfWorkFactory implementation based on the given mode (run-time or design-time).
        /// </summary>
        /// <param name="isInDesignTime">Used to determine which implementation of IUnitOfWorkFactory should be returned.</param>
        public static IUnitOfWorkFactory<IDevAVDbUnitOfWork> GetUnitOfWorkFactory(bool isInDesignTime) {
            if(isInDesignTime)
                throw new NotSupportedException();
            return DbUnitOfWorkFactory.Instance;
        }
    }
    #endregion
}
