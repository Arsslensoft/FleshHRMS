using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DevExpress.DevAV {
    public enum EmployeeTaskStatus {
        [Display(Name = "Not Started")]
        NotStarted,
        [Display(Name = "Completed")]
        Completed,
        [Display(Name = "In Progress")]
        InProgress,
        [Display(Name = "Need Assistance")]
        NeedAssistance,
        [Display(Name = "Deferred")]
        Deferred
    }
    public enum EmployeeTaskPriority {
        Low,
        Normal,
        High,
        Urgent
    }
    public class EmployeeTask : DatabaseObject {
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public EmployeeTaskStatus Status { get; set; }
        public EmployeeTaskPriority Priority { get; set; }
        public int Completion { get; set; }
        public bool Reminder { get; set; }
        public DateTime? ReminderDateTime { get; set; }
        public virtual Employee AssignedEmployee { get; set; }
        public long? AssignedEmployeeId { get; set; }
        public virtual Employee Owner { get; set; }
        public long? OwnerId { get; set; }
        public virtual CustomerEmployee CustomerEmployee { get; set; }
        public long? CustomerEmployeeId { get; set; }
        public override string ToString() {
            return string.Format("{0} - {1}, due {2}, {3},\r\nOwner: {4}", Subject, Description, DueDate, Status, Owner);
        }
        public bool Overdue {
            get {
                if(Status == EmployeeTaskStatus.Completed || !DueDate.HasValue) return false;
                DateTime dDate = DueDate.Value.Date.AddDays(1);
                if(DateTime.Now >= dDate) return true;
                return false;
            }
        }
    }
}
