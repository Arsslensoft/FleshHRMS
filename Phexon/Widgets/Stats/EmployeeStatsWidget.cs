using DevExpress.XtraCharts;
using PHRMS.ViewModels;
using System;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;
using PHRMS.Data;
namespace PHRMS.Widgets{
    public partial class EmployeeStatsWidget : UserControl, IDashboardWidget
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
        public ChartControl GetWorkTimeChartControl(BoardViewModel value)
        {

            // Create an empty chart.
            ChartControl swiftChart = new ChartControl();
            //// Create a pie series.
            Series series1 = new Series("Temps de travail", ViewType.SideBySideStackedBar);
            Series series2 = new Series("Temps de retards", ViewType.SideBySideStackedBar);
            Series series3 = new Series("Temps supplémentaires", ViewType.SideBySideStackedBar);
            Series series4 = new Series("Temps d'absence", ViewType.SideBySideStackedBar);
            Series series5 = new Series("Temps de congés", ViewType.SideBySideStackedBar);
            foreach (var at in value.GetEmployeeWorkTimes((lookUpEdit1.EditValue as Employee).Id))
            {

                series1.Points.Add(new SeriesPoint(at.Date, at.TotalWorkingTime.TotalHours));
                series2.Points.Add(new SeriesPoint(at.Date, at.TotalLateTime.TotalHours));
                series3.Points.Add(new SeriesPoint(at.Date, at.TotalOverTime.TotalHours));
                series4.Points.Add(new SeriesPoint(at.Date, at.TotalAbsentTime.TotalHours));
                series5.Points.Add(new SeriesPoint(at.Date, at.TotalLeaveTime.TotalHours));
            }

            swiftChart.Series.Add(series1);
            swiftChart.Series.Add(series2);
            swiftChart.Series.Add(series3);
            swiftChart.Series.Add(series4);
            swiftChart.Series.Add(series5);
            // Specify data members to bind the series.
            series1.ArgumentScaleType = ScaleType.DateTime;
            series1.ValueScaleType = ScaleType.Numerical;
           // series1.View = swiftPlotSeriesView1;
            // Group the first two series under the same stack.
            ((SideBySideStackedBarSeriesView)series1.View).StackedGroup = 0;
            ((SideBySideStackedBarSeriesView)series2.View).StackedGroup = 0;

            // Access the type-specific options of the diagram.
            ((XYDiagram)swiftChart.Diagram).EnableAxisXZooming = true;

            swiftChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;




            // Hide the legend (if necessary).
            swiftChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            // Add the chart to the form.
            swiftChart.Dock = DockStyle.Fill;

            return swiftChart;
        }

        BoardViewModel v;
        public void LoadDashboard(BoardViewModel value)
        {
            v = value;
            lookUpEdit1.Properties.DataSource = value.EmployeesViewModel.Entities.ToList();
  
        }

        public EmployeeStatsWidget()
        {
            InitializeComponent();
            bindingSource1.DataSource = new EmployeeStats();

        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit1.EditValue is Employee)
            {
                if(this.Controls.Count == 2)
                 this.Controls.RemoveAt(1);
                this.Controls.Add(GetWorkTimeChartControl(v));
            }
        }
    }
    class EmployeeStats
    {
        public Employee Employee { get; set; }
    }
}
