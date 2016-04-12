using DevExpress.XtraCharts;
using PHRMS.ViewModels;
using System;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
namespace PHRMS.Widgets{
    public partial class GlobalStatsWidget : UserControl, IDashboardWidget
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
            IEnumerable<WorkTime> data = CacheStats(value);
            // Create an empty chart.
            ChartControl swiftChart = new ChartControl();
            //// Create a pie series.
            Series series1 = new Series("Temps de travail", ViewType.FullStackedBar);
            Series series2 = new Series("Temps de retards", ViewType.FullStackedBar);
            Series series3 = new Series("Temps supplémentaires", ViewType.FullStackedBar);
            Series series4 = new Series("Temps d'absence", ViewType.FullStackedBar);
            Series series5 = new Series("Temps de congés", ViewType.FullStackedBar);
            foreach (var at in data)
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
            // Access the view-type-specific options of the series.
            ((FullStackedBarSeriesView)series1.View).BarWidth = 0.4;

            // Access the type-specific options of the diagram.
            ((XYDiagram)swiftChart.Diagram).EnableAxisXZooming = true;
            swiftChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;




            // Hide the legend (if necessary).
            swiftChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            // Add the chart to the form.
            swiftChart.Dock = DockStyle.Fill;

            return swiftChart;
        }
        IEnumerable<WorkTime> CacheStats(BoardViewModel bv)
        {
            IEnumerable<WorkTime> result = null;
            if (File.Exists(Application.StartupPath + "\\Data\\globalstats.dat"))
            {

                if (DateTime.Now.Subtract(new FileInfo(Application.StartupPath + "\\Data\\globalstats.dat").LastWriteTime).TotalDays >= 1)
                {
                    result = bv.TotalWorkTime;

                    File.Delete(Application.StartupPath + "\\Data\\globalstats.dat");

                    Stream stream = File.Open(Application.StartupPath + "\\Data\\globalstats.dat", FileMode.Create);
                    BinaryFormatter bformatter = new BinaryFormatter();


                    bformatter.Serialize(stream, result);
                    stream.Close();
                }
                else // deserialize
                {

                    Stream stream = File.Open(Application.StartupPath + "\\Data\\globalstats.dat", FileMode.Open);
                    BinaryFormatter bformatter = new BinaryFormatter();

                    result = (IEnumerable<WorkTime>)bformatter.Deserialize(stream);
                    stream.Close();
        
                }
            }
            else
            {
                result = bv.TotalWorkTime;

                Stream stream = File.Open(Application.StartupPath + "\\Data\\globalstats.dat", FileMode.Create);
                BinaryFormatter bformatter = new BinaryFormatter();


                bformatter.Serialize(stream, result);
                stream.Close();
       
            }

            return result;
        }
      
        public void LoadDashboard(BoardViewModel value)
        {
            this.Controls.Add(GetWorkTimeChartControl(value));
        }
      
        public GlobalStatsWidget() {
            InitializeComponent();
        }
    }
}
