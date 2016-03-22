using System;
using System.Linq;
using DevExpress.Mvvm.POCO;
using FHRMS.Common.Utils;
using FHRMS.DevAVDbDataModel;
using FHRMS.Common.DataModel;
using FHRMS.Data;
using FHRMS.Common.ViewModel;
using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Data.Entity;

namespace FHRMS.ViewModels {
    /// <summary>
    /// Represents the Orders collection view model.
    /// </summary>
    public partial class NotificationCollectionViewModel : CollectionViewModel<Notification, long, IDevAVDbUnitOfWork> {

        /// <summary>
        /// Initializes a new instance of the OrderCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the OrderCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected NotificationCollectionViewModel(IUnitOfWorkFactory<IDevAVDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Notifications) {
        }
        public NotificationCollectionViewModel()
            : this(DbUnitOfWorkFactory.Instance) {

        }
        
    

    }
}
