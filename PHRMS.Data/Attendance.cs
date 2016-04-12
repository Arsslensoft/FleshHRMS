using PHRMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Runtime.Serialization;

namespace PHRMS.Data
{

    public enum AttendanceDate
    {
        Today,
        Other
    }
    public enum AttendanceType
    {
        [Display(Name = "Entrée")]
        EnterOnly,
        [Display(Name = "Entrée/Sortie")]
        Both,
        [Display(Name = "Sortie justifié")]
        JustifiedExit,
        [Display(Name = "Sortie non justifié")]
        UnjustifiedExit
    }
    public class Attendance : DatabaseObject
    {
      

        public long? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }


        public long? CreatedById { get; set; }
        public virtual Employee CreatedBy { get; set; }

    
        public DateTime Date { get; set; }
 
        public TimeSpan TimeIn { get; set; }
        public TimeSpan TimeOut { get; set; }
        public TimeSpan BreakIn { get; set; }
        public TimeSpan BreakOut { get; set; }

        [NotMapped]
        public TimeSpan TotalWorkingHours
        {
            get
            {
                if (Type != AttendanceType.EnterOnly)
                    return TimeOut - TimeIn - (BreakOut - BreakIn);
                else return new TimeSpan(0);
            }
        }
        [NotMapped]
        public AttendanceDate ADate { get { return (Date.Date == DateTime.Today.Date)? AttendanceDate.Today: AttendanceDate.Other; } }

        public AttendanceType Type { get; set; }
        public string Reason { get; set; }

    }



}