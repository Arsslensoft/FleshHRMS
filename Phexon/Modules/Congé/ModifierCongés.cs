using System;
using System.Linq;
using PHRMS.Data;
using PHRMS.ViewModels;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;

namespace PHRMS.Modules {
    public partial class ModifierCongés : BaseModuleControl {
        public ModifierCongés()
            : base(CreateViewModel<LeaveViewModel>) {
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
        public LeaveViewModel ViewModel {
            get { return GetViewModel<LeaveViewModel>(); }
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
            // Owner
            ViewModel.Entity.AssignedEmployee = ViewModel.FindEmployeeId(MainViewModel.CurrentEmployee);
            ViewModel.Entity.AssignedEmployeeId = MainViewModel.CurrentEmployee.Id;
          
            if(employee != null) {
                ViewModel.Entity.Owner = ViewModel.FindEmployeeId(employee);
                ViewModel.Entity.OwnerId = employee.Id;

            }

            this.layoutControlItem7.Visibility = (MainViewModel.CurrentEmployee.Role > EmployeeRole.Agent) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;





            
        }
        void InitLookupEditors() {
            var employeesLookup = ViewModel.GetEmployees().ToList();
          
            assignedToLookUpEdit.Properties.DataSource = employeesLookup;
        
        }
        void InitDropDownEditors() {
            statusImageComboBoxEdit.Properties.Items.AddEnum<LeaveStatus>();
            linkedToLookUpEdit.Properties.Items.AddEnum<LeaveType>();
            

            for(var i = 0; i < statusImageComboBoxEdit.Properties.Items.Count; i++)
                statusImageComboBoxEdit.Properties.Items[i].ImageIndex = i;
            priorityImageComboBoxEdit.Properties.Items.AddEnum<LeavePriority>();
            for(var i = 0; i < priorityImageComboBoxEdit.Properties.Items.Count; i++)
                priorityImageComboBoxEdit.Properties.Items[i].ImageIndex = i;
        }
        void UpdateEditors(Leave task) {
            if(task == null) return;
            taskBindingSource.DataSource = task;
      
        }
      
      
        public static Employee NewTaskOwner { get; set; }
    }
}
