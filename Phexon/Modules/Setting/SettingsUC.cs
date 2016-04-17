using DevExpress.XtraEditors;

namespace PHRMS.Modules
{
    public partial class SettingsUC : XtraUserControl
    {
        public SettingsUC(bool allowTransition)
        {
            InitializeComponent();
            checkEdit1.Checked = allowTransition;
        }
    }
}