namespace FHRMS.ViewModels {
    using System;
    using FHRMS.ViewModels;
    using FHRMS.Data;
    using System.Linq;
    using FHRMS.DevAVDbDataModel;

    partial class ScheduleViewModel : IBaseViewModel
    {
        public new bool IsNew() { return base.IsNew(); }
        public IQueryable<Employee> GetEmployees() {
            return UnitOfWork.Employees.GetEntities();
        }
        public event EventHandler EntityChanged;
        protected override void OnEntityChanged() {
            base.OnEntityChanged();
            EventHandler handler = EntityChanged;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }
        internal Employee FindEmployeeId(Employee employee) {
            if(employee == null) return null;
            return UnitOfWork.Employees.Find(employee.Id);
        }
        internal Schedule FindScheduleId(Schedule employee)
        {
            if (employee == null) return null;
            return UnitOfWork.Schedules.Find(employee.Id);
        }
    }
}
