using System;
using System.Linq;
using PHRMS.Data;
using PHRMS.ViewModels;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.Mvvm;

namespace PHRMS.Modules {
    public partial class ModifierPlaning : BaseModuleControl {
        public ModifierPlaning()
            : base(CreateViewModel<ShiftsViewModel>) {
            InitializeComponent();
            ViewModel.EntityChanged += ViewModel_EntityChanged;
            InitLookupEditors();
            BindCommands();
            BindEditors();
        }
        protected override void OnDisposing() {
            ViewModel.EntityChanged -= ViewModel_EntityChanged;
            base.OnDisposing();
        }
        public ShiftsViewModel ViewModel
        {
            get { return GetViewModel<ShiftsViewModel>(); }
        }
        protected override void UpdateViewModel() {
            ViewModel.ValidationErrors = errorProvider.HasErrors;
            ViewModel.Update();
        }
        protected override void OnParentViewModelAttached() {
            base.OnParentViewModelAttached();
            if(ViewModel.IsNew()) {
                InitNew(AbsenceOwner);
            }
        }
        void ViewModel_EntityChanged(object sender, EventArgs e) {
            UpdateEditors(ViewModel.Entity);
        }
        void InitNew(Employee employee)
        {
            ViewModel.Entity.Start = DateTime.Now;
        
            if (employee != null)
            {
                ViewModel.Entity.Employee = ViewModel.FindEmployeeId(employee);
                ViewModel.Entity.EmployeeId = employee.Id;
            }
        }
        DXErrorProvider errorProvider;
        void BindEditors() {
            fullNameLabelControl.DataBindings.Add("Text", assignedToLookUpEdit, "Text", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
            errorProvider = new DXErrorProvider(layout);
            errorProvider.DataSource = noteBindingSource;

            foreach(var item in layout.Controls) {
                BaseEdit edit = item as BaseEdit;
                if(edit == null || edit.DataBindings.Count == 0) continue;
                edit.Properties.EditValueChanged += (s, e) => QueueViewModelUpdate();
            }
        }
        void BindCommands() {
            saveSimpleButton.BindCommand(() => ViewModel.SaveAndClose(), ViewModel);
            cancelSimpleButton.BindCommand(() => ViewModel.Close(), ViewModel);
        }
        void InitLookupEditors() {
            imageComboBoxEdit1.Properties.Items.AddEnum<PHRMS.Data.ShiftType>();
            imageComboBoxEdit2.Properties.Items.AddEnum<PHRMS.Data.ReccuranceType>();
            assignedToLookUpEdit.Properties.DataSource = ViewModel.GetEmployees().ToList();
            imageComboBoxEdit3.Properties.Items.AddEnum<PHRMS.Data.StatusType>();
            imageComboBoxEdit4.Properties.Items.AddEnum<PHRMS.Data.LabelType>();
        }
        void UpdateEditors(Shift note) {
            if(note == null) return;
            noteBindingSource.DataSource = note;
        }
        public static Employee AbsenceOwner { get; set; }
      
    }
  
}
