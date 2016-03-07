using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.DevAV.ViewModels;
using DevExpress.DevAV.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using DevExpress.DevAV;
using DevExpress.XtraGrid;
using DevExpress.DevAV.Common.Utils;
using DevExpress.XtraBars.Ribbon;

namespace DevExpress.DevAV.Modules {
    public partial class Sales : BaseModuleControl {
        List<DevExpress.DevAV.ViewModels.SalesInfo> listSales;
        SearchControl searchControl;
        public Sales()
            : base(CreateViewModel<OrderCollectionViewModel>) {
            InitializeComponent();
            InitializeData();
        }


        void InitializeData() {
            listSales = ViewModel.GetSales();
            salesBindingSource.SetItemsSource(ViewModel.Entities);
            chartControl.Series[0].ArgumentDataMember = "Name";
            chartControl.Series[0].ValueDataMembers.AddRange(new string[] { "Value" });

            dateTimeChartRangeControlClient1.DataProvider.DataSource = CreateViewModel<OrderCollectionViewModel>().Entities.ToBindingList();
            dateTimeChartRangeControlClient1.DataProvider.ValueDataMember = "TotalAmount";
            dateTimeChartRangeControlClient1.DataProvider.ArgumentDataMember = "OrderDate";
            FillComboBox();
            RefreshChart(0);
        }

        void FillComboBox() {
            var index = 0;
            foreach(var si in listSales) {
                var caption = "Sales (FY" + si.time.Year + ")";
                si.Caption = caption;
                var gi = new GalleryItem() { Caption = caption, Tag = index };
                this.popupMenu1.Gallery.Groups[0].Items.Add(gi);
                index++;
            }
        }
        void Gallery_ItemClick(object sender, GalleryItemClickEventArgs e) {
            var index = (int)e.Item.Tag;
            RefreshChart(index);
        }

        void RefreshChart(int index) {
            dropDownButton1.Text = listSales[index].Caption;
            chartControl.Series[0].DataSource = listSales[index].ListProductInfo;
            chartControl.Refresh();
        }
        protected override void OnParentChanged(System.EventArgs e) {
            base.OnParentChanged(e);
            if(Parent != null) {
                InitializeButtonPanel();
            } else {
                searchControl.QueryIsSearchColumn -= searchControl_AllowSearchColumn;
            }
        }
        void InitializeButtonPanel() {
            var listBI = new List<ButtonInfo>();
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "View", Name = "2", Image = ImageHelper.GetImageFromToolbarResource("Edit"), mouseEventHandler = OnEditClick });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Print", Name = "4", Image = ImageHelper.GetImageFromToolbarResource("Print"), mouseEventHandler = OnPrintClick });
            BottomPanel.InitializeButtons(listBI);
            searchControl = BottomPanel.searchControl;
            BottomPanel.searchControl.Client = salesGridControl;
            BottomPanel.searchControl.QueryIsSearchColumn += new QueryIsSearchColumnEventHandler(searchControl_AllowSearchColumn);
        }

        void OnPrintClick(object sender, EventArgs e) {
            MainViewModel main = GetParentViewModel<MainViewModel>();
            main.SelectModule(ModuleType.SalesPrint, (x) => {
                ViewModelHelper.EnsureModuleViewModel(main.SelectedModule, GetParentViewModel<MainViewModel>(), salesGridControl);
                ((BaseModuleControl)main.SelectedModule).Refresh();
            });
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
        public OrderCollectionViewModel ViewModel {
            get {
                return GetViewModel<OrderCollectionViewModel>();
            }
        }

        void collapseButton_Click(object sender, EventArgs e) {
            if(lcgChart.Visibility == XtraLayout.Utils.LayoutVisibility.Always) {
                ItemsHideHelper.HideCore(new object[] { lcgChart }, buttonHide, true);
                return;
            }
            if(lcgChart.Visibility == XtraLayout.Utils.LayoutVisibility.Never) {
                ItemsHideHelper.ExpandCore(new object[] { lcgChart }, buttonHide, true);
                return;
            }
        }
        void dropDownButton1_Click(object sender, EventArgs e) {
            popupMenu1.MenuBarWidth = 0;
            popupMenu1.MinWidth = dropDownButton1.Width;
            dropDownButton1.ShowDropDown();
        }

        void rangeControl_RangeChanged(object sender, RangeControlRangeEventArgs range) {
            DateTime min, max;
            min = (DateTime)range.Range.Minimum;
            max = (DateTime)range.Range.Maximum;
            ViewModel.FilterExpression = e => e.OrderDate > min && e.OrderDate < max;
            salesBindingSource.SetItemsSource(ViewModel.Entities);
        }
        void OnEditClick(object sender, EventArgs e) {
            ShowSale(salesGridView.GetFocusedRow());
        }
        void salesGridView_RowClick(object sender, XtraGrid.Views.Grid.RowClickEventArgs e) {
            if(e.Clicks > 1 && e.RowHandle >= 0) {
                ShowSale(salesGridView.GetFocusedRow());
            }
        }

        void ShowSale(object data) {
            if(data == null) {
                return;
            }
            var dataObject = data as DatabaseObject;
            var main = GetParentViewModel<MainViewModel>();
            main.SelectModule(ModuleType.OrderView, (x) => {
                ViewModelHelper.EnsureModuleViewModel(main.SelectedModule, GetParentViewModel<MainViewModel>(), dataObject.Id);
                ((BaseModuleControl)main.SelectedModule).Refresh();
            });
        }

        void chartControl_CustomDrawSeriesPoint(object sender, XtraCharts.CustomDrawSeriesPointEventArgs e) {
            ChartControlLegendCustomPainter.Paint(e);
        }

        void salesGridView_FocusedRowObjectChanged(object sender, XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e) {
            ViewModel.SelectedEntity = e.Row as Order;
        }

    }
}
