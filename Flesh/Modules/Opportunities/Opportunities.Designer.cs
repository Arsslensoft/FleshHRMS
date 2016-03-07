namespace DevExpress.DevAV.Modules {
    partial class Opportunities {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.RangeControlRange rangeControlRange1 = new DevExpress.XtraEditors.RangeControlRange();
            DevExpress.XtraEditors.AreaChartRangeControlClientView areaChartRangeControlClientView1 = new DevExpress.XtraEditors.AreaChartRangeControlClientView();
            DevExpress.XtraCharts.SimpleDiagram simpleDiagram1 = new DevExpress.XtraCharts.SimpleDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.FunnelSeriesLabel funnelSeriesLabel1 = new DevExpress.XtraCharts.FunnelSeriesLabel();
            DevExpress.XtraCharts.FunnelSeriesView funnelSeriesView1 = new DevExpress.XtraCharts.FunnelSeriesView();
            DevExpress.XtraCharts.FunnelSeriesView funnelSeriesView2 = new DevExpress.XtraCharts.FunnelSeriesView();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Opportunities));
            this.rangeControl = new DevExpress.XtraEditors.RangeControl();
            this.dateTimeChartRangeControlClient1 = new DevExpress.XtraEditors.DateTimeChartRangeControlClient();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.panelContainer = new DevExpress.XtraEditors.PanelControl();
            this.pivotGridControl = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.opportunitiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fieldPercentage = new DevExpress.XtraPivotGrid.PivotGridField();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.fieldOpportunities = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldCity = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldState = new DevExpress.XtraPivotGrid.PivotGridField();
            this.opportunitiesMapView1 = new DevExpress.DevAV.Modules.OpportunitiesMapView();
            this.chartControl = new DevExpress.XtraCharts.ChartControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.chartControlLCI = new DevExpress.XtraLayout.LayoutControlItem();
            this.pivotGridLCI = new DevExpress.XtraLayout.LayoutControlItem();
            this.buttonHide = new DevExpress.XtraLayout.SimpleLabelItem();
            this.opportunitiesSimpleLabel = new DevExpress.XtraLayout.SimpleLabelItem();
            this.rangeControlLCI = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rangeControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeChartRangeControlClient1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opportunitiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(simpleDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(funnelSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(funnelSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(funnelSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlLCI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridLCI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opportunitiesSimpleLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeControlLCI)).BeginInit();
            this.SuspendLayout();
            this.rangeControl.AnimateOnDataChange = true;
            this.rangeControl.Client = this.dateTimeChartRangeControlClient1;
            this.rangeControl.Location = new System.Drawing.Point(42, 502);
            this.rangeControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rangeControl.MaximumSize = new System.Drawing.Size(0, 100);
            this.rangeControl.MinimumSize = new System.Drawing.Size(0, 100);
            this.rangeControl.Name = "rangeControl";
            rangeControlRange1.Maximum = new System.DateTime(((long)(0)));
            rangeControlRange1.Minimum = new System.DateTime(2014, 6, 1, 0, 0, 0, 0);
            rangeControlRange1.Owner = this.rangeControl;
            this.rangeControl.SelectedRange = rangeControlRange1;
            this.rangeControl.ShowZoomScrollBar = false;
            this.rangeControl.Size = new System.Drawing.Size(1058, 100);
            this.rangeControl.StyleController = this.dataLayoutControl1;
            this.rangeControl.TabIndex = 19;
            this.rangeControl.Text = "rangeControl1";
            areaChartRangeControlClientView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(194)))), ((int)(((byte)(224)))));
            this.dateTimeChartRangeControlClient1.DataProvider.TemplateView = areaChartRangeControlClientView1;
            this.dateTimeChartRangeControlClient1.GridOptions.Auto = false;
            this.dateTimeChartRangeControlClient1.GridOptions.GridAlignment = DevExpress.XtraEditors.RangeControlDateTimeGridAlignment.Month;
            this.dateTimeChartRangeControlClient1.GridOptions.GridSpacing = 2D;
            this.dateTimeChartRangeControlClient1.GridOptions.SnapAlignment = DevExpress.XtraEditors.RangeControlDateTimeGridAlignment.Month;
            this.dateTimeChartRangeControlClient1.GridOptions.SnapSpacing = 2D;
            this.dateTimeChartRangeControlClient1.PaletteName = "NatureColors";
            this.dataLayoutControl1.AllowCustomization = false;
            this.dataLayoutControl1.Controls.Add(this.rangeControl);
            this.dataLayoutControl1.Controls.Add(this.panelContainer);
            this.dataLayoutControl1.Controls.Add(this.chartControl);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-1359, 205, 938, 715);
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(1142, 624);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            this.panelContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelContainer.Controls.Add(this.pivotGridControl);
            this.panelContainer.Controls.Add(this.opportunitiesMapView1);
            this.panelContainer.Location = new System.Drawing.Point(42, 47);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(694, 427);
            this.panelContainer.TabIndex = 5;
            this.pivotGridControl.CausesValidation = false;
            this.pivotGridControl.DataSource = this.opportunitiesBindingSource;
            this.pivotGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldPercentage,
            this.fieldOpportunities,
            this.fieldCity,
            this.fieldState});
            this.pivotGridControl.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControl.Name = "pivotGridControl";
            this.pivotGridControl.OptionsSelection.MultiSelect = false;
            this.pivotGridControl.OptionsView.ColumnTotalsLocation = DevExpress.XtraPivotGrid.PivotTotalsLocation.Near;
            this.pivotGridControl.OptionsView.ShowColumnGrandTotalHeader = false;
            this.pivotGridControl.OptionsView.ShowColumnHeaders = false;
            this.pivotGridControl.OptionsView.ShowFilterHeaders = false;
            this.pivotGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1});
            this.pivotGridControl.Size = new System.Drawing.Size(694, 427);
            this.pivotGridControl.TabIndex = 20;
            this.pivotGridControl.CustomCellValue += new System.EventHandler<DevExpress.XtraPivotGrid.PivotCellValueEventArgs>(this.pivotGridControl1_CustomCellValue);
            this.fieldPercentage.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea;
            this.fieldPercentage.Appearance.Cell.Options.UseTextOptions = true;
            this.fieldPercentage.Appearance.Cell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldPercentage.Appearance.CellGrandTotal.Options.UseTextOptions = true;
            this.fieldPercentage.Appearance.CellGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldPercentage.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldPercentage.AreaIndex = 1;
            this.fieldPercentage.Caption = "Percentage";
            this.fieldPercentage.FieldEdit = this.repositoryItemProgressBar1;
            this.fieldPercentage.FieldName = "Opportunity";
            this.fieldPercentage.Name = "fieldPercentage";
            this.fieldPercentage.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average;
            this.fieldPercentage.UnboundFieldName = "Opportunity";
            this.fieldPercentage.Width = 200;
            this.repositoryItemProgressBar1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemProgressBar1.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemProgressBar1.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemProgressBar1.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(81)))), ((int)(((byte)(165)))));
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            this.repositoryItemProgressBar1.ReadOnly = true;
            this.repositoryItemProgressBar1.ShowTitle = true;
            this.repositoryItemProgressBar1.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(81)))), ((int)(((byte)(165)))));
            this.fieldOpportunities.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea;
            this.fieldOpportunities.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldOpportunities.AreaIndex = 0;
            this.fieldOpportunities.Caption = "Opportunities";
            this.fieldOpportunities.FieldName = "Total";
            this.fieldOpportunities.Name = "fieldOpportunities";
            this.fieldOpportunities.Width = 240;
            this.fieldCity.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea;
            this.fieldCity.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldCity.AreaIndex = 1;
            this.fieldCity.Caption = "City";
            this.fieldCity.FieldName = "CustomerStore.City";
            this.fieldCity.Name = "fieldCity";
            this.fieldCity.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
            this.fieldCity.Width = 200;
            this.fieldState.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea;
            this.fieldState.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldState.AreaIndex = 0;
            this.fieldState.Caption = "State";
            this.fieldState.FieldName = "CustomerStore.State";
            this.fieldState.Name = "fieldState";
            this.fieldState.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.DisplayText;
            this.fieldState.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
            this.fieldState.Width = 150;
            this.opportunitiesMapView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opportunitiesMapView1.Location = new System.Drawing.Point(0, 0);
            this.opportunitiesMapView1.Margin = new System.Windows.Forms.Padding(6);
            this.opportunitiesMapView1.Name = "opportunitiesMapView1";
            this.opportunitiesMapView1.Quote = null;
            this.opportunitiesMapView1.Size = new System.Drawing.Size(694, 427);
            this.opportunitiesMapView1.TabIndex = 21;
            this.chartControl.AccessibleName = "";
            this.chartControl.AllowDrop = true;
            this.chartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl.DataSource = this.opportunitiesBindingSource;
            simpleDiagram1.EqualPieSize = false;
            this.chartControl.Diagram = simpleDiagram1;
            this.chartControl.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.chartControl.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside;
            this.chartControl.Legend.Antialiasing = true;
            this.chartControl.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartControl.Legend.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chartControl.Legend.Margins.Bottom = 0;
            this.chartControl.Legend.Margins.Left = 0;
            this.chartControl.Legend.Margins.Right = 0;
            this.chartControl.Legend.Margins.Top = 0;
            this.chartControl.Legend.MarkerSize = new System.Drawing.Size(20, 20);
            this.chartControl.Legend.Padding.Bottom = 0;
            this.chartControl.Legend.Padding.Left = 0;
            this.chartControl.Legend.Padding.Right = 0;
            this.chartControl.Legend.Padding.Top = 40;
            this.chartControl.Location = new System.Drawing.Point(768, 47);
            this.chartControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartControl.Name = "chartControl";
            this.chartControl.PaletteName = "Palette 1";
            this.chartControl.PaletteRepository.Add("Palette 1", new DevExpress.XtraCharts.Palette("Palette 1", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(156))))), System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(156)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85))))), System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(113)))), ((int)(((byte)(0))))), System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(113)))), ((int)(((byte)(0)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198))))), System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198))))))}));
            funnelSeriesLabel1.Antialiasing = true;
            funnelSeriesLabel1.BackColor = System.Drawing.Color.Transparent;
            funnelSeriesLabel1.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            funnelSeriesLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            funnelSeriesLabel1.Position = DevExpress.XtraCharts.FunnelSeriesLabelPosition.Center;
            funnelSeriesLabel1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            funnelSeriesLabel1.TextPattern = "{V:c}";
            series1.Label = funnelSeriesLabel1;
            series1.LegendTextPattern = "{A}";
            series1.Name = "Series 1";
            series1.SynchronizePointOptions = false;
            funnelSeriesView1.AlignToCenter = true;
            series1.View = funnelSeriesView1;
            this.chartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl.SeriesTemplate.SynchronizePointOptions = false;
            this.chartControl.SeriesTemplate.View = funnelSeriesView2;
            this.chartControl.Size = new System.Drawing.Size(332, 427);
            this.chartControl.TabIndex = 5;
            this.chartControl.CustomDrawSeriesPoint += new DevExpress.XtraCharts.CustomDrawSeriesPointEventHandler(this.chartControl_CustomDrawSeriesPoint);
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.chartControlLCI,
            this.pivotGridLCI,
            this.buttonHide,
            this.opportunitiesSimpleLabel,
            this.rangeControlLCI});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(40, 40, 0, 20);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1142, 624);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            this.chartControlLCI.BestFitWeight = 200;
            this.chartControlLCI.Control = this.chartControl;
            this.chartControlLCI.CustomizationFormText = "chartControlLCI";
            this.chartControlLCI.Location = new System.Drawing.Point(726, 45);
            this.chartControlLCI.MinSize = new System.Drawing.Size(336, 24);
            this.chartControlLCI.Name = "chartControlLCI";
            this.chartControlLCI.Size = new System.Drawing.Size(336, 431);
            this.chartControlLCI.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.chartControlLCI.Text = "chartControlLCI";
            this.chartControlLCI.TextSize = new System.Drawing.Size(0, 0);
            this.chartControlLCI.TextToControlDistance = 0;
            this.chartControlLCI.TextVisible = false;
            this.pivotGridLCI.Control = this.panelContainer;
            this.pivotGridLCI.CustomizationFormText = "pivotGridLCI";
            this.pivotGridLCI.Location = new System.Drawing.Point(0, 45);
            this.pivotGridLCI.Name = "pivotGridLCI";
            this.pivotGridLCI.Size = new System.Drawing.Size(698, 431);
            this.pivotGridLCI.Text = "pivotGridLCI";
            this.pivotGridLCI.TextSize = new System.Drawing.Size(0, 0);
            this.pivotGridLCI.TextToControlDistance = 0;
            this.pivotGridLCI.TextVisible = false;
            this.buttonHide.AllowHotTrack = false;
            this.buttonHide.CustomizationFormText = " ";
            this.buttonHide.Image = ((System.Drawing.Image)(resources.GetObject("buttonHide.Image")));
            this.buttonHide.Location = new System.Drawing.Point(698, 45);
            this.buttonHide.MaxSize = new System.Drawing.Size(28, 0);
            this.buttonHide.MinSize = new System.Drawing.Size(28, 24);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(28, 431);
            this.buttonHide.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.buttonHide.Text = " ";
            this.buttonHide.TextSize = new System.Drawing.Size(138, 25);
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            this.opportunitiesSimpleLabel.AllowHotTrack = false;
            this.opportunitiesSimpleLabel.AppearanceItemCaption.FontSizeDelta = 3;
            this.opportunitiesSimpleLabel.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(82)))), ((int)(((byte)(163)))));
            this.opportunitiesSimpleLabel.AppearanceItemCaption.Options.UseFont = true;
            this.opportunitiesSimpleLabel.AppearanceItemCaption.Options.UseForeColor = true;
            this.opportunitiesSimpleLabel.CustomizationFormText = "OPPORTUNITIES";
            this.opportunitiesSimpleLabel.Location = new System.Drawing.Point(0, 0);
            this.opportunitiesSimpleLabel.Name = "opportunitiesSimpleLabel";
            this.opportunitiesSimpleLabel.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 10, 10);
            this.opportunitiesSimpleLabel.Size = new System.Drawing.Size(1062, 45);
            this.opportunitiesSimpleLabel.Text = "OPPORTUNITIES";
            this.opportunitiesSimpleLabel.TextSize = new System.Drawing.Size(138, 25);
            this.rangeControlLCI.Control = this.rangeControl;
            this.rangeControlLCI.CustomizationFormText = "rangeControlLCI";
            this.rangeControlLCI.OptionsPrint.AllowPrint = false;
            this.rangeControlLCI.Location = new System.Drawing.Point(0, 476);
            this.rangeControlLCI.Name = "rangeControlLCI";
            this.rangeControlLCI.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 26, 2);
            this.rangeControlLCI.Size = new System.Drawing.Size(1062, 128);
            this.rangeControlLCI.Text = "rangeControlLCI";
            this.rangeControlLCI.TextSize = new System.Drawing.Size(0, 0);
            this.rangeControlLCI.TextToControlDistance = 0;
            this.rangeControlLCI.TextVisible = false;
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Opportunities";
            this.Size = new System.Drawing.Size(1142, 624);
            this.Load += new System.EventHandler(this.opportunities_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rangeControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeChartRangeControlClient1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opportunitiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(simpleDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(funnelSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(funnelSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(funnelSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlLCI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridLCI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opportunitiesSimpleLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeControlLCI)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.BindingSource opportunitiesBindingSource;
        private XtraCharts.ChartControl chartControl;
        private XtraLayout.LayoutControlItem chartControlLCI;
        private XtraPivotGrid.PivotGridControl pivotGridControl;
        private XtraLayout.LayoutControlItem pivotGridLCI;
        private XtraLayout.SimpleLabelItem buttonHide;
        private XtraLayout.SimpleLabelItem opportunitiesSimpleLabel;
        private XtraPivotGrid.PivotGridField fieldPercentage;
        private XtraPivotGrid.PivotGridField fieldOpportunities;
        private XtraPivotGrid.PivotGridField fieldCity;
        private XtraPivotGrid.PivotGridField fieldState;
        private XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private OpportunitiesMapView opportunitiesMapView1;
        private DevExpress.XtraEditors.PanelControl panelContainer;
        private XtraEditors.RangeControl rangeControl;
        private XtraEditors.DateTimeChartRangeControlClient dateTimeChartRangeControlClient1;
        private XtraLayout.LayoutControlItem rangeControlLCI;



    }
}
