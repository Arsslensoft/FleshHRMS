using DevExpress.DevAV.Helpers;
using DevExpress.DevAV.ViewModels;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.DevAV;
using System.Drawing;
using System.Linq;
using System;
using DevExpress.DevAV.Common.ViewModel;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.DevAV.Common.Utils;

namespace DevExpress.DevAV.Modules {
    public enum CustomersFilter {
        AllStores,
        MyAccount,
        JohnAccount,
        TopStores
    }
    public partial class CustomersModule : BaseModuleControl {
        SearchControl searchControl;
        TileBar customerTileBar;
        public CustomersModule()
            : base(CreateViewModel<CustomerCollectionViewModel>) {
            InitializeComponent();
            LoadData();
        }

        protected override void OnFontChanged(System.EventArgs e) {
            base.OnFontChanged(e);
        }
        protected override bool ScaleChildren {
            get {
                return base.ScaleChildren;
            }
        }
        protected override void ScaleControl(SizeF factor, BoundsSpecified specified) {
            base.ScaleControl(factor, specified);
        }
        protected internal override void OnTransitionCompleted() {
            base.OnTransitionCompleted();
            InitializeButtonPanel();
        }
        protected override void OnParentChanged(System.EventArgs e) {
            base.OnParentChanged(e);
            if(Parent != null) {
                SubscribeTileBarCustomersFilter();
            }
            else {
                if(searchControl != null)searchControl.QueryIsSearchColumn -= searchControl_AllowSearchColumn;
                customerTileBar.ItemClick -= CustomerTileBar_ItemClick;
            }
        }

        void SubscribeTileBarCustomersFilter() {
            customerTileBar = CustomerTileBar;
            CustomerTileBar.ItemClick += CustomerTileBar_ItemClick;
        }

        void CustomerTileBar_ItemClick(object sender, TileItemEventArgs e) {
            if(e.Item.Tag is CustomersFilter) {
                viewCustomers.ActiveFilter.Clear();
                CustomersFilter filter = (CustomersFilter)e.Item.Tag;
                switch(filter) {
                    case CustomersFilter.MyAccount:
                        viewCustomers.ActiveFilter.Add(viewCustomers.Columns["HomeOffice.State"], new ColumnFilterInfo(CriteriaOperator.Parse("HomeOffice.State == 'CA'")));
                        break;
                    case CustomersFilter.JohnAccount:
                        viewCustomers.ActiveFilter.Add(viewCustomers.Columns["HomeOffice.State"], new ColumnFilterInfo(CriteriaOperator.Parse("HomeOffice.State == 'WA'")));
                        break;
                    case CustomersFilter.TopStores:
                        viewCustomers.ActiveFilter.Add(viewCustomers.Columns["AnnualRevenue"], new ColumnFilterInfo(CriteriaOperator.Parse("AnnualRevenue >= 90000000000M")));
                        break;
                }
            }
            if(e.Item.Tag is string) {
                SetFilterString((string)e.Item.Tag);
            }
        }
        public CustomerCollectionViewModel ViewModel {
            get {
                return GetViewModel<CustomerCollectionViewModel>();
            }
        }
        void LoadData() {
            customerBindingSource.DataSource = ViewModel.Entities.Where(e => e.Employees.Count > 0);
        }

        void gridView1_CustomUnboundColumnData(object sender, XtraGrid.Views.Base.CustomColumnDataEventArgs e) {
            if(e.Column.ColumnEdit is RepositoryItemSparklineEdit) {
                e.Value = ViewModel.GetMonthlySalesByCustomer((Customer)e.Row);
            }
        }

        void InitializeButtonPanel() {
            var listBI = new List<ButtonInfo>();
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "New", Name = "2", Image = ImageHelper.GetImageFromToolbarResource("New"), mouseEventHandler = newMouseClick });
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Edit", Name = "3", Image = ImageHelper.GetImageFromToolbarResource("Edit"), mouseEventHandler = editMouseClick });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Custom Filter", Name = "6", Image = ImageHelper.GetImageFromToolbarResource("CustomFilter"), mouseEventHandler = customFilterClick });
            BottomPanel.InitializeButtons(listBI);
            searchControl = BottomPanel.searchControl;
            BottomPanel.searchControl.Client = gridCustomers;
            BottomPanel.searchControl.QueryIsSearchColumn += new QueryIsSearchColumnEventHandler(searchControl_AllowSearchColumn);
        }
        private bool SetFilterString(string filterString) {
            viewCustomers.ActiveFilter.Clear();
            try {
                viewCustomers.ActiveFilterCriteria = CriteriaOperator.TryParse(filterString);
                return true;
            } catch {
                return false;
            }
        }

        void customFilterClick(object sender, EventArgs e) {
            CustomersFilterModule customFilter = new CustomersFilterModule(ViewModel.Entities.ToBindingList());
            DialogResult result = FlyoutDialog.Show(FindForm(), customFilter);
            if(result == DialogResult.OK) {
                if(customFilter.checkEdit.Checked) {
                    if(SetFilterString(customFilter.filterControl.FilterString))
                        CustomerTileBar.Groups[0].Items.Add(new TileBarItem() { TextAlignment = TileItemContentAlignment.MiddleCenter, Text = customFilter.textEdit.Text, Tag = customFilter.filterControl.FilterString });
                } else {
                    SetFilterString(customFilter.filterControl.FilterString);
                }

            }
        }
        void newMouseClick(object sender, System.EventArgs e) {
            ShowCustomerEdit(null);
        }

        void editMouseClick(object sender, System.EventArgs e) {
            ShowCustomerEditForFocused();
        }

        private void ShowCustomerEditForFocused() {
            var customer = viewCustomers.GetFocusedRow() as Customer;
            if(customer == null) return;
            ShowCustomerEdit(customer);
        }
        void searchControl_AllowSearchColumn(object sender, QueryIsSearchColumnEventArgs e) {
            var column = sender as DevExpress.XtraEditors.Filtering.FilterColumn;
            if(column == null) {
                return;
            }
            if(column.FieldName != string.Empty) {
                e.IsSearchColumn = true;
            } else {
                e.IsSearchColumn = false;
            }
        }
        void ShowCustomerEdit(Customer customer) {
            var main = GetParentViewModel<MainViewModel>();
            main.SelectModule(ModuleType.CustomerEditableView, (x) => {
                if(customer != null) {
                    ViewModelHelper.EnsureModuleViewModel(main.SelectedModule, GetParentViewModel<MainViewModel>(), customer.Id);
                }
                else {
                    ViewModelHelper.EnsureModuleViewModel(main.SelectedModule, GetParentViewModel<MainViewModel>(), new DefaultEntityInitializer<Customer, DevAV.DevAVDbDataModel.IDevAVDbUnitOfWork>());
                }
                ((BaseModuleControl)main.SelectedModule).Refresh();
            });
        }

        private void viewCustomers_FocusedRowObjectChanged(object sender, XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e) {
            var customer = e.Row as Customer;
            if(customer == null) return;
            customerEmployeeBindingSource.DataSource = customer.Employees;
            customerStoreBindingSource.DataSource = ViewModel.GetCustomerStoresByCustomer(customer);
            labelControl1.Text = customer.Name;
            ViewModel.SelectedEntity = customer;
        }
        protected bool IsStorsViewVisible() {
            return storesGridLCI.Visibility == XtraLayout.Utils.LayoutVisibility.Always;
        }
        void barButtonItemStores_ItemClick(object sender, XtraBars.ItemClickEventArgs e) {
            storesGridLCI.Visibility = XtraLayout.Utils.LayoutVisibility.Always;
            employeeGridLCI.Visibility = XtraLayout.Utils.LayoutVisibility.Never;
            dropDownButton1.Text = "Stores";
        }

        void barButtonItemContacts_ItemClick(object sender, XtraBars.ItemClickEventArgs e) {
            storesGridLCI.Visibility = XtraLayout.Utils.LayoutVisibility.Never;
            employeeGridLCI.Visibility = XtraLayout.Utils.LayoutVisibility.Always;
            dropDownButton1.Text = "Contacts";
        }

        void gridView1_CustomDrawFooterCell(object sender, XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e) {
            e.Info.AllowDrawBackground = false;
        }

        void gridView1_CustomSummaryCalculate(object sender, Data.CustomSummaryEventArgs e) {
            var gs = (GridSummaryItem)e.Item;
            if(object.Equals(gs.Tag, "FY2013")) {
                e.TotalValue = ViewModel.GetTotalSales(viewCustomers.DataController.GetAllFilteredAndSortedRows());
                e.TotalValueReady = true;
            }
        }

        void dropDownButton1_ShowDropDownControl(object sender, ShowDropDownControlEventArgs e) {
            popupMenu1.MinWidth = dropDownButton1.Width;
        }

        void dropDownButton1_Click(object sender, System.EventArgs e) {
            dropDownButton1.ShowDropDown();
        }

        private void viewCustomers_RowClick(object sender, XtraGrid.Views.Grid.RowClickEventArgs e) {
            if(e.Clicks > 1 && e.RowHandle >= 0) ShowCustomerEditForFocused();
        }

    }
}
