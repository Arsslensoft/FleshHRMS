using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FHRMS.Data;
using FHRMS.Data;

namespace FHRMS.Data {
    public class Address : IDataErrorInfo {
        [Display(Name = "Address")]
        public string Line { get; set; }
        public string City { get; set; }
        public StateEnum State { get; set; }
        [ZipCode, Display(Name = "Zip code")]
        public string ZipCode { get; set; }

     
        public string CityLine {
            get { 
        		return GetCityLine(City, State, ZipCode); 
        	}
        }
        public override string ToString() {
            return string.Format("{0}, {1}", Line, CityLine);
        }
        #region IDataErrorInfo
        string IDataErrorInfo.Error { get { return null; } }
        string IDataErrorInfo.this[string columnName] {
            get { return IDataErrorInfoHelper.GetErrorText(this, columnName); }
        }
        #endregion

        internal static string GetCityLine(string city, StateEnum state, string zipCode) {
            return string.Format("{0}, {1} {2}", city, state, zipCode);
        }
    }
}
