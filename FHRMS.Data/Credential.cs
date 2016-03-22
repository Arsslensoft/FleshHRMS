using DevExpress.Common;
using DevExpress.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;


namespace FHRMS.Data
{
   public class Credential : IDataErrorInfo 
    {

       public string Username { get; set; }
       public string PasswordHash { get; set; }
        [NotMapped]
        public string Password { get { return ""; } set { PasswordHash = GetSha256FromString(value); } }
      
        public string GetSha256FromString(string strData)
        {
            var message = Encoding.ASCII.GetBytes(strData);
            SHA256Managed hashString = new SHA256Managed();
            string hex = "";

            var hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }  
    
        #region IDataErrorInfo
        string IDataErrorInfo.Error { get { return null; } }
        string IDataErrorInfo.this[string columnName] {
            get { return IDataErrorInfoHelper.GetErrorText(this, columnName); }
        }
        #endregion


    }
}
