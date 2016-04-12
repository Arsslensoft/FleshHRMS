namespace PHRMS.Widgets
{
    partial class HolidayWidget
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tasksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tasksGridControl = new DevExpress.XtraGrid.GridControl();
            this.tasksGridView = new DevExpress.XtraGrid.Views.Grid.GridViewWithButtons();
            this.colOwnedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.completeProgressBar = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.printRepositoryItemButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.completeProgressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printRepositoryItemButtonEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // tasksBindingSource
            // 
            this.tasksBindingSource.DataSource = typeof(PHRMS.Data.Holiday);
            // 
            // tasksGridControl
            // 
            this.tasksGridControl.DataSource = this.tasksBindingSource;
            this.tasksGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tasksGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.tasksGridControl.Location = new System.Drawing.Point(10, 10);
            this.tasksGridControl.MainView = this.tasksGridView;
            this.tasksGridControl.Name = "tasksGridControl";
            this.tasksGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.completeProgressBar,
            this.repositoryItemComboBox1,
            this.printRepositoryItemButtonEdit});
            this.tasksGridControl.Size = new System.Drawing.Size(598, 340);
            this.tasksGridControl.TabIndex = 25;
            this.tasksGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tasksGridView});
            // 
            // tasksGridView
            // 
            this.tasksGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOwnedBy,
            this.colSubject,
            this.colDueDate,
            this.colStart});
            this.tasksGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.tasksGridView.GridControl = this.tasksGridControl;
            this.tasksGridView.Name = "tasksGridView";
            this.tasksGridView.OptionsBehavior.Editable = false;
            this.tasksGridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.tasksGridView.OptionsFind.AllowFindPanel = false;
            this.tasksGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.tasksGridView.OptionsView.ShowGroupPanel = false;
            this.tasksGridView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.tasksGridView.OptionsView.ShowIndicator = false;
            this.tasksGridView.ShowButtons = false;
            this.tasksGridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.tasksGridView_RowClick);
            // 
            // colOwnedBy
            // 
            this.colOwnedBy.Caption = "Crée par";
            this.colOwnedBy.FieldName = "CreatedBy.FullName";
            this.colOwnedBy.Name = "colOwnedBy";
            this.colOwnedBy.Visible = true;
            this.colOwnedBy.VisibleIndex = 0;
            this.colOwnedBy.Width = 92;
            // 
            // colSubject
            // 
            this.colSubject.Caption = "Nom";
            this.colSubject.FieldName = "Name";
            this.colSubject.Name = "colSubject";
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 1;
            this.colSubject.Width = 229;
            // 
            // colDueDate
            // 
            this.colDueDate.Caption = "Date de fin";
            this.colDueDate.FieldName = "DueDate";
            this.colDueDate.Name = "colDueDate";
            this.colDueDate.Visible = true;
            this.colDueDate.VisibleIndex = 3;
            this.colDueDate.Width = 103;
            // 
            // colStart
            // 
            this.colStart.Caption = "Date de début";
            this.colStart.FieldName = "StartDate";
            this.colStart.Name = "colStart";
            this.colStart.Visible = true;
            this.colStart.VisibleIndex = 2;
            // 
            // completeProgressBar
            // 
            this.completeProgressBar.Name = "completeProgressBar";
            this.completeProgressBar.ProgressPadding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.completeProgressBar.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.completeProgressBar.ShowTitle = true;
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
            // 
            // printRepositoryItemButtonEdit
            // 
            this.printRepositoryItemButtonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Print", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.printRepositoryItemButtonEdit.Name = "printRepositoryItemButtonEdit";
            this.printRepositoryItemButtonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // NotificationWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tasksGridControl);
            this.Name = "NotificationWidget";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(618, 360);
            ((System.ComponentModel.ISupportInitialize)(this.tasksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.completeProgressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printRepositoryItemButtonEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource tasksBindingSource;
        private DevExpress.XtraGrid.GridControl tasksGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridViewWithButtons tasksGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colOwnedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStart;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar completeProgressBar;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit printRepositoryItemButtonEdit;






    }
}
