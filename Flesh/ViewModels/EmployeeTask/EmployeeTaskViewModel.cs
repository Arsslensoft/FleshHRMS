using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using FHRMS.Common.Utils;
using FHRMS.DevAVDbDataModel;
using FHRMS.Common.DataModel;
using FHRMS.Data;
using FHRMS.Common.ViewModel;

namespace FHRMS.ViewModels {
    /// <summary>
    /// Represents the single EmployeeTask object view model.
    /// </summary>
    public partial class EmployeeTaskViewModel : SingleObjectViewModel<EmployeeTask, long, IDevAVDbUnitOfWork> {

        /// <summary>
        /// Initializes a new instance of the EmployeeTaskViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the EmployeeTaskViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected EmployeeTaskViewModel(IUnitOfWorkFactory<IDevAVDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Tasks, x => x.Subject) {
        }
        public EmployeeTaskViewModel()
            : this(DbUnitOfWorkFactory.Instance) {
        }

        /// <summary>
        /// The look-up collection of CustomerEmployees for the corresponding navigation property in the view.
        /// </summary>
        public IList<CustomerEmployee> LookUpCustomerEmployees {
            get { return GetLookUpEntities(x => x.CustomerEmployees); }
        }

        /// <summary>
        /// The look-up collection of Employees for the corresponding navigation property in the view.
        /// </summary>
        public IList<Employee> LookUpEmployees {
            get { return GetLookUpEntities(x => x.Employees); }
        }
    }
}
