using System;
using System.Collections.Generic;
using PHRMS.Data;
using PHRMS.Helpers;
using PHRMS.ViewModels;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using PHRMS.Utils;
using DevExpress.Mvvm;

namespace PHRMS.Modules {
    public partial class Congés : BaseModuleControl {
        public Congés()
            : base(CreateViewModel<LeaveCollectionViewModel>) {
            InitializeComponent();
            UpdateData();
            ((ITileControl)tileControl1).Properties.LargeItemWidth = 200;
            tileControl1.UseParentAutoScaleFactor = false;
        }
        protected override void OnInitServices( DevExpress.Mvvm.IServiceContainer serviceContainer) {
            base.OnInitServices(serviceContainer);
            serviceContainer.RegisterService(new FlyoutDetailFormDocumentManagerService(ModuleType.ModifierCongés));
        }
        void UpdateData() {
            tasksGridControl.SetItemsSource(ViewModel.Entities);
            TileItemsUpdateElementText();
        }
        void TileItemsUpdateElementText() {
            if(ViewModel.Entities != null) {
                tileItemAll.Text = ViewModel.AllCount.ToString();
                tileItemCompleted.Text = ViewModel.CompletedCount.ToString();
                tileItemDeferred.Text = ViewModel.RefusedCount.ToString();
                tileItemHighPriority.Text = ViewModel.HighPriorityCount.ToString();
                tileItemInProgress.Text = ViewModel.OnGoingCount.ToString();
                tileItemNotStartedTask.Text = ViewModel.PendingCount.ToString();
                tileItemUrgent.Text = ViewModel.UrgentCount.ToString();
            }
        }
        public LeaveCollectionViewModel ViewModel {
            get { return GetViewModel<LeaveCollectionViewModel>(); }
        }
        protected internal override void OnTransitionCompleted() {
            base.OnTransitionCompleted();
            InitializeButtonPanel();
        }
    
          
        void InitializeButtonPanel() {
            List<ButtonInfo> listBI = new List<ButtonInfo>();
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Nouvelle demande", Name = "1", Image = ImageHelper.GetImageFromToolbarResource("New"), mouseEventHandler = (s, e) => { NewButtonClick(); } });
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Modifier", Name = "2", Image = ImageHelper.GetImageFromToolbarResource("Edit"), mouseEventHandler = (s, e) => { EditButtonClick(); } });
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Supprimer", Name = "3", Image = ImageHelper.GetImageFromToolbarResource("Delete"), mouseEventHandler = (s, e) => { DeleteButtonClick(); } });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Imprimer", Name = "4", Image = ImageHelper.GetImageFromToolbarResource("Print"), mouseEventHandler = (s, e) => { PrintButtonClick(); } });
            BottomPanel.InitializeButtons(listBI, false);
        }
        void PrintButtonClick() {
            MainViewModel main = GetParentViewModel<MainViewModel>();
            main.SelectModule(ModuleType.ImprimerCongé, (x) =>
            {
                ViewModelHelper.EnsureModuleViewModel(main.SelectedModule, main, tasksGridControl);
                ((BaseModuleControl)main.SelectedModule).Refresh();
            });
        }
        void DeleteButtonClick() {
           if ( MainViewModel.CurrentEmployee.Role > EmployeeRole.Agent){
            ViewModel.Delete(ViewModel.SelectedEntity);
            TileItemsUpdateElementText();}
            else if (MainViewModel.CurrentEmployee.Role <= EmployeeRole.Agent )
               DevExpress.XtraEditors.XtraMessageBox.Show(" Accès refusé ", " Contrôle d'accès ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
        void NewButtonClick() {
            if ( MainViewModel.CurrentEmployee.Role != EmployeeRole.Employee)
            ViewModel.New();
            else if (MainViewModel.CurrentEmployee.Role == EmployeeRole.Employee) 
                DevExpress.XtraEditors.XtraMessageBox.Show(" Accès refusé ", " Contrôle d'accès ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
        void EditButtonClick() {
            Edit(ViewModel.SelectedEntity);
        }
        void Edit(Leave task) {

            if (ViewModel.CanEdit(task) && MainViewModel.CurrentEmployee.Role > EmployeeRole.Agent)
                ViewModel.Edit(task);
            else if (MainViewModel.CurrentEmployee.Role <= EmployeeRole.Agent)
                DevExpress.XtraEditors.XtraMessageBox.Show("Accès refusé", "Contrôle d'accès", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
        void collapseButton_Click(object sender, EventArgs e) {
            if(tileControlLCI.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always) {
                ItemsHideHelper.Hide(new object[] { tileControlLCI }, buttonHide);
                return;
            }
            if(tileControlLCI.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Never) {
                ItemsHideHelper.Expand(new object[] { tileControlLCI }, buttonHide);
                return;
            }
        }
        void TileClickFilter(string filter, TileItem tileItem) {
            tasksGridView.ActiveFilter.Clear();
            string fieldName = GetFieldName(filter);
            tasksGridView.ActiveFilter.Add(tasksGridView.Columns[fieldName], new ColumnFilterInfo(filter));
            tileItem.Text = tasksGridView.DataRowCount.ToString();
        }
        static string GetFieldName(string filter) {
            if(filter.StartsWith("Priority")) return "Priority";
            else return "Status";
        }
        void tileItem_ItemClick(object sender, TileItemEventArgs e) {
            string filter = e.Item.Tag as string;
            TileClickFilter(filter, e.Item);
        }
        void tasksGridView_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e) {
            ViewModel.SelectedEntity = e.Row as Leave;
        }
        void tasksGridView_RowClick(object sender, RowClickEventArgs e) {
            if(e.Clicks > 1 && e.RowHandle >= 0)
                Edit(GetTask(e.RowHandle));
           
        }
        Leave GetTask(int rowHandle) {
            return tasksGridView.GetRow(rowHandle) as Leave;
        }
    }
}
