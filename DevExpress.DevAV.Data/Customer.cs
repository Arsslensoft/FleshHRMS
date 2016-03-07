using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Runtime.Serialization;
using DevExpress.DataAnnotations;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

namespace DevExpress.DevAV {
    public enum CustomerStatus {
        Active,
        Suspended
    }
    public partial class Customer : DatabaseObject {
        public Customer() {
            Employees = new List<CustomerEmployee>();
            Orders = new List<Order>();
            HomeOffice = new Address();
            BillingAddress = new Address();
        }
        [Required]
        public string Name { get; set; }
        public Address HomeOffice { get; set; }
        public Address BillingAddress { get; set; }
        public virtual List<CustomerEmployee> Employees { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Phone]
        public string Fax { get; set; }
        [Url]
        public string Website { get; set; }
        [DataType(DataType.Currency)]
        public decimal AnnualRevenue { get; set; }
        [Display(Name = "Total Stores")]
        public int TotalStores { get; set; }
        [Display(Name = "Total Employees")]
        public int TotalEmployees { get; set; }
        public CustomerStatus Status { get; set; }
        [InverseProperty("Customer")]
        public virtual List<Order> Orders { get; set; }
        [InverseProperty("Customer")]
        public virtual List<Quote> Quotes { get; set; }
        [InverseProperty("Customer")]
        public virtual List<CustomerStore> CustomerStores { get; set; }
        public virtual string Profile { get; set; }
        public byte[] Logo { get; set; }
        Image img = null;
        public Image Image {
            get {
                if(img == null)
                    img = CreateImage(Logo);
                return img;
            }
        }
        internal static Image CreateImage(byte[] data) {
            if(data == null)
                return ResourceImageHelper.CreateImageFromResourcesEx("DevExpress.DevAV.Resources.Unknown-user.png", typeof(Employee).Assembly);
            else
                return ByteImageConverter.FromByteArray(data);
        }
    }
}
