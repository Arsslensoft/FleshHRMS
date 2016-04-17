using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraScheduler;
using PHRMS.Data;
using PHRMS.Helpers;
using PHRMS.Services;
using PHRMS.ViewModels;
using Padding = System.Windows.Forms.Padding;

namespace PHRMS.Modules
{
    public partial class ModifierEmployé : BaseModuleControl
    {
        private AbsencesCollectionViewModel notesViewModel;


        private BaseModuleControl openedSubModule;

        private ShiftsCollectionViewModel shiftsViewModel;
        private LeaveCollectionViewModel tasksViewModel;

        public ModifierEmployé()
            : base(CreateViewModel<EmployeeViewModel>)
        {
            InitializeComponent();

            ViewModel.EntityChanged += ViewModel_EntityChanged;
            InitializeCustomDrawRows();
            InitializeData();
            BindEditors();
            lbNotes.Tag = 1;
            lbTasks.Tag = 2;
            lbSchedule.Tag = 3;
            new LabelTabController(lbTasks.Tag, lbNotes, lbTasks, lbSchedule).EditValueChanged += (s, e) =>
            {
                lciNotes.Visibility = (int) s == 1 ? LayoutVisibility.Always : LayoutVisibility.Never;
                lciTasks.Visibility = (int) s == 2 ? LayoutVisibility.Always : LayoutVisibility.Never;
                lciSchedule.Visibility = (int) s == 3 ? LayoutVisibility.Always : LayoutVisibility.Never;
            };
        }

        public EmployeeViewModel ViewModel
        {
            get { return GetViewModel<EmployeeViewModel>(); }
        }

        public MainViewModel MainViewModel
        {
            get { return GetParentViewModel<MainViewModel>(); }
        }

        public LeaveCollectionViewModel TasksViewModel
        {
            get { return TryGetModuleViewModel(ref tasksViewModel, ModuleType.Congés); }
        }

        public AbsencesCollectionViewModel NotesViewModel
        {
            get { return TryGetModuleViewModel(ref notesViewModel, ModuleType.Absences); }
        }

        public ShiftsCollectionViewModel ShiftsViewModel
        {
            get { return TryGetModuleViewModel(ref shiftsViewModel, ModuleType.Shifts); }
        }

        protected override void OnDisposing()
        {
            ViewModel.EntityChanged -= ViewModel_EntityChanged;
            base.OnDisposing();
        }

        protected override void UpdateViewModel()
        {
            ViewModel.ValidationErrors = errorProvider.HasErrors;
            ViewModel.Update();
        }

        protected internal override void OnTransitionCompleted()
        {
            base.OnTransitionCompleted();
            employeeLabelControl.Focus();
            InitializeButtonPanel();
        }

        private void BindEditors()
        {
            foreach (var item in dataLayoutControl.Controls)
            {
                var edit = item as BaseEdit;
                if (edit == null || edit.DataBindings.Count == 0) continue;
                edit.Properties.EditValueChanged += (s, e) => QueueViewModelUpdate();
            }
        }

        private void InitializeCustomDrawRows()
        {
            notesGridView.ButtonsColumn = noteColSubject;
            notesGridView.ButtonsPanel.Buttons.Add(new EditorButton(ButtonPredefines.Glyph) {Caption = "Modifier"});
            notesGridView.ButtonsPanel.Buttons.Add(new EditorButton(ButtonPredefines.Glyph) {Caption = "Supprimer"});
            notesGridView.ButtonsPanel.Buttons[0].Click += (s, e) => { DoEditNote(((EditorButton) s).Tag as Absence); };
            notesGridView.ButtonsPanel.Buttons[1].Click +=
                (s, e) => { DoDeleteNote(((EditorButton) s).Tag as Absence); };
            notesGridView.ShowButtons = true;
            notesGridView.UserCellPadding = new Padding(3, 3, 3, 3);
            notesGridView.Appearance.SelectedRow.Assign(notesGridView.Appearance.FocusedCell);

            tasksGridView.ButtonsColumn = colComplete;
            tasksGridView.ButtonsPanel.Buttons.Add(new EditorButton(ButtonPredefines.Glyph)
            {
                Caption = "Modifier",
                Width = 66
            });
            tasksGridView.ButtonsPanel.Buttons[0].Click += (s, e) => { DoEditTask(((EditorButton) s).Tag as Leave); };
            tasksGridView.ShowButtons = true;
        }

        private void InitializeData()
        {
            roleLookUpEdit.Properties.Items.AddEnum<EmployeeRole>();
            statusLookUpEdit.Properties.Items.AddEnum<EmployeeStatus>();
            departmentLookUpEdit.Properties.Items.AddEnum<EmployeeDepartment>();
        }

        private void DoDeleteNote(Absence note)
        {
            if (ViewModel.EmployeeEvaluationsLookUp.CanDelete(note))
                ViewModel.EmployeeEvaluationsLookUp.Delete(note);
        }

        private void DoEditNote(Absence note)
        {
            if (ViewModel.EmployeeEvaluationsLookUp.CanEdit(note))
                ViewModel.EmployeeEvaluationsLookUp.Edit(note);
        }

        private void DoEditTask(Leave task)
        {
            if (ViewModel.EmployeeAssignedTasksLookUp.CanEdit(task))
                ViewModel.EmployeeAssignedTasksLookUp.Edit(task);
        }

        private void ViewModel_EntityChanged(object sender, EventArgs e)
        {
            UpdateEditors(ViewModel.Entity);
        }

        private void UpdateEditors(Employee employee)
        {
            if (employee == null) return;
            ViewModelHelper.EnsureViewModel(ViewModel.EmployeeAssignedTasksLookUp, TasksViewModel);
            ViewModelHelper.EnsureViewModel(ViewModel.EmployeeEvaluationsLookUp, NotesViewModel);
            ViewModelHelper.EnsureViewModel(ViewModel.EmployeeShiftsLookUp, ShiftsViewModel);
            if (Equals(employeeBindingSource.DataSource, employee))
                employeeBindingSource.ResetBindings(false);
            else
                employeeBindingSource.DataSource = employee;
            if (stateUC1.stateLookUpEdit.DataBindings.Count == 0)
            {
                stateUC1.stateLookUpEdit.DataBindings.Add("EditValue", addressBindingSource, "State");
            }
            tasksBindingSource.SetItemsSource(ViewModel.EmployeeAssignedTasksLookUp.Entities);
            notesBindingSource.SetItemsSource(ViewModel.EmployeeEvaluationsLookUp.Entities);
            shiftsBindingSource.SetItemsSource(ViewModel.EmployeeShiftsLookUp.Entities);
        }

        private void InitializeButtonPanel()
        {
            var listBI = new List<ButtonInfo>();
            listBI.Add(new ButtonInfo
            {
                Type = typeof(SimpleButton),
                Text = "Enregistrer",
                Name = "5",
                Image = ImageHelper.GetImageFromToolbarResource("Save"),
                mouseEventHandler = (s, e) =>
                {
                    if (!errorProvider.HasErrors) Save();
                }
            });
            listBI.Add(new ButtonInfo
            {
                Type = typeof(SimpleButton),
                Text = "Annuler",
                Name = "4",
                Image = ImageHelper.GetImageFromToolbarResource("Cancel"),
                mouseEventHandler = (s, e) => { Cancel(); }
            });

            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo
            {
                Type = typeof(SimpleButton),
                Text = "Rapports",
                Name = "6",
                Image = ImageHelper.GetImageFromToolbarResource("Reports"),
                mouseEventHandler = (s, e) => { ReportsButtonClick(); }
            });
            listBI.Add(new ButtonInfo());

            listBI.Add(new ButtonInfo
            {
                Type = typeof(SimpleButton),
                Text = "Congés",
                Name = "8",
                Image = ImageHelper.GetImageFromToolbarResource("Task"),
                mouseEventHandler = (s, e) => { TaskButtonClick(); }
            });

            listBI.Add(new ButtonInfo
            {
                Type = typeof(SimpleButton),
                Text = "Absence",
                Name = "10",
                Image = ImageHelper.GetImageFromToolbarResource("Note"),
                mouseEventHandler = (s, e) => { NoteButtonClick(); }
            });
            BottomPanel.InitializeButtons(listBI, false);
        }

        private void NoteButtonClick()
        {
            ModifierAbsence.AbsenceOwner = ViewModel.Entity;
            ViewModel.EmployeeEvaluationsLookUp.New();
        }

        private void TaskButtonClick()
        {
            ModifierCongés.NewTaskOwner = ViewModel.Entity;
            ViewModel.EmployeeAssignedTasksLookUp.New();
        }

        public void CloseSubModule()
        {
            openedSubModule.Parent = null;
            openedSubModule.Dispose();
            openedSubModule = null;
            dataLayoutControl.Dock = DockStyle.Top;
            InitializeButtonPanel();
        }

        private void ReportsButtonClick()
        {
            GotoModule(ModuleType.ImprimerEmployé, EmployeeReportType.Profile);
        }

        private void GotoModule(ModuleType mt, object param)
        {
            dataLayoutControl.Dock = DockStyle.Fill;
            var moduleLocator = GetService<IModuleLocator>();
            openedSubModule = moduleLocator.GetModule(mt) as BaseModuleControl;
            ViewModelHelper.EnsureModuleViewModel(openedSubModule, ViewModel, param);
            openedSubModule.Dock = DockStyle.Fill;
            openedSubModule.Parent = this;
            openedSubModule.OnTransitionCompleted();
            openedSubModule.BringToFront();
        }

        protected override void Return()
        {
            MainViewModel.SelectModule(ModuleType.Employés);
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            if (CheckSave()) Return();
        }

        private void tasksGridView_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks > 1 && e.RowHandle >= 0)
            {
                DoEditTask(tasksGridView.GetFocusedRow() as Leave);
            }
        }

        private void notesGridView_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks > 1 && e.RowHandle >= 0)
            {
                DoEditNote(notesGridView.GetFocusedRow() as Absence);
            }
        }

        private void ModifierEmployé_Resize(object sender, EventArgs e)
        {
            dataLayoutControl.Size = new Size(Width, SystemInformation.VirtualScreen.Height);
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            e.Handled = true;
            if (schedulerControl1.SelectedAppointments.Count == 0)
            {
                ModifierPlaning.AbsenceOwner = ViewModel.Entity;
                ViewModel.EmployeeShiftsLookUp.New();
            }
            else
            {
                if (ViewModel.EmployeeShiftsLookUp.CanEdit(shiftsBindingSource.Current as Shift))
                    ViewModel.EmployeeShiftsLookUp.Edit(shiftsBindingSource.Current as Shift);

                schedulerStorage1.RefreshData();
            }
        }

        private void schedulerStorage1_AppointmentDeleting(object sender, PersistentObjectCancelEventArgs e)
        {
            if (ViewModel.EmployeeShiftsLookUp.CanDelete(shiftsBindingSource.Current as Shift))
                ViewModel.EmployeeShiftsLookUp.Delete(shiftsBindingSource.Current as Shift);
        }

        private void schedulerStorage1_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            if (ViewModel.EmployeeShiftsLookUp.CanSave(shiftsBindingSource.Current as Shift))
                ViewModel.EmployeeShiftsLookUp.Save(shiftsBindingSource.Current as Shift);
        }

        private void schedulerStorage1_AppointmentInserting(object sender, PersistentObjectCancelEventArgs e)
        {
        }
    }
}