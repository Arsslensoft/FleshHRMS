using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FHRMS.ViewModels;
using FHRMS.Modules;
using DevExpress.XtraCharts;
using System.Reflection;

namespace FHRMS.Widgets
{
    public partial class LeaveByTypeWidget : UserControl, IDashboardWidget
    {
        public static T GetAttribute<T>(Enum enumValue) where T : Attribute
        {
            T attribute;

            MemberInfo memberInfo = enumValue.GetType().GetMember(enumValue.ToString())
                                            .FirstOrDefault();

            if (memberInfo != null)
            {
                attribute = (T)memberInfo.GetCustomAttributes(typeof(T), false).FirstOrDefault();
                return attribute;
            }
            return null;
        }
    
  
        public ChartControl GetLeavesByTypeChartControl(BoardViewModel value)
        {
            System.ComponentModel.DataAnnotations.DisplayAttribute dispatt = null;
            // Create an empty chart.
            ChartControl pieChart = new ChartControl();
            // Create a pie series.
            Series series1 = new Series("Congés par types", ViewType.Pie);
            foreach (var at in value.LeavesByType)
            {
                dispatt = null;
                series1.Points.Add(new SeriesPoint((dispatt = GetAttribute<System.ComponentModel.DataAnnotations.DisplayAttribute>(at.Type)) != null ? dispatt.Name : at.Type.ToString(), at.Percentage * 100));
            }

            // Add the series to the chart.
            pieChart.Series.Add(series1);

            // Format the the series labels.
            series1.Label.TextPattern = "{A}: {VP:p0}";

            // Adjust the position of series labels. 
            ((PieSeriesLabel)series1.Label).Position = PieSeriesLabelPosition.TwoColumns;

            // Detect overlapping of series labels.
            ((PieSeriesLabel)series1.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;

            // Access the view-type-specific options of the series.
            PieSeriesView myView = (PieSeriesView)series1.View;

            // Show a title for the series.
            myView.Titles.Add(new SeriesTitle());
            myView.Titles[0].Text = series1.Name;

            myView.HeightToWidthRatio = 0.75;

            // Hide the legend (if necessary).
            pieChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            // Add the chart to the form.
            pieChart.Dock = DockStyle.Fill;

            return pieChart;
        }
   

        public  void LoadDashboard(BoardViewModel value)
        {
            this.Controls.Add(GetLeavesByTypeChartControl(value));
        }


        public LeaveByTypeWidget()
        {
            InitializeComponent();
           
            //SalesPerformanceDataGenerator.Current.UpdateDataSource += OnUpdateDataSource;

        }
        protected override void Dispose(bool disposing) {
            
            //SalesPerformanceDataGenerator.Current.UpdateDataSource -= OnUpdateDataSource;
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        void OnUpdateDataSource(object sender, EventArgs e) {
           // monthlySalesItemBindingSource.DataSource = SalesPerformanceDataGenerator.Current.MonthlySales;
        }
    }
 
}
