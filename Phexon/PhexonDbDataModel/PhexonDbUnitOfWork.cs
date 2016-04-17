namespace PHRMS.Data
{
    /// <summary>
    ///     A PhexonDbUnitOfWork instance that represents the run-time implementation of the IPhexonDbUnitOfWork interface.
    /// </summary>
    public class PhexonDbUnitOfWork : DbUnitOfWork<PhexonDb>, IPhexonDbUnitOfWork
    {
        /// <summary>
        ///     Initializes a new instance of the PhexonDbUnitOfWork class.
        /// </summary>
        /// <param name="context">An underlying DbContext.</param>
        public PhexonDbUnitOfWork(PhexonDb context)
            : base(context)
        {
        }


        IRepository<Employee, long> IPhexonDbUnitOfWork.Employees
        {
            get { return GetRepository(x => x.Set<Employee>(), x => x.Id); }
        }

        IRepository<Leave, long> IPhexonDbUnitOfWork.Tasks
        {
            get { return GetRepository(x => x.Set<Leave>(), x => x.Id); }
        }


        IRepository<Warning, long> IPhexonDbUnitOfWork.Warnings
        {
            get { return GetRepository(x => x.Set<Warning>(), x => x.Id); }
        }

        IRepository<Absence, long> IPhexonDbUnitOfWork.Evaluations
        {
            get { return GetRepository(x => x.Set<Absence>(), x => x.Id); }
        }

        IRepository<Attendance, long> IPhexonDbUnitOfWork.Attendances
        {
            get { return GetRepository(x => x.Set<Attendance>(), x => x.Id); }
        }

        IRepository<Picture, long> IPhexonDbUnitOfWork.Pictures
        {
            get { return GetRepository(x => x.Set<Picture>(), x => x.Id); }
        }

        IRepository<Notification, long> IPhexonDbUnitOfWork.Notifications
        {
            get { return GetRepository(x => x.Set<Notification>(), x => x.Id); }
        }

        IRepository<Shift, long> IPhexonDbUnitOfWork.Shifts
        {
            get { return GetRepository(x => x.Set<Shift>(), x => x.Id); }
        }

        IRepository<Holiday, long> IPhexonDbUnitOfWork.Holidays
        {
            get { return GetRepository(x => x.Set<Holiday>(), x => x.Id); }
        }
    }
}