namespace PHRMS.Modules {
    partial class Avertissements
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Avertissements));
            DevExpress.XtraEditors.TileItemElement tileItemElement11 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement12 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement13 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement14 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement15 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement16 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement17 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement18 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement19 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement20 = new DevExpress.XtraEditors.TileItemElement();
            this.tasksGridControl = new DevExpress.XtraGrid.GridControl();
            this.taskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tasksGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.AssignedTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OwnedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Subject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEnter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.priorityImageList = new DevExpress.Utils.ImageCollection(this.components);
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.tileControl1 = new DevExpress.XtraEditors.TileControl();
            this.tileGroup2 = new DevExpress.XtraEditors.TileGroup();
            this.tileItemAll = new DevExpress.XtraEditors.TileItem();
            this.tileItemSevere = new DevExpress.XtraEditors.TileItem();
            this.tileItemSerious = new DevExpress.XtraEditors.TileItem();
            this.tileItemInconvenient = new DevExpress.XtraEditors.TileItem();
            this.tileItemLow = new DevExpress.XtraEditors.TileItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tileControlLCI = new DevExpress.XtraLayout.LayoutControlItem();
            this.buttonHide = new DevExpress.XtraLayout.SimpleLabelItem();
            this.tasksSLI = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem2 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem3 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem4 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem5 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem7 = new DevExpress.XtraLayout.SimpleLabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priorityImageList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileControlLCI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksSLI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // tasksGridControl
            // 
            this.tasksGridControl.DataSource = this.taskBindingSource;
            this.tasksGridControl.Location = new System.Drawing.Point(310, 49);
            this.tasksGridControl.MainView = this.tasksGridView;
            this.tasksGridControl.Name = "tasksGridControl";
            this.tasksGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1,
            this.repositoryItemComboBox1});
            this.tasksGridControl.Size = new System.Drawing.Size(1072, 538);
            this.tasksGridControl.TabIndex = 1;
            this.tasksGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tasksGridView});
            // 
            // taskBindingSource
            // 
            this.taskBindingSource.DataSource = typeof(PHRMS.Data.Warning);
            // 
            // tasksGridView
            // 
            this.tasksGridView.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.tasksGridView.Appearance.FooterPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.tasksGridView.Appearance.GroupFooter.Options.UseTextOptions = true;
            this.tasksGridView.Appearance.GroupFooter.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.tasksGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.AssignedTo,
            this.OwnedBy,
            this.Subject,
            this.DueDate,
            this.StartDate,
            this.colEnter});
            this.tasksGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.tasksGridView.FooterPanelHeight = 60;
            this.tasksGridView.GridControl = this.tasksGridControl;
            this.tasksGridView.Name = "tasksGridView";
            this.tasksGridView.OptionsBehavior.Editable = false;
            this.tasksGridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.tasksGridView.OptionsFind.AllowFindPanel = false;
            this.tasksGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.tasksGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.tasksGridView.OptionsView.ShowFooter = true;
            this.tasksGridView.OptionsView.ShowGroupPanel = false;
            this.tasksGridView.OptionsView.ShowIndicator = false;
            this.tasksGridView.RowHeight = 10;
            this.tasksGridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.DueDate, DevExpress.Data.ColumnSortOrder.Descending)});
            this.tasksGridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.tasksGridView_RowClick);
            this.tasksGridView.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.tasksGridView_FocusedRowObjectChanged);
            // 
            // AssignedTo
            // 
            this.AssignedTo.Caption = "Employé";
            this.AssignedTo.FieldName = "Employee.FullName";
            this.AssignedTo.Name = "AssignedTo";
            this.AssignedTo.Visible = true;
            this.AssignedTo.VisibleIndex = 1;
            this.AssignedTo.Width = 190;
            // 
            // OwnedBy
            // 
            this.OwnedBy.Caption = "Responsable";
            this.OwnedBy.FieldName = "CreatedBy.FullName";
            this.OwnedBy.Name = "OwnedBy";
            this.OwnedBy.Visible = true;
            this.OwnedBy.VisibleIndex = 2;
            this.OwnedBy.Width = 185;
            // 
            // Subject
            // 
            this.Subject.Caption = "Raison";
            this.Subject.FieldName = "Reason";
            this.Subject.Name = "Subject";
            this.Subject.Visible = true;
            this.Subject.VisibleIndex = 5;
            this.Subject.Width = 412;
            // 
            // DueDate
            // 
            this.DueDate.Caption = "Date";
            this.DueDate.FieldName = "Date";
            this.DueDate.Name = "DueDate";
            this.DueDate.OptionsColumn.FixedWidth = true;
            this.DueDate.Visible = true;
            this.DueDate.VisibleIndex = 0;
            this.DueDate.Width = 115;
            // 
            // StartDate
            // 
            this.StartDate.Caption = "Sévérité";
            this.StartDate.FieldName = "Severity";
            this.StartDate.Name = "StartDate";
            this.StartDate.OptionsColumn.FixedWidth = true;
            this.StartDate.Visible = true;
            this.StartDate.VisibleIndex = 4;
            this.StartDate.Width = 79;
            // 
            // colEnter
            // 
            this.colEnter.Caption = "Type";
            this.colEnter.FieldName = "Type";
            this.colEnter.Name = "colEnter";
            this.colEnter.Visible = true;
            this.colEnter.VisibleIndex = 3;
            this.colEnter.Width = 89;
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            this.repositoryItemProgressBar1.ProgressPadding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.repositoryItemProgressBar1.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.repositoryItemProgressBar1.ShowTitle = true;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemComboBox1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", PHRMS.Data.LeavePriority.Low, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", PHRMS.Data.LeavePriority.Normal, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", PHRMS.Data.LeavePriority.High, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", PHRMS.Data.LeavePriority.Urgent, 3)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.PopupSizeable = true;
            this.repositoryItemComboBox1.SmallImages = this.priorityImageList;
            // 
            // priorityImageList
            // 
            this.priorityImageList.ImageSize = new System.Drawing.Size(24, 24);
            this.priorityImageList.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("priorityImageList.ImageStream")));
            this.priorityImageList.InsertImage(global::PHRMS.Properties.Resources.LowPriority, "LowPriority", typeof(global::PHRMS.Properties.Resources), 0);
            this.priorityImageList.Images.SetKeyName(0, "LowPriority");
            this.priorityImageList.InsertImage(global::PHRMS.Properties.Resources.NormalPriority, "NormalPriority", typeof(global::PHRMS.Properties.Resources), 1);
            this.priorityImageList.Images.SetKeyName(1, "NormalPriority");
            this.priorityImageList.InsertImage(global::PHRMS.Properties.Resources.MediumPriority, "MediumPriority", typeof(global::PHRMS.Properties.Resources), 2);
            this.priorityImageList.Images.SetKeyName(2, "MediumPriority");
            this.priorityImageList.InsertImage(global::PHRMS.Properties.Resources.HighPriority, "HighPriority", typeof(global::PHRMS.Properties.Resources), 3);
            this.priorityImageList.Images.SetKeyName(3, "HighPriority");
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.AllowCustomization = false;
            this.dataLayoutControl1.BackColor = System.Drawing.Color.White;
            this.dataLayoutControl1.Controls.Add(this.tileControl1);
            this.dataLayoutControl1.Controls.Add(this.tasksGridControl);
            this.dataLayoutControl1.DataSource = this.taskBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(810, 371, 864, 732);
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(1424, 589);
            this.dataLayoutControl1.TabIndex = 26;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // tileControl1
            // 
            this.tileControl1.AllowDrag = false;
            this.tileControl1.AllowGlyphSkinning = true;
            this.tileControl1.AllowSelectedItem = true;
            this.tileControl1.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(114)))), ((int)(((byte)(191)))));
            this.tileControl1.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.tileControl1.AppearanceItem.Normal.BackColor = System.Drawing.Color.White;
            this.tileControl1.AppearanceItem.Normal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.tileControl1.AppearanceItem.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.tileControl1.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileControl1.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileControl1.AppearanceItem.Normal.Options.UseForeColor = true;
            this.tileControl1.AppearanceItem.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(69)))), ((int)(((byte)(148)))));
            this.tileControl1.AppearanceItem.Pressed.Options.UseBackColor = true;
            this.tileControl1.AppearanceItem.Selected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(81)))), ((int)(((byte)(165)))));
            this.tileControl1.AppearanceItem.Selected.BorderColor = System.Drawing.Color.Transparent;
            this.tileControl1.AppearanceItem.Selected.ForeColor = System.Drawing.Color.White;
            this.tileControl1.AppearanceItem.Selected.Options.UseBackColor = true;
            this.tileControl1.AppearanceItem.Selected.Options.UseBorderColor = true;
            this.tileControl1.AppearanceItem.Selected.Options.UseForeColor = true;
            this.tileControl1.DragSize = new System.Drawing.Size(0, 0);
            this.tileControl1.Groups.Add(this.tileGroup2);
            this.tileControl1.IndentBetweenItems = 5;
            this.tileControl1.ItemPadding = new System.Windows.Forms.Padding(7, 7, 7, 4);
            this.tileControl1.ItemSize = 80;
            this.tileControl1.Location = new System.Drawing.Point(42, 47);
            this.tileControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tileControl1.MaxId = 7;
            this.tileControl1.Name = "tileControl1";
            this.tileControl1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileControl1.Padding = new System.Windows.Forms.Padding(0);
            this.tileControl1.SelectedItem = this.tileItemAll;
            this.tileControl1.Size = new System.Drawing.Size(236, 540);
            this.tileControl1.TabIndex = 26;
            this.tileControl1.Text = "tileControl1";
            // 
            // tileGroup2
            // 
            this.tileGroup2.Items.Add(this.tileItemAll);
            this.tileGroup2.Items.Add(this.tileItemSevere);
            this.tileGroup2.Items.Add(this.tileItemSerious);
            this.tileGroup2.Items.Add(this.tileItemInconvenient);
            this.tileGroup2.Items.Add(this.tileItemLow);
            this.tileGroup2.Name = "tileGroup2";
            this.tileGroup2.Text = null;
            // 
            // tileItemAll
            // 
            tileItemElement11.Appearance.Normal.FontSizeDelta = 128;
            tileItemElement11.Appearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            tileItemElement11.Appearance.Normal.Options.UseFont = true;
            tileItemElement11.Appearance.Normal.Options.UseForeColor = true;
            tileItemElement11.Appearance.Selected.FontSizeDelta = 128;
            tileItemElement11.Appearance.Selected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(168)))), ((int)(((byte)(209)))));
            tileItemElement11.Appearance.Selected.Options.UseFont = true;
            tileItemElement11.Appearance.Selected.Options.UseForeColor = true;
            tileItemElement11.Text = "183";
            tileItemElement11.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            tileItemElement11.TextLocation = new System.Drawing.Point(-2, -12);
            tileItemElement12.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement12.Image")));
            tileItemElement12.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileItemElement12.Text = "Tous";
            tileItemElement12.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft;
            this.tileItemAll.Elements.Add(tileItemElement11);
            this.tileItemAll.Elements.Add(tileItemElement12);
            this.tileItemAll.Id = 0;
            this.tileItemAll.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileItemAll.Name = "tileItemAll";
            this.tileItemAll.Tag = "Severity != \'null\'";
            this.tileItemAll.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem_ItemClick);
            // 
            // tileItemSevere
            // 
            tileItemElement13.Appearance.Normal.FontSizeDelta = 128;
            tileItemElement13.Appearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            tileItemElement13.Appearance.Normal.Options.UseFont = true;
            tileItemElement13.Appearance.Normal.Options.UseForeColor = true;
            tileItemElement13.Appearance.Selected.FontSizeDelta = 128;
            tileItemElement13.Appearance.Selected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(168)))), ((int)(((byte)(209)))));
            tileItemElement13.Appearance.Selected.Options.UseFont = true;
            tileItemElement13.Appearance.Selected.Options.UseForeColor = true;
            tileItemElement13.Text = "5";
            tileItemElement13.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            tileItemElement13.TextLocation = new System.Drawing.Point(-2, -12);
            tileItemElement14.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement14.Image")));
            tileItemElement14.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileItemElement14.Text = "Sévére";
            tileItemElement14.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft;
            this.tileItemSevere.Elements.Add(tileItemElement13);
            this.tileItemSevere.Elements.Add(tileItemElement14);
            this.tileItemSevere.Id = 1;
            this.tileItemSevere.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileItemSevere.Name = "tileItemSevere";
            this.tileItemSevere.Tag = "Severity == \'Severe\'";
            this.tileItemSevere.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem_ItemClick);
            // 
            // tileItemSerious
            // 
            tileItemElement15.Appearance.Normal.FontSizeDelta = 128;
            tileItemElement15.Appearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            tileItemElement15.Appearance.Normal.Options.UseFont = true;
            tileItemElement15.Appearance.Normal.Options.UseForeColor = true;
            tileItemElement15.Appearance.Selected.FontSizeDelta = 128;
            tileItemElement15.Appearance.Selected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(168)))), ((int)(((byte)(209)))));
            tileItemElement15.Appearance.Selected.Options.UseFont = true;
            tileItemElement15.Appearance.Selected.Options.UseForeColor = true;
            tileItemElement15.Text = "5";
            tileItemElement15.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            tileItemElement15.TextLocation = new System.Drawing.Point(-2, -12);
            tileItemElement16.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement16.Image")));
            tileItemElement16.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileItemElement16.Text = "Grave";
            tileItemElement16.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft;
            this.tileItemSerious.Elements.Add(tileItemElement15);
            this.tileItemSerious.Elements.Add(tileItemElement16);
            this.tileItemSerious.Id = 2;
            this.tileItemSerious.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileItemSerious.Name = "tileItemSerious";
            this.tileItemSerious.Tag = "Severity == \'Serious\'";
            this.tileItemSerious.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem_ItemClick);
            // 
            // tileItemInconvenient
            // 
            tileItemElement17.Appearance.Normal.FontSizeDelta = 128;
            tileItemElement17.Appearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            tileItemElement17.Appearance.Normal.Options.UseFont = true;
            tileItemElement17.Appearance.Normal.Options.UseForeColor = true;
            tileItemElement17.Appearance.Selected.FontSizeDelta = 128;
            tileItemElement17.Appearance.Selected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(168)))), ((int)(((byte)(209)))));
            tileItemElement17.Appearance.Selected.Options.UseFont = true;
            tileItemElement17.Appearance.Selected.Options.UseForeColor = true;
            tileItemElement17.Text = "5";
            tileItemElement17.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            tileItemElement17.TextLocation = new System.Drawing.Point(-2, -12);
            tileItemElement18.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement18.Image")));
            tileItemElement18.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileItemElement18.Text = "Gènant";
            tileItemElement18.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft;
            this.tileItemInconvenient.Elements.Add(tileItemElement17);
            this.tileItemInconvenient.Elements.Add(tileItemElement18);
            this.tileItemInconvenient.Id = 3;
            this.tileItemInconvenient.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileItemInconvenient.Name = "tileItemInconvenient";
            this.tileItemInconvenient.Tag = "Severity = \'Inconvenient\'";
            this.tileItemInconvenient.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem_ItemClick);
            // 
            // tileItemLow
            // 
            tileItemElement19.Appearance.Normal.FontSizeDelta = 128;
            tileItemElement19.Appearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            tileItemElement19.Appearance.Normal.Options.UseFont = true;
            tileItemElement19.Appearance.Normal.Options.UseForeColor = true;
            tileItemElement19.Appearance.Selected.FontSizeDelta = 128;
            tileItemElement19.Appearance.Selected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(168)))), ((int)(((byte)(209)))));
            tileItemElement19.Appearance.Selected.Options.UseFont = true;
            tileItemElement19.Appearance.Selected.Options.UseForeColor = true;
            tileItemElement19.Text = "5";
            tileItemElement19.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            tileItemElement19.TextLocation = new System.Drawing.Point(-2, -12);
            tileItemElement20.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement20.Image")));
            tileItemElement20.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileItemElement20.Text = "Faible";
            tileItemElement20.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft;
            this.tileItemLow.Elements.Add(tileItemElement19);
            this.tileItemLow.Elements.Add(tileItemElement20);
            this.tileItemLow.Id = 4;
            this.tileItemLow.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileItemLow.Name = "tileItemLow";
            this.tileItemLow.Tag = "Severity == \'Low\'";
            this.tileItemLow.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem_ItemClick);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.tileControlLCI,
            this.buttonHide,
            this.tasksSLI});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(40, 40, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1424, 589);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.tasksGridControl;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(268, 45);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 4, 2);
            this.layoutControlItem1.Size = new System.Drawing.Size(1076, 544);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // tileControlLCI
            // 
            this.tileControlLCI.Control = this.tileControl1;
            this.tileControlLCI.CustomizationFormText = "tileControlLCI";
            this.tileControlLCI.Location = new System.Drawing.Point(0, 45);
            this.tileControlLCI.MaxSize = new System.Drawing.Size(240, 0);
            this.tileControlLCI.MinSize = new System.Drawing.Size(240, 24);
            this.tileControlLCI.Name = "tileControlLCI";
            this.tileControlLCI.OptionsPrint.AllowPrint = false;
            this.tileControlLCI.Size = new System.Drawing.Size(240, 544);
            this.tileControlLCI.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.tileControlLCI.TextSize = new System.Drawing.Size(0, 0);
            this.tileControlLCI.TextVisible = false;
            // 
            // buttonHide
            // 
            this.buttonHide.AllowHotTrack = false;
            this.buttonHide.CustomizationFormText = " ";
            this.buttonHide.Image = ((System.Drawing.Image)(resources.GetObject("buttonHide.Image")));
            this.buttonHide.Location = new System.Drawing.Point(240, 45);
            this.buttonHide.MaxSize = new System.Drawing.Size(28, 0);
            this.buttonHide.MinSize = new System.Drawing.Size(28, 1);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(28, 544);
            this.buttonHide.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.buttonHide.Text = " ";
            this.buttonHide.TextSize = new System.Drawing.Size(83, 25);
            this.buttonHide.Click += new System.EventHandler(this.collapseButton_Click);
            // 
            // tasksSLI
            // 
            this.tasksSLI.AllowHotTrack = false;
            this.tasksSLI.AllowHtmlStringInCaption = true;
            this.tasksSLI.AppearanceItemCaption.FontSizeDelta = 3;
            this.tasksSLI.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(82)))), ((int)(((byte)(163)))));
            this.tasksSLI.AppearanceItemCaption.Options.UseFont = true;
            this.tasksSLI.AppearanceItemCaption.Options.UseForeColor = true;
            this.tasksSLI.CustomizationFormText = "TASKS";
            this.tasksSLI.Location = new System.Drawing.Point(0, 0);
            this.tasksSLI.Name = "tasksSLI";
            this.tasksSLI.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 2, 10, 10);
            this.tasksSLI.Size = new System.Drawing.Size(1344, 45);
            this.tasksSLI.Text = "Pointages";
            this.tasksSLI.TextSize = new System.Drawing.Size(83, 25);
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.AppearanceItemCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.simpleLabelItem1.CustomizationFormText = " ";
            this.simpleLabelItem1.Image = ((System.Drawing.Image)(resources.GetObject("simpleLabelItem1.Image")));
            this.simpleLabelItem1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.simpleLabelItem1.Location = new System.Drawing.Point(200, 34);
            this.simpleLabelItem1.MaxSize = new System.Drawing.Size(28, 0);
            this.simpleLabelItem1.MinSize = new System.Drawing.Size(28, 17);
            this.simpleLabelItem1.Name = "buttonHide";
            this.simpleLabelItem1.Size = new System.Drawing.Size(28, 512);
            this.simpleLabelItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.simpleLabelItem1.Text = " ";
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(127, 13);
            // 
            // simpleLabelItem2
            // 
            this.simpleLabelItem2.AllowHotTrack = false;
            this.simpleLabelItem2.AppearanceItemCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.simpleLabelItem2.CustomizationFormText = " ";
            this.simpleLabelItem2.Image = ((System.Drawing.Image)(resources.GetObject("simpleLabelItem2.Image")));
            this.simpleLabelItem2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.simpleLabelItem2.Location = new System.Drawing.Point(200, 34);
            this.simpleLabelItem2.MaxSize = new System.Drawing.Size(28, 0);
            this.simpleLabelItem2.MinSize = new System.Drawing.Size(28, 17);
            this.simpleLabelItem2.Name = "buttonHide";
            this.simpleLabelItem2.Size = new System.Drawing.Size(28, 512);
            this.simpleLabelItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.simpleLabelItem2.Text = " ";
            this.simpleLabelItem2.TextSize = new System.Drawing.Size(127, 13);
            // 
            // simpleLabelItem3
            // 
            this.simpleLabelItem3.AllowHotTrack = false;
            this.simpleLabelItem3.AppearanceItemCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.simpleLabelItem3.CustomizationFormText = " ";
            this.simpleLabelItem3.Image = ((System.Drawing.Image)(resources.GetObject("simpleLabelItem3.Image")));
            this.simpleLabelItem3.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.simpleLabelItem3.Location = new System.Drawing.Point(200, 34);
            this.simpleLabelItem3.MaxSize = new System.Drawing.Size(28, 0);
            this.simpleLabelItem3.MinSize = new System.Drawing.Size(28, 17);
            this.simpleLabelItem3.Name = "buttonHide";
            this.simpleLabelItem3.Size = new System.Drawing.Size(28, 512);
            this.simpleLabelItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.simpleLabelItem3.Text = " ";
            this.simpleLabelItem3.TextSize = new System.Drawing.Size(127, 13);
            // 
            // simpleLabelItem4
            // 
            this.simpleLabelItem4.AllowHotTrack = false;
            this.simpleLabelItem4.AppearanceItemCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.simpleLabelItem4.CustomizationFormText = " ";
            this.simpleLabelItem4.Image = ((System.Drawing.Image)(resources.GetObject("simpleLabelItem4.Image")));
            this.simpleLabelItem4.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.simpleLabelItem4.Location = new System.Drawing.Point(200, 34);
            this.simpleLabelItem4.MaxSize = new System.Drawing.Size(28, 0);
            this.simpleLabelItem4.MinSize = new System.Drawing.Size(28, 17);
            this.simpleLabelItem4.Name = "buttonHide";
            this.simpleLabelItem4.Size = new System.Drawing.Size(28, 512);
            this.simpleLabelItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.simpleLabelItem4.Text = " ";
            this.simpleLabelItem4.TextSize = new System.Drawing.Size(127, 13);
            // 
            // simpleLabelItem5
            // 
            this.simpleLabelItem5.AllowHotTrack = false;
            this.simpleLabelItem5.AppearanceItemCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.simpleLabelItem5.CustomizationFormText = " ";
            this.simpleLabelItem5.Image = ((System.Drawing.Image)(resources.GetObject("simpleLabelItem5.Image")));
            this.simpleLabelItem5.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.simpleLabelItem5.Location = new System.Drawing.Point(200, 34);
            this.simpleLabelItem5.MaxSize = new System.Drawing.Size(28, 0);
            this.simpleLabelItem5.MinSize = new System.Drawing.Size(28, 17);
            this.simpleLabelItem5.Name = "buttonHide";
            this.simpleLabelItem5.Size = new System.Drawing.Size(28, 512);
            this.simpleLabelItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.simpleLabelItem5.Text = " ";
            this.simpleLabelItem5.TextSize = new System.Drawing.Size(127, 13);
            // 
            // simpleLabelItem7
            // 
            this.simpleLabelItem7.AllowHotTrack = false;
            this.simpleLabelItem7.AppearanceItemCaption.FontSizeDelta = 5;
            this.simpleLabelItem7.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(82)))), ((int)(((byte)(163)))));
            this.simpleLabelItem7.AppearanceItemCaption.Options.UseFont = true;
            this.simpleLabelItem7.AppearanceItemCaption.Options.UseForeColor = true;
            this.simpleLabelItem7.CustomizationFormText = "Status";
            this.simpleLabelItem7.Location = new System.Drawing.Point(151, 0);
            this.simpleLabelItem7.Name = "simpleLabelItem1";
            this.simpleLabelItem7.Size = new System.Drawing.Size(830, 34);
            this.simpleLabelItem7.Text = "Status";
            this.simpleLabelItem7.TextSize = new System.Drawing.Size(127, 30);
            // 
            // Avertissements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "Avertissements";
            this.Size = new System.Drawing.Size(1424, 589);
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priorityImageList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileControlLCI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksSLI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl tasksGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView tasksGridView;
        private DevExpress.XtraGrid.Columns.GridColumn AssignedTo;
        private DevExpress.XtraGrid.Columns.GridColumn OwnedBy;
        private DevExpress.XtraGrid.Columns.GridColumn Subject;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn DueDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private  DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private System.Windows.Forms.BindingSource taskBindingSource;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TileControl tileControl1;
        private DevExpress.XtraEditors.TileGroup tileGroup2;
        private DevExpress.XtraEditors.TileItem tileItemAll;
        private DevExpress.XtraEditors.TileItem tileItemSevere;
        private DevExpress.XtraEditors.TileItem tileItemInconvenient;
        private DevExpress.XtraEditors.TileItem tileItemSerious;
        private DevExpress.XtraEditors.TileItem tileItemLow;
        private DevExpress.XtraLayout.LayoutControlItem tileControlLCI;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem2;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem3;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem4;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem5;
        private DevExpress.XtraLayout.SimpleLabelItem buttonHide;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem7;
        private DevExpress.XtraLayout.SimpleLabelItem tasksSLI;
        private  DevExpress.Utils.ImageCollection priorityImageList;
        private DevExpress.XtraGrid.Columns.GridColumn StartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEnter;



    }
}
