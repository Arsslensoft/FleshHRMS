using System;

namespace PHRMS.Data
{
    public class Post : DatabaseObject
    {
        public long? CreatedById { get; set; }
        public virtual Employee CreatedBy { get; set; }

        public DateTime Date { get; set; }
        public string Message { get; set; }
    }

    public class Notification : DatabaseObject
    {
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}