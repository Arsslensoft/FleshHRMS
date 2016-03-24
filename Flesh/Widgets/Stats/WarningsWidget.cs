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
    public partial class WarningsWidget : UserControl, IDashboardWidget
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
    
    
        public ChartControl GetWarningsBySeverityChartControl(BoardViewModel value)
        {
            System.ComponentModel.DataAnnotations.DisplayAttribute dispatt = null;
            var data = CacheStats(value);
            // Create an empty chart.
            ChartControl DoughnutChart = new ChartControl();
            // Create a pie series.
            Series series1 = new Series("Avertissements par sévérité", ViewType.Doughnut);
            foreach (var at in data)
            {
                dispatt = null;
                series1.Points.Add(new SeriesPoint((dispatt = GetAttribute<System.ComponentModel.DataAnnotations.DisplayAttribute>(at.Type)) != null ? dispatt.Name : at.Type.ToString(), at.Percentage * 100));
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
            ((DoughnutSeriesLabel)series1.Label).Position = PieSeriesLabelPosition.TwoColumns;
            ((DoughnutSeriesLabel)series1.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;
            ((DoughnutSeriesLabel)series1.Label).ResolveOverlappingMinIndent = 5;

     

            // Access the diagram's options.
            ((SimpleDiagram)DoughnutChart.Diagram).Dimension = 2;

            // Add a title to the chart and hide the legend.
            ChartTitle chartTitle1 = new ChartTitle();
            chartTitle1.Text = "Avertissements par sévérité";
            DoughnutChart.Titles.Add(chartTitle1);
            DoughnutChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            DoughnutChart.Dock = DockStyle.Fill;

            return DoughnutChart;
        }
        IEnumerable<PercentageStats<Data.WarningSeverity>> CacheStats(BoardViewModel bv)
        {
            IEnumerable<PercentageStats<Data.WarningSeverity>> result = null;
            string filename = Application.StartupPath + "\\Data\\warnSEVstats.dat";
            if (System.IO.File.Exists(filename))
            {

                if (DateTime.Now.Subtract(new System.IO.FileInfo(filename).LastWriteTime).TotalDays >= 1)
                {
                    result = bv.WarningBySeverity;

                    System.IO.File.Delete(filename);

                    System.IO.Stream stream = System.IO.File.Open(filename, System.IO.FileMode.Create);
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();


                    bformatter.Serialize(stream, result);
                    stream.Close();
                }
                else // deserialize
                {

                    System.IO.Stream stream = System.IO.File.Open(filename, System.IO.FileMode.Open);
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    result = (IEnumerable<PercentageStats<Data.WarningSeverity>>)bformatter.Deserialize(stream);
                    stream.Close();

                }
            }
            else
            {
                result = bv.WarningBySeverity;

                System.IO.Stream stream = System.IO.File.Open(filename, System.IO.FileMode.Create);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();


                bformatter.Serialize(stream, result);
                stream.Close();

            }

            return result;
        }

        public  void LoadDashboard(BoardViewModel value)
        {
            this.Controls.Add(GetWarningsBySeverityChartControl(value));
        }


        public WarningsWidget()
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
