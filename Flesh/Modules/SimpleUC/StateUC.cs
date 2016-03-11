using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;

namespace FHRMS.Modules.Customers {
    public partial class StateUC : XtraUserControl {
        public StateUC() {
            InitializeComponent();
            stateLookUpEdit.Properties.DataSource = Enum.GetValues(typeof(FHRMS.Data.StateEnum));
            stateLookUpEdit.Properties.ShowHeader = false;
        }
    }
}
