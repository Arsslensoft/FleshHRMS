namespace PHRMS.ViewModels {
    using System;
    using System.Collections.Generic;
    using PHRMS.Data;
    using DevExpress.Mvvm.POCO;
    using PHRMS.Helpers;
    using PHRMS.ViewModels;

    public class EmployeesReportViewModel :
    ReportViewModelBase<EmployeeReportType, Employee, long, IPhexonDbUnitOfWork> {
        private Lazy<LeaveCollectionViewModel> taskCollectionViewModel;
        public EmployeesReportViewModel() {
            taskCollectionViewModel = new Lazy<LeaveCollectionViewModel>(ViewModelSource.Create<LeaveCollectionViewModel>);
        }
        public IList<Leave> Tasks {
            get {
                return taskCollectionViewModel.Value.Entities.ToBindingList();
            }
        }
    }
   
}
