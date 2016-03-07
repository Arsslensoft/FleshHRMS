using System;
using System.Linq;
using DevExpress.DevAV;
using DevExpress.DevAV.ViewModels;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;

namespace DevExpress.DevAV.Modules {
    public partial class EditTask : BaseModuleControl {
        public EditTask()
            : base(CreateViewModel<EmployeeTaskViewModel>) {
            InitializeComponent();
            ViewModel.EntityChanged += ViewModel_EntityChanged;
            InitLookupEditors();
            InitDropDownEditors();
            BindCommands();
            BindEditors();
        }
        protected override void OnDisposing() {
            ViewModel.EntityChanged -= ViewModel_EntityChanged;
            base.OnDisposing();
        }
        public EmployeeTaskViewModel ViewModel {
            get { return GetViewModel<EmployeeTaskViewModel>(); }
        }
        protected override void UpdateViewModel() {
            ViewModel.ValidationErrors = errorProvider.HasErrors;
            ViewModel.Update();
        }
        protected override void OnParentViewModelAttached() {
            base.OnParentViewModelAttached();
            if(ViewModel.IsNew()) {
                InitNew(NewTaskOwner);
            }
        }
        void BindCommands() {
            saveSimpleButton.BindCommand(() => ViewModel.SaveAndClose(), ViewModel);
            cancelSimpleButton.BindCommand(() => ViewModel.Close(), ViewModel);
        }
        DXErrorProvider errorProvider;
        void BindEditors() {

            errorProvider = new DXErrorProvider(layout);
            errorProvider.DataSource = taskBindingSource;

            foreach(var item in layout.Controls) {
                BaseEdit edit = item as BaseEdit;
                if(edit == null || edit.DataBindings.Count == 0) continue;
                edit.Properties.EditValueChanged += (s, e) => QueueViewModelUpdate();
            }
        }
        void ViewModel_EntityChanged(object sender, EventArgs e) {
            UpdateEditors(ViewModel.Entity);
        }
        void InitNew(Employee employee) {
            ViewModel.Entity.StartDate = DateTime.Now;
            ViewModel.Entity.DueDate = DateTime.Now + new TimeSpan(48, 0, 0);
            if(employee != null) {
                ViewModel.Entity.Owner = ViewModel.FindEmployeeId(employee);
                ViewModel.Entity.OwnerId = employee.Id;
            }
        }
        void InitLookupEditors() {
            var employeesLookup = ViewModel.GetEmployees().ToList();
            ownerLookUpEdit.Properties.DataSource = employeesLookup;
            assignedToLookUpEdit.Properties.DataSource = employeesLookup;
            linkedToLookUpEdit.Properties.DataSource = employeesLookup;
        }
        void InitDropDownEditors() {
            statusImageComboBoxEdit.Properties.Items.AddEnum<EmployeeTaskStatus>();
            for(var i = 0; i < statusImageComboBoxEdit.Properties.Items.Count; i++)
                statusImageComboBoxEdit.Properties.Items[i].ImageIndex = i;
            priorityImageComboBoxEdit.Properties.Items.AddEnum<EmployeeTaskPriority>();
            for(var i = 0; i < priorityImageComboBoxEdit.Properties.Items.Count; i++)
                priorityImageComboBoxEdit.Properties.Items[i].ImageIndex = i;
        }
        void UpdateEditors(EmployeeTask task) {
            if(task == null) return;
            taskBindingSource.DataSource = task;
            cbReminderDate.Enabled = cbReminderTime.Enabled = cbReminder.Checked;
        }
        void tbComplete_EditValueChanging(object sender, XtraEditors.Controls.ChangingEventArgs e) {
            tbComplete.Refresh();
        }
        void cbReminder_CheckedChanged(object sender, EventArgs e) {
            cbReminderDate.Enabled = cbReminderTime.Enabled = cbReminder.Checked;
        }
        public static Employee NewTaskOwner { get; set; }
    }
}
