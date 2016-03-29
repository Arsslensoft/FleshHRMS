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
    public class Holiday : DatabaseObject
    {

        public long? CreatedById { get; set; }
        public virtual Employee CreatedBy { get; set; }


        public string Name { get; set; }
        public DateTime StartDate { get; set; }
   
        public DateTime DueDate { get; set; }
        public bool ExcludePermanence { get; set; }
     
        [NotMapped]
        public TimeSpan TotalTime
        {
            get
            {

                return StartDate - DueDate;
            }
        }



    }
}
