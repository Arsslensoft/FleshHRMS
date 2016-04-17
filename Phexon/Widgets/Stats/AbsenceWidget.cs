using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using PHRMS.Data;
using PHRMS.ViewModels;

namespace PHRMS.Widgets
{
    public partial class AbsenceWidget : UserControl, IDashboardWidget
    {
        public AbsenceWidget()
        {
            InitializeComponent();

            //SalesPerformanceDataGenerator.Current.UpdateDataSource += OnUpdateDataSource;
        }

        public void LoadDashboard(BoardViewModel value)
        {
            Controls.Add(GetAbsenceByTypeChartControl(value));
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

        public ChartControl GetAbsenceByTypeChartControl(BoardViewModel value)
        {
            DisplayAttribute dispatt = null;
            var data = CacheStats(value);
            // Create an empty chart.
            var pieChart = new ChartControl();
            // Create a pie series.
            var series1 = new Series("Absences par types", ViewType.Pie);
            foreach (var at in data)
            {
                dispatt = null;
                series1.Points.Add(
                    new SeriesPoint(
                        (dispatt = GetAttribute<DisplayAttribute>(at.Type)) != null ? dispatt.Name : at.Type.ToString(),
                        at.Percentage*100));
            }

            // Add the series to the chart.
            pieChart.Series.Add(series1);

            // Format the the series labels.
            series1.Label.TextPattern = "{A}: {VP:p0}";

            // Adjust the position of series labels. 
            ((PieSeriesLabel) series1.Label).Position = PieSeriesLabelPosition.TwoColumns;

            // Detect overlapping of series labels.
            ((PieSeriesLabel) series1.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;

            // Access the view-type-specific options of the series.
            var myView = (PieSeriesView) series1.View;

            // Show a title for the series.
            myView.Titles.Add(new SeriesTitle());
            myView.Titles[0].Text = series1.Name;


            myView.HeightToWidthRatio = 0.75;

            // Hide the legend (if necessary).
            pieChart.Legend.Visibility = DefaultBoolean.False;

            // Add the chart to the form.
            pieChart.Dock = DockStyle.Fill;

            return pieChart;
        }

        private IEnumerable<PercentageStats<AbsenceType>> CacheStats(BoardViewModel bv)
        {
            IEnumerable<PercentageStats<AbsenceType>> result = null;
            var filename = Application.StartupPath + "\\Data\\abstypestats.dat";
            if (File.Exists(filename))
            {
                if (DateTime.Now.Subtract(new FileInfo(filename).LastWriteTime).TotalDays >= 1)
                {
                    result = bv.AbsencesByType;

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

                    result = (IEnumerable<PercentageStats<AbsenceType>>) bformatter.Deserialize(stream);
                    stream.Close();
                }
            }
            else
            {
                result = bv.AbsencesByType;

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