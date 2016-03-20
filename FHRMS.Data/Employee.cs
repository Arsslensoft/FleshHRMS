using DevExpress.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Runtime.Serialization;

namespace FHRMS.Data {
    public enum EmployeeStatus {
        [Display(Name = "Salarié")]
        Salaried,
        [Display(Name = "Commission")]
        Commission,
        [Display(Name = "Contractuel")]
        Contract,
        [Display(Name = "Clôturé")]
        Terminated,
        [Display(Name = "En congé")]
        OnLeave
    }
    public enum EmployeeDepartment {
        [Display(Name = "Sales")]
        Sales = 1,
        [Display(Name = "Support")]
        Support,
        [Display(Name = "Shipping")]
        Shipping,
        [Display(Name = "Engineering")]
        Engineering,
        [Display(Name = "Human Resources")]
        HumanResources,
        [Display(Name = "Management")]
        Management,
        [Display(Name = "IT")]
        IT
    }
    public enum PersonPrefix {
        Dr,
        Mr,
        Ms,
        Miss,
        Mrs
    }
    public enum EmployeeRole
    {
        [Display(Name = "Employé")]
        Employee,
       [Display(Name = "Responsable")]
        Manager,
            [Display(Name = "Directeur")]
        Director
    }
    public partial class Employee : DatabaseObject {
        public Employee() {
            AssignedTasks = new List<Leave>();
            OwnedTasks = new List<Leave>();
            Address = new Address();
        }
        public EmployeeDepartment Department { get; set; }
        [Required]
        public string Title { get; set; }

        public EmployeeStatus Status { get; set; }
        [Display(Name = "Hire Date")]
        public DateTime? HireDate { get; set; }
        [InverseProperty("AssignedEmployee")]
        public virtual List<Leave> AssignedTasks { get; set; }
        [InverseProperty("Owner")]
        public virtual List<Leave> OwnedTasks { get; set; }
        [InverseProperty("Employee")]
        public virtual List<Absence> Evaluations { get; set; }
        public string PersonalProfile { get; set; }
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }
        [NotMapped,Display(Name = "Full Name")]
        public string FullName { get { return GetFullName(); } }
        public PersonPrefix Prefix { get; set; }
		[DevExpress.DataAnnotations.Phone, Display(Name = "Home Phone")]
        public string HomePhone { get; set; }
		[Required, DevExpress.DataAnnotations.Phone, Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }
		[Required, DevExpress.DataAnnotations.EmailAddress]
        public string Email { get; set; }
        public string Skype { get; set; }
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }
        public virtual Picture Picture { get; set; }
        public long? PictureId { get; set; }
        public Address Address { get; set; }
       
        [Required]
        public EmployeeRole Role { get; set; }
        [Required, DevExpress.DataAnnotations.CIN]
        public string CIN { get; set; }
        [Required]
        public int LeaveCredit { get; set; }
        [Required]
        public double Salary { get; set; }

        Image _photo = null;
        [NotMapped]
        public Image Photo {
            get {
                if(_photo == null)
                    _photo = Picture.CreateImage();
                return _photo;
            }
            set {
                if(_photo == value) return;
                if(_photo != null)
                    _photo.Dispose();
                _photo = value;
                Picture = PictureExtension.FromImage(value);
            }
        }
        bool unsetFullName = false;
        [NotMapped, Display(Name = "Full Name")]
        public string FullNameBindable {
            get {
                string fullname= string.IsNullOrEmpty(FullName) || unsetFullName ? GetFullName() : FullName;

                //if (string.IsNullOrEmpty(FullName))
                //{
                //    FullName = fullname;
                //    unsetFullName = false;
                //}
                return fullname;

            }
          
        }
        public void ResetBindable() {
            if(_photo != null)
                _photo.Dispose();
            _photo = null;
            unsetFullName = false;
        }
        string GetFullName() {
            return string.Format("{0} {1}", FirstName, LastName);
        }
        public override string ToString() {
            return FullName;
        }
    }
}
