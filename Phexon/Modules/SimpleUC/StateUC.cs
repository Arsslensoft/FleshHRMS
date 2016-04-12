using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;

namespace PHRMS.Modules.Customers {
    public partial class StateUC : XtraUserControl {
        public StateUC() {
            InitializeComponent();
            stateLookUpEdit.Properties.DataSource = Enum.GetValues(typeof(PHRMS.Data.StateEnum));
            stateLookUpEdit.Properties.ShowHeader = false;
        }
    }
}
