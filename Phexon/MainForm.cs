using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.About;
using DevExpress.Utils.Animation;
using DevExpress.Utils.Gesture;
using DevExpress.Utils.Menu;
using DevExpress.Utils.Taskbar;
using DevExpress.Utils.Taskbar.Core;
using DevExpress.Utils.TouchHelpers;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using PHRMS.Modules;
using PHRMS.ViewModels;

namespace PHRMS
{
    public partial class MainForm : XtraForm, IMainModule, ISwipeGestureClient
    {
        private bool allowFlyoutPanel = true;
        private bool allowTransition = true;
        private bool transitionEffective;

        private MainViewModel viewModel;

        public MainForm()
        {
            TaskbarHelper.InitDemoJumpList(TaskbarAssistant.Default, this);

            Icon = Program.AppIcon;
            ShowSplashScreen();
            InitializeComponent();
            PrepareUI();
            InitViewModel();

            UAlgo.Default.DoEventObject(UAlgo.kDemo, UAlgo.pWinForms, this);
        }

        public void StartTransition(bool effective)
        {
            transitionEffective = effective;
            if (!allowTransition) return;
            if (effective) transitionManager1.StartTransition(modulesContainer);
        }

        public void EndTransition(bool effective)
        {
            if (!effective || !allowTransition)
            {
                transitionManager1_AfterTransitionEnds(null, EventArgs.Empty);
                return;
            }
            transitionManager1.EndTransition();
        }

        public bool IsDocked(ModuleType type)
        {
            return true;
        }

        public void DockModule(ModuleType moduleType)
        {
        }

        public void ShowPeek(ModuleType moduleType)
        {
        }

        public void SaveLayoutToStream(MemoryStream ms)
        {
        }

        public void RestoreLayoutFromStream(MemoryStream ms)
        {
        }

        public IDXMenuManager MenuManager
        {
            get { return barManager1; }
        }

        public void OnSwipe(SwipeEventArgs args)
        {
            if (args.IsBottomEdge && allowFlyoutPanel)
            {
                flyoutPanel1.ShowPopup();
            }
        }

        internal void ShowSplashForLogin()
        {
            if (InvokeRequired)
                Invoke(new Invoker(delegate { ShowSplashScreen(); }));
            else Show();
        }

        private void ShowSplashScreen()
        {
            SplashScreenManager.ShowForm(this, typeof(FleshSplashScreen), true, true, false);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mainTileBar.SelectedItem = dashboardTileBarItem;
            InitTileBar();


            Dashboard.MainView = viewModel;
            viewModel.SelectModule(ModuleType.Dashboard);
        }

        private void InitViewModel()
        {
            viewModel = ViewModelSource.Create(() => new MainViewModel(this));

            var lg = new Login(viewModel);
            SplashScreenManager.CloseForm();
            lg.ShowDialog();
            SplashScreenManager.ShowForm(this, typeof(FleshSplashScreen), true, true, false);

            PrefetchChildModules();
            viewModel.ModuleAdded += viewModel_ModuleAdded;
            viewModel.ModuleRemoved += viewModel_ModuleRemoved;
            viewModel.ModuleTransitionCompleted += viewModel_ModuleTransitionCompleted;
        }


        private void PrefetchChildModules()
        {
            if (Debugger.IsAttached) return;

            viewModel.GetModule(ModuleType.Congés);
        }

        private void viewModel_ModuleAdded(object sender, EventArgs e)
        {
            var moduleControl = sender as Control;
            moduleControl.Dock = DockStyle.Fill;
            moduleControl.Size = modulesContainer.ClientSize;
            moduleControl.Parent = modulesContainer;
        }

        private void viewModel_ModuleRemoved(object sender, EventArgs e)
        {
            var moduleControl = sender as Control;
            moduleControl.Parent = null;
        }

        private void transitionManager1_BeforeTransitionStarts(ITransition transition, CancelEventArgs e)
        {
            bottomPanelBase1.Enabled = true;
        }

        private void transitionManager1_AfterTransitionEnds(ITransition transition, EventArgs e)
        {
            if (!IsHandleCreated) return;
            var method = new MethodInvoker(() =>
            {
                bottomPanelBase1.Enabled = true;
                var moduleControl = viewModel.SelectedModule as BaseModuleControl;
                if (moduleControl != null) moduleControl.OnTransitionCompleted();
            });
            if (InvokeRequired) BeginInvoke(method);
            else method();
        }

        private void viewModel_ModuleTransitionCompleted(object sender, EventArgs e)
        {
        }

        private void ChangeToSlideAnimation()
        {
            transitionManager1.Transitions.Clear();
            var slide = new SlideTransition();
            slide.Parameters.FrameInterval = 5000;
            var transition = new Transition();
            transition.TransitionType = slide;
            transition.Control = modulesContainer;
            transitionManager1.Transitions.Add(transition);
        }

        private void PrepareUI()
        {
            if (Program.IsTablet)
            {
                ChangeToSlideAnimation();
                TouchKeyboardSupport.EnableTouchKeyboard = true;
                SetupAsTablet();
                return;
            }
            SetupHeightWidth();
            DisableBottomPanelSwipe();
        }

        private void SetupHeightWidth()
        {
            if (Screen.PrimaryScreen.WorkingArea.Height > 970)
            {
                ClientSize = new Size(ClientSize.Width, 945);
            }
        }

        private void DisableBottomPanelSwipe()
        {
            bottomPanelBase1.Dock = DockStyle.Bottom;
            bottomPanelBase1.Parent = this;
            bottomPanelBase1.SendToBack();
            allowFlyoutPanel = false;
        }

        private void SetupAsTablet()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            DisableBottomPanelSwipe();
            WindowsFormsSettings.PopupMenuStyle = PopupMenuStyle.RadialMenu;
        }

        private void InitTileBar()
        {
            dashboardTileBarItem.Tag = ModuleType.Dashboard;

            employeesTileBarItem.Tag = ModuleType.Employés;
            tasksTileBarItem.Tag = ModuleType.Congés;
            absencesTileBarItem.Tag = ModuleType.Absences;
            attendanceTileBarItem.Tag = ModuleType.Attendances;
            warningsTileBarItem.Tag = ModuleType.Avertissements;
            statsTileBarItem.Tag = ModuleType.Statistiques;
        }

        public static void ShowNewItemMessage(Control source)
        {
            XtraMessageBox.Show(source.FindForm(), "Add NewItem", "Waring", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void navButtonClose_ElementClick(object sender, NavElementEventArgs e)
        {
            var lg = new Login(viewModel);
            lg.ShowDialog();
        }

        private void productTileBar_ItemClick(object sender, TileItemEventArgs e)
        {
            mainTileBar.HideDropDownWindow();
        }

        private void customTileBar_ItemClick(object sender, TileItemEventArgs e)
        {
            mainTileBar.HideDropDownWindow();
        }

        private void mainTileBar_SelectedItemChanged(object sender, TileItemEventArgs e)
        {
            if (e.Item.Tag is ModuleType)
            {
                viewModel.SelectModule((ModuleType) e.Item.Tag);
            }
        }

        private void navButtonSettings_ElementClick(object sender, NavElementEventArgs e)
        {
            var settingsUC = new SettingsUC(allowTransition);
            var result = FlyoutDialog.Show(this, settingsUC);
            if (result == DialogResult.OK)
            {
                allowTransition = settingsUC.checkEdit1.Checked;
            }
        }

        private void navButtonHelp_ElementClick(object sender, NavElementEventArgs e)
        {
            var ab = new AboutForm();
            ab.ShowDialog();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //  this.Hide();
            //e.Cancel = true;
        }
    }
}