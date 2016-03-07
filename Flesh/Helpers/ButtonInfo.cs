using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DevExpress.DevAV.Helpers {
    public class ButtonInfo {
        public string Text { get; set; }
        public string Name { get; set; }
        public Image Image { get; set; }
        public Control PopupMenuContent { get; set; }

        public EventHandler mouseEventHandler { get; set; }
        public Type Type { get; set; }
    }
    public static class ImageHelper {
        public static Image GetImageFromToolbarResource(string name) {
            var imageStream = Assembly.GetEntryAssembly().GetManifestResourceStream("DevExpress.DevAV.Resources.Toolbar." + name + ".png");
            return Image.FromStream(imageStream);
        }
    }
}
