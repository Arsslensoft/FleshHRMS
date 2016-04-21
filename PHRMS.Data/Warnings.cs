using System;
using System.ComponentModel.DataAnnotations;

namespace PHRMS.Data
{
    public enum WarningSeverity
    {
        [Display(Name = "Sévére")] Severe,
        [Display(Name = "Grave")] Serious,
        [Display(Name = "Gènant")] Inconvenient,
        [Display(Name = "Faible")] Low
    }

    public enum WarningType
    {
        [Display(Name = "Verbal")] Verbal
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