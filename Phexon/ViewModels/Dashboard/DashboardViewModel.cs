namespace PHRMS.ViewModels {
    using System;
    using PHRMS.Services;
    using DevExpress.Mvvm;
    using System.Collections.Generic;
    using System.Linq;
using PHRMS.Data;
using System.Runtime.Serialization;
    
    public class BoardViewModel : DevExpress.Mvvm.ViewModelBase {

       
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
                          group p.Id by p.StartDate.Date into g
                          select new { AbsenceDate = g.Key, Absences = g.ToList() };
                List<DailyAbsence> result = new List<DailyAbsence>();

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
                          group p.Id by p.Kind into g
                          select new { AbsenceDate = g.Key, Absences = g.ToList() };
                List<PercentageStats<AbsenceType>> result = new List<PercentageStats<AbsenceType>>();

                foreach (var item in abs)
                    result.Add(new PercentageStats<AbsenceType>(item.AbsenceDate, (double)item.Absences.Count / AbsenceViewModel.Entities.Count));


                return result;
            }
        }
   
        public IEnumerable<PercentageStats<LeaveType>> LeavesByType
        {
            get
            {
                var abs = from p in LeavesViewModel.Entities
                          group p.Id by p.Kind into g
                          select new { LeaveType = g.Key, Leaves = g.ToList() };
                List<PercentageStats<LeaveType>> result = new List<PercentageStats<LeaveType>>();

                foreach (var item in abs)
                    result.Add(new PercentageStats<LeaveType>(item.LeaveType, (double)item.Leaves.Count / LeavesViewModel.Entities.Count));


                return result;
            }
        }
        public IEnumerable<PercentageStats<LeaveStatus>> LeaveByStatus
        {
            get
            {
                var abs = from p in LeavesViewModel.Entities
                          group p.Id by p.Status into g
                          select new { LeaveStatus = g.Key, Leaves = g.ToList() };
                List<PercentageStats<LeaveStatus>> result = new List<PercentageStats<LeaveStatus>>();

                foreach (var item in abs)
                    result.Add(new PercentageStats<LeaveStatus>(item.LeaveStatus, (double)item.Leaves.Count / LeavesViewModel.Entities.Count));


                return result;
            }
        }

        public IEnumerable<PercentageStats<WarningSeverity>> WarningBySeverity
        {
            get
            {
                var abs = from p in WarningsViewModel.Entities
                          group p.Id by p.Severity into g
                          select new { Warntatus = g.Key, Warning = g.ToList() };
                List<PercentageStats<WarningSeverity>> result = new List<PercentageStats<WarningSeverity>>();

                foreach (var item in abs)
                    result.Add(new PercentageStats<WarningSeverity>(item.Warntatus, (double)item.Warning.Count / WarningsViewModel.Entities.Count));


                return result;
            }
        }

        public List<Tuple<Shift, List<Attendance>, List<Absence>, List<Leave>>> GetEmployeeWorkTime()
        {
            List<Tuple<Shift, List<Attendance>, List<Absence>, List<Leave>>> tuple = new List<Tuple<Shift, List<Attendance>, List<Absence>, List<Leave>>>();
            foreach (Shift s in ShiftsesViewModel.Entities)
            {
                List<Attendance> attendances = new List<Attendance>();
                foreach (Attendance a in AttendancesViewModel.Entities.Where(x => x.EmployeeId == s.EmployeeId && x.Date.DayOfWeek == s.Start.DayOfWeek))
                    attendances.Add(a);

                
                List<Absence> absences = new List<Absence>();
                foreach (Absence a in AbsenceViewModel.Entities.Where(x => x.EmployeeId == s.EmployeeId))
                {
                    if ((a.StartDate.Date - a.EndDate.Date).Days == 1 && s.Start.DayOfWeek == a.StartDate.DayOfWeek) // 1 day absence
                        absences.Add(a);
                    else
                    {
                         for (int i = 0; i < (a.EndDate.Date - a.StartDate.Date).Days; i++)
                             if (s.Start.DayOfWeek == a.StartDate.AddDays(i).DayOfWeek)
                                 absences.Add(a);
                    }
                }
                List<Leave> leaves = new List<Leave>();
                foreach (Leave a in LeavesViewModel.Entities.Where(x => x.AssignedEmployeeId == s.EmployeeId && (x.Status == LeaveStatus.Completed || x.Status == LeaveStatus.OnGoing)))
                    leaves.Add(a);

                tuple.Add(new Tuple<Shift, List<Attendance>, List<Absence>, List<Leave>>(s, attendances, absences,leaves));
            }
            return tuple;

        }

        public WorkTime ClassifyAttendance(Attendance a, Shift s)
        {
            if (a.Type == AttendanceType.UnjustifiedExit || a.Type == AttendanceType.EnterOnly)// absence
                return new WorkTime(s.EmployeeId.Value, a.Date.Date, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, s.TotalWorkingHours,TimeSpan.Zero); 
            else if(a.Type == AttendanceType.JustifiedExit) // leave
                return new WorkTime(s.EmployeeId.Value, a.Date.Date, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero,  TimeSpan.Zero,s.TotalWorkingHours); 
            else {
                      TimeSpan late = ((a.TimeIn > s.Start.TimeOfDay)?(a.TimeIn -s.Start.TimeOfDay):TimeSpan.Zero) + ((a.TimeOut <s.End.TimeOfDay)?(s.End.TimeOfDay - a.TimeOut ):TimeSpan.Zero);
                      TimeSpan overtime =( (a.TimeIn <s.Start.TimeOfDay)?(s.Start.TimeOfDay - a.TimeIn ):TimeSpan.Zero) + ((a.TimeOut >s.End.TimeOfDay)?(a.TimeOut - s.End.TimeOfDay):TimeSpan.Zero) ;
                return new WorkTime(s.EmployeeId.Value, a.Date.Date, a.TotalWorkingHours-late-overtime, late, overtime, TimeSpan.Zero, TimeSpan.Zero);
                 }

        }
        public IEnumerable<WorkTime> AllWorkTimes
        {
            get
            {
                List<WorkTime> result = new List<WorkTime>();
                List<Tuple<Shift, List<Attendance>, List<Absence>, List<Leave>>> presence = GetEmployeeWorkTime();
                foreach (var tp in presence)
                {

                    foreach (Attendance at in tp.Item2)                  
                         result.Add(ClassifyAttendance(at,tp.Item1));

                    foreach (Leave a in tp.Item4)
                    {
                        for (int i = 0; i < (a.DueDate.Value.Date - a.StartDate.Value.Date).Days; i++){
                             WorkTime w = new WorkTime(tp.Item1.EmployeeId.Value, a.StartDate.Value.Date.AddDays(i), TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, tp.Item1.TotalWorkingHours);
                      
                        
                         if(!result.Contains(w))
                                result.Add(w);
                        }

                    }
                    foreach (Absence a in tp.Item3)
                    {

                        for (int i = 0; i < (a.EndDate.Date - a.StartDate.Date).Days; i++)
                        {
                            WorkTime w = new WorkTime(tp.Item1.EmployeeId.Value, a.StartDate.Date.AddDays(i), TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, tp.Item1.TotalWorkingHours, TimeSpan.Zero);
                            if(!result.Contains(w))
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
                          group p by p.Date into g
                          select new { Date = g.Key, Work=g.ToList()};

                List<WorkTime> result = new List<WorkTime>();

                foreach (var item in abs){
                    WorkTime work = new WorkTime(0, item.Date, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero);
                    foreach (WorkTime w in item.Work)
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
        
                List<WorkTime> result = new List<WorkTime>();
                List<Tuple<Shift, List<Attendance>, List<Absence>, List<Leave>>> presence = GetEmployeeWorkTime();
                foreach (var tp in presence)
                {
                    if(tp.Item1.EmployeeId != id)
                        continue;

                    foreach (Attendance at in tp.Item2)
                    {
                        WorkTime w = ClassifyAttendance(at, tp.Item1);
                        if (!result.Contains(w))
                            result.Add(w);
                    }
                    foreach (Leave a in tp.Item4)
                    {
                        for (int i = 0; i < (a.DueDate.Value.Date - a.StartDate.Value.Date).Days; i++)
                        {
                            WorkTime w = new WorkTime(tp.Item1.EmployeeId.Value, a.StartDate.Value.Date.AddDays(i), TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, tp.Item1.TotalWorkingHours);


                            if (!result.Contains(w))
                                result.Add(w);
                        }

                    }
                    foreach (Absence a in tp.Item3)
                    {

                        for (int i = 0; i < (a.EndDate.Date - a.StartDate.Date).Days; i++)
                        {
                            WorkTime w = new WorkTime(tp.Item1.EmployeeId.Value, a.StartDate.Date.AddDays(i), TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, tp.Item1.TotalWorkingHours, TimeSpan.Zero);
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
        public PercentageStats(T d, double c )
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
        [System.ComponentModel.DataAnnotations.Display(Name = "Obligatoire")]
        Duty,
        [System.ComponentModel.DataAnnotations.Display(Name = "Supplèmentaires")]
        OverTime,
        [System.ComponentModel.DataAnnotations.Display(Name = "Retards")]
        Late
    }
        [Serializable()]    //Set this attribute to all the classes that want to serialize
    public class WorkTime : IEquatable<WorkTime>
    {

        public long EmployeeId { get; set; }
        public WorkTime(long eid,DateTime d, TimeSpan a,TimeSpan b,TimeSpan c,TimeSpan e, TimeSpan f)
        {
            EmployeeId = eid;
            Date = d;
            TotalWorkingTime = a;
            TotalLateTime = b;
            TotalOverTime = c;
            TotalAbsentTime = e;
            TotalLeaveTime = f;
        }
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
