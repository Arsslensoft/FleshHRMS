namespace DevExpress.DevAV.ViewModels {
    using System;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.DevAV;
    using DevExpress.DevAV.DevAVDbDataModel;
    using System.Linq;
    using DevExpress.Mvvm;

    partial class ProductViewModel : IBaseViewModel {
        public new bool IsNew() { return base.IsNew(); }
        public IQueryable<Employee> GetEmployees() {
            return UnitOfWork.Employees.GetEntities();
        }
        public override void Delete() {
            MessageBoxService.ShowMessage("To ensure data integrity, the Products module doesn't allow records to be deleted. Record deletion is supported by the Employees module.", "Delete Product", MessageButton.OK);
        }
    }
}
