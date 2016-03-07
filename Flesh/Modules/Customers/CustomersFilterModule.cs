using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.DevAV.ViewModels;
using System.IO;
using DevExpress.DevAV.Helpers;
using DevExpress.DevAV;
using DevExpress.XtraGrid;

namespace DevExpress.DevAV.Modules {
    public partial class CustomersFilterModule : BaseModuleControl {
       public CustomersFilterModule(IList<Customer> list)
            : base(CreateViewModel<CustomerViewModel>) {
            InitializeComponent();
            filterControl.SourceControl = list;
        }
    }
}
