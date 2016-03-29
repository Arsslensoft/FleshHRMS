using FHRMS.Data;
using FHRMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHRMS
{
  public  class PhexonPilot
    {

      public BoardViewModel MainView { get; set; }
      public bool IsOnLeave(Employee emp)
      {
          return emp.Status == EmployeeStatus.OnLeave;
      }
      public void MarkReturnIfAbsent(Employee emp)
      {
          foreach(Absence a in emp.Absences)
              if (a.StartDate == a.EndDate)
              {

              }
      }
      public void AbsenceDetectionRoutine()
      {
          List<long> emp = new List<long>();
          foreach (Attendance a in MainView.AttendancesViewModel.Entities.Where(x => x.ADate == AttendanceDate.Today))
          {
              if (!emp.Contains(a.EmployeeId.Value))
                  emp.Add(a.EmployeeId.Value);

              MarkReturnIfAbsent(a.Employee);
          }

          foreach (Employee e in MainView.EmployeesViewModel.Entities)
          {
              if (emp.Contains(e.Id) || IsOnLeave(e))
                  continue;

              // absence detected
              Absence abs = new Absence();
              abs.EmployeeId = e.Id;
              abs.StartDate = DateTime.Now.Date;
              abs.Kind = AbsenceType.Unwarranted;
              abs.WarrantId = 0;
              abs.Comment = "Autodetected";
              abs.CreatedById = 1;
             
              abs.EndDate =abs.StartDate;
              MainView.AbsenceViewModel.Save(abs);
              

          }
      }



      public void StartService()
      {

      }

    }
}
