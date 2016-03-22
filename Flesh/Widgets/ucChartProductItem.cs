using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FHRMS.ViewModels;

namespace FHRMS.Widgets
{
    public partial class ucChartProductItem : UserControl, IDashboardWidget
    {
        public NotificationCollectionViewModel ViewModel
        {
            set
            {
                value.
                // Specify data members to bind the chart's series template.
                chartControl1.SeriesDataMember = "Month";
                chartControl1.SeriesTemplate.ArgumentDataMember = "Date";
                chartControl1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Value" });
                gridControl1.SetItemsSource(value.Entities);
            }

        }
        public ucChartProductItem() {
            InitializeComponent();
           
            //SalesPerformanceDataGenerator.Current.UpdateDataSource += OnUpdateDataSource;
            //monthlySalesItemBindingSource.DataSource = SalesPerformanceDataGenerator.Current.MonthlySales;
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
