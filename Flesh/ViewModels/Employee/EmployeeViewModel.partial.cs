namespace DevExpress.DevAV.ViewModels {
    using System;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.DevAV;
    using System.Linq;
    using DevExpress.DevAV.DevAVDbDataModel;

    partial class EmployeeViewModel : IBaseViewModel {
        protected override string GetTitle() {
            return Entity.FullName;
        }
        public IQueryable<Employee> GetEmployyes() {
            return  UnitOfWork.Employees.GetEntities();
        }
        public event EventHandler EntityChanged;
        protected override void OnEntityChanged() {
            base.OnEntityChanged();
            EventHandler handler = EntityChanged;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
