using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;

namespace FHRMS.Data {
    public enum AbsenceType {
        [Display(Name = "Justifi� avec motif")]
       MotiveWarranted,
        [Display(Name = "Justifi� avec certificat m�dical")]
        CertificateWarranted,
        [Display(Name = "Non justifi�")]
        Unwarranted
    }
    public partial class Absence : DatabaseObject {
        public virtual Employee CreatedBy { get; set; }
        public long? CreatedById { get; set; }
        public long WarrantId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Employee Employee { get; set; }
        public long? EmployeeId { get; set; }
        public string Comment { get; set; }
        public virtual AbsenceType Kind { get; set; }
    }
}
