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


    public enum PointingStatus
    {
        Open,
        Closed
    }
    public class EmployeePointing : DatabaseObject
    {
        public EmployeePointing()
        {
        
        }

        public long? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

    
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public PointingStatus Status {get;set;}

    }



}