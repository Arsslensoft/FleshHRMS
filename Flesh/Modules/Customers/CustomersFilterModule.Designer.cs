namespace DevExpress.DevAV.Modules {
    partial class CustomersFilterModule {
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.filterControl = new DevExpress.XtraEditors.FilterControl();
            this.cancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.okButton = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit = new DevExpress.XtraEditors.TextEdit();
            this.checkEdit = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.customersLabelItem = new DevExpress.XtraLayout.SimpleLabelItem();
            this.customFilterLabelItem = new DevExpress.XtraLayout.SimpleLabelItem();
            this.checkBoxLCI = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEditLCI = new DevExpress.XtraLayout.LayoutControlItem();
            this.okButtonLCI = new DevExpress.XtraLayout.LayoutControlItem();
            this.cancelButtonLCI = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.filterControlLCI = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersLabelItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customFilterLabelItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxLCI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditLCI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.okButtonLCI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButtonLCI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterControlLCI)).BeginInit();
            this.SuspendLayout();
            this.layoutControl1.Controls.Add(this.filterControl);
            this.layoutControl1.Controls.Add(this.cancelButton);
            this.layoutControl1.Controls.Add(this.okButton);
            this.layoutControl1.Controls.Add(this.textEdit);
            this.layoutControl1.Controls.Add(this.checkEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-1104, 135, 813, 793);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(952, 480);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            this.filterControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.filterControl.Location = new System.Drawing.Point(12, 62);
            this.filterControl.Name = "filterControl";
            this.filterControl.Size = new System.Drawing.Size(928, 273);
            this.filterControl.TabIndex = 9;
            this.filterControl.Text = "filterControl1";
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(839, 433);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(101, 35);
            this.cancelButton.StyleController = this.layoutControl1;
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(724, 433);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(101, 35);
            this.okButton.StyleController = this.layoutControl1;
            this.okButton.TabIndex = 7;
            this.okButton.Text = "OK";
            this.textEdit.EditValue = "";
            this.textEdit.Location = new System.Drawing.Point(253, 354);
            this.textEdit.Name = "textEdit";
            this.textEdit.Properties.NullValuePrompt = "Enter a name for your custom filter";
            this.textEdit.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEdit.Size = new System.Drawing.Size(687, 40);
            this.textEdit.StyleController = this.layoutControl1;
            this.textEdit.TabIndex = 6;
            this.checkEdit.Location = new System.Drawing.Point(12, 357);
            this.checkEdit.Name = "checkEdit";
            this.checkEdit.Properties.Caption = "Save for future use";
            this.checkEdit.Size = new System.Drawing.Size(237, 34);
            this.checkEdit.StyleController = this.layoutControl1;
            this.checkEdit.TabIndex = 5;
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.customersLabelItem,
            this.customFilterLabelItem,
            this.checkBoxLCI,
            this.textEditLCI,
            this.okButtonLCI,
            this.cancelButtonLCI,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.emptySpaceItem5,
            this.filterControlLCI});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(952, 480);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            this.customersLabelItem.AllowHotTrack = false;
            this.customersLabelItem.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.customersLabelItem.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.customersLabelItem.AppearanceItemCaption.Options.UseFont = true;
            this.customersLabelItem.AppearanceItemCaption.Options.UseForeColor = true;
            this.customersLabelItem.CustomizationFormText = "Products";
            this.customersLabelItem.Location = new System.Drawing.Point(0, 0);
            this.customersLabelItem.MaxSize = new System.Drawing.Size(100, 29);
            this.customersLabelItem.MinSize = new System.Drawing.Size(100, 29);
            this.customersLabelItem.Name = "customersLabelItem";
            this.customersLabelItem.Size = new System.Drawing.Size(100, 29);
            this.customersLabelItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.customersLabelItem.Text = "Customers";
            this.customersLabelItem.TextSize = new System.Drawing.Size(111, 25);
            this.customFilterLabelItem.AllowHotTrack = false;
            this.customFilterLabelItem.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.customFilterLabelItem.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.customFilterLabelItem.AppearanceItemCaption.Options.UseFont = true;
            this.customFilterLabelItem.AppearanceItemCaption.Options.UseForeColor = true;
            this.customFilterLabelItem.CustomizationFormText = "Custom Filter";
            this.customFilterLabelItem.Location = new System.Drawing.Point(100, 0);
            this.customFilterLabelItem.Name = "customFilterLabelItem";
            this.customFilterLabelItem.Size = new System.Drawing.Size(832, 29);
            this.customFilterLabelItem.Text = "Custom Filter";
            this.customFilterLabelItem.TextSize = new System.Drawing.Size(111, 25);
            this.checkBoxLCI.Control = this.checkEdit;
            this.checkBoxLCI.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxLCI.CustomizationFormText = "checkBoxLCI";
            this.checkBoxLCI.FillControlToClientArea = false;
            this.checkBoxLCI.Location = new System.Drawing.Point(0, 342);
            this.checkBoxLCI.MinSize = new System.Drawing.Size(166, 38);
            this.checkBoxLCI.Name = "checkBoxLCI";
            this.checkBoxLCI.Size = new System.Drawing.Size(241, 44);
            this.checkBoxLCI.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.checkBoxLCI.Text = "checkBoxLCI";
            this.checkBoxLCI.TextSize = new System.Drawing.Size(0, 0);
            this.checkBoxLCI.TextToControlDistance = 0;
            this.checkBoxLCI.TextVisible = false;
            this.textEditLCI.Control = this.textEdit;
            this.textEditLCI.CustomizationFormText = "textEditLCI";
            this.textEditLCI.Location = new System.Drawing.Point(241, 342);
            this.textEditLCI.Name = "textEditLCI";
            this.textEditLCI.Size = new System.Drawing.Size(691, 44);
            this.textEditLCI.Text = "textEditLCI";
            this.textEditLCI.TextSize = new System.Drawing.Size(0, 0);
            this.textEditLCI.TextToControlDistance = 0;
            this.textEditLCI.TextVisible = false;
            this.okButtonLCI.Control = this.okButton;
            this.okButtonLCI.CustomizationFormText = "okButtonLCI";
            this.okButtonLCI.Location = new System.Drawing.Point(712, 421);
            this.okButtonLCI.MaxSize = new System.Drawing.Size(105, 39);
            this.okButtonLCI.MinSize = new System.Drawing.Size(105, 39);
            this.okButtonLCI.Name = "okButtonLCI";
            this.okButtonLCI.Size = new System.Drawing.Size(105, 39);
            this.okButtonLCI.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.okButtonLCI.Text = "okButtonLCI";
            this.okButtonLCI.TextSize = new System.Drawing.Size(0, 0);
            this.okButtonLCI.TextToControlDistance = 0;
            this.okButtonLCI.TextVisible = false;
            this.cancelButtonLCI.Control = this.cancelButton;
            this.cancelButtonLCI.CustomizationFormText = "cancelButtonLCI";
            this.cancelButtonLCI.Location = new System.Drawing.Point(827, 421);
            this.cancelButtonLCI.MaxSize = new System.Drawing.Size(105, 39);
            this.cancelButtonLCI.MinSize = new System.Drawing.Size(105, 39);
            this.cancelButtonLCI.Name = "cancelButtonLCI";
            this.cancelButtonLCI.Size = new System.Drawing.Size(105, 39);
            this.cancelButtonLCI.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.cancelButtonLCI.Text = "cancelButtonLCI";
            this.cancelButtonLCI.TextSize = new System.Drawing.Size(0, 0);
            this.cancelButtonLCI.TextToControlDistance = 0;
            this.cancelButtonLCI.TextVisible = false;
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 421);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(712, 39);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(817, 421);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(10, 39);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(10, 39);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(10, 39);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 327);
            this.emptySpaceItem3.MaxSize = new System.Drawing.Size(0, 15);
            this.emptySpaceItem3.MinSize = new System.Drawing.Size(10, 15);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(932, 15);
            this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 29);
            this.emptySpaceItem4.MaxSize = new System.Drawing.Size(0, 21);
            this.emptySpaceItem4.MinSize = new System.Drawing.Size(10, 21);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(932, 21);
            this.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem4.Text = "emptySpaceItem4";
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.CustomizationFormText = "emptySpaceItem5";
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 386);
            this.emptySpaceItem5.MaxSize = new System.Drawing.Size(0, 35);
            this.emptySpaceItem5.MinSize = new System.Drawing.Size(10, 35);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(932, 35);
            this.emptySpaceItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem5.Text = "emptySpaceItem5";
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            this.filterControlLCI.Control = this.filterControl;
            this.filterControlLCI.CustomizationFormText = "filterControlLCI";
            this.filterControlLCI.Location = new System.Drawing.Point(0, 50);
            this.filterControlLCI.Name = "filterControlLCI";
            this.filterControlLCI.Size = new System.Drawing.Size(932, 277);
            this.filterControlLCI.Text = "filterControlLCI";
            this.filterControlLCI.TextSize = new System.Drawing.Size(0, 0);
            this.filterControlLCI.TextToControlDistance = 0;
            this.filterControlLCI.TextVisible = false;
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "CustomersFilterModule";
            this.Size = new System.Drawing.Size(952, 480);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersLabelItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customFilterLabelItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxLCI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditLCI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.okButtonLCI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButtonLCI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterControlLCI)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private XtraLayout.LayoutControl layoutControl1;
        private XtraLayout.LayoutControlGroup layoutControlGroup1;
        public XtraEditors.TextEdit textEdit;
        public XtraEditors.CheckEdit checkEdit;
        private XtraLayout.SimpleLabelItem customersLabelItem;
        private XtraLayout.SimpleLabelItem customFilterLabelItem;
        private XtraLayout.LayoutControlItem checkBoxLCI;
        private XtraLayout.LayoutControlItem textEditLCI;
        private XtraEditors.SimpleButton cancelButton;
        private XtraEditors.SimpleButton okButton;
        private XtraLayout.LayoutControlItem okButtonLCI;
        private XtraLayout.LayoutControlItem cancelButtonLCI;
        private XtraLayout.EmptySpaceItem emptySpaceItem1;
        private XtraLayout.EmptySpaceItem emptySpaceItem2;
        private XtraLayout.EmptySpaceItem emptySpaceItem3;
        private XtraLayout.EmptySpaceItem emptySpaceItem4;
        private XtraLayout.EmptySpaceItem emptySpaceItem5;
        public XtraEditors.FilterControl filterControl;
        private XtraLayout.LayoutControlItem filterControlLCI;

    }
}
