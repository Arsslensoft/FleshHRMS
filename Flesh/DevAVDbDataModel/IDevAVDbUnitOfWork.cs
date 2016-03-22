using System;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Collections.Generic;
using FHRMS.Common.Utils;
using FHRMS.Common.DataModel;
using FHRMS.Common.DataModel.EntityFramework;
using FHRMS.Data;

namespace FHRMS.DevAVDbDataModel {
    /// <summary>
    /// IDevAVDbUnitOfWork extends the IUnitOfWork interface with repositories representing specific entities.
    /// </summary>
    public interface IDevAVDbUnitOfWork : IUnitOfWork {

    

        /// <summary>
        /// The Employee entities repository.
        /// </summary>
        IRepository<Employee, long> Employees { get; }

        /// <summary>
        /// The Leave entities repository.
        /// </summary>
        IRepository<Leave, long> Tasks { get; }

        /// <summary>
        /// The Absence entities repository.
        /// </summary>
        IRepository<Absence, long> Evaluations { get; }


        /// <summary>
        /// The Attendance entities repository.
        /// </summary>
        IRepository<Attendance, long> Attendances { get; }

        /// <summary>
        /// The Warning entities repository.
        /// </summary>
        IRepository<Warning, long> Warnings { get; }

        /// <summary>
        /// The Picture entities repository.
        /// </summary>
        IRepository<Picture, long> Pictures { get; }

      

     

        /// <summary>
        /// The State entities repository.
        /// </summary>
        IRepository<State, StateEnum> States { get; }

        /// <summary>
        /// The Holiday entities repository.
        /// </summary>
        IRepository<Holiday, long> Holidays { get; }

        /// <summary>
        /// The Shift entities repository.
        /// </summary>
        IRepository<Shift, long> Shifts { get; }
    }
}
