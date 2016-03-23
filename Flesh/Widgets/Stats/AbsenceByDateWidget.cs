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
    public partial class AbsenceByDateWidget : UserControl, IDashboardWidget
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
    
    
        public ChartControl GetAbsencesByDateChartControl(BoardViewModel value)
        {
         

            // Create an empty chart.
            ChartControl sideBySideBarChart = new ChartControl();

            // Create the first side-by-side bar series and add points to it.
            Series series1 = new Series("Absences par date", ViewType.Bar);

            foreach (var at in value.DailyAbsences)
                series1.Points.Add(new SeriesPoint(at.Date, at.Count));

         
            // Add the series to the chart.
            sideBySideBarChart.Series.Add(series1);

            // Hide the legend (if necessary).
            sideBySideBarChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;


            // Add a title to the chart (if necessary).
            ChartTitle chartTitle1 = new ChartTitle();
            chartTitle1.Text = "Side-by-Side Bar Chart";
            sideBySideBarChart.Titles.Add(chartTitle1);

            // Add the chart to the form.
            sideBySideBarChart.Dock = DockStyle.Fill;
            return sideBySideBarChart;
        }


        public  void LoadDashboard(BoardViewModel value)
        {
            this.Controls.Add(GetAbsencesByDateChartControl(value));
        }


        public AbsenceByDateWidget()
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
