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
    /// Represents the single Leave object view model.
    /// </summary>
    public partial class LeaveViewModel : SingleObjectViewModel<Leave, long, IDevAVDbUnitOfWork> {

        /// <summary>
        /// Initializes a new instance of the LeaveViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the LeaveViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected LeaveViewModel(IUnitOfWorkFactory<IDevAVDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Tasks, x => x.Subject) {
        }
        public LeaveViewModel()
            : this(DbUnitOfWorkFactory.Instance) {
        }


        /// <summary>
        /// The look-up collection of Employés for the corresponding navigation property in the view.
        /// </summary>
        public IList<Employee> LookUpEmployees {
            get { return GetLookUpEntities(x => x.Employees); }
        }
    }
}
