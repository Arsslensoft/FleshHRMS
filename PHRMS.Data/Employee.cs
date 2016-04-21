using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PHRMS.Data
{
    public enum EmployeeStatus
    {
        [Display(Name = "En travail")] Working,
        [Display(Name = "En congé")] OnLeave
    }

    public enum EmployeeDepartment
    {
        [Display(Name = "Commercial")] Sales = 1,
        [Display(Name = "Support")] Support,
        [Display(Name = "Livraison")] Shipping,
        [Display(Name = "Ingénierie")] Engineering,
        [Display(Name = "Ressources humaines")] HumanResources,
        [Display(Name = "Gestion")] Management,
        [Display(Name = "IT")] IT
    }

    public enum PersonPrefix
    {
        Dr,
        Mr,
        Ms,
        Miss,
        Mrs
    }

    public enum EmployeeRole
    {
        [Display(Name = "Employé")] Employee = 0,
        [Display(Name = "Agent")] Agent = 1,
        [Display(Name = "Responsable")] Manager = 2,
        [Display(Name = "Super Utilisateur")] SuperUser = 3
    }

    public class Employee : DatabaseObject
    {
        private Image _photo;
        private bool unsetFullName;

        public Employee()
        {
            AssignedLeaves = new List<Leave>();
            OwnedLeaves = new List<Leave>();
            Shifts = new List<Shift>();
            Address = new Address();
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

        [NotMapped, Display(Name = "Full Name")]
        public string FullName
        {
            get { return GetFullName(); }
        }

        public PersonPrefix Prefix { get; set; }

        [Phone, Display(Name = "Home Phone")]
        public string HomePhone { get; set; }

        [Required, Phone, Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }

        public virtual Picture Picture { get; set; }
        public long? PictureId { get; set; }
        public Address Address { get; set; }


        public string PasswordHash { get; set; }

        [NotMapped]
        public string Password
        {
            get { return Decrypt(PasswordHash); }
            set { PasswordHash = Encrypt(value); }
        }

        public string Encrypt(string originalString)
        {
            if (String.IsNullOrEmpty(originalString))
            {
                throw new ArgumentNullException
                       ("The string which needs to be encrypted can not be null.");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }
        byte[] bytes = ASCIIEncoding.ASCII.GetBytes("SJKL8D9F");
        public string Decrypt(string cryptedString)
        {
            if (String.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException
                   ("The string which needs to be decrypted can not be null.");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream
                    (Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }
        [Required]
        public EmployeeRole Role { get; set; }

        [Required, CIN]
        public string CIN { get; set; }

        [Required]
        public int LeaveCredit { get; set; }

        [Required]
        public int LateCredit { get; set; }

    

        [NotMapped]
        public Image Photo
        {
            get
            {
                if (_photo == null)
                    _photo = Picture.CreateImage();
                return _photo;
            }
            set
            {
                if (_photo == value) return;
                if (_photo != null)
                    _photo.Dispose();
                _photo = value;
                Picture = PictureExtension.FromImage(value);
            }
        }

        [NotMapped, Display(Name = "Full Name")]
        public string FullNameBindable
        {
            get
            {
                var fullname = string.IsNullOrEmpty(FullName) || unsetFullName ? GetFullName() : FullName;

                //if (string.IsNullOrEmpty(FullName))
                //{
                //    FullName = fullname;
                //    unsetFullName = false;
                //}
                return fullname;
            }
        }

        public string GetSha256FromString(string strData)
        {
            var message = Encoding.ASCII.GetBytes(strData);
            var hashString = new SHA256Managed();
            var hex = "";

            var hashValue = hashString.ComputeHash(message);
            foreach (var x in hashValue)
            {
                hex += string.Format("{0:x2}", x);
            }
            return hex;
        }

        public void ResetBindable()
        {
            if (_photo != null)
                _photo.Dispose();
            _photo = null;
            unsetFullName = false;
        }

        private string GetFullName()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}