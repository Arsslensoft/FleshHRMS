﻿using PHRMS.Data;
namespace PHRMS {
    partial class ReportPrintSettingsControl {
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

                if(printerItemContainer != null) {
                    printerItemContainer.Dispose();
                    printerItemContainer = null;
                }
                if(imagesContainer != null) {
                    imagesContainer.Dispose();
                    imagesContainer = null;
                }
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
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnOptions = new DevExpress.XtraEditors.SimpleButton();
            this.cbPrinters = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Printer = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem2 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.settingsPanel = new PHRMS.SettingPanel();
            this.layoutControlItemSettings = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbPrinters.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Printer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.AllowCustomization = false;
            this.layoutControl.Controls.Add(this.settingsPanel);
            this.layoutControl.Controls.Add(this.btnPrint);
            this.layoutControl.Controls.Add(this.btnOptions);
            this.layoutControl.Controls.Add(this.cbPrinters);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(394, 553);
            this.layoutControl.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnPrint.Location = new System.Drawing.Point(40, 71);
            this.btnPrint.MaximumSize = new System.Drawing.Size(75, 75);
            this.btnPrint.MinimumSize = new System.Drawing.Size(75, 75);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ShowToolTips = false;
            this.btnPrint.Size = new System.Drawing.Size(75, 75);
            this.btnPrint.StyleController = this.layoutControl;
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(40, 242);
            this.btnOptions.MaximumSize = new System.Drawing.Size(0, 40);
            this.btnOptions.MinimumSize = new System.Drawing.Size(0, 40);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(144, 40);
            this.btnOptions.StyleController = this.layoutControl;
            this.btnOptions.TabIndex = 3;
            this.btnOptions.Text = "Print Options";
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // cbPrinters
            // 
            this.cbPrinters.Location = new System.Drawing.Point(40, 192);
            this.cbPrinters.Name = "cbPrinters";
            this.cbPrinters.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPrinters.Size = new System.Drawing.Size(312, 42);
            this.cbPrinters.StyleController = this.layoutControl;
            this.cbPrinters.TabIndex = 2;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.Printer,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.simpleLabelItem1,
            this.simpleLabelItem2,
            this.layoutControlItemSettings,
            this.simpleSeparator1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(40, 0, 0, 40);
            this.layoutControlGroup1.Size = new System.Drawing.Size(394, 553);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnPrint;
            this.layoutControlItem1.CustomizationFormText = "Print";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 71);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Size = new System.Drawing.Size(77, 75);
            this.layoutControlItem1.Text = "Print";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // Printer
            // 
            this.Printer.AppearanceItemCaption.FontSizeDelta = 3;
            this.Printer.AppearanceItemCaption.Options.UseFont = true;
            this.Printer.Control = this.cbPrinters;
            this.Printer.CustomizationFormText = "Printer";
            this.Printer.Location = new System.Drawing.Point(0, 146);
            this.Printer.Name = "Printer";
            this.Printer.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 16, 8);
            this.Printer.Size = new System.Drawing.Size(312, 96);
            this.Printer.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.Printer.TextLocation = DevExpress.Utils.Locations.Top;
            this.Printer.TextSize = new System.Drawing.Size(57, 25);
            this.Printer.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnOptions;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 242);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem3.Size = new System.Drawing.Size(144, 42);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(144, 242);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(168, 42);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.AppearanceItemCaption.FontSizeDelta = 6;
            this.simpleLabelItem1.AppearanceItemCaption.Options.UseFont = true;
            this.simpleLabelItem1.CustomizationFormText = "Print";
            this.simpleLabelItem1.Location = new System.Drawing.Point(0, 0);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 20, 20);
            this.simpleLabelItem1.Size = new System.Drawing.Size(312, 71);
            this.simpleLabelItem1.Text = "Print";
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(157, 31);
            // 
            // simpleLabelItem2
            // 
            this.simpleLabelItem2.AllowHotTrack = false;
            this.simpleLabelItem2.AllowHtmlStringInCaption = true;
            this.simpleLabelItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.simpleLabelItem2.AppearanceItemCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.simpleLabelItem2.CustomizationFormText = "Specify how you want<br>the report to be printed";
            this.simpleLabelItem2.Location = new System.Drawing.Point(77, 71);
            this.simpleLabelItem2.Name = "simpleLabelItem2";
            this.simpleLabelItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(12, 0, 0, 0);
            this.simpleLabelItem2.Size = new System.Drawing.Size(235, 75);
            this.simpleLabelItem2.Text = "Specify how you want<br>the report to be printed";
            this.simpleLabelItem2.TextSize = new System.Drawing.Size(157, 40);
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.CustomizationFormText = "simpleSeparator1";
            this.simpleSeparator1.Location = new System.Drawing.Point(312, 0);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.simpleSeparator1.Size = new System.Drawing.Size(42, 513);
            this.simpleSeparator1.Spacing = new DevExpress.XtraLayout.Utils.Padding(40, 0, 0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.FontSizeDelta = 4;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.cbPrinters;
            this.layoutControlItem2.CustomizationFormText = "Printer";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 213);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(353, 59);
            this.layoutControlItem2.Text = "Printer";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(114, 32);
            // 
            // settingsPanel
            // 
            this.settingsPanel.Location = new System.Drawing.Point(40, 328);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(312, 185);
            this.settingsPanel.TabIndex = 4;
            // 
            // layoutControlItemSettings
            // 
            this.layoutControlItemSettings.AppearanceItemCaption.FontSizeDelta = 3;
            this.layoutControlItemSettings.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItemSettings.Control = this.settingsPanel;
            this.layoutControlItemSettings.CustomizationFormText = "Settings";
            this.layoutControlItemSettings.Location = new System.Drawing.Point(0, 284);
            this.layoutControlItemSettings.Name = "layoutControlItem4";
            this.layoutControlItemSettings.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 16, 0);
            this.layoutControlItemSettings.Size = new System.Drawing.Size(312, 229);
            this.layoutControlItemSettings.Text = "Settings";
            this.layoutControlItemSettings.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItemSettings.TextSize = new System.Drawing.Size(157, 25);
            // 
            // ReportPrintSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.Name = "ReportPrintSettingsControl";
            this.Size = new System.Drawing.Size(394, 553);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbPrinters.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Printer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSettings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbPrinters;
        private DevExpress.XtraEditors.SimpleButton btnOptions;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
        private DevExpress.XtraLayout.LayoutControlItem Printer;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemSettings;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private SettingPanel settingsPanel;
    }
}