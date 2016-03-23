namespace FHRMS.Widgets
{
    partial class WarningsWidget
    {
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
            swiftPlotSeriesView1 = new DevExpress.XtraCharts.SwiftPlotSeriesView();
            this.monthlySalesItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.monthlySalesItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            this.SuspendLayout();

            // 
            // chartControl1
            // 
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControl1.Size = new System.Drawing.Size(764, 415);
            this.chartControl1.TabIndex = 0;
            swiftPlotDiagram1.AxisX.DateTimeScaleOptions.AggregateFunction = DevExpress.XtraCharts.AggregateFunction.None;
            swiftPlotDiagram1.AxisX.DateTimeScaleOptions.GridOffset = 1D;
            swiftPlotDiagram1.AxisX.DateTimeScaleOptions.ScaleMode = DevExpress.XtraCharts.ScaleMode.Manual;
            swiftPlotDiagram1.AxisX.Label.ResolveOverlappingOptions.MinIndent = 2;
            swiftPlotDiagram1.AxisX.MinorCount = 5;
            swiftPlotDiagram1.AxisX.Tickmarks.MinorLength = 1;
            swiftPlotDiagram1.AxisX.Tickmarks.Thickness = 2;
            swiftPlotDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram1.AxisX.WholeRange.AutoSideMargins = false;
            swiftPlotDiagram1.AxisX.WholeRange.SideMarginsValue = 8D;
            swiftPlotDiagram1.AxisY.Title.Text = "Count";
            swiftPlotDiagram1.AxisY.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(134)))), ((int)(((byte)(206)))));
            swiftPlotDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = swiftPlotDiagram1;
            // 
            // AbsenceWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           
            this.Name = "AbsenceWidget";
            this.Size = new System.Drawing.Size(764, 415);
            ((System.ComponentModel.ISupportInitialize)(this.monthlySalesItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource monthlySalesItemBindingSource;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView1;

    }
}
