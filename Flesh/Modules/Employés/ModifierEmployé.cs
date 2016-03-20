using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FHRMS.Data;
using FHRMS.ViewModels;
using FHRMS.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
using FHRMS.Common.Utils;

namespace FHRMS.Modules {
    public partial class ModifierEmployé : BaseModuleControl {
        BaseModuleControl openedSubModule;
        public ModifierEmployé()
            : base(CreateViewModel<EmployeeViewModel>) {
            InitializeComponent();
           
            ViewModel.EntityChanged += ViewModel_EntityChanged;
            InitializeCustomDrawRows();
            InitializeData();
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
        LeaveCollectionViewModel tasksViewModel;
        public LeaveCollectionViewModel TasksViewModel {
            get { return TryGetModuleViewModel<LeaveCollectionViewModel>(ref tasksViewModel, ModuleType.Congés); }
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
                DoEditNote(((EditorButton)s).Tag as Absence);
            };
            notesGridView.ButtonsPanel.Buttons[1].Click += (s, e) =>
            {
                DoDeleteNote(((EditorButton)s).Tag as Absence);
            };
            notesGridView.ShowButtons = true;
            notesGridView.UserCellPadding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            notesGridView.Appearance.SelectedRow.Assign(notesGridView.Appearance.FocusedCell);

            tasksGridView.ButtonsColumn = colComplete;
            tasksGridView.ButtonsPanel.Buttons.Add(new EditorButton(ButtonPredefines.Glyph) { Caption = "Edit", Width = 66 });
            tasksGridView.ButtonsPanel.Buttons[0].Click += (s, e) =>
            {
                DoEditTask(((EditorButton)s).Tag as Leave);
            };
            tasksGridView.ShowButtons = true;
        }
        void InitializeData()
        {
            roleLookUpEdit.Properties.Items.AddEnum<FHRMS.Data.EmployeeRole>();
            statusLookUpEdit.Properties.Items.AddEnum<FHRMS.Data.EmployeeStatus>();
            departmentLookUpEdit.Properties.Items.AddEnum<FHRMS.Data.EmployeeDepartment>();
        }
        void DoDeleteNote(Absence note) {
            if(ViewModel.EmployeeEvaluationsLookUp.CanDelete(note))
                ViewModel.EmployeeEvaluationsLookUp.Delete(note);
        }
        void DoEditNote(Absence note) {
            if(ViewModel.EmployeeEvaluationsLookUp.CanEdit(note))
                ViewModel.EmployeeEvaluationsLookUp.Edit(note);
        }
        void DoEditTask(Leave task) {
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
                Text = "Enregistrer",
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
                Text = "Annuler",
                Name = "4",
                Image = ImageHelper.GetImageFromToolbarResource("Cancel"),
                mouseEventHandler = (s, e) =>
                {
                    Cancel();
                }
            });

            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Rapports", Name = "6", Image = ImageHelper.GetImageFromToolbarResource("Reports"), mouseEventHandler = (s, e) => { ReportsButtonClick(); } });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Publipostage", Name = "7", Image = ImageHelper.GetImageFromToolbarResource("MailMerge"), mouseEventHandler = (s, e) => { MailMergeClick(); } });
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Congés", Name = "8", Image = ImageHelper.GetImageFromToolbarResource("Task"), mouseEventHandler = (s, e) => { TaskButtonClick(); } });
            listBI.Add(new ButtonInfo()
            {
                Type = typeof(SimpleButton),
                Text = "Réunion",
                Name = "9",
                Image = ImageHelper.GetImageFromToolbarResource("Meeting"),
                mouseEventHandler = (s, e) =>
                {
                    XtraMessageBox.Show(string.Format("Planifier une réunion avec {0}?", ViewModel.Entity.FullName), string.Empty, MessageBoxButtons.YesNoCancel);
                }
            });
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Absence", Name = "10", Image = ImageHelper.GetImageFromToolbarResource("Note"), mouseEventHandler = (s, e) => { NoteButtonClick(); } });
            BottomPanel.InitializeButtons(listBI, false);
        }
        void NoteButtonClick() {
            ModifierAbsence.NewNoteOwner = ViewModel.Entity;
            ViewModel.EmployeeEvaluationsLookUp.New();
        }
        void TaskButtonClick() {
            ModifierCongés.NewTaskOwner = ViewModel.Entity;
            ViewModel.EmployeeAssignedTasksLookUp.New();
        }
        void MailMergeClick() {
            GotoModule(ModuleType.PublipostageEmployé, ViewModel.Entity);
        }
        public void CloseSubModule() {
     
            openedSubModule.Parent = null;
            openedSubModule.Dispose();
            openedSubModule = null;
            dataLayoutControl.Dock = DockStyle.Top;
            InitializeButtonPanel();
        }
        void ReportsButtonClick() {
            GotoModule(ModuleType.ImprimerEmployé, EmployeeReportType.Profile);
        }
        void GotoModule(ModuleType mt, object param) {
            dataLayoutControl.Dock = DockStyle.Fill;
            var moduleLocator = GetService<Services.IModuleLocator>();
            openedSubModule = moduleLocator.GetModule(mt) as BaseModuleControl;
            ViewModelHelper.EnsureModuleViewModel(openedSubModule, ViewModel, param);
            openedSubModule.Dock = DockStyle.Fill;
            openedSubModule.Parent = this;
            openedSubModule.OnTransitionCompleted();
            openedSubModule.BringToFront();
   
          
        }
        protected override void Return() {
       
            MainViewModel.SelectModule(ModuleType.Employés);
        }
        void returnButton_Click(object sender, EventArgs e) {
            if(CheckSave()) Return();
        }
        void tasksGridView_RowClick(object sender, RowClickEventArgs e) {
            if(e.Clicks > 1 && e.RowHandle >= 0) {
                DoEditTask(tasksGridView.GetFocusedRow() as Leave);
            }
        }
        void notesGridView_RowClick(object sender, RowClickEventArgs e) {
            if(e.Clicks > 1 && e.RowHandle >= 0) {
                DoEditNote(notesGridView.GetFocusedRow() as Absence);
            }
        }

        private void ModifierEmployé_Resize(object sender, EventArgs e)
        {
            dataLayoutControl.Size = new System.Drawing.Size(this.Width, System.Windows.Forms.SystemInformation.VirtualScreen.Height);
        }

       
    }
}
