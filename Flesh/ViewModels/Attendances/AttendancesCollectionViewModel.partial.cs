using System.Linq;
using FHRMS.Data;
using FHRMS.DevAVDbDataModel;
using FHRMS.ViewModels;

namespace FHRMS.ViewModels {
    partial class AttendancesCollectionViewModel
    {
        public int AllCount {
            get { return GetAllCount(); }
        }
        public int TodaysCount {
            get { return GetTodaysCount(); }
        }
        public int JustifiedExitCount {
            get { return GetJustifiedExitCount(); }
        }
        public int ExitCount {
            get { return GetExitCount(); }
        }
        public int BothCount
        {
            get { return GetBothCount(); }
        }

        public int EnterCount
        {
            get { return GetEnterCount(); }
        }

        int GetTodaysCount()
        {
            return Entities.Where(e => e.ADate == AttendanceDate.Today).Count();
        }
        int GetJustifiedExitCount()
        {
            return Entities.Where(e => e.Type == AttendanceType.JustifiedExit).Count();
        }
        int GetExitCount()
        {
            return Entities.Where(e => e.Type == AttendanceType.UnjustifiedExit).Count();
        }
        int GetBothCount()
        {
            return Entities.Where(e => e.Type == AttendanceType.Both).Count();
        }
        int GetEnterCount()
        {
            return Entities.Where(e => e.Type == AttendanceType.EnterOnly).Count();
        }

        int GetAllCount() {
            return Entities.Count();
        }
     

    }
}
