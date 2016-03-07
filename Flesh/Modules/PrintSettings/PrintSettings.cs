using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;

namespace DevExpress.DevAV.Modules {
    public partial class PrintSettings : XtraUserControl, ISupportNavigation {
        public PrintSettings() {
            InitializeComponent();
        }
        public virtual void OnNavigatedFrom(INavigationArgs args) {
        }
        public virtual void OnNavigatedTo(INavigationArgs args) {
        }
    }
}
