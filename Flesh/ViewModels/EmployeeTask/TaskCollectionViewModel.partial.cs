using System.Linq;
using DevExpress.DevAV;
using DevExpress.DevAV.DevAVDbDataModel;
using DevExpress.DevAV.ViewModels;

namespace DevExpress.DevAV.ViewModels {
    partial class EmployeeTaskCollectionViewModel {
        public int AllCount {
            get { return GetAllCount(); }
        }
        public int InProgressCount {
            get { return GetInProgressCount(); }
        }
        public int NotStartedCount {
            get { return GetNotStartedCount(); }
        }
        public int DeferredCount {
            get { return GetDeferredCount(); }
        }
        public int CompletedCount {
            get { return GetCompletedCount(); }
        }
        public int UrgentCount {
            get { return GetUrgentCount(); }
        }
        public int HighPriorityCount {
            get { return GetHighPriorityCount(); }
        }
        int GetHighPriorityCount() {
            return Entities.Where(e => e.Priority == EmployeeTaskPriority.High).Count();
        }
        int GetUrgentCount() {
            return Entities.Where(e => e.Priority == EmployeeTaskPriority.Urgent).Count();
        }
        int GetCompletedCount() {
            return Entities.Where(e => e.Status == EmployeeTaskStatus.Completed).Count();
        }
        int GetDeferredCount() {
            return Entities.Where(e => e.Status == EmployeeTaskStatus.Deferred).Count();
        }
        int GetNotStartedCount() {
            return Entities.Where(e => e.Status == EmployeeTaskStatus.NotStarted).Count();
        }
        int GetAllCount() {
            return Entities.Count();
        }
        int GetInProgressCount() {
            return Entities.Where(e => e.Status == EmployeeTaskStatus.InProgress).Count();
        }
    }
}
