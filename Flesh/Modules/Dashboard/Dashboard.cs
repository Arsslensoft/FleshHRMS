using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DevExpress.DevAV.ViewModels;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using DevExpress.DevAV.Common.Utils;
using DevExpress.DevAV.Helpers;

namespace DevExpress.DevAV.Modules {
    public enum Periods : int {
        Month = 1,
        Today = 2,
        Year = 0
    }
    public partial class Dashboard : BaseModuleControl {
        private List<DevExpress.DevAV.ViewModels.SalesInfo> listSales;
        private List<CostInfo> listCost;
        public Dashboard()
            : base(CreateViewModel<OrderCollectionViewModel>) {
            InitializeComponent();
            InitializeData();
        }
        private void InitializeData() {
            salesBindingSource.SetItemsSource(ViewModel.Entities);
            InitializeOpportunitiesChartControl();
            InitializeRevenuesChartControl();
            InitializeCostChartControl();
        }
        private void InitializeCostChartControl() {
            listCost = ViewModel.GetCostForDashboard();
            costChartControl.Series[0].ArgumentDataMember = "Name";
            costChartControl.Series[0].ValueDataMembers.AddRange(new string[] { "Value" });
            SetCostData(0);
        }
        private void InitializeRevenuesChartControl() {
            listSales = ViewModel.GetSalesForDashboard();
            SetRevenuesData(0);
            revenuesChartControl.Series[0].ArgumentDataMember = "Name";
            revenuesChartControl.Series[0].ValueDataMembers.AddRange(new string[] { "Value" });
        }
        private void InitializeOpportunitiesChartControl() {
            opportunitiesChartControl.Series[0].DataSource = CreateViewModel<QuoteCollectionViewModel>().GetQuoteInfos();
            opportunitiesChartControl.Series[0].ArgumentDataMember = "StageName";
            opportunitiesChartControl.Series[0].ValueDataMembers.AddRange(new string[] { "Summary" });
        }
        protected internal override void OnTransitionCompleted() {
            base.OnTransitionCompleted();
            InitializeButtonPanel();
        }
        private void InitializeButtonPanel() {
            BottomPanel.Visible = false;
        }
        public OrderCollectionViewModel ViewModel {
            get {
                return GetViewModel<OrderCollectionViewModel>();
            }
        }
        private void SetRevenuesData(Periods period) {
            revenuesChartControl.Series[0].DataSource = listSales[(int)period].ListProductInfo;
            revenuesChartControl.Refresh();
        }
        private void SetCostData(Periods period) {
            costChartControl.Series[0].DataSource = listCost[(int)period].ListProductInfo;
            costChartControl.Refresh();
        }
        private void todayRevenuesSimpleButton_Click(object sender, EventArgs e) {
            SetRevenuesData(Periods.Today);
        }
        private void monthRevenuesSimpleButton_Click(object sender, EventArgs e) {
            SetRevenuesData(Periods.Month);
        }
        private void yearRevenuesSimpleButton_Click(object sender, EventArgs e) {
            SetRevenuesData(Periods.Year);
        }
        private void todayCostSimpleButton_Click(object sender, EventArgs e) {
            SetCostData(Periods.Today);
        }
        private void monthCostSimpleButton_Click(object sender, EventArgs e) {
            SetCostData(Periods.Month);
        }
        private void yearCostSimpleButton_Click(object sender, EventArgs e) {
            SetCostData(Periods.Year);
        }

        private void revenuesChartControl_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e) {
            ChartControlLegendCustomPainter.Paint(e);
        }

        private void opportunitiesChartControl_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e) {
            ChartControlLegendCustomPainter.Paint(e);
        }
    }
    public class ChartControlLegendCustomPainter {
        public static void Paint(CustomDrawSeriesPointEventArgs e) {
            int imageSizeW = 18, imageSizeH = 14;
            var image = new Bitmap(imageSizeW, imageSizeH);
            using (var graphics = Graphics.FromImage(image)) {
                graphics.FillRectangle(new SolidBrush(e.LegendDrawOptions.Color), new Rectangle(new Point(0, 0), new Size(imageSizeW, imageSizeH)));
            }
            e.LegendMarkerImage = image;
            e.DisposeLegendMarkerImage = true;
            e.LegendMarkerVisible = true;
        }
    }
}
