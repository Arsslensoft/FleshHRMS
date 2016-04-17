using System;
using DevExpress.XtraEditors;
using PHRMS.Data;

namespace PHRMS.Modules.Customers
{
    public partial class StateUC : XtraUserControl
    {
        public StateUC()
        {
            InitializeComponent();
            stateLookUpEdit.Properties.DataSource = Enum.GetValues(typeof(StateEnum));
            stateLookUpEdit.Properties.ShowHeader = false;
        }
    }
}