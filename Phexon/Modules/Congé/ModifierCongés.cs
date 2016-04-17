using System;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraLayout.Utils;
using PHRMS.Data;
using PHRMS.ViewModels;

namespace PHRMS.Modules
{
    public partial class ModifierCongés : BaseModuleControl
    {
        private DXErrorProvider errorProvider;

        public ModifierCongés()
            : base(CreateViewModel<LeaveViewModel>)
        {
            InitializeComponent();
            ViewModel.EntityChanged += ViewModel_EntityChanged;
            InitLookupEditors();
            InitDropDownEditors();
            BindCommands();
            BindEditors();
        }

        public LeaveViewModel ViewModel
        {
            get { return GetViewModel<LeaveViewModel>(); }
        }


        public static Employee NewTaskOwner { get; set; }

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

        protected override void OnParentViewModelAttached()
        {
            base.OnParentViewModelAttached();
            if (ViewModel.IsNew())
            {
                InitNew(NewTaskOwner);
            }
        }

        private void BindCommands()
        {
            saveSimpleButton.BindCommand(() => ViewModel.SaveAndClose(), ViewModel);
            cancelSimpleButton.BindCommand(() => ViewModel.Close(), ViewModel);
        }

        private void BindEditors()
        {
            errorProvider = new DXErrorProvider(layout);
            errorProvider.DataSource = taskBindingSource;

            foreach (var item in layout.Controls)
            {
                var edit = item as BaseEdit;
                if (edit == null || edit.DataBindings.Count == 0) continue;
                edit.Properties.EditValueChanged += (s, e) => QueueViewModelUpdate();
            }
        }

        private void ViewModel_EntityChanged(object sender, EventArgs e)
        {
            UpdateEditors(ViewModel.Entity);
        }

        private void InitNew(Employee employee)
        {
            ViewModel.Entity.StartDate = DateTime.Now;
            ViewModel.Entity.DueDate = DateTime.Now + new TimeSpan(48, 0, 0);
            // Owner
            ViewModel.Entity.Owner = MainViewModel.CurrentEmployee;
            ViewModel.Entity.OwnerId = MainViewModel.CurrentEmployee.Id;

            if (employee != null)
            {
                ViewModel.Entity.AssignedEmployee = ViewModel.FindEmployeeId(employee);
                ViewModel.Entity.AssignedEmployeeId = employee.Id;
            }

            layoutControlItem7.Visibility = MainViewModel.CurrentEmployee.Role > EmployeeRole.Agent
                ? LayoutVisibility.Always
                : LayoutVisibility.Never;
        }

        private void InitLookupEditors()
        {
            var employeesLookup = ViewModel.GetEmployees().ToList();

            assignedToLookUpEdit.Properties.DataSource = employeesLookup;
        }

        private void InitDropDownEditors()
        {
            statusImageComboBoxEdit.Properties.Items.AddEnum<LeaveStatus>();
            linkedToLookUpEdit.Properties.Items.AddEnum<LeaveType>();


            for (var i = 0; i < statusImageComboBoxEdit.Properties.Items.Count; i++)
                statusImageComboBoxEdit.Properties.Items[i].ImageIndex = i;
            priorityImageComboBoxEdit.Properties.Items.AddEnum<LeavePriority>();
            for (var i = 0; i < priorityImageComboBoxEdit.Properties.Items.Count; i++)
                priorityImageComboBoxEdit.Properties.Items[i].ImageIndex = i;
        }

        private void UpdateEditors(Leave task)
        {
            if (task == null) return;
            taskBindingSource.DataSource = task;
        }
    }
}