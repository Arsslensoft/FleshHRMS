﻿using System.Collections.Generic;
using PHRMS.Data;

namespace PHRMS.ViewModels
{
    /// <summary>
    ///     Represents the single Absence object view model.
    /// </summary>
    public partial class ShiftsViewModel : SingleObjectViewModel<Shift, long, IPhexonDbUnitOfWork>
    {
        /// <summary>
        ///     Initializes a new instance of the EvaluationViewModel class.
        ///     This constructor is declared protected to avoid undesired instantiation of the EvaluationViewModel type without the
        ///     POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected ShiftsViewModel(IUnitOfWorkFactory<IPhexonDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Shifts, x => x.Subject)
        {
        }

        public ShiftsViewModel()
            : this(DbUnitOfWorkFactory.Instance)
        {
        }

        /// <summary>
        ///     The look-up collection of Employés for the corresponding navigation property in the view.
        /// </summary>
        public IList<Employee> LookUpEmployees
        {
            get { return GetLookUpEntities(x => x.Employees); }
        }
    }
}