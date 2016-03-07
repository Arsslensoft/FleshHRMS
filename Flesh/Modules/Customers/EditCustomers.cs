using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.DevAV.ViewModels;
using DevExpress.XtraMap;
using DevExpress.DevAV.Helpers;

namespace DevExpress.DevAV.Modules {
    public partial class CustomerEditableView : BaseModuleControl {
        public CustomerEditableView()
            : base(CreateViewModel<CustomerViewModel>) {
            InitializeComponent();
            MakeMapVisible();
            ViewModel.Minimum = (DateTime)rangeControl.SelectedRange.Minimum;
            ViewModel.Maximum = (DateTime)rangeControl.SelectedRange.Maximum;
        }
        public void MakeMapVisible() {
            customerDetailsTab.Visibility = XtraLayout.Utils.LayoutVisibility.Never;
            mapTab.Visibility = XtraLayout.Utils.LayoutVisibility.Always;
        }
        public void MakeGridVisible() {
            mapTab.Visibility = XtraLayout.Utils.LayoutVisibility.Never;
            customerDetailsTab.Visibility = XtraLayout.Utils.LayoutVisibility.Always;
        }

        public override void Refresh() {
            if(ViewModel.Entity != null) {
                ordersGridControl.DataSource = ViewModel.Entity.Orders;
                customerBindingSource.DataSource = ViewModel.Entity;
                addressUserControl1.ItemForLine.Text = "ADDRESS";
                addressUserControl1.addressBindingSource.DataSource = ViewModel.Entity.HomeOffice;
                addressUserControl2.addressBindingSource.DataSource = ViewModel.Entity.BillingAddress;
                if(addressUserControl1.StateImageComboBoxEdit.stateLookUpEdit.DataBindings.Count == 0) {
                    addressUserControl1.StateImageComboBoxEdit.stateLookUpEdit.DataBindings.Add("EditValue", ViewModel.Entity.HomeOffice, "State");
                }
                if(addressUserControl2.StateImageComboBoxEdit.stateLookUpEdit.DataBindings.Count == 0) {
                    addressUserControl2.StateImageComboBoxEdit.stateLookUpEdit.DataBindings.Add("EditValue", ViewModel.Entity.BillingAddress, "State");
                }
                orderBindingSource.DataSource = ViewModel.Entity.Orders;
                dateTimeChartRangeControlClient1.DataProvider.DataSource = ViewModel.Entity.Orders;
                dateTimeChartRangeControlClient1.DataProvider.SeriesDataMember = string.Empty;
                dateTimeChartRangeControlClient1.DataProvider.ValueDataMember = "TotalAmount";
                dateTimeChartRangeControlClient1.DataProvider.ArgumentDataMember = "OrderDate";
                customerMapView1.ViewModel = ViewModel;
            }
            base.Refresh();
        }
        protected internal override void OnTransitionCompleted() {
            base.OnTransitionCompleted();
            InitializeButtonPanel();
        }
        void InitializeButtonPanel() {
            var listBI = new List<ButtonInfo>();
            listBI.Add(new ButtonInfo() {
                Type = typeof(SimpleButton), Text = "Save", Name = "2", Image = ImageHelper.GetImageFromToolbarResource("Save"), mouseEventHandler = (s, e) => {
                    Save();
                }
            });
            listBI.Add(new ButtonInfo() {
                Type = typeof(SimpleButton), Text = "Cancel", Name = "3", Image = ImageHelper.GetImageFromToolbarResource("Cancel"), mouseEventHandler = (s, e) => {
                    Cancel();
                }
            });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo() {
                Type = typeof(SimpleButton), Text = "Order List", Name = "4", Image = ImageHelper.GetImageFromToolbarResource("OrderList"), mouseEventHandler = (s, e) => {
                    MakeGridVisible();
                }
            });
            listBI.Add(new ButtonInfo() {
                Type = typeof(SimpleButton), Text = "Sales Map", Name = "5", Image = ImageHelper.GetImageFromToolbarResource("SalesMap"), mouseEventHandler = (s, e) => {
                    MakeMapVisible();
                }
            });
            BottomPanel.InitializeButtons(listBI, false);
        }
        void returnButtonClick(object sender, EventArgs e) {
            if(CheckSave()) Return();
        }
        protected override void Return() {
            GetParentViewModel<MainViewModel>().SelectModule(ModuleType.CustomersModule);
        }
        static string key = "AmSNFwVzMvaqFlCYQx9RRUfcAwSQCzi_Vcesric6JFQuBO9wZFXEsqzili-INaUA";
        protected BingMapDataProvider CreateBingDataProvider(BingMapKind kind) {
            return new BingMapDataProvider() { BingKey = key, Kind = kind };
        }

        public CustomerViewModel ViewModel {
            get {
                return GetViewModel<CustomerViewModel>();
            }
        }
        public virtual void OnNavigatedFrom(INavigationArgs args) {
        }
        public virtual void OnNavigatedTo(INavigationArgs args) {
        }
        void rangeControl_RangeChanged(object sender, RangeControlRangeEventArgs range) {
            DateTime min, max;
            ViewModel.Minimum = min = (DateTime)range.Range.Minimum;
            ViewModel.Maximum = max = (DateTime)range.Range.Maximum;
            ordersView.ActiveFilterString = "[OrderDate] > #" + min.ToShortDateString() + "#  AND [OrderDate] < #" + max.ToShortDateString() + "#";
            customerMapView1.UpdateUI(ViewModel);
        }
    }
}
