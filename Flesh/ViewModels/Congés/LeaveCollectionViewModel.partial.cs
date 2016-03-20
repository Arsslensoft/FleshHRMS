using System.Linq;
using FHRMS.Data;
using FHRMS.DevAVDbDataModel;
using FHRMS.ViewModels;

namespace FHRMS.ViewModels {
    partial class LeaveCollectionViewModel {
        public int AllCount {
            get { return GetAllCount(); }
        }
        public int OnGoingCount {
            get { return GetOnGoingCount(); }
        }
        public int PendingCount {
            get { return GetPendingCount(); }
        }
        public int RefusedCount {
            get { return GetRefusedCount(); }
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
            return Entities.Where(e => e.Priority == LeavePriority.High).Count();
        }
        int GetUrgentCount() {
            return Entities.Where(e => e.Priority == LeavePriority.Urgent).Count();
        }
     
        int GetCompletedCount() {
            return Entities.Where(e => e.Status == LeaveStatus.Completed).Count();
        }
        int GetPendingCount() {
            return Entities.Where(e => e.Status == LeaveStatus.Pending).Count();
        }
        int GetRefusedCount() {
            return Entities.Where(e => e.Status == LeaveStatus.Refused).Count();
        }
        int GetAllCount() {
            return Entities.Count();
        }
        int GetOnGoingCount() {
            return Entities.Where(e => e.Status == LeaveStatus.OnGoing).Count();
        }

    }
}
