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
    public partial class WarningsWidget : UserControl, IDashboardWidget
    {
        public WarningsWidget()
        {
            InitializeComponent();

            //SalesPerformanceDataGenerator.Current.UpdateDataSource += OnUpdateDataSource;
        }

        public void LoadDashboard(BoardViewModel value)
        {
            Controls.Add(GetWarningsBySeverityChartControl(value));
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


        public ChartControl GetWarningsBySeverityChartControl(BoardViewModel value)
        {
            DisplayAttribute dispatt = null;
            var data = CacheStats(value);
            // Create an empty chart.
            var DoughnutChart = new ChartControl();
            // Create a pie series.
            var series1 = new Series("Avertissements par sévérité", ViewType.Doughnut);
            foreach (var at in data)
            {
                dispatt = null;
                series1.Points.Add(
                    new SeriesPoint(
                        (dispatt = GetAttribute<DisplayAttribute>(at.Type)) != null ? dispatt.Name : at.Type.ToString(),
                        at.Percentage*100));
            }

            // Add the series to the chart.
            DoughnutChart.Series.Add(series1);

            // Format the the series labels.
            series1.Label.TextPattern = "{A}: {VP:p0}";

            series1.Label.TextPattern = "{A}: {VP:P0}";

            // Specify how series points are sorted.
            series1.SeriesPointsSorting = SortingMode.Ascending;
            series1.SeriesPointsSortingKey = SeriesPointKey.Argument;

            // Specify the behavior of series labels.
            ((DoughnutSeriesLabel) series1.Label).Position = PieSeriesLabelPosition.TwoColumns;
            ((DoughnutSeriesLabel) series1.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;
            ((DoughnutSeriesLabel) series1.Label).ResolveOverlappingMinIndent = 5;


            // Access the diagram's options.
            ((SimpleDiagram) DoughnutChart.Diagram).Dimension = 2;

            // Add a title to the chart and hide the legend.
            var chartTitle1 = new ChartTitle();
            chartTitle1.Text = "Avertissements par sévérité";
            DoughnutChart.Titles.Add(chartTitle1);
            DoughnutChart.Legend.Visibility = DefaultBoolean.False;
            DoughnutChart.Dock = DockStyle.Fill;

            return DoughnutChart;
        }

        private IEnumerable<PercentageStats<WarningSeverity>> CacheStats(BoardViewModel bv)
        {
            IEnumerable<PercentageStats<WarningSeverity>> result = null;
            var filename = Application.StartupPath + "\\Data\\warnSEVstats.dat";
            if (File.Exists(filename))
            {
                if (DateTime.Now.Subtract(new FileInfo(filename).LastWriteTime).TotalDays >= 1)
                {
                    result = bv.WarningBySeverity;

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

                    result = (IEnumerable<PercentageStats<WarningSeverity>>) bformatter.Deserialize(stream);
                    stream.Close();
                }
            }
            else
            {
                result = bv.WarningBySeverity;

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