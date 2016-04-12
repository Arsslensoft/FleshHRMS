using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace PHRMS.Helpers {
    public static class ItemsHideHelper {
        public static void Hide(ICollection baseItemCollection, SimpleLabelItem button) {
            HideCore(baseItemCollection, button, false);
        }
        public static void HideCore(ICollection baseItemCollection, SimpleLabelItem button, bool conversely) {
            foreach (BaseLayoutItem bli in baseItemCollection) {
                bli.Visibility = LayoutVisibility.Never;
            }
            if (conversely) {
                button.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("PHRMS.Resources.ArrowLeft.png"));
            } else {
                button.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("PHRMS.Resources.ArrowRight.png"));
            }
        }

        public static void Expand(ICollection baseItemCollection, SimpleLabelItem button) {
            ExpandCore(baseItemCollection, button, false);
        }
        public static void ExpandCore(ICollection baseItemCollection, SimpleLabelItem button, bool conversely) {
            foreach (BaseLayoutItem bli in baseItemCollection) {
                bli.Visibility = LayoutVisibility.Always;
            }
            if (conversely) {
                button.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("PHRMS.Resources.ArrowRight.png"));
            } else {
                button.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("PHRMS.Resources.ArrowLeft.png"));
            }
        }
    }
}
