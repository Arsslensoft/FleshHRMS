using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.DevAV;
using DevExpress.DevAV.ViewModels;
using DevExpress.DevAV.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
using DevExpress.DevAV.Common.Utils;

namespace DevExpress.DevAV.Modules {
    public partial class EmployeeEdit : BaseModuleControl {
        BaseModuleControl openedSubModule;
        public EmployeeEdit()
            : base(CreateViewModel<EmployeeViewModel>) {
            InitializeComponent();
            ViewModel.EntityChanged += ViewModel_EntityChanged;
            InitializeCustomDrawRows();
            BindEditors();
            lbNotes.Tag = true;
            lbTasks.Tag = false;
            new LabelTabController(lbTasks.Tag, lbNotes, lbTasks).EditValueChanged += (s, e) =>
            {
                lciNotes.Visibility = (bool)s ? LayoutVisibility.Always : LayoutVisibility.Never;
                lciTasks.Visibility = !(bool)s ? LayoutVisibility.Always : LayoutVisibility.Never;
            };
        }
        protected override void OnDisposing() {
            ViewModel.EntityChanged -= ViewModel_EntityChanged;
            base.OnDisposing();
        }
        public EmployeeViewModel ViewModel {
            get { return GetViewModel<EmployeeViewModel>(); }
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
        protected override void UpdateViewModel() {
            ViewModel.ValidationErrors = errorProvider.HasErrors;
            ViewModel.Update();
        }
        protected internal override void OnTransitionCompleted() {
            base.OnTransitionCompleted();
            employeeLabelControl.Focus();
            InitializeButtonPanel();
        }
        void BindEditors() {
            foreach(var item in dataLayoutControl.Controls) {
                BaseEdit edit = item as BaseEdit;
                if(edit == null || edit.DataBindings.Count == 0) continue;
                edit.Properties.EditValueChanged += (s, e) => QueueViewModelUpdate();
            }
        }
        void InitializeCustomDrawRows() {
            notesGridView.ButtonsColumn = noteColSubject;
            notesGridView.ButtonsPanel.Buttons.Add(new EditorButton(ButtonPredefines.Glyph) { Caption = "Edit" });
            notesGridView.ButtonsPanel.Buttons.Add(new EditorButton(ButtonPredefines.Glyph) { Caption = "Delete" });
            notesGridView.ButtonsPanel.Buttons[0].Click += (s, e) =>
            {
                DoEditNote(((EditorButton)s).Tag as Evaluation);
            };
            notesGridView.ButtonsPanel.Buttons[1].Click += (s, e) =>
            {
                DoDeleteNote(((EditorButton)s).Tag as Evaluation);
            };
            notesGridView.ShowButtons = true;
            notesGridView.UserCellPadding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            notesGridView.Appearance.SelectedRow.Assign(notesGridView.Appearance.FocusedCell);

            tasksGridView.ButtonsColumn = colComplete;
            tasksGridView.ButtonsPanel.Buttons.Add(new EditorButton(ButtonPredefines.Glyph) { Caption = "Edit", Width = 66 });
            tasksGridView.ButtonsPanel.Buttons[0].Click += (s, e) =>
            {
                DoEditTask(((EditorButton)s).Tag as EmployeeTask);
            };
            tasksGridView.ShowButtons = true;
        }
        void DoDeleteNote(Evaluation note) {
            if(ViewModel.EmployeeEvaluationsLookUp.CanDelete(note))
                ViewModel.EmployeeEvaluationsLookUp.Delete(note);
        }
        void DoEditNote(Evaluation note) {
            if(ViewModel.EmployeeEvaluationsLookUp.CanEdit(note))
                ViewModel.EmployeeEvaluationsLookUp.Edit(note);
        }
        void DoEditTask(EmployeeTask task) {
            if(ViewModel.EmployeeAssignedTasksLookUp.CanEdit(task))
                ViewModel.EmployeeAssignedTasksLookUp.Edit(task);
        }
        void ViewModel_EntityChanged(object sender, EventArgs e) {
            UpdateEditors(ViewModel.Entity);
        }
        void UpdateEditors(Employee employee) {
            if(employee == null) return;
            ViewModelHelper.EnsureViewModel(ViewModel.EmployeeAssignedTasksLookUp, TasksViewModel);
            ViewModelHelper.EnsureViewModel(ViewModel.EmployeeEvaluationsLookUp, NotesViewModel);
            if(object.Equals(employeeBindingSource.DataSource, employee))
                employeeBindingSource.ResetBindings(false);
            else
                employeeBindingSource.DataSource = employee;
            if(stateUC1.stateLookUpEdit.DataBindings.Count == 0) {
                stateUC1.stateLookUpEdit.DataBindings.Add("EditValue", addressBindingSource, "State");
            }
            tasksBindingSource.SetItemsSource(ViewModel.EmployeeAssignedTasksLookUp.Entities);
            notesBindingSource.SetItemsSource(ViewModel.EmployeeEvaluationsLookUp.Entities);
        }
        void InitializeButtonPanel() {
            var listBI = new List<ButtonInfo>();
            listBI.Add(new ButtonInfo()
            {
                Type = typeof(SimpleButton),
                Text = "Save",
                Name = "5",
                Image = ImageHelper.GetImageFromToolbarResource("Save"),
                mouseEventHandler = (s, e) =>
                {
                    if(!errorProvider.HasErrors) Save();
                }
            });
            listBI.Add(new ButtonInfo()
            {
                Type = typeof(SimpleButton),
                Text = "Cancel",
                Name = "4",
                Image = ImageHelper.GetImageFromToolbarResource("Cancel"),
                mouseEventHandler = (s, e) =>
                {
                    Cancel();
                }
            });

            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Reports", Name = "6", Image = ImageHelper.GetImageFromToolbarResource("Reports"), mouseEventHandler = (s, e) => { ReportsButtonClick(); } });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Mail Merge", Name = "7", Image = ImageHelper.GetImageFromToolbarResource("MailMerge"), mouseEventHandler = (s, e) => { MailMergeClick(); } });
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Task", Name = "8", Image = ImageHelper.GetImageFromToolbarResource("Task"), mouseEventHandler = (s, e) => { TaskButtonClick(); } });
            listBI.Add(new ButtonInfo()
            {
                Type = typeof(SimpleButton),
                Text = "Meeting",
                Name = "9",
                Image = ImageHelper.GetImageFromToolbarResource("Meeting"),
                mouseEventHandler = (s, e) =>
                {
                    XtraMessageBox.Show(string.Format("Schedule meeting with {0}?", ViewModel.Entity.FullName), string.Empty, MessageBoxButtons.YesNoCancel);
                }
            });
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Note", Name = "10", Image = ImageHelper.GetImageFromToolbarResource("Note"), mouseEventHandler = (s, e) => { NoteButtonClick(); } });
            BottomPanel.InitializeButtons(listBI, false);
        }
        void NoteButtonClick() {
            EditNotes.NewNoteOwner = ViewModel.Entity;
            ViewModel.EmployeeEvaluationsLookUp.New();
        }
        void TaskButtonClick() {
            EditTask.NewTaskOwner = ViewModel.Entity;
            ViewModel.EmployeeAssignedTasksLookUp.New();
        }
        void MailMergeClick() {
            GotoModule(ModuleType.EmployeeMailMerge, ViewModel.Entity);
        }
        public void CloseSubModule() {
            openedSubModule.Parent = null;
            openedSubModule.Dispose();
            openedSubModule = null;
            InitializeButtonPanel();
        }
        void ReportsButtonClick() {
            GotoModule(ModuleType.EmployeesPrint, EmployeeReportType.Profile);
        }
        void GotoModule(ModuleType mt, object param) {
            var moduleLocator = GetService<Services.IModuleLocator>();
            openedSubModule = moduleLocator.GetModule(mt) as BaseModuleControl;
            ViewModelHelper.EnsureModuleViewModel(openedSubModule, ViewModel, param);
            openedSubModule.Dock = DockStyle.Fill;
            openedSubModule.Parent = this;
            openedSubModule.OnTransitionCompleted();
            openedSubModule.BringToFront();
        }
        protected override void Return() {
            MainViewModel.SelectModule(ModuleType.Employees);
        }
        void returnButton_Click(object sender, EventArgs e) {
            if(CheckSave()) Return();
        }
        void tasksGridView_RowClick(object sender, RowClickEventArgs e) {
            if(e.Clicks > 1 && e.RowHandle >= 0) {
                DoEditTask(tasksGridView.GetFocusedRow() as EmployeeTask);
            }
        }
        void notesGridView_RowClick(object sender, RowClickEventArgs e) {
            if(e.Clicks > 1 && e.RowHandle >= 0) {
                DoEditNote(notesGridView.GetFocusedRow() as Evaluation);
            }
        }
    }
}
