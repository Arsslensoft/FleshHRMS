namespace FHRMS.Widgets
{
    partial class ucChartProductItem {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        
        #region Component Designer generated code   

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.SwiftPlotDiagram swiftPlotDiagram1 = new DevExpress.XtraCharts.SwiftPlotDiagram();
            DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView1 = new DevExpress.XtraCharts.SwiftPlotSeriesView();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.monthlySalesItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlySalesItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // chartControl1
            // 
            this.chartControl1.BorderOptions.Color = System.Drawing.Color.White;
            this.chartControl1.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl1.DataSource = this.monthlySalesItemBindingSource;
            swiftPlotDiagram1.AxisX.DateTimeScaleOptions.AggregateFunction = DevExpress.XtraCharts.AggregateFunction.None;
            swiftPlotDiagram1.AxisX.DateTimeScaleOptions.GridOffset = 1D;
            swiftPlotDiagram1.AxisX.DateTimeScaleOptions.ScaleMode = DevExpress.XtraCharts.ScaleMode.Manual;
            swiftPlotDiagram1.AxisX.Label.ResolveOverlappingOptions.MinIndent = 2;
            swiftPlotDiagram1.AxisX.Label.TextPattern = "{A:MMMM}";
            swiftPlotDiagram1.AxisX.MinorCount = 5;
            swiftPlotDiagram1.AxisX.Tickmarks.MinorLength = 1;
            swiftPlotDiagram1.AxisX.Tickmarks.Thickness = 2;
            swiftPlotDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram1.AxisX.WholeRange.AutoSideMargins = false;
            swiftPlotDiagram1.AxisX.WholeRange.SideMarginsValue = 8D;
            swiftPlotDiagram1.AxisY.Title.Text = "Revenue";
            swiftPlotDiagram1.AxisY.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(134)))), ((int)(((byte)(206)))));
            swiftPlotDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = swiftPlotDiagram1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.chartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
            this.chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartControl1.Legend.EquallySpacedItems = false;
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.SeriesDataMember = "Product";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControl1.SeriesTemplate.ArgumentDataMember = "CurrentDate";
            this.chartControl1.SeriesTemplate.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.DateTime;
            this.chartControl1.SeriesTemplate.SummaryFunction = "SUM([Revenue])";
            swiftPlotSeriesView1.Antialiasing = true;
            swiftPlotSeriesView1.LineStyle.Thickness = 2;
            this.chartControl1.SeriesTemplate.View = swiftPlotSeriesView1;
            this.chartControl1.Size = new System.Drawing.Size(764, 415);
            this.chartControl1.TabIndex = 0;
            // 
            // monthlySalesItemBindingSource
            // 
            this.monthlySalesItemBindingSource.DataSource = typeof(FHRMS.Data.Absence);
            // 
            // ucChartProductItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartControl1);
            this.Name = "ucChartProductItem";
            this.Size = new System.Drawing.Size(764, 415);
            ((System.ComponentModel.ISupportInitialize)(swiftPlotDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlySalesItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.BindingSource monthlySalesItemBindingSource;


    }
}
