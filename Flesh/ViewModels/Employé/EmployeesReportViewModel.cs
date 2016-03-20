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
    public partial class LeaveCollectionViewModel : CollectionViewModel<Leave, long, IDevAVDbUnitOfWork> {
        public LeaveCollectionViewModel()
            : base(DbUnitOfWorkFactory.Instance, x => x.Tasks) {
        }
    }
}
