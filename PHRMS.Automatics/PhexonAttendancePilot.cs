using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PHRMS.Data;
using System.IO;

namespace PHRMS.Automatics
{
   public class PhexonAttendancePilot
    {
       public PHRMS.Data.PhexonDb DatabaseManager { get; set; }

       public PhexonAttendancePilot()
       {
           DatabaseManager = new PhexonDb();

       }

       public Employee GetEmployeeById(long id)
       {
            List<Employee> emp =           DatabaseManager.Employees.Where(x => x.Id == id).ToList();
            return (emp.Count > 0) ? emp[0] : null;
                     
       }
       public void GetTodaysEmployeeAttendance(Employee emp, ref Attendance at)
       {
           List<Attendance> att = DatabaseManager.Attendances.Where(x => x.EmployeeId == emp.Id && x.ADate == AttendanceDate.Today).ToList();
           if (att.Count > 0) at = att[0];
           else at = null;
       }
       public Shift GetTodaysShift(Employee emp)
       {
           List<Shift> att = DatabaseManager.Shifts.Where(x => x.EmployeeId == emp.Id && x.Start.Date == DateTime.Now.Date).ToList();
           return (att.Count > 0) ? att[0] : null;
       }
       void AddAttendance(Employee emp)
       {
           Attendance a = new Attendance();
           a.EmployeeId = emp.Id;
           a.CreatedById = 5;
           a.BreakIn = TimeSpan.Zero;
           a.TimeIn = DateTime.Now.TimeOfDay ; 
           a.BreakOut = TimeSpan.Zero;
           a.TimeOut = TimeSpan.Zero;
           a.Date = DateTime.Now.Date;
           a.Employee = emp;
           a.Reason = "";
           a.Type = AttendanceType.EnterOnly;
           DatabaseManager.Attendances.Add(a);

       }
       void ModifyAttendance(Attendance att)
       {
           Shift sh = GetTodaysShift(att.Employee);
           if (sh == null && sh.ShiftKind == ShiftType.Continuous)
           {

               switch (att.Type)
               {
                   case AttendanceType.EnterOnly:
                       att.Type = AttendanceType.BreakIn;
                       att.BreakIn = DateTime.Now.TimeOfDay;
                       break;
                   case AttendanceType.BreakIn:

                                att.Type = AttendanceType.BreakOut;
                       att.BreakOut = DateTime.Now.TimeOfDay;
                       break;
                   case AttendanceType.BreakOut:

                                att.Type = AttendanceType.Both;
                       att.TimeOut = DateTime.Now.TimeOfDay;
                       break;
                   
               }

           }
           else
           {
               att.Type = AttendanceType.Both;
               att.TimeOut = DateTime.Now.TimeOfDay;
           }
       }
       public bool AddOrUpdateAttendance(long id)
       {
           Employee emp = GetEmployeeById(id);
           if(emp != null)
               {
                   Attendance att = null;
                   GetTodaysEmployeeAttendance(emp, ref att);
                   if (att == null)
                       AddAttendance(emp);
                   else ModifyAttendance(att);
                   return true;
               }else return false;
       }

       public void DoAttendanceJob(string path)
       {
           DatabaseManager.Attendances.Load();
           DatabaseManager.Shifts.Load();
           DatabaseManager.Employees.Load();
           string id_from_file = File.ReadAllText(path);
           long id = long.Parse(id_from_file);

           AddOrUpdateAttendance(id);

           DatabaseManager.SaveChanges();
       }



    }
}
