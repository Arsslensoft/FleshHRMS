using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using PHRMS.ViewModels;
using PHRMS.Widgets;

namespace PHRMS.Modules
{
    public partial class Statistiques : BaseModuleControl
    {
        private bool init;

        private Random random = new Random();

        public Statistiques()
            : base(CreateViewModel<BoardViewModel>)
        {
            InitializeComponent();

            widgetView1.AllowDocumentStateChangeAnimation = DefaultBoolean.True;
            widgetView1.QueryControl += OnQueryControl;
            SetWidgetsAppearances();
        }


        public MainViewModel MainViewModel
        {
            get { return GetParentViewModel<MainViewModel>(); }
        }

        public BoardViewModel ViewModel
        {
            get { return GetViewModel<BoardViewModel>(); }
        }


        private void OnQueryControl(object sender, QueryControlEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Document.ControlTypeName))
            {
                e.Control = Activator.CreateInstance(Type.GetType(e.Document.ControlTypeName)) as Control;
                if (e.Control is IDashboardWidget)
                {
                    InitializeViewModels();
                    ((IDashboardWidget) e.Control).LoadDashboard(ViewModel);
                }
            }
            else
                e.Control = new Control();
        }

        private void OnLayoutModeCheckedChanged(object sender, ItemClickEventArgs e)
        {
            var layoutMode = (LayoutMode) e.Item.Tag;
            widgetView1.BeginUpdateAnimation();
            widgetView1.LayoutMode = layoutMode;

            widgetView1.EndUpdateAnimation();
        }

        private void OnFlowDirectionCheckedChanged(object sender, ItemClickEventArgs e)
        {
            widgetView1.BeginUpdateAnimation();
            var flowDirection = (FlowDirection) e.Item.Tag;
            widgetView1.FlowLayoutProperties.FlowDirection = flowDirection;
            widgetView1.EndUpdateAnimation();
        }


        private void SetWidgetsAppearances()
        {
            var documents = new List<BaseDocument>();
            documents.AddRange(widgetView1.Documents.ToArray());
            documents.AddRange(widgetView1.FloatDocuments.ToArray());
        }

        private void ResetWidgetAppearances()
        {
            var documents = new List<BaseDocument>();
            documents.AddRange(widgetView1.FloatDocuments.ToArray());
            documents.AddRange(widgetView1.Documents.ToArray());
            foreach (Document document in documents)
            {
                document.AppearanceActiveCaption.Reset();
                document.AppearanceCaption.Reset();
            }
        }

        private void InitializeViewModels()
        {
            if (!init)
            {
                ViewModel.AbsenceViewModel = TryGetModuleViewModel<AbsencesCollectionViewModel>(ModuleType.Absences);
                ViewModel.AttendancesViewModel =
                    TryGetModuleViewModel<AttendancesCollectionViewModel>(ModuleType.Attendances);
                ViewModel.EmployeesViewModel = TryGetModuleViewModel<EmployeeCollectionViewModel>(ModuleType.Employés);
                ViewModel.LeavesViewModel = TryGetModuleViewModel<LeaveCollectionViewModel>(ModuleType.Congés);
                ViewModel.NotificationsViewModel =
                    TryGetModuleViewModel<NotificationCollectionViewModel>(ModuleType.Notifications);
                ViewModel.ShiftsesViewModel = TryGetModuleViewModel<ShiftsCollectionViewModel>(ModuleType.Shifts);
                ViewModel.WarningsViewModel =
                    TryGetModuleViewModel<WarningsCollectionViewModel>(ModuleType.Avertissements);
                init = true;
            }
        }

        protected internal override void OnTransitionCompleted()
        {
            base.OnTransitionCompleted();
            InitializeButtonPanel();
        }

        private void InitializeButtonPanel()
        {
            BottomPanel.Visible = false;
        }
    }
}