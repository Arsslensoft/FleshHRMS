namespace PHRMS.ViewModels {
    using System;
    using PHRMS.ViewModels;
    using PHRMS.Data;
    using System.Linq;

    partial class HolidayViewModel : IBaseViewModel
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
    }
}
