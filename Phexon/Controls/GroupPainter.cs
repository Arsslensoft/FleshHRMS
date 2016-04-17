using System.Drawing;
using DevExpress.Utils.Drawing;

namespace DevExpress.XtraEditors.Drawing
{
    public class PanelWrapper : IPanelControlOwner
    {
        #region IPanelControlOwner Members

        Color IPanelControlOwner.GetForeColor()
        {
            return Color.Empty;
        }

        void IPanelControlOwner.OnCustomDrawCaption(GroupCaptionCustomDrawEventArgs e)
        {
        }

        #endregion
    }
}