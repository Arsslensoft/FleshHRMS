using DevExpress.DevAV;
namespace DevExpress.DevAV.Preview {
    partial class ReportExportSettingsControl {
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
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.btnExport = new DevExpress.XtraEditors.DropDownButton();
            this.settingsPanel = new SettingPanel();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.layoutControlItemSettings = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleLabelItem2 = new DevExpress.XtraLayout.SimpleLabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem2)).BeginInit();
            this.SuspendLayout();
            this.layoutControl.AllowCustomization = false;
            this.layoutControl.Controls.Add(this.btnExport);
            this.layoutControl.Controls.Add(this.settingsPanel);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(300, 600);
            this.layoutControl.TabIndex = 4;
            this.btnExport.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnExport.Location = new System.Drawing.Point(40, 89);
            this.btnExport.MaximumSize = new System.Drawing.Size(75, 75);
            this.btnExport.MinimumSize = new System.Drawing.Size(75, 75);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 75);
            this.btnExport.StyleController = this.layoutControl;
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            this.settingsPanel.Location = new System.Drawing.Point(40, 215);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(242, 345);
            this.settingsPanel.TabIndex = 4;
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.simpleLabelItem1,
            this.layoutControlItemSettings,
            this.simpleSeparator1,
            this.layoutControlItem1,
            this.simpleLabelItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(40, 0, 0, 40);
            this.layoutControlGroup1.Size = new System.Drawing.Size(324, 600);
            this.layoutControlGroup1.Text = "Root";
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleLabelItem1.AppearanceItemCaption.Options.UseFont = true;
            this.simpleLabelItem1.CustomizationFormText = "Print";
            this.simpleLabelItem1.Location = new System.Drawing.Point(0, 0);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 24);
            this.simpleLabelItem1.Size = new System.Drawing.Size(242, 89);
            this.simpleLabelItem1.Text = "Export";
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(138, 65);
            this.layoutControlItemSettings.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.layoutControlItemSettings.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItemSettings.Control = this.settingsPanel;
            this.layoutControlItemSettings.CustomizationFormText = "Settings";
            this.layoutControlItemSettings.Location = new System.Drawing.Point(0, 164);
            this.layoutControlItemSettings.Name = "layoutControlItem4";
            this.layoutControlItemSettings.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 16, 0);
            this.layoutControlItemSettings.Size = new System.Drawing.Size(242, 396);
            this.layoutControlItemSettings.Text = "Settings";
            this.layoutControlItemSettings.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItemSettings.TextSize = new System.Drawing.Size(138, 32);
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.CustomizationFormText = "simpleSeparator1";
            this.simpleSeparator1.Location = new System.Drawing.Point(242, 0);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.simpleSeparator1.Size = new System.Drawing.Size(42, 560);
            this.simpleSeparator1.Spacing = new DevExpress.XtraLayout.Utils.Padding(40, 0, 0, 0);
            this.simpleSeparator1.Text = "simpleSeparator1";
            this.layoutControlItem1.Control = this.btnExport;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 89);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Size = new System.Drawing.Size(92, 75);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            this.simpleLabelItem2.AllowHotTrack = false;
            this.simpleLabelItem2.AllowHtmlStringInCaption = true;
            this.simpleLabelItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.simpleLabelItem2.AppearanceItemCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.simpleLabelItem2.CustomizationFormText = "Specify how you want<br>the report to be printed";
            this.simpleLabelItem2.Location = new System.Drawing.Point(92, 89);
            this.simpleLabelItem2.Name = "simpleLabelItem2";
            this.simpleLabelItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(12, 0, 0, 0);
            this.simpleLabelItem2.Size = new System.Drawing.Size(150, 75);
            this.simpleLabelItem2.Text = "The DevExpress Reporting<br>platform allows you to<br>export any report to<br>PDF" +
    ", XLS, RTF and countless<br>image file formats.";
            this.simpleLabelItem2.TextSize = new System.Drawing.Size(138, 65);


            this.Controls.Add(this.layoutControl);
            this.Name = "ReportExportSettingsControl";
            this.Size = new System.Drawing.Size(300, 600);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private XtraLayout.LayoutControl layoutControl;
        private SettingPanel settingsPanel;
        private XtraEditors.DropDownButton btnExport;
        private XtraLayout.LayoutControlGroup layoutControlGroup1;
        private XtraLayout.SimpleLabelItem simpleLabelItem1;
        private XtraLayout.SimpleLabelItem simpleLabelItem2;
        private XtraLayout.LayoutControlItem layoutControlItemSettings;
        private XtraLayout.SimpleSeparator simpleSeparator1;
        private XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
