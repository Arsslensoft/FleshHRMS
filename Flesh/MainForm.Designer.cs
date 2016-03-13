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
        	DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
        	DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
        	DevExpress.XtraEditors.TileItemElement tileItemElement8 = new DevExpress.XtraEditors.TileItemElement();
        	DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
        	DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
        	DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
        	DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
        	DevExpress.XtraEditors.TileItemElement tileItemElement13 = new DevExpress.XtraEditors.TileItemElement();
        	DevExpress.XtraEditors.TileItemElement tileItemElement9 = new DevExpress.XtraEditors.TileItemElement();
        	DevExpress.XtraEditors.TileItemElement tileItemElement10 = new DevExpress.XtraEditors.TileItemElement();
        	DevExpress.XtraEditors.TileItemElement tileItemElement11 = new DevExpress.XtraEditors.TileItemElement();
        	DevExpress.XtraEditors.TileItemElement tileItemElement12 = new DevExpress.XtraEditors.TileItemElement();
        	DevExpress.XtraEditors.TileItemElement tileItemElement14 = new DevExpress.XtraEditors.TileItemElement();
        	DevExpress.XtraEditors.TileItemElement tileItemElement15 = new DevExpress.XtraEditors.TileItemElement();
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
        	this.tasksTileBarItem = new DevExpress.XtraBars.Navigation.TileBarItem();
        	this.employeesTileBarItem = new DevExpress.XtraBars.Navigation.TileBarItem();
        	this.tileBarGroup3 = new DevExpress.XtraBars.Navigation.TileBarGroup();
        	this.productsTileBarItem = new DevExpress.XtraBars.Navigation.TileBarItem();
        	this.productsTileBarDropDownContainter = new DevExpress.XtraBars.Navigation.TileBarDropDownContainer();
        	this.productTileBar = new DevExpress.XtraBars.Navigation.TileBar();
        	this.tileBarGroup1 = new DevExpress.XtraBars.Navigation.TileBarGroup();
        	this.hdVideoTBI = new DevExpress.XtraBars.Navigation.TileBarItem();
        	this.plasmaTBI = new DevExpress.XtraBars.Navigation.TileBarItem();
        	this.monitorTBI = new DevExpress.XtraBars.Navigation.TileBarItem();
        	this.remouteControlTBI = new DevExpress.XtraBars.Navigation.TileBarItem();
        	this.customersTileBarItem = new DevExpress.XtraBars.Navigation.TileBarItem();
        	this.customTileBarDropDownContainter = new DevExpress.XtraBars.Navigation.TileBarDropDownContainer();
        	this.customTileBar = new DevExpress.XtraBars.Navigation.TileBar();
        	this.tileBarGroup4 = new DevExpress.XtraBars.Navigation.TileBarGroup();
        	this.AllStoresTBI = new DevExpress.XtraBars.Navigation.TileBarItem();
        	this.customMyAccountTileBarItem = new DevExpress.XtraBars.Navigation.TileBarItem();
        	this.customJohnAccountTileBarItem = new DevExpress.XtraBars.Navigation.TileBarItem();
        	this.customTopStoresTileBarItem = new DevExpress.XtraBars.Navigation.TileBarItem();
        	this.salesTileBarItem = new DevExpress.XtraBars.Navigation.TileBarItem();
        	this.opportunitiesTileBarItem = new DevExpress.XtraBars.Navigation.TileBarItem();
        	this.transitionManager1 = new DevExpress.Utils.Animation.TransitionManager();
        	this.bottomPanelBase1 = new FHRMS.Modules.BottomPanelBase();
        	this.flyoutPanel1 = new DevExpress.Utils.FlyoutPanel();
        	this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
        	this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
        	this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
        	this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
        	this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
        	((System.ComponentModel.ISupportInitialize)(this.productsTileBarDropDownContainter)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.customTileBarDropDownContainter)).BeginInit();
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
        	this.modulesContainer.Location = new System.Drawing.Point(0, 161);
        	this.modulesContainer.Name = "modulesContainer";
        	this.modulesContainer.Size = new System.Drawing.Size(1362, 584);
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
        	this.tileNavPane.Size = new System.Drawing.Size(1362, 38);
        	this.tileNavPane.TabIndex = 0;
        	this.tileNavPane.Text = "tileNavPane1";
        	// 
        	// navButtonHome
        	// 
        	this.navButtonHome.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
        	this.navButtonHome.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
        	this.navButtonHome.Caption = null;
        	this.navButtonHome.Enabled = false;
        	this.navButtonHome.Glyph = ((System.Drawing.Image)(resources.GetObject("navButtonHome.Glyph")));
        	this.navButtonHome.Name = "navButtonHome";
        	// 
        	// navButtonHelp
        	// 
        	this.navButtonHelp.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
        	this.navButtonHelp.Caption = null;
        	this.navButtonHelp.Glyph = ((System.Drawing.Image)(resources.GetObject("navButtonHelp.Glyph")));
        	this.navButtonHelp.Name = "navButtonHelp";
        	this.navButtonHelp.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.navButtonHelp_ElementClick);
        	// 
        	// navButtonClose
        	// 
        	this.navButtonClose.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
        	this.navButtonClose.Caption = null;
        	this.navButtonClose.Glyph = ((System.Drawing.Image)(resources.GetObject("navButtonClose.Glyph")));
        	this.navButtonClose.Name = "navButtonClose";
        	this.navButtonClose.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.navButtonClose_ElementClick);
        	// 
        	// mainTileBar
        	// 
        	this.mainTileBar.AllowDrag = false;
        	this.mainTileBar.AllowSelectedItem = true;
        	this.mainTileBar.AppearanceGroupText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
        	this.mainTileBar.AppearanceGroupText.Options.UseForeColor = true;
        	this.mainTileBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
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
        	this.mainTileBar.Size = new System.Drawing.Size(1362, 123);
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
        	this.tileBarGroup2.Text = "MY WORLD";
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
        	// tasksTileBarItem
        	// 
        	this.tasksTileBarItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
        	this.tasksTileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
        	tileItemElement3.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement3.Image")));
        	tileItemElement3.Text = "Congés";
        	this.tasksTileBarItem.Elements.Add(tileItemElement3);
        	this.tasksTileBarItem.Id = 1;
        	this.tasksTileBarItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
        	this.tasksTileBarItem.Name = "tasksTileBarItem";
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
        	// tileBarGroup3
        	// 
        	this.tileBarGroup3.Items.Add(this.productsTileBarItem);
        	this.tileBarGroup3.Items.Add(this.customersTileBarItem);
        	this.tileBarGroup3.Items.Add(this.salesTileBarItem);
        	this.tileBarGroup3.Items.Add(this.opportunitiesTileBarItem);
        	this.tileBarGroup3.Name = "tileBarGroup3";
        	this.tileBarGroup3.Text = "OPERATIONS";
        	// 
        	// productsTileBarItem
        	// 
        	this.productsTileBarItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
        	this.productsTileBarItem.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(196)))));
        	this.productsTileBarItem.AppearanceItem.Normal.Options.UseBackColor = true;
        	this.productsTileBarItem.DropDownControl = this.productsTileBarDropDownContainter;
        	this.productsTileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
        	tileItemElement8.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement8.Image")));
        	tileItemElement8.Text = "Absences";
        	this.productsTileBarItem.Elements.Add(tileItemElement8);
        	this.productsTileBarItem.Id = 3;
        	this.productsTileBarItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
        	this.productsTileBarItem.Name = "productsTileBarItem";
        	// 
        	// productsTileBarDropDownContainter
        	// 
        	this.productsTileBarDropDownContainter.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(196)))));
        	this.productsTileBarDropDownContainter.Appearance.Options.UseBackColor = true;
        	this.productsTileBarDropDownContainter.Controls.Add(this.productTileBar);
        	this.productsTileBarDropDownContainter.Location = new System.Drawing.Point(0, 0);
        	this.productsTileBarDropDownContainter.Name = "productsTileBarDropDownContainter";
        	this.productsTileBarDropDownContainter.Size = new System.Drawing.Size(931, 120);
        	this.productsTileBarDropDownContainter.TabIndex = 3;
        	// 
        	// productTileBar
        	// 
        	this.productTileBar.AllowDrag = false;
        	this.productTileBar.AllowSelectedItem = true;
        	this.productTileBar.AppearanceGroupText.ForeColor = System.Drawing.Color.White;
        	this.productTileBar.AppearanceGroupText.Options.UseForeColor = true;
        	this.productTileBar.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(209)))), ((int)(((byte)(255)))));
        	this.productTileBar.AppearanceItem.Hovered.ForeColor = System.Drawing.Color.Black;
        	this.productTileBar.AppearanceItem.Hovered.Options.UseBackColor = true;
        	this.productTileBar.AppearanceItem.Hovered.Options.UseForeColor = true;
        	this.productTileBar.AppearanceItem.Normal.BackColor = System.Drawing.Color.White;
        	this.productTileBar.AppearanceItem.Normal.ForeColor = System.Drawing.Color.Black;
        	this.productTileBar.AppearanceItem.Normal.Options.UseBackColor = true;
        	this.productTileBar.AppearanceItem.Normal.Options.UseForeColor = true;
        	this.productTileBar.AppearanceItem.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(149)))), ((int)(((byte)(201)))));
        	this.productTileBar.AppearanceItem.Pressed.Options.UseBackColor = true;
        	this.productTileBar.AppearanceItem.Selected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(163)))), ((int)(((byte)(217)))));
        	this.productTileBar.AppearanceItem.Selected.ForeColor = System.Drawing.Color.White;
        	this.productTileBar.AppearanceItem.Selected.Options.UseBackColor = true;
        	this.productTileBar.AppearanceItem.Selected.Options.UseForeColor = true;
        	this.productTileBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(196)))));
        	this.productTileBar.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.productTileBar.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
        	this.productTileBar.Groups.Add(this.tileBarGroup1);
        	this.productTileBar.IndentBetweenGroups = 0;
        	this.productTileBar.ItemSize = 40;
        	this.productTileBar.Location = new System.Drawing.Point(0, 0);
        	this.productTileBar.MaxId = 5;
        	this.productTileBar.Name = "productTileBar";
        	this.productTileBar.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
        	this.productTileBar.SelectedItem = this.hdVideoTBI;
        	this.productTileBar.Size = new System.Drawing.Size(931, 120);
        	this.productTileBar.TabIndex = 1;
        	this.productTileBar.Text = "tileBar4";
        	this.productTileBar.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.productTileBar_ItemClick);
        	// 
        	// tileBarGroup1
        	// 
        	this.tileBarGroup1.Items.Add(this.hdVideoTBI);
        	this.tileBarGroup1.Items.Add(this.plasmaTBI);
        	this.tileBarGroup1.Items.Add(this.monitorTBI);
        	this.tileBarGroup1.Items.Add(this.remouteControlTBI);
        	this.tileBarGroup1.Name = "tileBarGroup1";
        	this.tileBarGroup1.Text = "CUSTOM FILTER";
        	// 
        	// hdVideoTBI
        	// 
        	this.hdVideoTBI.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
        	this.hdVideoTBI.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
        	tileItemElement4.Text = "HD Video player";
        	tileItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
        	this.hdVideoTBI.Elements.Add(tileItemElement4);
        	this.hdVideoTBI.Id = 0;
        	this.hdVideoTBI.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
        	this.hdVideoTBI.Name = "hdVideoTBI";
        	this.hdVideoTBI.Tag = FHRMS.Modules.ProductCustomFilter.HDVideoPlayer;
        	// 
        	// plasmaTBI
        	// 
        	this.plasmaTBI.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
        	this.plasmaTBI.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
        	tileItemElement5.Text = "50inch Plasma";
        	tileItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
        	this.plasmaTBI.Elements.Add(tileItemElement5);
        	this.plasmaTBI.Id = 1;
        	this.plasmaTBI.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
        	this.plasmaTBI.Name = "plasmaTBI";
        	this.plasmaTBI.Tag = FHRMS.Modules.ProductCustomFilter.Plasma;
        	// 
        	// monitorTBI
        	// 
        	this.monitorTBI.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
        	this.monitorTBI.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
        	tileItemElement6.Text = "21inch Monitor";
        	tileItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
        	this.monitorTBI.Elements.Add(tileItemElement6);
        	this.monitorTBI.Id = 2;
        	this.monitorTBI.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
        	this.monitorTBI.Name = "monitorTBI";
        	this.monitorTBI.Tag = FHRMS.Modules.ProductCustomFilter.Monitor;
        	// 
        	// remouteControlTBI
        	// 
        	this.remouteControlTBI.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
        	this.remouteControlTBI.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
        	tileItemElement7.Text = "Remote Control";
        	tileItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
        	this.remouteControlTBI.Elements.Add(tileItemElement7);
        	this.remouteControlTBI.Id = 3;
        	this.remouteControlTBI.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
        	this.remouteControlTBI.Name = "remouteControlTBI";
        	this.remouteControlTBI.Tag = FHRMS.Modules.ProductCustomFilter.RemoteControl;
        	// 
        	// customersTileBarItem
        	// 
        	this.customersTileBarItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
        	this.customersTileBarItem.DropDownControl = this.customTileBarDropDownContainter;
        	this.customersTileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
        	tileItemElement13.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement13.Image")));
        	tileItemElement13.Text = "Pointage";
        	this.customersTileBarItem.Elements.Add(tileItemElement13);
        	this.customersTileBarItem.Id = 4;
        	this.customersTileBarItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
        	this.customersTileBarItem.Name = "customersTileBarItem";
        	// 
        	// customTileBarDropDownContainter
        	// 
        	this.customTileBarDropDownContainter.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
        	this.customTileBarDropDownContainter.Appearance.Options.UseBackColor = true;
        	this.customTileBarDropDownContainter.Controls.Add(this.customTileBar);
        	this.customTileBarDropDownContainter.Location = new System.Drawing.Point(0, 0);
        	this.customTileBarDropDownContainter.Name = "customTileBarDropDownContainter";
        	this.customTileBarDropDownContainter.Size = new System.Drawing.Size(821, 151);
        	this.customTileBarDropDownContainter.TabIndex = 2;
        	// 
        	// customTileBar
        	// 
        	this.customTileBar.AllowDrag = false;
        	this.customTileBar.AllowSelectedItem = true;
        	this.customTileBar.AppearanceGroupText.ForeColor = System.Drawing.Color.White;
        	this.customTileBar.AppearanceGroupText.Options.UseForeColor = true;
        	this.customTileBar.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
        	this.customTileBar.AppearanceItem.Hovered.ForeColor = System.Drawing.Color.White;
        	this.customTileBar.AppearanceItem.Hovered.Options.UseBackColor = true;
        	this.customTileBar.AppearanceItem.Hovered.Options.UseForeColor = true;
        	this.customTileBar.AppearanceItem.Normal.BackColor = System.Drawing.Color.White;
        	this.customTileBar.AppearanceItem.Normal.ForeColor = System.Drawing.Color.Black;
        	this.customTileBar.AppearanceItem.Normal.Options.UseBackColor = true;
        	this.customTileBar.AppearanceItem.Normal.Options.UseForeColor = true;
        	this.customTileBar.AppearanceItem.Selected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
        	this.customTileBar.AppearanceItem.Selected.ForeColor = System.Drawing.Color.White;
        	this.customTileBar.AppearanceItem.Selected.Options.UseBackColor = true;
        	this.customTileBar.AppearanceItem.Selected.Options.UseForeColor = true;
        	this.customTileBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
        	this.customTileBar.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.customTileBar.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
        	this.customTileBar.Groups.Add(this.tileBarGroup4);
        	this.customTileBar.IndentBetweenGroups = 0;
        	this.customTileBar.ItemSize = 40;
        	this.customTileBar.Location = new System.Drawing.Point(0, 0);
        	this.customTileBar.MaxId = 4;
        	this.customTileBar.Name = "customTileBar";
        	this.customTileBar.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
        	this.customTileBar.SelectedItem = this.AllStoresTBI;
        	this.customTileBar.Size = new System.Drawing.Size(821, 151);
        	this.customTileBar.TabIndex = 0;
        	this.customTileBar.Text = "tileBar2";
        	this.customTileBar.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.customTileBar_ItemClick);
        	// 
        	// tileBarGroup4
        	// 
        	this.tileBarGroup4.Items.Add(this.AllStoresTBI);
        	this.tileBarGroup4.Items.Add(this.customMyAccountTileBarItem);
        	this.tileBarGroup4.Items.Add(this.customJohnAccountTileBarItem);
        	this.tileBarGroup4.Items.Add(this.customTopStoresTileBarItem);
        	this.tileBarGroup4.Name = "tileBarGroup4";
        	this.tileBarGroup4.Text = "CUSTOM FILTER";
        	// 
        	// AllStoresTBI
        	// 
        	this.AllStoresTBI.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
        	tileItemElement9.Text = "All Customers";
        	tileItemElement9.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
        	this.AllStoresTBI.Elements.Add(tileItemElement9);
        	this.AllStoresTBI.Id = 3;
        	this.AllStoresTBI.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
        	this.AllStoresTBI.Name = "AllStoresTBI";
        	this.AllStoresTBI.Tag = FHRMS.Modules.CustomersFilter.AllStores;
        	// 
        	// customMyAccountTileBarItem
        	// 
        	this.customMyAccountTileBarItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
        	this.customMyAccountTileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
        	tileItemElement10.Text = "My Accounts";
        	tileItemElement10.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
        	this.customMyAccountTileBarItem.Elements.Add(tileItemElement10);
        	this.customMyAccountTileBarItem.Id = 0;
        	this.customMyAccountTileBarItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
        	this.customMyAccountTileBarItem.Name = "customMyAccountTileBarItem";
        	this.customMyAccountTileBarItem.Tag = FHRMS.Modules.CustomersFilter.MyAccount;
        	// 
        	// customJohnAccountTileBarItem
        	// 
        	this.customJohnAccountTileBarItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
        	this.customJohnAccountTileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
        	tileItemElement11.Text = "John\'s Accounts";
        	tileItemElement11.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
        	this.customJohnAccountTileBarItem.Elements.Add(tileItemElement11);
        	this.customJohnAccountTileBarItem.Id = 1;
        	this.customJohnAccountTileBarItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
        	this.customJohnAccountTileBarItem.Name = "customJohnAccountTileBarItem";
        	this.customJohnAccountTileBarItem.Tag = FHRMS.Modules.CustomersFilter.JohnAccount;
        	// 
        	// customTopStoresTileBarItem
        	// 
        	this.customTopStoresTileBarItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
        	this.customTopStoresTileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
        	tileItemElement12.Text = "Top Stores";
        	tileItemElement12.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
        	this.customTopStoresTileBarItem.Elements.Add(tileItemElement12);
        	this.customTopStoresTileBarItem.Id = 2;
        	this.customTopStoresTileBarItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
        	this.customTopStoresTileBarItem.Name = "customTopStoresTileBarItem";
        	this.customTopStoresTileBarItem.Tag = FHRMS.Modules.CustomersFilter.TopStores;
        	// 
        	// salesTileBarItem
        	// 
        	this.salesTileBarItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
        	this.salesTileBarItem.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(112)))), ((int)(((byte)(56)))));
        	this.salesTileBarItem.AppearanceItem.Normal.Options.UseBackColor = true;
        	this.salesTileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
        	tileItemElement14.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement14.Image")));
        	tileItemElement14.Text = "Avertissements";
        	this.salesTileBarItem.Elements.Add(tileItemElement14);
        	this.salesTileBarItem.Id = 5;
        	this.salesTileBarItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
        	this.salesTileBarItem.Name = "salesTileBarItem";
        	// 
        	// opportunitiesTileBarItem
        	// 
        	this.opportunitiesTileBarItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
        	this.opportunitiesTileBarItem.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
        	tileItemElement15.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement15.Image")));
        	tileItemElement15.Text = "Statistiques";
        	this.opportunitiesTileBarItem.Elements.Add(tileItemElement15);
        	this.opportunitiesTileBarItem.Id = 6;
        	this.opportunitiesTileBarItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
        	this.opportunitiesTileBarItem.Name = "opportunitiesTileBarItem";
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
        	this.bottomPanelBase1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        	this.barDockControlTop.Size = new System.Drawing.Size(1362, 0);
        	// 
        	// barDockControlBottom
        	// 
        	this.barDockControlBottom.CausesValidation = false;
        	this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.barDockControlBottom.Location = new System.Drawing.Point(0, 745);
        	this.barDockControlBottom.Size = new System.Drawing.Size(1362, 0);
        	// 
        	// barDockControlLeft
        	// 
        	this.barDockControlLeft.CausesValidation = false;
        	this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
        	this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
        	this.barDockControlLeft.Size = new System.Drawing.Size(0, 745);
        	// 
        	// barDockControlRight
        	// 
        	this.barDockControlRight.CausesValidation = false;
        	this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
        	this.barDockControlRight.Location = new System.Drawing.Point(1362, 0);
        	this.barDockControlRight.Size = new System.Drawing.Size(0, 745);
        	// 
        	// MainForm
        	// 
        	this.ClientSize = new System.Drawing.Size(1362, 745);
        	this.Controls.Add(this.flyoutPanel1);
        	this.Controls.Add(this.modulesContainer);
        	this.Controls.Add(this.mainTileBar);
        	this.Controls.Add(this.tileNavPane);
        	this.Controls.Add(this.customTileBarDropDownContainter);
        	this.Controls.Add(this.productsTileBarDropDownContainter);
        	this.Controls.Add(this.barDockControlLeft);
        	this.Controls.Add(this.barDockControlRight);
        	this.Controls.Add(this.barDockControlBottom);
        	this.Controls.Add(this.barDockControlTop);
        	this.Name = "MainForm";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "DevAV";
        	this.Load += new System.EventHandler(this.MainForm_Load);
        	((System.ComponentModel.ISupportInitialize)(this.productsTileBarDropDownContainter)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.customTileBarDropDownContainter)).EndInit();
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
        private DevExpress.XtraBars.Navigation.TileBarItem productsTileBarItem;
        private DevExpress.XtraBars.Navigation.TileBarItem customersTileBarItem;
        private DevExpress.XtraBars.Navigation.TileBarItem salesTileBarItem;
        private DevExpress.XtraBars.Navigation.TileBarItem opportunitiesTileBarItem;
        private DevExpress.XtraBars.Navigation.TileBarDropDownContainer customTileBarDropDownContainter;
        private DevExpress.XtraBars.Navigation.TileBarDropDownContainer productsTileBarDropDownContainter;
        private DevExpress.XtraBars.Navigation.TileBarGroup tileBarGroup4;
        private DevExpress.XtraBars.Navigation.TileBarItem customMyAccountTileBarItem;
        private DevExpress.XtraBars.Navigation.TileBarItem customJohnAccountTileBarItem;
        private DevExpress.XtraBars.Navigation.TileBarItem customTopStoresTileBarItem;
        public DevExpress.XtraBars.Navigation.TileBar productTileBar;
        private DevExpress.XtraBars.Navigation.TileBarGroup tileBarGroup1;
        private DevExpress.XtraBars.Navigation.TileBarItem hdVideoTBI;
        private DevExpress.XtraBars.Navigation.TileBarItem plasmaTBI;
        private DevExpress.XtraBars.Navigation.TileBarItem monitorTBI;
        private DevExpress.XtraBars.Navigation.TileBarItem remouteControlTBI;
        private DevExpress.XtraBars.Navigation.NavButton navButtonHome;
        public Modules.BottomPanelBase bottomPanelBase1;
        private  DevExpress.Utils.FlyoutPanel flyoutPanel1;
        private DevExpress.XtraBars.Navigation.TileBarItem AllStoresTBI;
        public DevExpress.XtraBars.Navigation.TileBar customTileBar;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager1;
    }
}
