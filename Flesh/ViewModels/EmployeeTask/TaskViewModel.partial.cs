namespace DevExpress.DevAV.ViewModels {
    using System;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.DevAV;
    using System.Linq;
    using DevExpress.DevAV.DevAVDbDataModel;

    partial class EmployeeTaskViewModel : IBaseViewModel {
        public new bool IsNew() { return base.IsNew(); }
        public IQueryable<Employee> GetEmployees() {
            return UnitOfWork.Employees.GetEntities();
        }
        public EmployeeTask CreateTask() {
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
            if(Entity.Owner != null) return Entity.Owner.FullName;
            return string.Empty;
        }
    }
}
