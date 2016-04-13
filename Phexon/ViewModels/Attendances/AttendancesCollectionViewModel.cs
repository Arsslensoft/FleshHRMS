﻿using System;
using System.Linq;
using DevExpress.Mvvm.POCO;
using PHRMS.Utils;
using PHRMS.Data;
using PHRMS.ViewModels;

namespace PHRMS.ViewModels {
    /// <summary>
    /// Represents the Congés collection view model.
    /// </summary>
    public partial class AttendancesCollectionViewModel : CollectionViewModel<Attendance, long, IPhexonDbUnitOfWork> {

        /// <summary>
        /// Initializes a new instance of the LeaveCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the LeaveCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected AttendancesCollectionViewModel(IUnitOfWorkFactory<IPhexonDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Attendances) {
        }
        public AttendancesCollectionViewModel()
            : this(DbUnitOfWorkFactory.Instance) {
        }
    }
}