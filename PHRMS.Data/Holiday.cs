using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PHRMS.Data
{
    public class Holiday : DatabaseObject
    {
        public long? CreatedById { get; set; }
        public virtual Employee CreatedBy { get; set; }


        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }


        [NotMapped]
        public TimeSpan TotalTime
        {
            get { return StartDate - DueDate; }
        }
    }
}