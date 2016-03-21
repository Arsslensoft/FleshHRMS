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

    public enum WarningSeverity
    {
        [Display(Name = "S�v�re")]
        Severe,
        [Display(Name = "Grave")]
        Serious,
        [Display(Name = "G�nant")]
        Inconvenient,
        [Display(Name = "Faible")]
        Low
    }
    public enum WarningType
    {
        [Display(Name = "Verbal")]
        Verbal
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