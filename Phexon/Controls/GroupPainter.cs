using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using DevExpress.Data;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
namespace DevExpress.XtraEditors.Drawing {
    public class PanelWrapper : IPanelControlOwner {
        #region IPanelControlOwner Members

        Color IPanelControlOwner.GetForeColor() {
            return Color.Empty;
        }

        void IPanelControlOwner.OnCustomDrawCaption(GroupCaptionCustomDrawEventArgs e) {
        }

        #endregion
    }

}
