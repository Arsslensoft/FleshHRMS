using System;
using System.Collections.Generic;
using DevExpress.Mvvm.POCO;
using PHRMS.Data;
using PHRMS.Helpers;

namespace PHRMS.ViewModels
{
    public class EmployeesReportViewModel :
        ReportViewModelBase<EmployeeReportType, Employee, long, IPhexonDbUnitOfWork>
    {
        private readonly Lazy<LeaveCollectionViewModel> taskCollectionViewModel;

        public EmployeesReportViewModel()
        {
            taskCollectionViewModel =
                new Lazy<LeaveCollectionViewModel>(ViewModelSource.Create<LeaveCollectionViewModel>);
        }

        public IList<Leave> Tasks
        {
            get { return taskCollectionViewModel.Value.Entities.ToBindingList(); }
        }
    }
}