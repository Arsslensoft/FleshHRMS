using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using System.Runtime.Serialization;

namespace FHRMS.Data {
    public class Picture : DatabaseObject {
        public byte[] Data { get; set; }
    }
    static class PictureExtension {
        public const string DefaultPic = DefaultUserPic;
        public const string DefaultUserPic = "FHRMS.Data.Resources.Unknown-user.png";
        internal static Image CreateImage(this Picture picture, string defaultImage = null) {
            if(picture == null) {
                if(string.IsNullOrEmpty(defaultImage))
                    defaultImage = DefaultPic;
                return ResourceImageHelper.CreateImageFromResourcesEx(defaultImage, typeof(Picture).Assembly);
            }
            else return ByteImageConverter.FromByteArray(picture.Data);
        }
        internal static Picture FromImage(Image image) {
            return (image == null) ? null : new Picture()
            {
                Data = ByteImageConverter.ToByteArray(image, image.RawFormat)
            };
        }
    }
}
