using FHRMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Runtime.Serialization;

namespace FHRMS.Data
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