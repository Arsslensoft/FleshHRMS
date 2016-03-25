using DevExpress.Utils.Animation;
using DevExpress;
namespace FHRMS {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.Utils.Animation.Transition transition1 = new DevExpress.Utils.Animation.Transition();
            DevExpress.Utils.Animation.SlideFadeTransition slideFadeTransition1 = new DevExpress.Utils.Animation.SlideFadeTransition();
            this.modulesContainer = new DevExpress.XtraEditors.XtraUserControl();
            this.tileNavPane = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.navButtonHome = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButtonHelp = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButtonClose = new DevExpress.XtraBars.Navigation.NavButton();
            this.mainTileBar = new DevExpress.XtraBars.Navigation.TileBar();
            this.tileBarGroup2 = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.dashboardTileBarItem = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.employeesTileBarItem = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tasksTileBarItem = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tileBarGroup3 = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.absencesTileBarItem = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.attendanceTileBarItem = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.warningsTileBarItem = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.statsTileBarItem = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.transitionManager1 = new DevExpress.Utils.Animation.TransitionManager();
            this.bottomPanelBase1 = new FHRMS.Modules.BottomPanelBase();
            this.flyoutPanel1 = new DevExpress.Utils.FlyoutPanel();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).BeginInit();
            this.flyoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // modulesContainer
            // 
            this.modulesContainer.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.modulesContainer.Appearance.Options.UseBackColor = true;
            this.modulesContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modulesContainer.Location = new System.Drawing.Point(0, 183);
            this.modulesContainer.Name = "modulesContainer";
            this.modulesContainer.Size = new System.Drawing.Size(1354, 550);
            this.modulesContainer.TabIndex = 0;
            // 
            // tileNavPane
            // 
            this.tileNavPane.AllowGlyphSkinning = true;
            this.tileNavPane.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.tileNavPane.Appearance.Options.UseBackColor = true;
            this.tileNavPane.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(212)))), ((int)(((byte)(219)))));
            this.tileNavPane.AppearanceHovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tileNavPane.AppearanceHovered.Options.UseBackColor = true;
            this.tileNavPane.AppearanceHovered.Options.UseForeColor = true;
            this.tileNavPane.AppearanceSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(212)))), ((int)(((byte)(219)))));
            this.tileNavPane.AppearanceSelected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tileNavPane.AppearanceSelected.Options.UseBackColor = true;
            this.tileNavPane.AppearanceSelected.Options.UseForeColor = true;
            this.tileNavPane.ButtonPadding = new System.Windows.Forms.Padding(12);
            this.tileNavPane.Buttons.Add(this.navButtonHome);
            this.tileNavPane.Buttons.Add(this.navButtonHelp);
            this.tileNavPane.Buttons.Add(this.navButtonClose);
            // 
            // tileNavCategory1
            // 
            this.tileNavPane.DefaultCategory.Name = "tileNavCategory1";
            this.tileNavPane.DefaultCategory.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane.DefaultCategory.OwnerCollection = null;
            // 
            // 
            // 
            this.tileNavPane.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileNavPane.DefaultCategory.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tileNavPane.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileNavPane.Location = new System.Drawing.Point(0, 0);
            this.tileNavPane.Name = "tileNavPane";
            this.tileNavPane.OptionsPrimaryDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane.OptionsSecondaryDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane.Size = new System.Drawing.Size(1354, 38);
            this.tileNavPane.TabIndex = 0;
            this.tileNavPane.Text = "tileNavPane1";
            // 
            // navButtonHome
            // 
            this.navButtonHome.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.navButtonHome.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.navButtonHome.Appearance.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navButtonHome.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(112)))), ((int)(((byte)(56)))));
            this.navButtonHome.Appearance.Options.UseFont = true;
            this.navButtonHome.Appearance.Options.UseForeColor = true;
            this.navButtonHome.Caption = "PHE<b>X</b>ON";
            this.navButtonHome.Enabled = false;
            this.navButtonHome.Name = "navButtonHome";
            // 
            // navButtonHelp
            // 
            this.navButtonHelp.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navButtonHelp.Caption = null;
            this.navButtonHelp.Glyph = ((System.Drawing.Image)(resources.GetObject("navButtonHelp.Glyph")));
            this.navButtonHelp.Name = "navButtonHelp";
            this.navButtonHelp.Visible = false;
            this.navButtonHelp.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.navButtonHelp_ElementClick);
            // 
            // navButtonClose
            // 
            this.navButtonClose.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navButtonClose.Caption = null;
            this.navButtonClose.Glyph = ((System.Drawing.Image)(resources.GetObject("navButtonClose.Glyph")));
            this.navButtonClose.Name = "navButtonClose";
            this.navButtonClose.Visible = false;
            this.navButtonClose.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.navButtonClose_ElementClick);
            // 
            // mainTileBar
            // 
            this.mainTileBar.AllowDrag = false;
            this.mainTileBar.AllowSelectedItem = true;
            this.mainTileBar.AppearanceGroupText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.mainTileBar.AppearanceGroupText.Options.UseForeColor = true;
            this.mainTileBar.BackColor = System.Drawing.Color.Black;
            this.mainTileBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainTileBar.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.mainTileBar.Groups.Add(this.tileBarGroup2);
            this.mainTileBar.Groups.Add(this.tileBarGroup3);
            this.mainTileBar.Location = new System.Drawing.Point(0, 38);
            this.mainTileBar.MaxId = 7;
            this.mainTileBar.Name = "mainTileBar";
            this.mainTileBar.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.mainTileBar.SelectedItem = this.dashboardTileBarItem;
            this.mainTileBar.SelectionBorderWidth = 2;
            this.mainTileBar.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.mainTileBar.Size = new System.Drawing.Size(1354, 145);
            this.mainTileBar.TabIndex = 1;
            this.mainTileBar.Text = "tileBar1";
            this.mainTileBar.SelectedItemChanged += new DevExpress.XtraEditors.TileItemClickEventHandler(this.mainTileBar_SelectedItemChanged);
            // 
            // tileBarGroup2
            // 
            this.tileBarGroup2.Items.Add(this.dashboardTileBarItem);
            this.tileBarGroup2.Items.Add(this.employeesTileBarItem);
            this.tileBarGroup2.Items.Add(this.tasksTileBarItem);
            this.tileBarGroup2.Name = "tileBarGroup2";
            // 
            // dashboardTileBarItem
            // 
            this.dashboardTileBarItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.dashboardTileBarItem.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(156)))));
            this.dashboardTileBarItem.AppearanceItem.Normal.Options.UseBackColor = true;
            this.dashboardTileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement1.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement1.Image")));
            tileItemElement1.Text = "Tableau de bord";
            this.dashboardTileBarItem.Elements.Add(tileItemElement1);
            this.dashboardTileBarItem.Id = 0;
            this.dashboardTileBarItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.dashboardTileBarItem.Name = "dashboardTileBarItem";
            // 
            // employeesTileBarItem
            // 
            this.employeesTileBarItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.employeesTileBarItem.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(109)))), ((int)(((byte)(0)))));
            this.employeesTileBarItem.AppearanceItem.Normal.Options.UseBackColor = true;
            this.employeesTileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement2.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement2.Image")));
            tileItemElement2.Text = "Employés";
            this.employeesTileBarItem.Elements.Add(tileItemElement2);
            this.employeesTileBarItem.Id = 2;
            this.employeesTileBarItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.employeesTileBarItem.Name = "employeesTileBarItem";
            // 
            // tasksTileBarItem
            // 
            this.tasksTileBarItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.tasksTileBarItem.AppearanceItem.Normal.BackColor = System.Drawing.Color.LimeGreen;
            this.tasksTileBarItem.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tasksTileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement3.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement3.Image")));
            tileItemElement3.Text = "Congés";
            this.tasksTileBarItem.Elements.Add(tileItemElement3);
            this.tasksTileBarItem.Id = 1;
            this.tasksTileBarItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tasksTileBarItem.Name = "tasksTileBarItem";
            // 
            // tileBarGroup3
            // 
            this.tileBarGroup3.Items.Add(this.absencesTileBarItem);
            this.tileBarGroup3.Items.Add(this.attendanceTileBarItem);
            this.tileBarGroup3.Items.Add(this.warningsTileBarItem);
            this.tileBarGroup3.Items.Add(this.statsTileBarItem);
            this.tileBarGroup3.Name = "tileBarGroup3";
            // 
            // absencesTileBarItem
            // 
            this.absencesTileBarItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.absencesTileBarItem.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(196)))));
            this.absencesTileBarItem.AppearanceItem.Normal.Options.UseBackColor = true;
            this.absencesTileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement4.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement4.Image")));
            tileItemElement4.Text = "Absences";
            this.absencesTileBarItem.Elements.Add(tileItemElement4);
            this.absencesTileBarItem.Id = 3;
            this.absencesTileBarItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.absencesTileBarItem.Name = "absencesTileBarItem";
            // 
            // attendanceTileBarItem
            // 
            this.attendanceTileBarItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.attendanceTileBarItem.AppearanceItem.Normal.BackColor = System.Drawing.Color.DarkViolet;
            this.attendanceTileBarItem.AppearanceItem.Normal.Options.UseBackColor = true;
            this.attendanceTileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement5.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement5.Image")));
            tileItemElement5.Text = "Pointage";
            this.attendanceTileBarItem.Elements.Add(tileItemElement5);
            this.attendanceTileBarItem.Id = 4;
            this.attendanceTileBarItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.attendanceTileBarItem.Name = "attendanceTileBarItem";
            // 
            // warningsTileBarItem
            // 
            this.warningsTileBarItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.warningsTileBarItem.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.warningsTileBarItem.AppearanceItem.Normal.Options.UseBackColor = true;
            this.warningsTileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement6.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement6.Image")));
            tileItemElement6.Text = "Avertissements";
            this.warningsTileBarItem.Elements.Add(tileItemElement6);
            this.warningsTileBarItem.Id = 5;
            this.warningsTileBarItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.warningsTileBarItem.Name = "warningsTileBarItem";
            // 
            // statsTileBarItem
            // 
            this.statsTileBarItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.statsTileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement7.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement7.Image")));
            tileItemElement7.Text = "Statistiques";
            this.statsTileBarItem.Elements.Add(tileItemElement7);
            this.statsTileBarItem.Id = 6;
            this.statsTileBarItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.statsTileBarItem.Name = "statsTileBarItem";
            // 
            // transitionManager1
            // 
            this.transitionManager1.ShowWaitingIndicator = false;
            transition1.Control = this.modulesContainer;
            slideFadeTransition1.Parameters.Background = System.Drawing.Color.Empty;
            slideFadeTransition1.Parameters.EffectOptions = DevExpress.Utils.Animation.PushEffectOptions.FromRight;
            slideFadeTransition1.Parameters.FrameInterval = 5000;
            transition1.TransitionType = slideFadeTransition1;
            this.transitionManager1.Transitions.Add(transition1);
            this.transitionManager1.BeforeTransitionStarts += new DevExpress.Utils.Animation.BeforeTransitionStartsEventHandler(this.transitionManager1_BeforeTransitionStarts);
            this.transitionManager1.AfterTransitionEnds += new DevExpress.Utils.Animation.AfterTransitionEndsEventHandler(this.transitionManager1_AfterTransitionEnds);
            // 
            // bottomPanelBase1
            // 
            this.bottomPanelBase1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomPanelBase1.Location = new System.Drawing.Point(0, 0);
            this.bottomPanelBase1.LookAndFeel.SkinName = "Metropolis Dark";
            this.bottomPanelBase1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.bottomPanelBase1.Margin = new System.Windows.Forms.Padding(2);
            this.bottomPanelBase1.MinimumSize = new System.Drawing.Size(0, 60);
            this.bottomPanelBase1.Name = "bottomPanelBase1";
            this.bottomPanelBase1.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.bottomPanelBase1.Size = new System.Drawing.Size(1384, 80);
            this.bottomPanelBase1.TabIndex = 1;
            // 
            // flyoutPanel1
            // 
            this.flyoutPanel1.Controls.Add(this.bottomPanelBase1);
            this.flyoutPanel1.Location = new System.Drawing.Point(0, 800);
            this.flyoutPanel1.MaximumSize = new System.Drawing.Size(0, 80);
            this.flyoutPanel1.MinimumSize = new System.Drawing.Size(0, 80);
            this.flyoutPanel1.Name = "flyoutPanel1";
            this.flyoutPanel1.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Bottom;
            this.flyoutPanel1.Options.CloseOnOuterClick = true;
            this.flyoutPanel1.OptionsButtonPanel.ButtonPanelLocation = DevExpress.Utils.FlyoutPanelButtonPanelLocation.Bottom;
            this.flyoutPanel1.OwnerControl = this;
            this.flyoutPanel1.Size = new System.Drawing.Size(1384, 80);
            this.flyoutPanel1.TabIndex = 5;
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 0;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1354, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 733);
            this.barDockControlBottom.Size = new System.Drawing.Size(1354, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 733);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1354, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 733);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Phexon";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.flyoutPanel1);
            this.Controls.Add(this.modulesContainer);
            this.Controls.Add(this.mainTileBar);
            this.Controls.Add(this.tileNavPane);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phexon Human Ressources Management System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).EndInit();
            this.flyoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private DevExpress.XtraBars.Navigation.TileNavPane tileNavPane;
        private DevExpress.XtraBars.Navigation.NavButton navButtonHelp;
        private DevExpress.XtraBars.Navigation.NavButton navButtonClose;
        public DevExpress.XtraBars.Navigation.TileBar mainTileBar;
        private DevExpress.XtraEditors.XtraUserControl modulesContainer;
        private TransitionManager transitionManager1;
        private DevExpress.XtraBars.Navigation.TileBarGroup tileBarGroup2;
        private DevExpress.XtraBars.Navigation.TileBarItem dashboardTileBarItem;
        private DevExpress.XtraBars.Navigation.TileBarItem tasksTileBarItem;
        private DevExpress.XtraBars.Navigation.TileBarItem employeesTileBarItem;
        private DevExpress.XtraBars.Navigation.TileBarGroup tileBarGroup3;
        private DevExpress.XtraBars.Navigation.TileBarItem absencesTileBarItem;
        private DevExpress.XtraBars.Navigation.TileBarItem attendanceTileBarItem;
        private DevExpress.XtraBars.Navigation.TileBarItem warningsTileBarItem;
        private DevExpress.XtraBars.Navigation.TileBarItem statsTileBarItem;
        private DevExpress.XtraBars.Navigation.NavButton navButtonHome;
        public Modules.BottomPanelBase bottomPanelBase1;
        private DevExpress.Utils.FlyoutPanel flyoutPanel1;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}
