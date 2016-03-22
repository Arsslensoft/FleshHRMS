﻿using System;
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

        public void SaveAll()
        {
            ((DevAVDbUnitOfWork)UnitOfWork).Context.SaveChanges();
        }

        protected override void RefreshLookUpCollections(long key) {
            EmployeeAssignedTasksLookUp = CreateLookUpCollectionViewModel(x => x.Tasks, x => x.AssignedEmployeeId, (x, m) => x.AssignedEmployee = m, key);
            EmployeeOwnedTasksLookUp = CreateLookUpCollectionViewModel(x => x.Tasks, x => x.OwnerId, (x, m) => x.Owner = m, key);
            EmployeeEvaluationsLookUp = CreateLookUpCollectionViewModel(x => x.Evaluations, x => x.EmployeeId, (x, m) => x.Employee = m, key);
            EmployeeShiftsLookUp = CreateLookUpCollectionViewModel(x => x.Shifts, x => x.EmployeeId, (x, m) => x.Employee = m, key);
        }

        /// <summary>
        /// The view model for the EmployeeAssignedTasks detail collection.
        /// </summary>
        public virtual CollectionViewModel<Leave, long, IDevAVDbUnitOfWork> EmployeeAssignedTasksLookUp { get; set; }

        /// <summary>
        /// The view model for the EmployeeOwnedTasks detail collection.
        /// </summary>
        public virtual CollectionViewModel<Leave, long, IDevAVDbUnitOfWork> EmployeeOwnedTasksLookUp { get; set; }

        /// <summary>
        /// The view model for the EmployeeEvaluations detail collection.
        /// </summary>
        public virtual CollectionViewModel<Absence, long, IDevAVDbUnitOfWork> EmployeeEvaluationsLookUp { get; set; }


        /// <summary>
        /// The view model for the EmployeeEvaluations detail collection.
        /// </summary>
        public virtual CollectionViewModel<Shift, long, IDevAVDbUnitOfWork> EmployeeShiftsLookUp { get; set; }
    }
}
