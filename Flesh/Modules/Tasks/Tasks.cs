using System;
using System.Collections.Generic;
using DevExpress.DevAV;
using DevExpress.DevAV.Helpers;
using DevExpress.DevAV.ViewModels;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.DevAV.Common.Utils;
using DevExpress.Mvvm;

namespace DevExpress.DevAV.Modules {
    public partial class Tasks : BaseModuleControl {
        public Tasks()
            : base(CreateViewModel<EmployeeTaskCollectionViewModel>) {
            InitializeComponent();
            UpdateData();
            ((ITileControl)tileControl1).Properties.LargeItemWidth = 200;
            tileControl1.UseParentAutoScaleFactor = false;
        }
        protected override void OnInitServices(Mvvm.IServiceContainer serviceContainer) {
            base.OnInitServices(serviceContainer);
            serviceContainer.RegisterService(new FlyoutDetailFormDocumentManagerService(ModuleType.EditTask));
        }
        void UpdateData() {
            tasksGridControl.SetItemsSource(ViewModel.Entities);
            TileItemsUpdateElementText();
        }
        void TileItemsUpdateElementText() {
            if(ViewModel.Entities != null) {
                tileItemAll.Text = ViewModel.AllCount.ToString();
                tileItemCompleted.Text = ViewModel.CompletedCount.ToString();
                tileItemDeferred.Text = ViewModel.DeferredCount.ToString();
                tileItemHighPriority.Text = ViewModel.HighPriorityCount.ToString();
                tileItemInProgress.Text = ViewModel.InProgressCount.ToString();
                tileItemNotStartedTask.Text = ViewModel.NotStartedCount.ToString();
                tileItemUrgent.Text = ViewModel.UrgentCount.ToString();
            }
        }
        public EmployeeTaskCollectionViewModel ViewModel {
            get { return GetViewModel<EmployeeTaskCollectionViewModel>(); }
        }
        protected internal override void OnTransitionCompleted() {
            base.OnTransitionCompleted();
            InitializeButtonPanel();
        }
        void InitializeButtonPanel() {
            List<ButtonInfo> listBI = new List<ButtonInfo>();
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "New", Name = "1", Image = ImageHelper.GetImageFromToolbarResource("New"), mouseEventHandler = (s, e) => { NewButtonClick(); } });
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Edit", Name = "2", Image = ImageHelper.GetImageFromToolbarResource("Edit"), mouseEventHandler = (s, e) => { EditButtonClick(); } });
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Delete", Name = "3", Image = ImageHelper.GetImageFromToolbarResource("Delete"), mouseEventHandler = (s, e) => { DeleteButtonClick(); } });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Print", Name = "4", Image = ImageHelper.GetImageFromToolbarResource("Print"), mouseEventHandler = (s, e) => { PrintButtonClick(); } });
            BottomPanel.InitializeButtons(listBI, false);
        }
        void PrintButtonClick() {
            MainViewModel main = GetParentViewModel<MainViewModel>();
            main.SelectModule(ModuleType.TaskPrint, (x) =>
            {
                ViewModelHelper.EnsureModuleViewModel(main.SelectedModule, main, tasksGridControl);
                ((BaseModuleControl)main.SelectedModule).Refresh();
            });
        }
        void DeleteButtonClick() {
            ViewModel.Delete(ViewModel.SelectedEntity);
            TileItemsUpdateElementText();
        }
        void NewButtonClick() {
            ViewModel.New();
        }
        void EditButtonClick() {
            Edit(ViewModel.SelectedEntity);
        }
        void Edit(EmployeeTask task) {
            if(ViewModel.CanEdit(task))
                ViewModel.Edit(task);
        }
        void collapseButton_Click(object sender, EventArgs e) {
            if(tileControlLCI.Visibility == XtraLayout.Utils.LayoutVisibility.Always) {
                ItemsHideHelper.Hide(new object[] { tileControlLCI }, buttonHide);
                return;
            }
            if(tileControlLCI.Visibility == XtraLayout.Utils.LayoutVisibility.Never) {
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
            ViewModel.SelectedEntity = e.Row as EmployeeTask;
        }
        void tasksGridView_RowClick(object sender, RowClickEventArgs e) {
            if(e.Clicks > 1 && e.RowHandle >= 0)
                Edit(GetTask(e.RowHandle));
        }
        EmployeeTask GetTask(int rowHandle) {
            return tasksGridView.GetRow(rowHandle) as EmployeeTask;
        }
    }
}
