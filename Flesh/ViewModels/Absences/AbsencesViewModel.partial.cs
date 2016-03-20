namespace FHRMS.ViewModels {
    using System;
    using FHRMS.ViewModels;
    using FHRMS.Data;
    using System.Linq;
    using FHRMS.DevAVDbDataModel;

    partial class AbsencesViewModel : IBaseViewModel
    {
        public new bool IsNew() { return base.IsNew(); }
        public IQueryable<Employee> GetEmployees() {
            return UnitOfWork.Employees.GetEntities();
        }
        public Absence CreateAbsence()
        {
           return CreateEntity();
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
        protected override string GetTitle() {
            if (Entity.Employee != null) return Entity.Employee.FullName;
            return string.Empty;
        }
    }
}
