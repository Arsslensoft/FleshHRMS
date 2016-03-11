using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace FHRMS.Modules {
    public partial class SettingsUC : XtraUserControl {
        public SettingsUC(bool allowTransition) {
            InitializeComponent();
            checkEdit1.Checked = allowTransition;
        }
    }
}
