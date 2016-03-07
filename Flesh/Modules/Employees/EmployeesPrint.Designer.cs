namespace DevExpress.DevAV.Modules {
    partial class EmployeesPrint {
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
            this.btnExcludeEvaluations = new DevExpress.XtraEditors.CheckButton();
            this.settingsLayout = new DevExpress.XtraLayout.LayoutControl();
            this.btnIncudeEvaluations = new DevExpress.XtraEditors.CheckButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.previewControl = new DevExpress.DevAV.ReportPreviewControl();
            this.printSettingsControl = new DevExpress.DevAV.ReportPrintSettingsControl();
            ((System.ComponentModel.ISupportInitialize)(this.settingsLayout)).BeginInit();
            this.settingsLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            this.btnExcludeEvaluations.GroupIndex = 1;
            this.btnExcludeEvaluations.Location = new System.Drawing.Point(2, 46);
            this.btnExcludeEvaluations.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExcludeEvaluations.MaximumSize = new System.Drawing.Size(0, 40);
            this.btnExcludeEvaluations.MinimumSize = new System.Drawing.Size(0, 40);
            this.btnExcludeEvaluations.Name = "btnExcludeEvaluations";
            this.btnExcludeEvaluations.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnExcludeEvaluations.Size = new System.Drawing.Size(257, 40);
            this.btnExcludeEvaluations.StyleController = this.settingsLayout;
            this.btnExcludeEvaluations.TabIndex = 2;
            this.btnExcludeEvaluations.TabStop = false;
            this.btnExcludeEvaluations.Text = "Exclude Evaluations";
            this.btnExcludeEvaluations.Click += new System.EventHandler(this.buttonSettings_Click);
            this.settingsLayout.Controls.Add(this.btnIncudeEvaluations);
            this.settingsLayout.Controls.Add(this.btnExcludeEvaluations);
            this.settingsLayout.Location = new System.Drawing.Point(39, 343);
            this.settingsLayout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.settingsLayout.Name = "settingsLayout";
            this.settingsLayout.OptionsView.UseParentAutoScaleFactor = true;
            this.settingsLayout.Root = this.Root;
            this.settingsLayout.Size = new System.Drawing.Size(261, 315);
            this.settingsLayout.TabIndex = 2;
            this.btnIncudeEvaluations.Checked = true;
            this.btnIncudeEvaluations.GroupIndex = 1;
            this.btnIncudeEvaluations.Location = new System.Drawing.Point(2, 2);
            this.btnIncudeEvaluations.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnIncudeEvaluations.MaximumSize = new System.Drawing.Size(0, 40);
            this.btnIncudeEvaluations.MinimumSize = new System.Drawing.Size(0, 40);
            this.btnIncudeEvaluations.Name = "btnIncudeEvaluations";
            this.btnIncudeEvaluations.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnIncudeEvaluations.Size = new System.Drawing.Size(257, 40);
            this.btnIncudeEvaluations.StyleController = this.settingsLayout;
            this.btnIncudeEvaluations.TabIndex = 2;
            this.btnIncudeEvaluations.Text = "Include Evaluations";
            this.btnIncudeEvaluations.Click += new System.EventHandler(this.buttonSettings_Click);
            this.Root.CustomizationFormText = "Root";
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(261, 315);
            this.Root.Text = "Root";
            this.layoutControlItem1.Control = this.btnIncudeEvaluations;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(261, 44);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            this.layoutControlItem2.Control = this.btnExcludeEvaluations;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 44);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(261, 271);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            this.previewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewControl.Location = new System.Drawing.Point(403, 0);
            this.previewControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.previewControl.Name = "previewControl";
            this.previewControl.Size = new System.Drawing.Size(962, 923);
            this.previewControl.TabIndex = 0;
            this.printSettingsControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.printSettingsControl.Location = new System.Drawing.Point(0, 0);
            this.printSettingsControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.printSettingsControl.Name = "printSettingsControl";
            this.printSettingsControl.SelectedPrinterName = "";
            this.printSettingsControl.Size = new System.Drawing.Size(403, 923);
            this.printSettingsControl.TabIndex = 1;
            this.printSettingsControl.PrintClick += new System.EventHandler(this.settingsControl_PrintClick);
            this.printSettingsControl.PrintOptionsClick += new System.EventHandler(this.settingsControl_PrintOptionsClick);
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.previewControl);
            this.Controls.Add(this.settingsLayout);
            this.Controls.Add(this.printSettingsControl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EmployeesPrint";
            this.Size = new System.Drawing.Size(1365, 923);
            ((System.ComponentModel.ISupportInitialize)(this.settingsLayout)).EndInit();
            this.settingsLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReportPreviewControl previewControl;
        private ReportPrintSettingsControl printSettingsControl;
        private DevExpress.XtraEditors.CheckButton btnIncudeEvaluations;
        private DevExpress.XtraEditors.CheckButton btnExcludeEvaluations;
        private DevExpress.XtraLayout.LayoutControl settingsLayout;
        private XtraLayout.LayoutControlGroup Root;
        private XtraLayout.LayoutControlItem layoutControlItem2;
        private XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
