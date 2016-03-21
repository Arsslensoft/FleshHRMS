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

    public enum ShiftType
    {
        [Display(Name = "Séance unique")]
        Single,
        [Display(Name = "Continue")]
        Continuous,
        [Display(Name = "Permanence")]
        Permanency
    }
    public class Shift : DatabaseObject
    {
      
        public long? CreatedById { get; set; }
        public virtual Employee CreatedBy { get; set; }


        public string Name { get; set; }
        
        public TimeSpan TimeIn { get; set; }
        public TimeSpan TimeOut { get; set; }

        public ShiftType Type { get; set; }

        [NotMapped]
        public TimeSpan TotalWorkingHours
        {
            get
            {
        
                    return TimeOut - TimeIn;
            }
        }
     
    

    }



}