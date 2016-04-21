using System;
using System.ComponentModel.DataAnnotations;

namespace PHRMS.Data
{
    public enum WarningSeverity
    {
        [Display(Name = "S�v�re")] Severe,
        [Display(Name = "Grave")] Serious,
        [Display(Name = "G�nant")] Inconvenient,
        [Display(Name = "Faible")] Low
    }

    public enum WarningType
    {
        [Display(Name = "Verbal")] Verbal,
        [Display(Name = "Bl�me")]
        Blame,
        [Display(Name = "�crit")]
        Written,
        [Display(Name = "�crit & inscrit")]
        WrittenRegistred
    }

    public class Warning : DatabaseObject
    {
        public long? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public long? CreatedById { get; set; }
        public virtual Employee CreatedBy { get; set; }
        public DateTime Date { get; set; }
        public WarningType Type { get; set; }
        public WarningSeverity Severity { get; set; }

        public string Reason { get; set; }
    }
}