namespace FHRMS.ViewModel {
    using System;
    using System.Collections.Generic;
    using FHRMS.Data;
    using FHRMS.DevAVDbDataModel;
    using FHRMS.ViewModels;
    using DevExpress.Mvvm.POCO;
    using FHRMS.Helpers;
    using FHRMS.Common.ViewModel;

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
