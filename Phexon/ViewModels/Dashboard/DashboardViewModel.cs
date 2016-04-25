using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DevExpress.Mvvm;
using PHRMS.Data;

namespace PHRMS.ViewModels
{
    public class BoardViewModel : ViewModelBase
    {
        public AbsencesCollectionViewModel AbsenceViewModel { get; set; }
        public LeaveCollectionViewModel LeavesViewModel { get; set; }
        public WarningsCollectionViewModel WarningsViewModel { get; set; }
        public AttendancesCollectionViewModel AttendancesViewModel { get; set; }
        public EmployeeCollectionViewModel EmployeesViewModel { get; set; }
        public ShiftsCollectionViewModel ShiftsesViewModel { get; set; }
        public NotificationCollectionViewModel NotificationsViewModel { get; set; }
        public HolidayCollectionViewModel HolidaysViewModel { get; set; }

        #region Statistics

        public IEnumerable<DailyAbsence> DailyAbsences
        {
            get
            {
                var abs = from p in AbsenceViewModel.Entities
                    group p.Id by p.StartDate.Date
                    into g
                    select new {AbsenceDate = g.Key, Absences = g.ToList()};
                var result = new List<DailyAbsence>();

                foreach (var item in abs)
                    result.Add(new DailyAbsence(item.AbsenceDate, item.Absences.Count));


                return result;
            }
        }

        public IEnumerable<PercentageStats<AbsenceType>> AbsencesByType
        {
            get
            {
                var abs = from p in AbsenceViewModel.Entities
                    group p.Id by p.Kind
                    into g
                    select new {AbsenceDate = g.Key, Absences = g.ToList()};
                var result = new List<PercentageStats<AbsenceType>>();

                foreach (var item in abs)
                    result.Add(new PercentageStats<AbsenceType>(item.AbsenceDate,
                        (double) item.Absences.Count/AbsenceViewModel.Entities.Count));


                return result;
            }
        }

        public IEnumerable<PercentageStats<LeaveType>> LeavesByType
        {
            get
            {
                var abs = from p in LeavesViewModel.Entities
                    group p.Id by p.Kind
                    into g
                    select new {LeaveType = g.Key, Leaves = g.ToList()};
                var result = new List<PercentageStats<LeaveType>>();

                foreach (var item in abs)
                    result.Add(new PercentageStats<LeaveType>(item.LeaveType,
                        (double) item.Leaves.Count/LeavesViewModel.Entities.Count));


                return result;
            }
        }

        public IEnumerable<PercentageStats<LeaveStatus>> LeaveByStatus
        {
            get
            {
                var abs = from p in LeavesViewModel.Entities
                    group p.Id by p.Status
                    into g
                    select new {LeaveStatus = g.Key, Leaves = g.ToList()};
                var result = new List<PercentageStats<LeaveStatus>>();

                foreach (var item in abs)
                    result.Add(new PercentageStats<LeaveStatus>(item.LeaveStatus,
                        (double) item.Leaves.Count/LeavesViewModel.Entities.Count));


                return result;
            }
        }

        public IEnumerable<PercentageStats<WarningSeverity>> WarningBySeverity
        {
            get
            {
                var abs = from p in WarningsViewModel.Entities
                    group p.Id by p.Severity
                    into g
                    select new {Warntatus = g.Key, Warning = g.ToList()};
                var result = new List<PercentageStats<WarningSeverity>>();

                foreach (var item in abs)
                    result.Add(new PercentageStats<WarningSeverity>(item.Warntatus,
                        (double) item.Warning.Count/WarningsViewModel.Entities.Count));


                return result;
            }
        }

        public List<Tuple<Shift, List<Attendance>, List<Absence>, List<Leave>>> GetEmployeeWorkTime()
        {
            var tuple = new List<Tuple<Shift, List<Attendance>, List<Absence>, List<Leave>>>();
            foreach (var s in ShiftsesViewModel.Entities)
            {
                var attendances = new List<Attendance>();
                foreach (
                    var a in
                        AttendancesViewModel.Entities.Where(
                            x => x.EmployeeId == s.EmployeeId && x.Date.DayOfWeek == s.Start.DayOfWeek))
                    attendances.Add(a);


                var absences = new List<Absence>();
                foreach (var a in AbsenceViewModel.Entities.Where(x => x.EmployeeId == s.EmployeeId))
                {
                    if ((a.StartDate.Date - a.EndDate.Date).Days == 1 && s.Start.DayOfWeek == a.StartDate.DayOfWeek)
                        // 1 day absence
                        absences.Add(a);
                    else
                    {
                        for (var i = 0; i < (a.EndDate.Date - a.StartDate.Date).Days; i++)
                            if (s.Start.DayOfWeek == a.StartDate.AddDays(i).DayOfWeek)
                                absences.Add(a);
                    }
                }
                var leaves = new List<Leave>();
                foreach (
                    var a in
                        LeavesViewModel.Entities.Where(
                            x =>
                                x.AssignedEmployeeId == s.EmployeeId &&
                                (x.Status == LeaveStatus.Completed || x.Status == LeaveStatus.OnGoing)))
                    leaves.Add(a);

                tuple.Add(new Tuple<Shift, List<Attendance>, List<Absence>, List<Leave>>(s, attendances, absences,
                    leaves));
            }
            return tuple;
        }

        public WorkTime ClassifyAttendance(Attendance a, Shift s)
        {
            if (a.Type == AttendanceType.UnjustifiedExit || a.Type == AttendanceType.EnterOnly) // absence
                return new WorkTime(s.EmployeeId.Value, a.Date.Date, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero,
                    s.TotalWorkingHours, TimeSpan.Zero);

            if (a.Type == AttendanceType.JustifiedExit) // leave
                return new WorkTime(s.EmployeeId.Value, a.Date.Date, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero,
                    TimeSpan.Zero, s.TotalWorkingHours);

            var breaktime = a.TotalBreakTime;
            
            var late = (a.TotalWorkingHours < s.TotalWorkingHours ? s.TotalWorkingHours - a.TotalWorkingHours : TimeSpan.Zero);
            var overtime = (a.TotalWorkingHours > s.TotalWorkingHours ? a.TotalWorkingHours - s.TotalWorkingHours : TimeSpan.Zero);
            // include breaks
            if (s.ShiftKind == ShiftType.Continuous)
            {
                late += (a.TotalBreakTime > s.TotalBreakTime) ? a.TotalBreakTime - s.TotalBreakTime : TimeSpan.Zero;
                overtime += (a.TotalBreakTime < s.TotalBreakTime)?s.TotalBreakTime - a.TotalBreakTime : TimeSpan.Zero;
            }
            return new WorkTime(s.EmployeeId.Value, a.Date.Date, a.TotalWorkingHours - late - overtime, late, overtime,
                TimeSpan.Zero, TimeSpan.Zero);
        }

        public IEnumerable<WorkTime> AllWorkTimes
        {
            get
            {
                var result = new List<WorkTime>();
                var presence = GetEmployeeWorkTime();
                foreach (var tp in presence)
                {
                    foreach (var at in tp.Item2)
                        result.Add(ClassifyAttendance(at, tp.Item1));

                    foreach (var a in tp.Item4)
                    {
                        for (var i = 0; i < (a.DueDate.Value.Date - a.StartDate.Value.Date).Days; i++)
                        {
                            var w = new WorkTime(tp.Item1.EmployeeId.Value, a.StartDate.Value.Date.AddDays(i),
                                TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, tp.Item1.TotalWorkingHours);


                            if (!result.Contains(w))
                                result.Add(w);
                        }
                    }
                    foreach (var a in tp.Item3)
                    {
                        for (var i = 0; i < (a.EndDate.Date - a.StartDate.Date).Days; i++)
                        {
                            var w = new WorkTime(tp.Item1.EmployeeId.Value, a.StartDate.Date.AddDays(i), TimeSpan.Zero,
                                TimeSpan.Zero, TimeSpan.Zero, tp.Item1.TotalWorkingHours, TimeSpan.Zero);
                            if (!result.Contains(w))
                                result.Add(w);
                        }
                    }
                }
                return result;
            }
        }

        public IEnumerable<WorkTime> TotalWorkTime
        {
            get
            {
                var abs = from p in AllWorkTimes
                    group p by p.Date
                    into g
                    select new {Date = g.Key, Work = g.ToList()};

                var result = new List<WorkTime>();

                foreach (var item in abs)
                {
                    var work = new WorkTime(0, item.Date, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero,
                        TimeSpan.Zero);
                    foreach (var w in item.Work)
                    {
                        work.TotalAbsentTime += w.TotalAbsentTime;
                        work.TotalLateTime += w.TotalLateTime;
                        work.TotalOverTime += w.TotalOverTime;
                        work.TotalWorkingTime += w.TotalWorkingTime;
                        work.TotalLeaveTime += w.TotalLeaveTime;
                    }
                    result.Add(work);
                }

                return result;
            }
        }

        public IEnumerable<WorkTime> GetEmployeeWorkTimes(long id)
        {
            var result = new List<WorkTime>();
            var presence = GetEmployeeWorkTime();
            foreach (var tp in presence)
            {
                if (tp.Item1.EmployeeId != id)
                    continue;

                foreach (var at in tp.Item2)
                {
                    var w = ClassifyAttendance(at, tp.Item1);
                    if (!result.Contains(w))
                        result.Add(w);
                }
                foreach (var a in tp.Item4)
                {
                    for (var i = 0; i < (a.DueDate.Value.Date - a.StartDate.Value.Date).Days; i++)
                    {
                        var w = new WorkTime(tp.Item1.EmployeeId.Value, a.StartDate.Value.Date.AddDays(i), TimeSpan.Zero,
                            TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, tp.Item1.TotalWorkingHours);


                        if (!result.Contains(w))
                            result.Add(w);
                    }
                }
                foreach (var a in tp.Item3)
                {
                    for (var i = 0; i < (a.EndDate.Date - a.StartDate.Date).Days; i++)
                    {
                        var w = new WorkTime(tp.Item1.EmployeeId.Value, a.StartDate.Date.AddDays(i), TimeSpan.Zero,
                            TimeSpan.Zero, TimeSpan.Zero, tp.Item1.TotalWorkingHours, TimeSpan.Zero);
                        if (!result.Contains(w))
                            result.Add(w);
                    }
                }
            }
            return result;
        }

        #endregion
    }

    #region Statistics Classes

    [Serializable]
    public class PercentageStats<T>
    {
        public PercentageStats(T d, double c)
        {
            Type = d;
            Percentage = c;
        }

        public T Type { get; set; }
        public double Percentage { get; set; }
    }

    [Serializable]
    public class DailyAbsence
    {
        public DailyAbsence(DateTime d, int c)
        {
            Date = d;
            Count = c;
        }

        public DateTime Date { get; set; }
        public int Count { get; set; }
    }


    public enum WorkTimeType
    {
        [Display(Name = "Obligatoire")] Duty,
        [Display(Name = "Supplèmentaires")] OverTime,
        [Display(Name = "Retards")] Late
    }

    [Serializable] //Set this attribute to all the classes that want to serialize
    public class WorkTime : IEquatable<WorkTime>
    {
        public WorkTime(long eid, DateTime d, TimeSpan working, TimeSpan late, TimeSpan over, TimeSpan absent, TimeSpan leave)
        {
            EmployeeId = eid;
            Date = d;
            TotalWorkingTime = working;
            TotalLateTime = late;
            TotalOverTime = over;
            TotalAbsentTime = absent;
            TotalLeaveTime = leave;
        }

        public long EmployeeId { get; set; }
        public DateTime Date { get; set; }

        public TimeSpan TotalWorkingTime { get; set; }
        public TimeSpan TotalLateTime { get; set; }
        public TimeSpan TotalOverTime { get; set; }
        public TimeSpan TotalAbsentTime { get; set; }
        public TimeSpan TotalLeaveTime { get; set; }

        public bool Equals(WorkTime w)
        {
            return w.Date.Date == Date.Date && w.EmployeeId == EmployeeId;
        }
    }

    #endregion
}