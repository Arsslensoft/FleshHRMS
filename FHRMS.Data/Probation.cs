using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;

namespace FHRMS.Data {
    public class Probation : DatabaseObject {
        public string Reason { get; set; }
    }
}