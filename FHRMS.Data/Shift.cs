using DevExpress.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Runtime.Serialization;

namespace FHRMS.Data
{
    public enum StatusType : int
    {
        Free=0,
        Tentative=1,
        Busy=2,
        OutOfOffice=3,
        WorkingElsewhere=4



    }
    public enum LabelType : int
    {
        None=0,
        Important=1,
        Busy=2,
        Business=3,
        Personal=4,
        Vacation=5,
        MustAttend=6,
        TravelRequired=7,
        NeedsPreparation=8,
        Birthday=9,
        Anniversary=10,
        PhoneCall=11



    }
    public enum ReccuranceType
    {
        [Display(Name = "Chaque semaine")]
        UpdatedWeekly,
        [Display(Name = "Chaque jour")]
        UpdateDaily,
        [Display(Name = "Fixe")]
        Constant
    }
    public enum ShiftType
    {
        Continuous,
        Single,
        Permanence
    }
    public class Shift : DatabaseObject
    {
        public long? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }


     
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Subject { get; set; }
        public ShiftType ShiftKind { get; set; }
        public ReccuranceType Recurrence { get; set; }

        public int Label { get; set; }
        public int Status { get; set; }


            [NotMapped]
            public LabelType LabelEnum { get { return (LabelType)Label; } set { Label = (int)value; } }
            [NotMapped]
            public StatusType StatusEnum { get { return (StatusType)Status; } set { Status = (int)value; } }
 
        [NotMapped]
        public TimeSpan TotalWorkingHours
        {
            get
            {

                return End - Start;
            }
        }
     
    

    }



}