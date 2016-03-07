using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;

namespace DevExpress.DevAV.Modules.Customers {
    public partial class StateUC : XtraUserControl {
        public StateUC() {
            InitializeComponent();
            stateLookUpEdit.Properties.DataSource = Enum.GetValues(typeof(DevExpress.DevAV.StateEnum));
            stateLookUpEdit.Properties.ShowHeader = false;
        }
    }
}
