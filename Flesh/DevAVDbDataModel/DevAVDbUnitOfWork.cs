﻿using System;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Collections.Generic;
using FHRMS.Common.Utils;
using FHRMS.Common.DataModel;
using FHRMS.Common.DataModel.EntityFramework;
using FHRMS.ViewModels;
using FHRMS.Data;

namespace FHRMS.DevAVDbDataModel {
    /// <summary>
    /// A DevAVDbUnitOfWork instance that represents the run-time implementation of the IDevAVDbUnitOfWork interface.
    /// </summary>
    public class DevAVDbUnitOfWork : DbUnitOfWork<PhexonDb>, IDevAVDbUnitOfWork {

        /// <summary>
        /// Initializes a new instance of the DevAVDbUnitOfWork class.
        /// </summary>
        /// <param name="context">An underlying DbContext.</param>
        public DevAVDbUnitOfWork(PhexonDb context)
            : base(context) {
        }

     
        IRepository<Employee, long> IDevAVDbUnitOfWork.Employees {
            get { return GetRepository(x => x.Set<Employee>(), x => x.Id); }
        }

        IRepository<Leave, long> IDevAVDbUnitOfWork.Tasks {
            get { return GetRepository(x => x.Set<Leave>(), x => x.Id); }
        }


        IRepository<Warning, long> IDevAVDbUnitOfWork.Warnings
        {
            get { return GetRepository(x => x.Set<Warning>(), x => x.Id); }
        }
        IRepository<Absence, long> IDevAVDbUnitOfWork.Evaluations {
            get { return GetRepository(x => x.Set<Absence>(), x => x.Id); }
        }
        IRepository<Attendance, long> IDevAVDbUnitOfWork.Attendances
        {
            get { return GetRepository(x => x.Set<Attendance>(), x => x.Id); }
        }
        IRepository<Picture, long> IDevAVDbUnitOfWork.Pictures {
            get { return GetRepository(x => x.Set<Picture>(), x => x.Id); }
        }

        IRepository<Notification, long> IDevAVDbUnitOfWork.Notifications
        {
            get { return GetRepository(x => x.Set<Notification>(), x => x.Id); }
        }

        IRepository<Shift, long> IDevAVDbUnitOfWork.Shifts
        {
            get { return GetRepository(x => x.Set<Shift>(), x => x.Id); }
        }
        IRepository<Holiday, long> IDevAVDbUnitOfWork.Holidays
        {
            get { return GetRepository(x => x.Set<Holiday>(), x => x.Id); }
        }


    }
}
