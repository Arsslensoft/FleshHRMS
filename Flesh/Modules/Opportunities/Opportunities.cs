using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.DevAV.ViewModels;
using DevExpress.DevAV.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using DevExpress.DevAV.Common.Utils;

namespace DevExpress.DevAV.Modules {
    public partial class Opportunities : BaseModuleControl {
        public Opportunities()
            : base(CreateViewModel<QuoteCollectionViewModel>) {
            InitializeComponent();
            InitializeData();
            rangeControl.RangeChanged += new DevExpress.XtraEditors.RangeChangedEventHandler(rangeControl_RangeChanged);
            MakeGridVisible();
        }
        private void rangeControl_RangeChanged(object sender, RangeControlRangeEventArgs range) {
            DateTime min, max;
            min = (DateTime)range.Range.Minimum;
            max = (DateTime)range.Range.Maximum;
            ViewModel.FilterExpression = e => e.Date > min && e.Date < max;
            opportunitiesBindingSource.SetItemsSource(ViewModel.Entities);
            if (chartControl.Series.Count == 0) {
                return;
            }
            chartControl.DataSource = ViewModel.GetQuoteInfos();
            if (ViewModel.Entities.Count > 0) {
                opportunitiesMapView1.Quote = ViewModel;
            }
        }

        private void InitializeData() {
            opportunitiesBindingSource.SetItemsSource(ViewModel.Entities);
            if (ViewModel.Entities.Count > 0) {
                opportunitiesMapView1.Quote = ViewModel;
            }
            chartControl.DataSource = ViewModel.GetQuoteInfos();
            chartControl.Series[0].ArgumentDataMember = "StageName";
            chartControl.Series[0].ValueDataMembers.AddRange(new string[] { "Summary" });
            dateTimeChartRangeControlClient1.DataProvider.DataSource = CreateViewModel<QuoteCollectionViewModel>().Entities.ToBindingList();
            dateTimeChartRangeControlClient1.DataProvider.ValueDataMember = "Total";
            dateTimeChartRangeControlClient1.DataProvider.ArgumentDataMember = "Date";
        }
        public QuoteCollectionViewModel ViewModel {
            get {
                return GetViewModel<QuoteCollectionViewModel>();
            }
        }
        protected internal override void OnTransitionCompleted() {
            base.OnTransitionCompleted();
            InitializeButtonPanel();
        }
        private void InitializeButtonPanel() {
            var listBI = new List<ButtonInfo>();
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Pivot Table", Name = "1", Image = ImageHelper.GetImageFromToolbarResource("PivotTable"), mouseEventHandler = (s, e) => {
                MakeGridVisible();
            } });
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Map View", Name = "2", Image = ImageHelper.GetImageFromToolbarResource("MapView"), mouseEventHandler = (s, e) => {
                MakeMapVisible();
            } });
            BottomPanel.InitializeButtons(listBI, false);
        }
        public void MakeMapVisible() {
            pivotGridControl.Visible = false;
            opportunitiesMapView1.Visible = true;

            ///pivotGridLCI.Visibility = XtraLayout.Utils.LayoutVisibility.Never;
        }
        public void MakeGridVisible() {
            pivotGridControl.Visible = true;
            opportunitiesMapView1.Visible = false;
        }
        private void pivotGridControl1_CustomCellValue(object sender, XtraPivotGrid.PivotCellValueEventArgs e) {
            if (e.DataField == fieldPercentage) {
                e.Value = Convert.ToDouble(e.Value) * 100;
            }
        }
        private void buttonHide_Click(object sender, EventArgs e) {
            if (chartControlLCI.Visibility == XtraLayout.Utils.LayoutVisibility.Always) {
                ItemsHideHelper.HideCore(new object[] { chartControlLCI }, buttonHide, true);
                return;
            }
            if (chartControlLCI.Visibility == XtraLayout.Utils.LayoutVisibility.Never) {
                ItemsHideHelper.ExpandCore(new object[] { chartControlLCI }, buttonHide, true);
                return;
            }
        }

        private void chartControl_CustomDrawSeriesPoint(object sender, XtraCharts.CustomDrawSeriesPointEventArgs e) {
            ChartControlLegendCustomPainter.Paint(e);
        }

        private void opportunities_Load(object sender, EventArgs e) {
        }
    }
}
