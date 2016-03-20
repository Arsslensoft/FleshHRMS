using System.ComponentModel.DataAnnotations;

namespace FHRMS.ViewModels {
    public enum EmployeeReportType {
        None,
        [Display(Name = "Profile Report")]
        Profile,
        [Display(Name = "Summary Report")]
        Summary,
        [Display(Name = "Employés Directory Report")]
        Directory,
        [Display(Name = "Task List Report")]
        TaskList
    }
}
