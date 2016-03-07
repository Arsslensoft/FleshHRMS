namespace DevExpress.DevAV.Modules {
    partial class EmployeeMailMerge {
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
            DevExpress.Snap.Core.API.DataSourceInfo dataSourceInfo1 = new DevExpress.Snap.Core.API.DataSourceInfo();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeMailMerge));
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.snapControl = new DevExpress.Snap.SnapControl();
            this.dataLayout = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.searchControl = new DevExpress.XtraEditors.SearchControl();
            this.employeesList = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colPhoto = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colFullName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTitle = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.cbMailTemplate = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.FullNameLabel = new DevExpress.XtraEditors.LabelControl();
            this.TitleLabel = new DevExpress.XtraEditors.LabelControl();
            this.PhotoPictureEdit = new DevExpress.XtraEditors.PictureEdit();
            this.lcgRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgSplit = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgMailMergeSetting = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ItemForTitle = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForFullName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPhoto = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.lcSnap = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayout)).BeginInit();
            this.dataLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMailTemplate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoPictureEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgSplit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMailMergeSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFullName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcSnap)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(DevExpress.DevAV.Employee);
            this.snapControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            dataSourceInfo1.DataSource = this.bindingSource;
            dataSourceInfo1.DataSourceName = "Employee";
            this.snapControl.DataSources.Add(dataSourceInfo1);
            this.snapControl.EnableToolTips = false;
            this.snapControl.Location = new System.Drawing.Point(0, 0);
            this.snapControl.Modified = true;
            this.snapControl.Name = "snapControl";
            this.snapControl.Options.Comments.ShowAllAuthors = false;
            this.snapControl.Options.CopyPaste.MaintainDocumentSectionSettings = false;
            this.snapControl.Options.Fields.UseCurrentCultureDateTimeFormat = false;
            this.snapControl.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.snapControl.Options.SnapMailMergeVisualOptions.DataSource = this.bindingSource;
            this.snapControl.Options.SnapMailMergeVisualOptions.DataSourceName = "Employee";
            this.snapControl.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.snapControl.Size = new System.Drawing.Size(506, 511);
            this.snapControl.TabIndex = 18;
            this.snapControl.Views.PrintLayoutView.AllowDisplayLineNumbers = false;
            this.dataLayout.AllowCustomization = false;
            this.dataLayout.BackColor = System.Drawing.Color.White;
            this.dataLayout.Controls.Add(this.searchControl);
            this.dataLayout.Controls.Add(this.snapControl);
            this.dataLayout.Controls.Add(this.employeesList);
            this.dataLayout.Controls.Add(this.cbMailTemplate);
            this.dataLayout.Controls.Add(this.FullNameLabel);
            this.dataLayout.Controls.Add(this.TitleLabel);
            this.dataLayout.Controls.Add(this.PhotoPictureEdit);
            this.dataLayout.DataSource = this.bindingSource;
            this.dataLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayout.Location = new System.Drawing.Point(0, 0);
            this.dataLayout.Margin = new System.Windows.Forms.Padding(0);
            this.dataLayout.Name = "dataLayout";
            this.dataLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(279, 92, 622, 722);
            this.dataLayout.OptionsView.UseParentAutoScaleFactor = true;
            this.dataLayout.Root = this.lcgRoot;
            this.dataLayout.Size = new System.Drawing.Size(843, 511);
            this.dataLayout.TabIndex = 1;
            this.dataLayout.Text = "dataLayoutControl1";
            this.searchControl.Client = this.employeesList;
            this.searchControl.Location = new System.Drawing.Point(524, 269);
            this.searchControl.MaximumSize = new System.Drawing.Size(300, 38);
            this.searchControl.MinimumSize = new System.Drawing.Size(100, 38);
            this.searchControl.Name = "searchControl";
            this.searchControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(40, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::DevExpress.DevAV.Properties.Resources.Clear1, true, true),
            new DevExpress.XtraEditors.Repository.SearchButton(40, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("searchControl.Properties.Buttons"))), true, true)});
            this.searchControl.Size = new System.Drawing.Size(300, 38);
            this.searchControl.StyleController = this.dataLayout;
            this.searchControl.TabIndex = 22;
            this.searchControl.QueryIsSearchColumn += new DevExpress.XtraEditors.QueryIsSearchColumnEventHandler(this.searchControl_QueryIsSearchColumn);
            this.employeesList.DataSource = this.bindingSource;
            this.employeesList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.employeesList.Location = new System.Drawing.Point(522, 309);
            this.employeesList.MainView = this.gridView;
            this.employeesList.Margin = new System.Windows.Forms.Padding(6);
            this.employeesList.Name = "employeesList";
            this.employeesList.ShowOnlyPredefinedDetails = true;
            this.employeesList.Size = new System.Drawing.Size(307, 192);
            this.employeesList.TabIndex = 20;
            this.employeesList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            this.gridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2});
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colPhoto,
            this.colFullName,
            this.colTitle});
            this.gridView.CustomizationFormBounds = new System.Drawing.Rectangle(1111, 708, 216, 215);
            this.gridView.GridControl = this.employeesList;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsDetail.EnableMasterViewMode = false;
            this.gridView.OptionsFind.AllowFindPanel = false;
            this.gridView.OptionsView.ColumnAutoWidth = true;
            this.gridView.OptionsView.ShowBands = false;
            this.gridView.OptionsView.ShowColumnHeaders = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridBand1.Columns.Add(this.colPhoto);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.OptionsBand.AllowSize = false;
            this.gridBand1.OptionsBand.FixedWidth = true;
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 50;
            this.colPhoto.FieldName = "Photo";
            this.colPhoto.Name = "colPhoto";
            this.colPhoto.OptionsColumn.AllowEdit = false;
            this.colPhoto.OptionsColumn.AllowFocus = false;
            this.colPhoto.RowCount = 2;
            this.colPhoto.Visible = true;
            this.colPhoto.Width = 50;
            this.gridBand2.Columns.Add(this.colFullName);
            this.gridBand2.Columns.Add(this.colTitle);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 218;
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.OptionsColumn.AllowEdit = false;
            this.colFullName.OptionsColumn.AllowFocus = false;
            this.colFullName.Visible = true;
            this.colFullName.Width = 218;
            this.colTitle.AppearanceCell.Options.UseTextOptions = true;
            this.colTitle.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.colTitle.FieldName = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.OptionsColumn.AllowEdit = false;
            this.colTitle.OptionsColumn.AllowFocus = false;
            this.colTitle.RowIndex = 1;
            this.colTitle.Visible = true;
            this.colTitle.Width = 218;
            this.cbMailTemplate.Location = new System.Drawing.Point(522, 197);
            this.cbMailTemplate.Margin = new System.Windows.Forms.Padding(6);
            this.cbMailTemplate.Name = "cbMailTemplate";
            this.cbMailTemplate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.cbMailTemplate.Size = new System.Drawing.Size(307, 40);
            this.cbMailTemplate.StyleController = this.dataLayout;
            this.cbMailTemplate.TabIndex = 19;
            this.FullNameLabel.Appearance.FontSizeDelta = 3;
            this.FullNameLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "FullName", true));
            this.FullNameLabel.Location = new System.Drawing.Point(671, 12);
            this.FullNameLabel.Margin = new System.Windows.Forms.Padding(6);
            this.FullNameLabel.Name = "FullNameLabel";
            this.FullNameLabel.Size = new System.Drawing.Size(156, 25);
            this.FullNameLabel.StyleController = this.dataLayout;
            this.FullNameLabel.TabIndex = 8;
            this.TitleLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Title", true));
            this.TitleLabel.Location = new System.Drawing.Point(671, 41);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(6);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(156, 20);
            this.TitleLabel.StyleController = this.dataLayout;
            this.TitleLabel.TabIndex = 8;
            this.PhotoPictureEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "Photo", true));
            this.PhotoPictureEdit.Location = new System.Drawing.Point(522, 10);
            this.PhotoPictureEdit.Margin = new System.Windows.Forms.Padding(6);
            this.PhotoPictureEdit.Name = "PhotoPictureEdit";
            this.PhotoPictureEdit.Properties.ReadOnly = true;
            this.PhotoPictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.PhotoPictureEdit.Size = new System.Drawing.Size(143, 157);
            this.PhotoPictureEdit.StyleController = this.dataLayout;
            this.PhotoPictureEdit.TabIndex = 17;
            this.lcgRoot.CustomizationFormText = "Root";
            this.lcgRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
            this.lcgRoot.GroupBordersVisible = false;
            this.lcgRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgSplit});
            this.lcgRoot.Location = new System.Drawing.Point(0, 0);
            this.lcgRoot.Name = "lcgRoot";
            this.lcgRoot.OptionsItemText.TextToControlDistance = 6;
            this.lcgRoot.Size = new System.Drawing.Size(843, 511);
            this.lcgRoot.Text = "lcgRoot";
            this.lcgRoot.TextVisible = false;
            this.lcgSplit.AllowDrawBackground = false;
            this.lcgSplit.CustomizationFormText = "autoGeneratedGroup0";
            this.lcgSplit.GroupBordersVisible = false;
            this.lcgSplit.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgMailMergeSetting,
            this.simpleSeparator1,
            this.lcSnap});
            this.lcgSplit.Location = new System.Drawing.Point(0, 0);
            this.lcgSplit.Name = "lcgSplit";
            this.lcgSplit.OptionsItemText.TextToControlDistance = 6;
            this.lcgSplit.Size = new System.Drawing.Size(843, 511);
            this.lcgSplit.Text = "lcgSplit";
            this.lcgMailMergeSetting.CustomizationFormText = "lcgMailMergeSetting";
            this.lcgMailMergeSetting.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMailMergeSetting.GroupBordersVisible = false;
            this.lcgMailMergeSetting.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.ItemForTitle,
            this.ItemForFullName,
            this.ItemForPhoto,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem1});
            this.lcgMailMergeSetting.Location = new System.Drawing.Point(508, 0);
            this.lcgMailMergeSetting.Name = "lcgMailMergeSetting";
            this.lcgMailMergeSetting.OptionsItemText.TextToControlDistance = 6;
            this.lcgMailMergeSetting.Padding = new DevExpress.XtraLayout.Utils.Padding(12, 12, 8, 8);
            this.lcgMailMergeSetting.Size = new System.Drawing.Size(335, 511);
            this.lcgMailMergeSetting.Text = "lcgMailMergeSetting";
            this.lcgMailMergeSetting.TextVisible = false;
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(147, 53);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(160, 10);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(160, 108);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForTitle.Control = this.TitleLabel;
            this.ItemForTitle.CustomizationFormText = "Title";
            this.ItemForTitle.Location = new System.Drawing.Point(147, 29);
            this.ItemForTitle.Name = "ItemForTitle";
            this.ItemForTitle.Size = new System.Drawing.Size(160, 24);
            this.ItemForTitle.Text = "Title";
            this.ItemForTitle.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForTitle.TextToControlDistance = 0;
            this.ItemForTitle.TextVisible = false;
            this.ItemForFullName.Control = this.FullNameLabel;
            this.ItemForFullName.CustomizationFormText = "Full Name";
            this.ItemForFullName.Location = new System.Drawing.Point(147, 0);
            this.ItemForFullName.Name = "ItemForFullName";
            this.ItemForFullName.Size = new System.Drawing.Size(160, 29);
            this.ItemForFullName.Text = "Full Name";
            this.ItemForFullName.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForFullName.TextToControlDistance = 0;
            this.ItemForFullName.TextVisible = false;
            this.ItemForPhoto.Control = this.PhotoPictureEdit;
            this.ItemForPhoto.CustomizationFormText = "Photo";
            this.ItemForPhoto.Location = new System.Drawing.Point(0, 0);
            this.ItemForPhoto.MaxSize = new System.Drawing.Size(147, 161);
            this.ItemForPhoto.MinSize = new System.Drawing.Size(147, 161);
            this.ItemForPhoto.Name = "ItemForPhoto";
            this.ItemForPhoto.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 4, 0, 4);
            this.ItemForPhoto.Size = new System.Drawing.Size(147, 161);
            this.ItemForPhoto.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForPhoto.Text = "Photo";
            this.ItemForPhoto.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForPhoto.TextToControlDistance = 0;
            this.ItemForPhoto.TextVisible = false;
            this.layoutControlItem3.Control = this.employeesList;
            this.layoutControlItem3.CustomizationFormText = "Select Employee";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 299);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem3.Size = new System.Drawing.Size(307, 192);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            this.layoutControlItem2.Control = this.cbMailTemplate;
            this.layoutControlItem2.CustomizationFormText = "Mail Template";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 161);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 4);
            this.layoutControlItem2.Size = new System.Drawing.Size(307, 70);
            this.layoutControlItem2.Text = "Letter Template:";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(175, 20);
            this.layoutControlItem1.Control = this.searchControl;
            this.layoutControlItem1.CustomizationFormText = "Select Employee from List:";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 231);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(307, 68);
            this.layoutControlItem1.Text = "Select Employee from List:";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(175, 20);
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.CustomizationFormText = "simpleSeparator1";
            this.simpleSeparator1.Location = new System.Drawing.Point(506, 0);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(2, 511);
            this.simpleSeparator1.Text = "simpleSeparator1";
            this.lcSnap.Control = this.snapControl;
            this.lcSnap.CustomizationFormText = "lcSnap";
            this.lcSnap.Location = new System.Drawing.Point(0, 0);
            this.lcSnap.Name = "lcSnap";
            this.lcSnap.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcSnap.Size = new System.Drawing.Size(506, 511);
            this.lcSnap.Text = "lcSnap";
            this.lcSnap.TextSize = new System.Drawing.Size(0, 0);
            this.lcSnap.TextToControlDistance = 0;
            this.lcSnap.TextVisible = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayout);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "EmployeeMailMerge";
            this.Size = new System.Drawing.Size(843, 511);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayout)).EndInit();
            this.dataLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMailTemplate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoPictureEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgSplit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMailMergeSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFullName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcSnap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private XtraDataLayout.DataLayoutControl dataLayout;
        private XtraLayout.LayoutControlGroup lcgRoot;
        private System.Windows.Forms.BindingSource bindingSource;
        private XtraEditors.LabelControl FullNameLabel;
        private XtraEditors.LabelControl TitleLabel;
        private XtraEditors.PictureEdit PhotoPictureEdit;
        private XtraLayout.LayoutControlGroup lcgSplit;
        private XtraLayout.LayoutControlItem ItemForFullName;
        private XtraLayout.LayoutControlItem ItemForTitle;
        private XtraLayout.LayoutControlItem ItemForPhoto;
        private DevExpress.Snap.SnapControl snapControl;
        private XtraLayout.EmptySpaceItem emptySpaceItem2;
        private XtraLayout.LayoutControlGroup lcgMailMergeSetting;
        private XtraEditors.ImageComboBoxEdit cbMailTemplate;
        private XtraLayout.LayoutControlItem layoutControlItem2;
        private XtraGrid.GridControl employeesList;
        private XtraLayout.LayoutControlItem layoutControlItem3;
        private XtraGrid.Views.BandedGrid.AdvBandedGridView gridView;
        private XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private XtraGrid.Views.BandedGrid.BandedGridColumn colFullName;
        private XtraGrid.Views.BandedGrid.BandedGridColumn colPhoto;
        private XtraGrid.Views.BandedGrid.BandedGridColumn colTitle;
        private XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private XtraLayout.SimpleSeparator simpleSeparator1;
        private XtraLayout.LayoutControlItem lcSnap;
        public XtraEditors.SearchControl searchControl;
        private XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
