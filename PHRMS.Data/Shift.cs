using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PHRMS.Data
{
    public enum StatusType
    {
        Free = 0,
        Tentative = 1,
        Busy = 2,
        OutOfOffice = 3,
        WorkingElsewhere = 4
    }

    public enum LabelType
    {
        None = 0,
        Important = 1,
        Busy = 2,
        Business = 3,
        Personal = 4,
        Vacation = 5,
        MustAttend = 6,
        TravelRequired = 7,
        NeedsPreparation = 8,
        Birthday = 9,
        Anniversary = 10,
        PhoneCall = 11
    }

    public enum ReccuranceType
    {
        [Display(Name = "Chaque semaine")] Weekly,
        [Display(Name = "Chaque jour")] Daily,
        [Display(Name = "Fixe")] Constant,

        [Display(Name = "Chaque jour sauf weekend")] DailyExceptWeekend,
        [Display(Name = "Chaque weekend")] Weekend
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
        public TimeSpan BreakStart { get; set; }
        public TimeSpan BreakEnd { get; set; }

        [NotMapped]
        public LabelType LabelEnum
        {
            get { return (LabelType) Label; }
            set { Label = (int) value; }
        }

        [NotMapped]
        public StatusType StatusEnum
        {
            get { return (StatusType) Status; }
            set { Status = (int) value; }
        }
       
        [NotMapped]
        public TimeSpan TotalBreakTime
        {
            get
            {

                return BreakEnd - BreakStart;
            }
        }

        [NotMapped]
        public TimeSpan TotalWorkingHours
        {
            get
            {
                if (ShiftKind == ShiftType.Continuous)
                    return (End - Start).Subtract(TotalBreakTime);
                return End - Start;
            }
        }
    }
}