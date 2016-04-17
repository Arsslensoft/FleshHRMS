using System;
using System.Linq;
using PHRMS.Data;
using PHRMS.ViewModels;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.Mvvm;

namespace PHRMS.Modules {
    public partial class ModifierAbsence : BaseModuleControl {
        public ModifierAbsence()
            : base(CreateViewModel<AbsencesViewModel>)
        {
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
        public AbsencesViewModel ViewModel {
            get { return GetViewModel<AbsencesViewModel>(); }
        }
        protected override void UpdateViewModel() {
            ViewModel.ValidationErrors = errorProvider.HasErrors;
            ViewModel.Update();
        }
        protected override void OnParentViewModelAttached() {
            base.OnParentViewModelAttached();
            if(ViewModel.IsNew()) {
                InitNew(AbsenceOwner,MainViewModel.CurrentEmployee);
            }
        }
        void ViewModel_EntityChanged(object sender, EventArgs e) {
            UpdateEditors(ViewModel.Entity);
        }
        void InitNew(Employee employee, Employee creator)
        {
            ViewModel.Entity.StartDate = DateTime.Now;
            if (creator != null)
            {
                ViewModel.Entity.CreatedBy = ViewModel.FindEmployeeId(creator);
                ViewModel.Entity.CreatedById = creator.Id;
            }
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
            imageComboBoxEdit1.Properties.Items.AddEnum<PHRMS.Data.AbsenceType>();
            assignedToLookUpEdit.Properties.DataSource = ViewModel.GetEmployees().ToList();
      
        }
        void UpdateEditors(Absence note) {
            if(note == null) return;
            noteBindingSource.DataSource = note;
        }
        public static Employee AbsenceOwner { get; set; }
        public static Employee AbsenceCreator { get; set; }
    }
   
    public class Shifts : BaseModuleControl
    {
        public Shifts()
            : base(CreateViewModel<ShiftsCollectionViewModel>)
        {
        }
        protected override void OnInitServices(DevExpress.Mvvm.IServiceContainer serviceContainer)
        {
            base.OnInitServices(serviceContainer);
         serviceContainer.RegisterService(new FlyoutDetailFormDocumentManagerService(ModuleType.ModifierPlaning));
        }
    }
    public class Notifications : BaseModuleControl
    {
        public Notifications()
            : base(CreateViewModel<NotificationCollectionViewModel>)
        {
        }
        protected override void OnInitServices(DevExpress.Mvvm.IServiceContainer serviceContainer)
        {
            base.OnInitServices(serviceContainer);
 
        }
    }

    public class Holidays : BaseModuleControl
    {
        public Holidays()
            : base(CreateViewModel<HolidayCollectionViewModel>)
        {
        }
        protected override void OnInitServices(DevExpress.Mvvm.IServiceContainer serviceContainer)
        {
            base.OnInitServices(serviceContainer);
            serviceContainer.RegisterService(new FlyoutDetailFormDocumentManagerService(ModuleType.ModifierFérier));
        }
    }
}
