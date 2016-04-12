using PHRMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Runtime.Serialization;

namespace PHRMS.Data {
    public enum EmployeeStatus {
        [Display(Name = "Salari�")]
        Salaried,
        [Display(Name = "Commission")]
        Commission,
        [Display(Name = "Contractuel")]
        Contract,
        [Display(Name = "Cl�tur�")]
        Terminated,
        [Display(Name = "En cong�")]
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
    public enum EmployeeRole : int
    {
        [Display(Name = "Employ�")]
        Employee=0,
       [Display(Name = "Agent")]
        Agent=1,
     [Display(Name = "Responsable")]
        Manager=2,
     [Display(Name = "Super Utilisateur")]
        SuperUser=3
    }
    public partial class Employee : DatabaseObject {
        public Employee() {
            AssignedLeaves = new List<Leave>();
            OwnedLeaves = new List<Leave>();
            Shifts = new List<Shift>();
            Address = new Address();
            Credential = new Credential();
        }
        public EmployeeDepartment Department { get; set; }
        [Required]
        public string Title { get; set; }

        public EmployeeStatus Status { get; set; }
        [Display(Name = "Hire Date")]
        public DateTime? HireDate { get; set; }
        [InverseProperty("AssignedEmployee")]
        public virtual List<Leave> AssignedLeaves { get; set; }
        [InverseProperty("Owner")]
        public virtual List<Leave> OwnedLeaves { get; set; }
        [InverseProperty("Employee")]
        public virtual List<Absence> Absences { get; set; }
        [InverseProperty("Employee")]
        public virtual List<Shift> Shifts { get; set; }
   

        public string PersonalProfile { get; set; }
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }
        [NotMapped,Display(Name = "Full Name")]
        public string FullName { get { return GetFullName(); } }
        public PersonPrefix Prefix { get; set; }
		[PHRMS.Data.Phone, Display(Name = "Home Phone")]
        public string HomePhone { get; set; }
		[Required, PHRMS.Data.Phone, Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }
		[Required, PHRMS.Data.EmailAddress]
        public string Email { get; set; }
        public string Skype { get; set; }
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }
        public virtual Picture Picture { get; set; }
        public long? PictureId { get; set; }
        public Address Address { get; set; }


        public Credential Credential { get; set; }

        [Required]
        public EmployeeRole Role { get; set; }

        [Required, PHRMS.Data.CIN]
        public string CIN { get; set; }

        [Required]
        public int LeaveCredit { get; set; }
        [Required]
        public int LateCredit { get; set; }

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
