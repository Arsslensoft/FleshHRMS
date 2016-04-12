using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;

namespace PHRMS.Data {
    public enum AbsenceType {
        [Display(Name = "Justifié avec motif")]
       MotiveWarranted,
        [Display(Name = "Justifié avec certificat médical")]
        CertificateWarranted,
        [Display(Name = "Non justifié")]
        Unwarranted,
        [Display(Name = "Retard")]
        Late
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
        [NotMapped]
        public TimeSpan TotalTime
        {
            get
            {
                return EndDate - StartDate;
            }
        }

        public virtual AbsenceType Kind { get; set; }
    }
}
