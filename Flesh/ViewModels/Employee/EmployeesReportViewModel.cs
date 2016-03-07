namespace DevExpress.DevAV.ViewModel {
    using System;
    using System.Collections.Generic;
    using DevExpress.DevAV;
    using DevExpress.DevAV.DevAVDbDataModel;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.Mvvm.POCO;
    using DevExpress.DevAV.Helpers;
    using DevExpress.DevAV.Common.ViewModel;

    public class EmployeesReportViewModel :
    ReportViewModelBase<EmployeeReportType, Employee, long, IDevAVDbUnitOfWork> {
        private Lazy<EmployeeTaskCollectionViewModel> taskCollectionViewModel;
        public EmployeesReportViewModel() {
            taskCollectionViewModel = new Lazy<EmployeeTaskCollectionViewModel>(ViewModelSource.Create<EmployeeTaskCollectionViewModel>);
        }
        public IList<EmployeeTask> Tasks {
            get {
                return taskCollectionViewModel.Value.Entities.ToBindingList();
            }
        }
    }
    public partial class EmployeeTaskCollectionViewModel : CollectionViewModel<EmployeeTask, long, IDevAVDbUnitOfWork> {
        public EmployeeTaskCollectionViewModel()
            : base(DbUnitOfWorkFactory.Instance, x => x.Tasks) {
        }
    }
}
