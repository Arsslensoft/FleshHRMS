using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using FHRMS.ViewModels;
using System.IO;
using FHRMS.Helpers;
using FHRMS.Data;
using DevExpress.XtraGrid;

namespace FHRMS.Modules {
    public partial class CustomersFilterModule : BaseModuleControl {
       public CustomersFilterModule(IList<Customer> list)
            : base(CreateViewModel<CustomerViewModel>) {
            InitializeComponent();
            filterControl.SourceControl = list;
        }
    }
}
