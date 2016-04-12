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
    /// Represents the single Absence object view model.
    /// </summary>
    public partial class ScheduleViewModel : SingleObjectViewModel<Schedule, long, IDevAVDbUnitOfWork>
    {

        /// <summary>
        /// Initializes a new instance of the EvaluationViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the EvaluationViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected ScheduleViewModel(IUnitOfWorkFactory<IDevAVDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Schedules, x => x.Name) {
        }
        public ScheduleViewModel()
            : this(DbUnitOfWorkFactory.Instance) {
        }
        protected override void RefreshLookUpCollections(long key)
        {
            EmployeeShiftsLookUp = CreateLookUpCollectionViewModel(x => x.Shifts, x => x.ScheduleId, (x, m) => x.Schedule = m,key);
        }
        /// <summary>
        /// The look-up collection of Employés for the corresponding navigation property in the view.
        /// </summary>
        public IList<Employee> LookUpEmployees {
            get { return GetLookUpEntities(x => x.Employees); }
        }

        public virtual CollectionViewModel<Shift, long, IDevAVDbUnitOfWork> EmployeeShiftsLookUp { get; set; }
    }
}
