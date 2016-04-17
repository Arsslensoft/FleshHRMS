using System.Linq;
using PHRMS.Data;

namespace PHRMS.ViewModels
{
    partial class LeaveCollectionViewModel
    {
        public int AllCount
        {
            get { return GetAllCount(); }
        }

        public int OnGoingCount
        {
            get { return GetOnGoingCount(); }
        }

        public int PendingCount
        {
            get { return GetPendingCount(); }
        }

        public int RefusedCount
        {
            get { return GetRefusedCount(); }
        }

        public int CompletedCount
        {
            get { return GetCompletedCount(); }
        }

        public int UrgentCount
        {
            get { return GetUrgentCount(); }
        }

        public int HighPriorityCount
        {
            get { return GetHighPriorityCount(); }
        }

        private int GetHighPriorityCount()
        {
            return Entities.Where(e => e.Priority == LeavePriority.High).Count();
        }

        private int GetUrgentCount()
        {
            return Entities.Where(e => e.Priority == LeavePriority.Urgent).Count();
        }

        private int GetCompletedCount()
        {
            return Entities.Where(e => e.Status == LeaveStatus.Completed).Count();
        }

        private int GetPendingCount()
        {
            return Entities.Where(e => e.Status == LeaveStatus.Pending).Count();
        }

        private int GetRefusedCount()
        {
            return Entities.Where(e => e.Status == LeaveStatus.Refused).Count();
        }

        private int GetAllCount()
        {
            return Entities.Count();
        }

        private int GetOnGoingCount()
        {
            return Entities.Where(e => e.Status == LeaveStatus.OnGoing).Count();
        }
    }
}