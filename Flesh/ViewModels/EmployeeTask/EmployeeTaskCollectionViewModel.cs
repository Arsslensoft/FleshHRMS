using System;
using System.Linq;
using DevExpress.Mvvm.POCO;
using FHRMS.Common.Utils;
using FHRMS.DevAVDbDataModel;
using FHRMS.Common.DataModel;
using FHRMS.Data;
using FHRMS.Common.ViewModel;

namespace FHRMS.ViewModels {
    /// <summary>
    /// Represents the Tasks collection view model.
    /// </summary>
    public partial class EmployeeTaskCollectionViewModel : CollectionViewModel<EmployeeTask, long, IDevAVDbUnitOfWork> {

        /// <summary>
        /// Initializes a new instance of the EmployeeTaskCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the EmployeeTaskCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected EmployeeTaskCollectionViewModel(IUnitOfWorkFactory<IDevAVDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Tasks) {
        }
        public EmployeeTaskCollectionViewModel()
            : this(DbUnitOfWorkFactory.Instance) {
        }
    }
}
