namespace DevExpress.DevAV.Modules {
    partial class OpportunitiesMapView {
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
            DevExpress.XtraMap.VectorItemsLayer vectorItemsLayer1 = new DevExpress.XtraMap.VectorItemsLayer();
            DevExpress.XtraMap.VectorItemsLayer vectorItemsLayer2 = new DevExpress.XtraMap.VectorItemsLayer();
            DevExpress.XtraMap.BubbleChartDataAdapter bubbleChartDataAdapter1 = new DevExpress.XtraMap.BubbleChartDataAdapter();
            DevExpress.XtraMap.VectorItemsLayer vectorItemsLayer3 = new DevExpress.XtraMap.VectorItemsLayer();
            DevExpress.XtraMap.MapItemStorage mapItemStorage1 = new DevExpress.XtraMap.MapItemStorage();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataLayoutControl = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.mapControl = new DevExpress.XtraMap.MapControl();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.mapControlLCI = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl)).BeginInit();
            this.dataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapControlLCI)).BeginInit();
            this.SuspendLayout();
            this.dataLayoutControl.AllowCustomization = false;
            this.dataLayoutControl.Controls.Add(this.mapControl);
            this.dataLayoutControl.DataSource = this.bindingSource;
            this.dataLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl.Margin = new System.Windows.Forms.Padding(12);
            this.dataLayoutControl.Name = "dataLayoutControl";
            this.dataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(846, 113, 681, 723);
            this.dataLayoutControl.Root = this.layoutControlGroup1;
            this.dataLayoutControl.Size = new System.Drawing.Size(572, 342);
            this.dataLayoutControl.TabIndex = 1;
            this.dataLayoutControl.Text = "dataLayoutControl1";
            this.mapControl.Cursor = System.Windows.Forms.Cursors.Default;
            vectorItemsLayer1.EnableHighlighting = false;
            vectorItemsLayer1.EnableSelection = false;
            vectorItemsLayer1.ItemStyle.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            vectorItemsLayer1.ItemStyle.Stroke = System.Drawing.Color.White;
            vectorItemsLayer1.ItemStyle.StrokeWidth = 0;
            vectorItemsLayer1.SelectedItemStyle.Fill = System.Drawing.Color.White;
            vectorItemsLayer1.SelectedItemStyle.StrokeWidth = 0;
            vectorItemsLayer1.ShapeTitlesPattern = "";
            bubbleChartDataAdapter1.Mappings.Latitude = "Latitude";
            bubbleChartDataAdapter1.Mappings.Longitude = "Longitude";
            bubbleChartDataAdapter1.Mappings.Value = "Total";
            bubbleChartDataAdapter1.MarkerType = DevExpress.XtraMap.MarkerType.Circle;
            vectorItemsLayer2.Data = bubbleChartDataAdapter1;
            vectorItemsLayer2.ItemStyle.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(113)))), ((int)(((byte)(0)))));
            vectorItemsLayer2.ItemStyle.Stroke = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(96)))), ((int)(((byte)(0)))));
            vectorItemsLayer2.ItemStyle.StrokeWidth = 1;
            vectorItemsLayer2.SelectedItemStyle.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(81)))), ((int)(((byte)(165)))));
            vectorItemsLayer2.SelectedItemStyle.StrokeWidth = 0;
            vectorItemsLayer2.ToolTipPattern = "City:%CI% Total:%CV%";
            vectorItemsLayer3.Data = mapItemStorage1;
            this.mapControl.Layers.Add(vectorItemsLayer1);
            this.mapControl.Layers.Add(vectorItemsLayer2);
            this.mapControl.Layers.Add(vectorItemsLayer3);
            this.mapControl.Location = new System.Drawing.Point(2, 2);
            this.mapControl.Name = "mapControl";
            this.mapControl.Size = new System.Drawing.Size(568, 338);
            this.mapControl.TabIndex = 18;
            this.mapControl.ToolTipController = this.toolTipController1;
            this.mapControl.ZoomLevel = 4D;
            this.mapControl.MapItemClick += new DevExpress.XtraMap.MapItemClickEventHandler(this.mapControl_MapItemClick);
            this.toolTipController1.BeforeShow += new DevExpress.Utils.ToolTipControllerBeforeShowEventHandler(this.toolTipController1_BeforeShow);
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 6;
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(572, 342);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.CustomizationFormText = "autoGeneratedGroup0";
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.mapControlLCI});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 6;
            this.layoutControlGroup2.Size = new System.Drawing.Size(572, 342);
            this.layoutControlGroup2.Text = "autoGeneratedGroup0";
            this.mapControlLCI.Control = this.mapControl;
            this.mapControlLCI.CustomizationFormText = "mapControlLCI";
            this.mapControlLCI.Location = new System.Drawing.Point(0, 0);
            this.mapControlLCI.Name = "mapControlLCI";
            this.mapControlLCI.Size = new System.Drawing.Size(572, 342);
            this.mapControlLCI.Text = "mapControlLCI";
            this.mapControlLCI.TextSize = new System.Drawing.Size(0, 0);
            this.mapControlLCI.TextToControlDistance = 0;
            this.mapControlLCI.TextVisible = false;
            this.Controls.Add(this.dataLayoutControl);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "OpportunitiesMapView";
            this.Size = new System.Drawing.Size(572, 342);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl)).EndInit();
            this.dataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapControlLCI)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private XtraDataLayout.DataLayoutControl dataLayoutControl;
        private XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.BindingSource bindingSource;
        private XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraMap.MapControl mapControl;
        private XtraLayout.LayoutControlItem mapControlLCI;
        private Utils.ToolTipController toolTipController1;
    }
}
