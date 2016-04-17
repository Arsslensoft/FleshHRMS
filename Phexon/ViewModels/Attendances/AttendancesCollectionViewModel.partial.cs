using System.Linq;
using PHRMS.Data;

namespace PHRMS.ViewModels
{
    partial class AttendancesCollectionViewModel
    {
        public int AllCount
        {
            get { return GetAllCount(); }
        }

        public int TodaysCount
        {
            get { return GetTodaysCount(); }
        }

        public int JustifiedExitCount
        {
            get { return GetJustifiedExitCount(); }
        }

        public int ExitCount
        {
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

        private int GetTodaysCount()
        {
            return Entities.Where(e => e.ADate == AttendanceDate.Today).Count();
        }

        private int GetJustifiedExitCount()
        {
            return Entities.Where(e => e.Type == AttendanceType.JustifiedExit).Count();
        }

        private int GetExitCount()
        {
            return Entities.Where(e => e.Type == AttendanceType.UnjustifiedExit).Count();
        }

        private int GetBothCount()
        {
            return Entities.Where(e => e.Type == AttendanceType.Both).Count();
        }

        private int GetEnterCount()
        {
            return Entities.Where(e => e.Type == AttendanceType.EnterOnly).Count();
        }

        private int GetAllCount()
        {
            return Entities.Count();
        }
    }
}