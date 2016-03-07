namespace DevExpress.DevAV.Modules.Customers {
    partial class AddressUserControl {

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.LineTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.addressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CityTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.StateImageComboBoxEdit = new DevExpress.DevAV.Modules.Customers.StateUC();
            this.ZipCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForLine = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCity = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForZipCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForState = new DevExpress.XtraLayout.LayoutControlItem();
            this.errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LineTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CityTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZipCodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForZipCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            this.dataLayoutControl1.AllowCustomization = false;
            this.dataLayoutControl1.Controls.Add(this.LineTextEdit);
            this.dataLayoutControl1.Controls.Add(this.CityTextEdit);
            this.dataLayoutControl1.Controls.Add(this.StateImageComboBoxEdit);
            this.dataLayoutControl1.Controls.Add(this.ZipCodeTextEdit);
            this.dataLayoutControl1.DataSource = this.addressBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-1269, 306, 841, 609);
            this.dataLayoutControl1.OptionsView.AutoSizeInLayoutControl = DevExpress.XtraLayout.AutoSizeModes.UseMinAndMaxSize;
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(643, 139);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            this.LineTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.addressBindingSource, "Line", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.LineTextEdit.Location = new System.Drawing.Point(105, 2);
            this.LineTextEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LineTextEdit.Name = "LineTextEdit";
            this.LineTextEdit.Size = new System.Drawing.Size(536, 40);
            this.LineTextEdit.StyleController = this.dataLayoutControl1;
            this.LineTextEdit.TabIndex = 4;
            this.addressBindingSource.DataSource = typeof(DevExpress.DevAV.Address);
            this.CityTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.addressBindingSource, "City", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CityTextEdit.Location = new System.Drawing.Point(105, 46);
            this.CityTextEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CityTextEdit.Name = "CityTextEdit";
            this.CityTextEdit.Size = new System.Drawing.Size(300, 40);
            this.CityTextEdit.StyleController = this.dataLayoutControl1;
            this.CityTextEdit.TabIndex = 5;
            this.StateImageComboBoxEdit.Location = new System.Drawing.Point(458, 46);
            this.StateImageComboBoxEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StateImageComboBoxEdit.Name = "StateImageComboBoxEdit";
            this.StateImageComboBoxEdit.Size = new System.Drawing.Size(183, 40);
            this.StateImageComboBoxEdit.TabIndex = 6;
            this.ZipCodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.addressBindingSource, "ZipCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ZipCodeTextEdit.Location = new System.Drawing.Point(105, 90);
            this.ZipCodeTextEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ZipCodeTextEdit.Name = "ZipCodeTextEdit";
            this.ZipCodeTextEdit.Properties.Mask.EditMask = "00000";
            this.ZipCodeTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.ZipCodeTextEdit.Size = new System.Drawing.Size(536, 40);
            this.ZipCodeTextEdit.StyleController = this.dataLayoutControl1;
            this.ZipCodeTextEdit.TabIndex = 7;
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(643, 139);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.AppearanceItemCaption.FontSizeDelta = -2;
            this.layoutControlGroup2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup2.CustomizationFormText = "autoGeneratedGroup0";
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForLine,
            this.ItemForCity,
            this.ItemForZipCode,
            this.ItemForState});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.OptionsItemText.TextAlignMode = DevExpress.XtraLayout.TextAlignModeGroup.CustomSize;
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new System.Drawing.Size(643, 139);
            this.layoutControlGroup2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Text = "autoGeneratedGroup0";
            this.ItemForLine.Control = this.LineTextEdit;
            this.ItemForLine.CustomizationFormText = "ADDRESS";
            this.ItemForLine.Location = new System.Drawing.Point(0, 0);
            this.ItemForLine.Name = "ItemForLine";
            this.ItemForLine.Size = new System.Drawing.Size(643, 44);
            this.ItemForLine.Text = "BILLING ADDRESS";
            this.ItemForLine.TextSize = new System.Drawing.Size(100, 13);
            this.ItemForCity.Control = this.CityTextEdit;
            this.ItemForCity.CustomizationFormText = "CITY";
            this.ItemForCity.Location = new System.Drawing.Point(0, 44);
            this.ItemForCity.Name = "ItemForCity";
            this.ItemForCity.Size = new System.Drawing.Size(407, 44);
            this.ItemForCity.Text = "CITY";
            this.ItemForCity.TextSize = new System.Drawing.Size(100, 13);
            this.ItemForZipCode.Control = this.ZipCodeTextEdit;
            this.ItemForZipCode.CustomizationFormText = "ZIP CODE";
            this.ItemForZipCode.Location = new System.Drawing.Point(0, 88);
            this.ItemForZipCode.Name = "ItemForZipCode";
            this.ItemForZipCode.Size = new System.Drawing.Size(643, 51);
            this.ItemForZipCode.Text = "ZIP CODE";
            this.ItemForZipCode.TextSize = new System.Drawing.Size(100, 13);
            this.ItemForState.Control = this.StateImageComboBoxEdit;
            this.ItemForState.CustomizationFormText = "STATE";
            this.ItemForState.Location = new System.Drawing.Point(407, 44);
            this.ItemForState.Name = "ItemForState";
            this.ItemForState.Size = new System.Drawing.Size(236, 44);
            this.ItemForState.Text = "STATE";
            this.ItemForState.TextSize = new System.Drawing.Size(46, 13);
            this.errorProvider.ContainerControl = this;
            this.errorProvider.DataSource = this.addressBindingSource;
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddressUserControl";
            this.Size = new System.Drawing.Size(643, 139);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LineTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CityTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZipCodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForZipCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public XtraDataLayout.DataLayoutControl dataLayoutControl1;
        public XtraEditors.TextEdit LineTextEdit;
        public System.Windows.Forms.BindingSource addressBindingSource;
        public XtraEditors.TextEdit CityTextEdit;
        public StateUC StateImageComboBoxEdit;
        public XtraEditors.TextEdit ZipCodeTextEdit;
        public XtraLayout.LayoutControlGroup layoutControlGroup1;
        public XtraLayout.LayoutControlGroup layoutControlGroup2;
        public XtraLayout.LayoutControlItem ItemForLine;
        public XtraLayout.LayoutControlItem ItemForCity;
        public XtraLayout.LayoutControlItem ItemForState;
        public XtraLayout.LayoutControlItem ItemForZipCode;
        private System.ComponentModel.IContainer components;
        private XtraEditors.DXErrorProvider.DXErrorProvider errorProvider;
    }
}
