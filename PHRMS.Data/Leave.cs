using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PHRMS.Data
{
    public enum LeaveStatus
    {
        [Display(Name = "En attente")] Pending,
        [Display(Name = "Refusé")] Refused,
        [Display(Name = "Terminé")] Completed,
        [Display(Name = "En cours")] OnGoing
    }

    public enum LeaveType
    {
        [Display(Name = "Payé")] Paid,
        [Display(Name = "Sans Solde")] Unpaid,
        [Display(Name = "Annuel")] Yearly,
        [Display(Name = "Examen")] Exam,

        [Display(Name = "Formation individuel")] Training,
        [Display(Name = "Recherche")] Research,
        [Display(Name = "Maladie")] Disease,
        [Display(Name = "Maternité")] Maternity,

        [Display(Name = "Paternité")] Paternity,
        [Display(Name = "Catastrophe naturelle")] Disaster,
        [Display(Name = "Autre")] Other
    }

    public enum LeavePriority
    {
        [Display(Name = "Faible")] Low,

        Normal,
        [Display(Name = "Haute")] High,

        Urgent
    }

    public class Leave : DatabaseObject
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public LeaveStatus Status { get; set; }
        public LeavePriority Priority { get; set; }
        public LeaveType Kind { get; set; }

        [NotMapped]
        public int Completion
        {
            get
            {
                if (DateTime.Now >= DueDate)
                    return 100;
                if (DueDate.HasValue && StartDate.HasValue)
                {
                    var total = (DueDate.Value - StartDate.Value).TotalSeconds;
                    var percentage = (DateTime.Now - StartDate.Value).TotalSeconds*100/total;
                    return (int) percentage;
                }
                return 0;
            }
        }

        public virtual Employee AssignedEmployee { get; set; }
        public long? AssignedEmployeeId { get; set; }
        public virtual Employee Owner { get; set; }
        public long? OwnerId { get; set; }

        public bool Overdue
        {
            get
            {
                if (Status == LeaveStatus.Completed || !DueDate.HasValue) return false;
                var dDate = DueDate.Value.Date.AddDays(1);
                if (DateTime.Now >= dDate) return true;
                return false;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}, due {2}, {3},\r\nOwner: {4}", Subject, Description, DueDate, Status, Owner);
        }
    }
}