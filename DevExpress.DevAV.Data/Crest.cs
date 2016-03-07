﻿using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;

namespace DevExpress.DevAV {
    public class Crest : DatabaseObject {
        public string CityName { get; set; }
        public byte[] SmallImage { get; set; }
        public byte[] LargeImage { get; set; }
        Image img;
        public Image LargeImageEx {
            get {
                if(img == null)
                    if(LargeImage == null)
                        return ResourceImageHelper.CreateImageFromResourcesEx("DevExpress.DevAV.Resources.Unknown-user.png", typeof(Employee).Assembly);
                    else
                        img = ByteImageConverter.FromByteArray(LargeImage);
                return img;
            }
        }
    }
}
