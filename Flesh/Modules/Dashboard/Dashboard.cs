using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FHRMS.ViewModels;
using DevExpress.XtraEditors;
using FHRMS.Common.Utils;
using FHRMS.Helpers;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using FHRMS.Widgets;


namespace FHRMS.Modules
{
  
    public partial class Dashboard : BaseModuleControl
    {
    
        static public MainViewModel MainView = null;
        Random random = new Random();
  
        public Dashboard()
            : base(CreateViewModel<BoardViewModel>)
        {
            InitializeComponent();
     
            widgetView1.AllowDocumentStateChangeAnimation = DevExpress.Utils.DefaultBoolean.True;
            widgetView1.QueryControl += OnQueryControl;
            SetWidgetsAppearances();

            
            ViewModelHelper.EnsureViewModel(ViewModel, MainView);
            InitializeViewModels();
     
        }
       
   
        public MainViewModel MainViewModel
        {
            get { return GetParentViewModel<MainViewModel>(); }
        }
          

       
        void OnQueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {

            if (!string.IsNullOrEmpty(e.Document.ControlTypeName))
            {
                e.Control = Activator.CreateInstance(Type.GetType(e.Document.ControlTypeName)) as Control;
                if (e.Control is IDashboardWidget)
                {
                 
                    ((IDashboardWidget)e.Control).LoadDashboard( ViewModel);
                }
            }
            else
                e.Control = new Control();
        }
        void OnLayoutModeCheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LayoutMode layoutMode = (LayoutMode)e.Item.Tag;
            widgetView1.BeginUpdateAnimation();
            widgetView1.LayoutMode = layoutMode;
            
            widgetView1.EndUpdateAnimation();
        }
        void OnFlowDirectionCheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            widgetView1.BeginUpdateAnimation();
            FlowDirection flowDirection = (FlowDirection)e.Item.Tag;
            widgetView1.FlowLayoutProperties.FlowDirection = flowDirection;
            widgetView1.EndUpdateAnimation();
        }
    
    
        void SetWidgetsAppearances()
        {
            List<BaseDocument> documents = new List<BaseDocument>();
            documents.AddRange(widgetView1.Documents.ToArray());
            documents.AddRange(widgetView1.FloatDocuments.ToArray());
          
            
        }
        void ResetWidgetAppearances()
        {
            List<BaseDocument> documents = new List<BaseDocument>();
            documents.AddRange(widgetView1.FloatDocuments.ToArray());
            documents.AddRange(widgetView1.Documents.ToArray());
            foreach (Document document in documents)
            {
                document.AppearanceActiveCaption.Reset();
                document.AppearanceCaption.Reset();
            }
        }



        bool init = false;
        private void InitializeViewModels()
        {
            if (!init)
            {
                ViewModel.AbsenceViewModel = TryGetModuleViewModel<AbsencesCollectionViewModel>(ModuleType.Absences);
                ViewModel.AttendancesViewModel = TryGetModuleViewModel<AttendancesCollectionViewModel>(ModuleType.Attendances);
                ViewModel.EmployeesViewModel = TryGetModuleViewModel<EmployeeCollectionViewModel>(ModuleType.Employés);
                ViewModel.LeavesViewModel = TryGetModuleViewModel<LeaveCollectionViewModel>(ModuleType.Congés);
                ViewModel.NotificationsViewModel = TryGetModuleViewModel<NotificationCollectionViewModel>(ModuleType.Notifications);
                ViewModel.SchedulesViewModel = TryGetModuleViewModel<ScheduleCollectionViewModel>(ModuleType.Shifts);
                ViewModel.WarningsViewModel = TryGetModuleViewModel<WarningsCollectionViewModel>(ModuleType.Avertissements);
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
        public BoardViewModel ViewModel
        {
            get
            {
                return GetViewModel<BoardViewModel>();
            }
        }

    }

}
