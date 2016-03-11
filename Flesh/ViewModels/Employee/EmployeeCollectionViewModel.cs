using System;
using System.Linq;
using DevExpress.Mvvm.POCO;
using FHRMS.Common.Utils;
using FHRMS.DevAVDbDataModel;
using FHRMS.Common.DataModel;
using FHRMS.Data;
using FHRMS.Common.ViewModel;
using System.Collections.Generic;

namespace FHRMS.ViewModels {
    /// <summary>
    /// Represents the Employees collection view model.
    /// </summary>
    public partial class EmployeeCollectionViewModel : CollectionViewModel<Employee, long, IDevAVDbUnitOfWork> {

        /// <summary>
        /// Initializes a new instance of the EmployeeCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the EmployeeCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected EmployeeCollectionViewModel(IUnitOfWorkFactory<IDevAVDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Employees) {
        }
        public EmployeeCollectionViewModel()
            : this(DbUnitOfWorkFactory.Instance) {
        }
    }
}
