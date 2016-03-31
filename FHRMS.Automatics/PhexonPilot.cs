using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FHRMS.Data;
namespace FHRMS.Automatics
{
    public class PhexonPilot
    {
        public static DateTime IndeterminateDate = DateTime.Parse("1/1/2015 00:00:00");
        public bool Between( DateTime x, DateTime start, DateTime end)
        {
            if (end == IndeterminateDate || (x.Date >= start.Date && x.Date <= end.Date)) // indeterminate date or between 2 dates
                return true;
            return false;
        }
        public FHRMS.Data.PhexonDb DatabaseManager { get; set; }
        public PhexonPilot()
        { 
            DatabaseManager = new Data.PhexonDb(); 
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
            w.Reason = "L'employé "+emp.FullName + " a dépassé les limites autorisés de d'absences";
            w.Severity = WarningSeverity.Inconvenient;
            w.Type = WarningType.Verbal;
            DatabaseManager.Warnings.Add(w);
            DatabaseManager.SaveChanges();
        }

        /// <summary>
        /// Weekly Routine 
        /// </summary>
        public void WeeklyRoutine()
        {
            // TODO:sync
            // Updates all shifts weekly (add 7 days)
            List<Shift> shifts = DatabaseManager.Shifts.Local.ToList();
            for (int i = 0; i < shifts.Count; i++)
            {
                Shift sh = shifts[i];
                sh.Start = sh.Start.AddDays(7);
                sh.End = sh.End.AddDays(7);
            }
        }

        public void MorningRoutineCheck()
        {
            Load();
            List<Attendance> attendances = DatabaseManager.Attendances.Local.Where(x => x.ADate == AttendanceDate.Today).ToList();
            foreach (Attendance a in attendances)
            {
                List<Shift> todays_shift = a.Employee.Shifts.Where(x => x.Start.Date == DateTime.Now.Date).ToList();
                if (todays_shift.Count > 0)
                {

                }
            }
        }
        public void DailyRoutineCheck()
        {
            Load();
            List<Attendance> attendances = DatabaseManager.Attendances.Local.Where(x => x.ADate == AttendanceDate.Today).ToList();
            List<Leave> active_leaves = DatabaseManager.Leaves.Local.Where(x => Between(DateTime.Now.Date, x.StartDate.Value, x.DueDate.Value)).ToList(); // look for attendances
            List<Absence> open_absences = DatabaseManager.Absences.Local.Where(x => x.EndDate == IndeterminateDate).ToList(); // look for open absences 
            List<Employee> employees = DatabaseManager.Employees.Local.ToList();

            var unattended_employees = (from emp in DatabaseManager.Employees
                                        where !attendances.Any(m => m.EmployeeId == emp.Id)
                           select emp);
            



           


            


        }
    }
}
