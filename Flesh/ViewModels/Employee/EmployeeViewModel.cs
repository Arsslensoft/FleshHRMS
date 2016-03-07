using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.DevAV.Common.Utils;
using DevExpress.DevAV.DevAVDbDataModel;
using DevExpress.DevAV.Common.DataModel;
using DevExpress.DevAV;
using DevExpress.DevAV.Common.ViewModel;

namespace DevExpress.DevAV.ViewModels {
    /// <summary>
    /// Represents the single Employee object view model.
    /// </summary>
    public partial class EmployeeViewModel : SingleObjectViewModel<Employee, long, IDevAVDbUnitOfWork> {

        /// <summary>
        /// Initializes a new instance of the EmployeeViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the EmployeeViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected EmployeeViewModel(IUnitOfWorkFactory<IDevAVDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Employees, x => x.FullName) {
        }
        public EmployeeViewModel()
            : this(DbUnitOfWorkFactory.Instance) {
        }

        /// <summary>
        /// The look-up collection of Pictures for the corresponding navigation property in the view.
        /// </summary>
        public IList<Picture> LookUpPictures {
            get { return GetLookUpEntities(x => x.Pictures); }
        }

        /// <summary>
        /// The look-up collection of Probations for the corresponding navigation property in the view.
        /// </summary>
        public IList<Probation> LookUpProbations {
            get { return GetLookUpEntities(x => x.Probations); }
        }

        protected override void RefreshLookUpCollections(long key) {
            EmployeeAssignedTasksLookUp = CreateLookUpCollectionViewModel(x => x.Tasks, x => x.AssignedEmployeeId, (x, m) => x.AssignedEmployee = m, key);
            EmployeeOwnedTasksLookUp = CreateLookUpCollectionViewModel(x => x.Tasks, x => x.OwnerId, (x, m) => x.Owner = m, key);
            EmployeeEvaluationsLookUp = CreateLookUpCollectionViewModel(x => x.Evaluations, x => x.EmployeeId, (x, m) => x.Employee = m, key);
        }

        /// <summary>
        /// The view model for the EmployeeAssignedTasks detail collection.
        /// </summary>
        public virtual CollectionViewModel<EmployeeTask, long, IDevAVDbUnitOfWork> EmployeeAssignedTasksLookUp { get; set; }

        /// <summary>
        /// The view model for the EmployeeOwnedTasks detail collection.
        /// </summary>
        public virtual CollectionViewModel<EmployeeTask, long, IDevAVDbUnitOfWork> EmployeeOwnedTasksLookUp { get; set; }

        /// <summary>
        /// The view model for the EmployeeEvaluations detail collection.
        /// </summary>
        public virtual CollectionViewModel<Evaluation, long, IDevAVDbUnitOfWork> EmployeeEvaluationsLookUp { get; set; }
    }
}
