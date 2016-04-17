using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using PHRMS.ViewModels;

namespace PHRMS.Widgets
{
    public partial class AbsenceByDateWidget : UserControl, IDashboardWidget
    {
        public AbsenceByDateWidget()
        {
            InitializeComponent();

            //SalesPerformanceDataGenerator.Current.UpdateDataSource += OnUpdateDataSource;
        }

        public void LoadDashboard(BoardViewModel value)
        {
            Controls.Add(GetAbsencesByDateChartControl(value));
        }

        public static T GetAttribute<T>(Enum enumValue) where T : Attribute
        {
            T attribute;

            var memberInfo = enumValue.GetType().GetMember(enumValue.ToString())
                .FirstOrDefault();

            if (memberInfo != null)
            {
                attribute = (T) memberInfo.GetCustomAttributes(typeof(T), false).FirstOrDefault();
                return attribute;
            }
            return null;
        }


        public ChartControl GetAbsencesByDateChartControl(BoardViewModel value)
        {
            // Create an empty chart.
            var sideBySideBarChart = new ChartControl();
            var data = CacheStats(value);
            // Create the first side-by-side bar series and add points to it.
            var series1 = new Series("Absences par date", ViewType.Bar);

            foreach (var at in data)
                series1.Points.Add(new SeriesPoint(at.Date, at.Count));


            // Add the series to the chart.
            sideBySideBarChart.Series.Add(series1);

            // Hide the legend (if necessary).
            sideBySideBarChart.Legend.Visibility = DefaultBoolean.False;


            // Add a title to the chart (if necessary).
            var chartTitle1 = new ChartTitle();
            chartTitle1.Text = "Side-by-Side Bar Chart";
            sideBySideBarChart.Titles.Add(chartTitle1);

            // Add the chart to the form.
            sideBySideBarChart.Dock = DockStyle.Fill;
            return sideBySideBarChart;
        }

        private IEnumerable<DailyAbsence> CacheStats(BoardViewModel bv)
        {
            IEnumerable<DailyAbsence> result = null;
            var filename = Application.StartupPath + "\\Data\\absdatestat.dat";
            if (File.Exists(filename))
            {
                if (DateTime.Now.Subtract(new FileInfo(filename).LastWriteTime).TotalDays >= 1)
                {
                    result = bv.DailyAbsences;

                    File.Delete(filename);

                    Stream stream = File.Open(filename, FileMode.Create);
                    var bformatter = new BinaryFormatter();


                    bformatter.Serialize(stream, result);
                    stream.Close();
                }
                else // deserialize
                {
                    Stream stream = File.Open(filename, FileMode.Open);
                    var bformatter = new BinaryFormatter();

                    result = (IEnumerable<DailyAbsence>) bformatter.Deserialize(stream);
                    stream.Close();
                }
            }
            else
            {
                result = bv.DailyAbsences;

                Stream stream = File.Open(filename, FileMode.Create);
                var bformatter = new BinaryFormatter();


                bformatter.Serialize(stream, result);
                stream.Close();
            }

            return result;
        }

        protected override void Dispose(bool disposing)
        {
            //SalesPerformanceDataGenerator.Current.UpdateDataSource -= OnUpdateDataSource;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void OnUpdateDataSource(object sender, EventArgs e)
        {
            // monthlySalesItemBindingSource.DataSource = SalesPerformanceDataGenerator.Current.MonthlySales;
        }
    }
}