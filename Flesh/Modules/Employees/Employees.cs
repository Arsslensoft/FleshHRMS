using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.DevAV;
using DevExpress.DevAV.Common.ViewModel;
using DevExpress.DevAV.ViewModels;
using DevExpress.DevAV.Helpers;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using DevExpress.DevAV.Common.Utils;
using DevExpress.DevAV.DevAVDbDataModel;

namespace DevExpress.DevAV.Modules {
    public partial class Employees : BaseModuleControl {
        BaseItemCollection hideItemCollection = new BaseItemCollection();
        BaseModuleControl openedSubModule;
        SearchControl searchControl;
        public Employees()
            : base(CreateViewModel<EmployeeCollectionViewModel>) {
            InitializeComponent();
            tileView1.FocusedRowObjectChanged += tileView1_FocusedRowObjectChanged;
            tileView1.ItemDoubleClick += tileView1_ItemDoubleClick;
            InitializeData();
            ((ITileControl)filterTileControl).Properties.LargeItemWidth = 200;
            filterTileControl.UseParentAutoScaleFactor = false;
            tileView1.DataController.Refreshed += DataController_Refreshed;
        }

        bool lockRefreshed = false;
        void DataController_Refreshed(object sender, EventArgs e) {
            if(!lockRefreshed) {
                lockRefreshed = true;
                foreach(TileItem item in tileGroup2.Items) {
                    filterTileControl_ItemClick(null, new TileItemEventArgs() { Item = item });
                }
                filterTileControl_ItemClick(null, new TileItemEventArgs() {Item = filterTileControl.SelectedItem });
                lockRefreshed = false;
            }
        }

        void tileView1_FocusedRowObjectChanged(object sender, XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e) {
            UpdateSelectedEntity(e.FocusedRowHandle);
        }

        void tileView1_ItemDoubleClick(object sender, XtraGrid.Views.Tile.TileViewItemClickEventArgs e) {
            UpdateSelectedEntity(e.Item.RowHandle);
            ShowEditEmployee(ViewModel.SelectedEntity);
        }

        void InitializeData() {
            employeeBindingSource.DataSource = ViewModel.Entities.ToBindingList();
            hideItemCollection.AddRange(new XtraLayout.BaseLayoutItem[] { tileControlLayoutItem });
            SortEmployees(true);
            gridControl1.DataSource = ViewModel.Entities;
            TileItemsUpdateElementText();
        }
        void TileItemsUpdateElementText() {
            tileItemAll.Text = ViewModel.AllCount.ToString();
            tileItemCommission.Text = ViewModel.CommissionCount.ToString();
            tileItemOnLeave.Text = ViewModel.OnLeaveCount.ToString();
            tileItemContract.Text = ViewModel.ProbationCount.ToString();
            tileItemSalaried.Text = ViewModel.SalairedCount.ToString();
            tileItemTerminated.Text = ViewModel.TerminatedCount.ToString();
        }
        void searchControl_AllowSearchColumn(object sender, QueryIsSearchColumnEventArgs e) {
            var column = sender as DevExpress.XtraEditors.Filtering.FilterColumn;
            if(column == null) {
                return;
            }
            if(column.FieldName != string.Empty) {
                e.IsSearchColumn = true;
            }
            else {
                e.IsSearchColumn = false;
            }
        }
        protected internal override void OnTransitionCompleted() {
            base.OnTransitionCompleted();
            UpdateButtonPanel();
        }
        protected override void OnParentChanged(System.EventArgs e) {
            base.OnParentChanged(e);
            TileItemsUpdateElementText();
            if(Parent == null) {
                searchControl.QueryIsSearchColumn -= searchControl_AllowSearchColumn;
                if(openedSubModule != null) CloseSubModule();
            }
        }
        int prevFocusedRow = 0;
        void UpdateButtonPanel() {
            if(Parent != null) {
                if(openedSubModule == null) {
                    InitializeButtonPanel();
                }
                else {
                    openedSubModule.Refresh();
                }
            }
        }
        public override void Refresh() {
            if(ViewModel.Entities != null) {
                InitializeDataBase();
            }
            UpdateButtonPanel();
            base.Refresh();
        }
        public void CloseSubModule() {
            openedSubModule.Parent = null;
            openedSubModule.Dispose();
            openedSubModule = null;
            UpdateButtonPanel();
        }
        void InitializeDataBase() {
            employeeBindingSource.SetItemsSource(ViewModel.Entities);
        }
        public EmployeeCollectionViewModel ViewModel {
            get { return GetViewModel<EmployeeCollectionViewModel>(); }
        }
        public MainViewModel MainViewModel {
            get { return GetParentViewModel<MainViewModel>(); }
        }
        EmployeeTaskCollectionViewModel tasksViewModel;
        public EmployeeTaskCollectionViewModel TasksViewModel {
            get { return TryGetModuleViewModel<EmployeeTaskCollectionViewModel>(ref tasksViewModel, ModuleType.Tasks); }
        }
        EvaluationCollectionViewModel notesViewModel;
        public EvaluationCollectionViewModel NotesViewModel {
            get { return TryGetModuleViewModel<EvaluationCollectionViewModel>(ref notesViewModel, ModuleType.Notes); }
        }
        void InitializeButtonPanel() {
            var listBI = new List<ButtonInfo>();
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Ascending", Name = "1", Image = ImageHelper.GetImageFromToolbarResource("SortAZ"), mouseEventHandler = (s, e) => { SortEmployees(true); } });
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Descending", Name = "2", Image = ImageHelper.GetImageFromToolbarResource("SortZA"), mouseEventHandler = (s, e) => { SortEmployees(false); } });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "New", Name = "2", Image = ImageHelper.GetImageFromToolbarResource("New"), mouseEventHandler = newMouseClick });
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Edit", Name = "4", Image = ImageHelper.GetImageFromToolbarResource("Edit"), mouseEventHandler = editMouseClick });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Reports", Name = "6", Image = ImageHelper.GetImageFromToolbarResource("Reports"), PopupMenuContent = layoutControl2 });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Mail Merge", Name = "7", Image = ImageHelper.GetImageFromToolbarResource("MailMerge"), mouseEventHandler = mailMergeClick });
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Task", Name = "8", Image = ImageHelper.GetImageFromToolbarResource("Task"), mouseEventHandler = taskMouseClick });
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Note", Name = "10", Image = ImageHelper.GetImageFromToolbarResource("Note"), mouseEventHandler = notesMouseClick });
            BottomPanel.InitializeButtons(listBI);
            searchControl = BottomPanel.searchControl;
            BottomPanel.searchControl.Client = gridControl1;
            BottomPanel.searchControl.QueryIsSearchColumn += new QueryIsSearchColumnEventHandler(searchControl_AllowSearchColumn);
        }
        protected int GetSelectedIndex() {
            return tileView1.GetRowHandle(tileView1.GetSelectedRows()[0]);
        }
        protected Employee GetSelectedEmployee() {
            return ViewModel.SelectedEntity;
        }
        void notesMouseClick(object sender, EventArgs e) {
            prevFocusedRow = GetSelectedIndex();
            var employee = GetSelectedEmployee();
            if(employee != null) {
                EditNotes.NewNoteOwner = employee;
                NotesViewModel.New();
            }
        }
        void mailMergeClick(object sender, EventArgs e) {
            prevFocusedRow = GetSelectedIndex();
            GotoModule(ModuleType.EmployeeMailMerge, GetSelectedEmployee());
        }
        void UpdateSelectedEntity(int focusedRowHandle) {
            ViewModel.SelectedEntity = tileView1.DataController.GetRow(tileView1.DataController.GetControllerRowHandle(focusedRowHandle)) as Employee;
        }
        void taskMouseClick(object sender, EventArgs e) {
            prevFocusedRow = GetSelectedIndex();
            var employee = GetSelectedEmployee();
            if(employee != null) {
                EditTask.NewTaskOwner = employee;
                TasksViewModel.New();
            }
        }
        void editMouseClick(object sender, EventArgs e) {
            ShowEditEmployeeForFocused();
        }
        void ShowEditEmployeeForFocused() {
            if(GetSelectedEmployee() == null) return;
            ShowEditEmployee(GetSelectedEmployee());
        }
        void newMouseClick(object sender, EventArgs e) {
            ViewModel.SelectedEntity = null;
            ShowEditEmployee(null);
        }
        void SortAscendingClick(object sender, EventArgs e) {
            SortEmployees(true);
        }
        void SortDescendingClick(object sender, EventArgs e) {
            SortEmployees(false);
        }
        void SortEmployees(bool ascending) {
            var lastName = tileView1.Columns["FullName"];
            if(lastName == null) return;
            tileView1.SortInfo.Clear();
            tileView1.SortInfo.Add(new XtraGrid.Columns.GridColumnSortInfo(lastName, ascending ? Data.ColumnSortOrder.Ascending : Data.ColumnSortOrder.Descending));
        }
        void ShowEditEmployee(Employee employee) {
            var main = GetParentViewModel<MainViewModel>();
            main.SelectModule(ModuleType.EmployeeEdit, (x) =>
            {
                if(employee != null) {
                    ViewModelHelper.EnsureModuleViewModel(main.SelectedModule, main, ViewModel.SelectedEntityKey);
                }
                else {
                    ViewModelHelper.EnsureModuleViewModel(main.SelectedModule, main, new DefaultEntityInitializer<Employee, DevAV.DevAVDbDataModel.IDevAVDbUnitOfWork>());
                }
                ((EmployeeEdit)main.SelectedModule).Refresh();
            });
        }
        void deleteMouseClick(object sender, EventArgs e) {
            ViewModel.Delete(GetSelectedEmployee());
            TileItemsUpdateElementText();
        }
        void simpleLabelItem1_MouseDown(object sender, MouseEventArgs e) {
            if(tileControlLayoutItem.Visibility == XtraLayout.Utils.LayoutVisibility.Always) {
                ItemsHideHelper.Hide(hideItemCollection, buttonHide);
                return;
            }
            if(tileControlLayoutItem.Visibility == XtraLayout.Utils.LayoutVisibility.Never) {
                ItemsHideHelper.Expand(hideItemCollection, buttonHide);
                return;
            }
        }
        string currentFilter = null;
        void filterTileControl_ItemClick(object sender, XtraEditors.TileItemEventArgs e) {
            TileItem item = e.Item;
            var filter = e.Item.Tag as string;
            if(currentFilter == filter) return;
            currentFilter = filter;
            EmployeeStatus es;
            if(!Enum.TryParse<EmployeeStatus>(filter, out es)) {
                currentFilter = null;
            }
            if(currentFilter == null)
                tileView1.ActiveFilter.Clear();
            else
                tileView1.ActiveFilterCriteria = CriteriaOperator.Parse("Status = ?", es);
            item.Text = tileView1.DataRowCount.ToString();
        }
        void GotoModule(ModuleType mt, object param) {
            var moduleLocator = GetService<Services.IModuleLocator>();
            openedSubModule = moduleLocator.GetModule(mt) as BaseModuleControl;
            UpdateSelectedEntity(tileView1.FocusedRowHandle);
            ViewModelHelper.EnsureModuleViewModel(openedSubModule, ViewModel, param);
            openedSubModule.Dock = DockStyle.Fill;
            openedSubModule.Parent = this;
            openedSubModule.OnTransitionCompleted();
            openedSubModule.BringToFront();
        }
        void printEmployeeProfileItem_Click(object sender, EventArgs e) {
            GotoModule(ModuleType.EmployeesPrint, EmployeeReportType.Profile);
        }
        void printEmployeeDirectoryItem_Click(object sender, EventArgs e) {
            GotoModule(ModuleType.EmployeesPrint, EmployeeReportType.Directory);
        }
        void printEmployeeListItem_Click(object sender, EventArgs e) {
            GotoModule(ModuleType.EmployeesPrint, EmployeeReportType.Summary);
        }

        private void gridControl1_Load(object sender, EventArgs e) {
            tileView1.FocusedRowHandle = 0;
            UpdateSelectedEntity(0);
        }
    }
}
