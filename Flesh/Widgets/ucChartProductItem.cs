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

namespace FHRMS.Widgets
{
    public partial class ucChartProductItem : UserControl, IDashboardWidget
    {
        StatisticsController sc;
        Dashboard dash;
        public Dashboard Dashboard
        {
            set
            {
                dash = value;
                sc = new StatisticsController(dash.NotesViewModel);
                monthlySalesItemBindingSource.DataSource = sc.DailyAbsences;
                Series series = new Series("Absences", ViewType.SwiftPlot);
                chartControl1.Series.Add(series);
                // Specify data members to bind the series.
                series.ArgumentScaleType = ScaleType.DateTime;
                series.ArgumentDataMember = "Date";
                series.ValueScaleType = ScaleType.Numerical;
                series.ValueDataMembers.AddRange(new string[] { "Count" });
                series.View = swiftPlotSeriesView1;
                ((SwiftPlotDiagram)chartControl1.Diagram).AxisY.Visibility = DevExpress.Utils.DefaultBoolean.False;
                chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;


                foreach (DailyAbsence a in sc.DailyAbsences)
                    chartControl1.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint(a.Date, a.Count));
            }

        }
        public ucChartProductItem() {
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
    #region Statistics
    public class DailyAbsence
    {
        public DailyAbsence(DateTime d, int c)
        {
            Date = d;
            Count = c;
        }
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
    public class StatisticsController
    {
        public StatisticsController(EvaluationCollectionViewModel ab)
        {
            AbsenceModel = ab;
        }
        public EvaluationCollectionViewModel AbsenceModel { get; set; }
        public IEnumerable<DailyAbsence> DailyAbsences
        {
            get
            {
                var abs = from p in AbsenceModel.Entities
                              group p.Id by p.StartDate.Date into g
                              select new { AbsenceDate = g.Key, Absences = g.ToList() };
                List<DailyAbsence> result = new List<DailyAbsence>();

                foreach (var item in abs)
                    result.Add(new DailyAbsence(item.AbsenceDate, item.Absences.Count));
                
                
                return result;
            }
        }
    }
    #endregion
}
