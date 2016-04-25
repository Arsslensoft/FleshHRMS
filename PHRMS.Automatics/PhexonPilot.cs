using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PHRMS.Data;
using System.Timers;
namespace PHRMS.Automatics
{
    public class PhexonPilot
    {
        public static DateTime IndeterminateDate = DateTime.Parse("1/1/2015 00:00:00");



        private System.Timers.Timer serverTimer;
        public PHRMS.Data.PhexonDb DatabaseManager { get; set; }
        public TimeSpan NightCheckTime { get; set; }
        public TimeSpan DailyCheckTime { get; set; }
        public TimeSpan ResetTime { get; set; }
        public bool IsRuning
        {
            get
            {
                return serverTimer.Enabled;
            }
        }

        public PhexonPilot(TimeSpan daily, TimeSpan night,TimeSpan reset)
        { 
            DatabaseManager = new Data.PhexonDb();
            DailyCheckTime = daily;
            NightCheckTime = night;
            ResetTime = reset;
        }
        public bool Between(DateTime x, DateTime start, DateTime end)
        {
            if (end == IndeterminateDate || (x.Date >= start.Date && x.Date <= end.Date)) // indeterminate date or between 2 dates
                return true;
            return false;
        }
        public void Load()
        {
            DatabaseManager.Employees.Load();
            DatabaseManager.Shifts.Load();
            DatabaseManager.Attendances.Load();
            DatabaseManager.Holidays.Load();
            DatabaseManager.Absences.Load();
            DatabaseManager.Leaves.Load();
            DatabaseManager.Warnings.Load();
        }

        /// <summary>
        /// Marks an employee as absent
        /// </summary>
        /// <param name="emp">Employee</param>
        public void MarkAsAbsent(Employee emp)
        {
            Absence abs = new Absence();
            abs.EmployeeId = emp.Id;
            abs.Employee = emp;
            abs.Comment = "Autodetected";
            abs.CreatedById = 5;
            abs.StartDate = DateTime.Now.Date;
            abs.WarrantId = 0;

  
            abs.Kind = AbsenceType.Unwarranted;
            abs.EndDate = IndeterminateDate.Date;
            DatabaseManager.Absences.Add(abs);
            DatabaseManager.SaveChanges();

        }


        /// <summary>
        /// Marks an employee as late
        /// </summary>
        /// <param name="emp">Employee</param>
        public void MarkAsLate(Employee emp, DateTime entry_date)
        {
            Absence abs = new Absence();
            abs.EmployeeId = emp.Id;
            abs.Employee = emp;
            abs.Comment = "Autodetected";
            abs.CreatedById = 5;
            abs.StartDate = DateTime.Now.Date;
            abs.WarrantId = 0;
            abs.Kind = AbsenceType.Late;
            abs.EndDate = entry_date;
            if (abs.Employee.LateCredit >= 1)
                abs.Employee.LateCredit--;
            else WarnLateCreditLimitExceeded(abs.Employee);
            
           
            DatabaseManager.Absences.Add(abs);
            DatabaseManager.SaveChanges();

        }

        /// <summary>
        /// Close Absences
        /// </summary>
        /// <param name="emp"></param>
        public void CloseAbsences(Employee emp)
        {
            List<Absence> abs = DatabaseManager.Absences.Local.ToList();
            for (int i = 0; i < abs.Count; i++)
            {
                if (abs[i].EndDate == IndeterminateDate && emp.Id == abs[i].EmployeeId)
                {
                    abs[i].EndDate = DateTime.Now;
                    // substracts from credit
                    int days = (int)abs[i].TotalTime.TotalDays;
                    if (days > emp.LeaveCredit)
                    {
                        emp.LeaveCredit = 0;
                        // Warn
                        WarnLeaveCreditLimitExceeded(emp);
                    }
                    else emp.LeaveCredit -= days;
                }
            }

            DatabaseManager.SaveChanges();

        }

        /// <summary>
        /// Warning of leaves
        /// </summary>
        /// <param name="emp"></param>
        public void WarnLeaveCreditLimitExceeded(Employee emp)
        {
            Warning w = new Warning();
            w.CreatedById = 5;
            w.Date = DateTime.Now;
            w.EmployeeId = emp.Id;
            w.Employee = emp;
            w.Reason = "Vous avez dépassé les limites autorisés de d'absences";
            w.Severity = WarningSeverity.Inconvenient;
            w.Type = WarningType.Verbal;
            DatabaseManager.Warnings.Add(w);
            DatabaseManager.SaveChanges();
        }

        public void WarnLateCreditLimitExceeded(Employee emp)
        {
            Warning w = new Warning();
            w.CreatedById = 5;
            w.Date = DateTime.Now;
            w.EmployeeId = emp.Id;
            w.Employee = emp;
            w.Reason = "Vous avez dépassé les limites autorisés de de retards";
            w.Severity = WarningSeverity.Inconvenient;
            w.Type = WarningType.Verbal;
            DatabaseManager.Warnings.Add(w);
            DatabaseManager.SaveChanges();
        }

        /// <summary>
        /// Weekly Routine 
        /// </summary>
        public void DailyRoutine()
        {
            try
            {
                Load();
                // TODO:sync
                // Updates all shifts weekly (add 7 days)
                List<Shift> shifts = DatabaseManager.Shifts.Local.ToList();
                for (int i = 0; i < shifts.Count; i++)
                {
                    Shift sh = shifts[i];
                    switch (sh.Recurrence)
                    {
                        case ReccuranceType.Daily:
                            sh.Start = sh.Start.AddDays(1);
                            sh.End = sh.End.AddDays(1);
                            break;
                        case ReccuranceType.DailyExceptWeekend:
                            if (DateTime.Now.DayOfWeek != DayOfWeek.Saturday && DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
                            {
                                sh.Start = sh.Start.AddDays(1);
                                sh.End = sh.End.AddDays(1);
                            }
                            else if (DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
                            {
                                sh.Start = sh.Start.AddDays(2);
                                sh.End = sh.End.AddDays(2);
                            }
                            break;
                        case ReccuranceType.Weekly:
                        case ReccuranceType.Weekend:
                            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                            {
                                sh.Start = sh.Start.AddDays(7);
                                sh.End = sh.End.AddDays(7);
                            }
                            break;
                    }

                }
                DatabaseManager.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Instance.Log.Error("Daily routine failed",ex);
            }
        }
        public Shift GetAppropriateShift(List<Shift> shifts)
        {
            DateTime now = DateTime.Now;

            foreach (Shift s in shifts){
                if (s.Start.Date <= now && s.End >= now) // in work shift
                    return s;
                else if (s.Start.Date == now.Date && (s.End <= now || s.Start >= now) )// after-shift / before-shift
                    return s;
        }
            return null;
        }
        public void NightRoutineCheck()
        {
            try{
            Load();
            List<Attendance> attendances = DatabaseManager.Attendances.Local.Where(x => x.ADate == AttendanceDate.Today).ToList();
            List<Leave> active_leaves = DatabaseManager.Leaves.Local.Where(x => Between(DateTime.Now.Date, x.StartDate.Value, x.DueDate.Value)).ToList(); // look for attendances
            List<Absence> open_absences = DatabaseManager.Absences.Local.Where(x => x.EndDate == IndeterminateDate).ToList(); // look for open absences 
            List<Employee> employees = DatabaseManager.Employees.Local.ToList();
            List<Holiday> holidays = DatabaseManager.Holidays.Local.Where(x => Between(DateTime.Now.Date, x.StartDate, x.DueDate)).ToList();

            var unattended_employees = (from emp in DatabaseManager.Employees
                                        where !attendances.Any(m => m.EmployeeId == emp.Id)
                           select emp);

                // detect late employees
            foreach (Attendance a in attendances)
            {
                List<Shift> todays_shift = a.Employee.Shifts.Where(x => x.Start.Date == DateTime.Now.Date).ToList();
                Shift sh = GetAppropriateShift(todays_shift);
                if (sh == null) // TODO:replace with assert sh == null : "Shift was not found for current employee";
                    throw new Exception("Shift was not found for current employee");

                if (a.TimeIn > sh.Start.TimeOfDay) // late
                {
                    if ((a.TimeIn - sh.Start.TimeOfDay) > new TimeSpan(2, 0, 0))
                        MarkAsAbsent(a.Employee); // absent after 2 hours
                    else
                        MarkAsLate(a.Employee, DateTime.Parse(a.Date.ToShortDateString() + " " + a.TimeIn.ToString("mm:hh:ss"))); // late
                }


            }

            if (holidays.Count == 0) // no holidays
            {
                // mark all unattended working employees as absent
                foreach (Employee emp in unattended_employees)
                {
                    List<Shift> todays_shift = emp.Shifts.Where(x => x.Start.Date == DateTime.Now.Date).ToList();
                    if (todays_shift.Count == 0 || emp.Status == EmployeeStatus.OnLeave)
                        continue;


                    MarkAsAbsent(emp);
                }

                // Attended employees
                foreach (Attendance at in attendances)
                {
                    if (at.Type == AttendanceType.UnjustifiedExit || at.Type == AttendanceType.EnterOnly) // unjustified exit absence
                        MarkAsAbsent(at.Employee);
                    else if (at.Type == AttendanceType.JustifiedExit)
                    {
                        if (at.Employee.LeaveCredit >= 1)
                            at.Employee.LeaveCredit--;
                        else WarnLeaveCreditLimitExceeded(at.Employee);

                    }
                    else
                    {
                        List<Shift> todays_shift = at.Employee.Shifts.Where(x => x.Start.Date == DateTime.Now.Date).ToList();

                        Shift sh = GetAppropriateShift(todays_shift);
                        if (at.TimeOut < sh.End.TimeOfDay) // too early
                        {
                            if ((sh.End.TimeOfDay - at.TimeOut) > new TimeSpan(2, 0, 0))
                                MarkAsAbsent(at.Employee); // absent before 2 hours

                        }
                    }

                }


            }
            else
            {
                // mark all unattended permanence employees as absent
                foreach (Employee emp in unattended_employees)
                {
                    List<Shift> todays_shift = emp.Shifts.Where(x => x.Start.Date == DateTime.Now.Date).ToList();
                    if (todays_shift.Count == 0 || emp.Status == EmployeeStatus.OnLeave)
                        continue;


                    MarkAsAbsent(emp);
                }
            }


            DatabaseManager.SaveChanges();

        }
        catch (Exception ex)
        {
            Logger.Instance.Log.Error("Nightly routine failed", ex);
        }

        }

   
       
        private void SetTimer()
        {
            // Create a timer with a 1 sec interval.
            serverTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            serverTimer.Elapsed += OnTimedEvent;
            serverTimer.AutoReset = true;
            serverTimer.Enabled = true;
        }
        bool daily_executed = false;
        bool nightly_executed = false;
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (DateTime.Now.TimeOfDay.Hours == NightCheckTime.Hours && DateTime.Now.TimeOfDay.Minutes == NightCheckTime.Minutes && !nightly_executed)
            {
                NightRoutineCheck();
                nightly_executed = true;
            }

            if (DateTime.Now.TimeOfDay.Hours == DailyCheckTime.Hours && DateTime.Now.TimeOfDay.Minutes == DailyCheckTime.Minutes && !daily_executed)
            {
                DailyRoutine();
                 daily_executed = true;
           }

            if (DateTime.Now.TimeOfDay.Hours == ResetTime.Hours && DateTime.Now.TimeOfDay.Minutes == ResetTime.Minutes)
            {
                 daily_executed = false;
                 nightly_executed = false;
            }
        }

        public void Start()
        {
            try
            {
                SetTimer();

            }
            catch (Exception ex)
            {
                Logger.Instance.Log.Error("Global routine failed", ex);
            }
           
        }
        public void Stop()
        {
            try
            {
                serverTimer.Stop();
                serverTimer.Dispose();
            }
            catch (Exception ex)
            {
                Logger.Instance.Log.Error("Failed to stop", ex);
            }
        }
    }
}
