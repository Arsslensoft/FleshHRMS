using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace FHRMS.Data {
    public class CustomerStore : DatabaseObject {
        public virtual Customer Customer { get; set; }
        public long? CustomerId { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public int TotalEmployees { get; set; }
        public int SquereFootage { get; set; }
        [DataType(DataType.Currency)]
        public decimal AnnualSales { get; set; }
        public virtual Crest Crest { get; set; }
        public long? CrestId { get; set; }
        public string Location { get; set; }
        public string City { get { return Address == null ? "" : Address.City; } }
        public StateEnum State { get { return Address == null ? StateEnum.Tunis : Address.State; } }
        public string CustomerName {
            get { return (Customer != null) ? Customer.Name : null; }
        }
        public string AddressLine {
            get { return (Address != null) ? Address.ToString() : null; }
        }
        public string AddressLines {
            get { return (Address != null) ? string.Format("{0}\r\n{1} {2}", Address.Line, Address.State, Address.ZipCode) : null; }
        }
        public string CrestCity {
            get { return (Crest != null) ? Crest.CityName : null; }
        }
        Image smallImg;
        public Image CrestSmallImage {
            get {
                if(smallImg == null && Crest != null)
                    smallImg = CreateImage(Crest.SmallImage);
                return smallImg;
            }
        }
        Image largeImg;
        public Image CrestLargeImage {
            get {
                if(largeImg == null && Crest != null)
                    largeImg = CreateImage(Crest.LargeImage);
                return largeImg;
            }
        }
        Image CreateImage(byte[] data) {
            if(data == null)
                return ResourceImageHelper.CreateImageFromResourcesEx("FHRMS.Data.Resources.Unknown-user.png", typeof(Employee).Assembly);
            else
                return ByteImageConverter.FromByteArray(data);
        }
    }
}
