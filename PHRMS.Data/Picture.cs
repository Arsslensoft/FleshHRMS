using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

namespace PHRMS.Data
{
    public class Picture : DatabaseObject
    {
        public byte[] Data { get; set; }
    }

    internal static class PictureExtension
    {
        public const string DefaultPic = DefaultUserPic;
        public const string DefaultUserPic = "PHRMS.Data.Resources.Unknown-user.png";

        internal static Image CreateImage(this Picture picture, string defaultImage = null)
        {
            if (picture == null)
            {
                if (string.IsNullOrEmpty(defaultImage))
                    defaultImage = DefaultPic;
                return ResourceImageHelper.CreateImageFromResourcesEx(defaultImage, typeof(Picture).Assembly);
            }
            return ByteImageConverter.FromByteArray(picture.Data);
        }

        internal static Picture FromImage(Image image)
        {
            return image == null
                ? null
                : new Picture
                {
                    Data = ByteImageConverter.ToByteArray(image, image.RawFormat)
                };
        }
    }
}