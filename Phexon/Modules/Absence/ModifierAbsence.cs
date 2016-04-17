using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Mvvm;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using PHRMS.Data;
using PHRMS.ViewModels;

namespace PHRMS.Modules
{
    public partial class ModifierAbsence : BaseModuleControl
    {
        private DXErrorProvider errorProvider;

        public ModifierAbsence()
            : base(CreateViewModel<AbsencesViewModel>)
        {
            InitializeComponent();
            ViewModel.EntityChanged += ViewModel_EntityChanged;
            InitLookupEditors();
            BindCommands();
            BindEditors();
        }

        public AbsencesViewModel ViewModel
        {
            get { return GetViewModel<AbsencesViewModel>(); }
        }

        public static Employee AbsenceOwner { get; set; }
        public static Employee AbsenceCreator { get; set; }

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
                InitNew(AbsenceOwner, MainViewModel.CurrentEmployee);
            }
        }

        private void ViewModel_EntityChanged(object sender, EventArgs e)
        {
            UpdateEditors(ViewModel.Entity);
        }

        private void InitNew(Employee employee, Employee creator)
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

        private void BindEditors()
        {
            fullNameLabelControl.DataBindings.Add("Text", assignedToLookUpEdit, "Text", true,
                DataSourceUpdateMode.OnPropertyChanged);
            errorProvider = new DXErrorProvider(layout);
            errorProvider.DataSource = noteBindingSource;

            foreach (var item in layout.Controls)
            {
                var edit = item as BaseEdit;
                if (edit == null || edit.DataBindings.Count == 0) continue;
                edit.Properties.EditValueChanged += (s, e) => QueueViewModelUpdate();
            }
        }

        private void BindCommands()
        {
            saveSimpleButton.BindCommand(() => ViewModel.SaveAndClose(), ViewModel);
            cancelSimpleButton.BindCommand(() => ViewModel.Close(), ViewModel);
        }

        private void InitLookupEditors()
        {
            imageComboBoxEdit1.Properties.Items.AddEnum<AbsenceType>();
            assignedToLookUpEdit.Properties.DataSource = ViewModel.GetEmployees().ToList();
        }

        private void UpdateEditors(Absence note)
        {
            if (note == null) return;
            noteBindingSource.DataSource = note;
        }
    }

    public class Shifts : BaseModuleControl
    {
        public Shifts()
            : base(CreateViewModel<ShiftsCollectionViewModel>)
        {
        }

        protected override void OnInitServices(IServiceContainer serviceContainer)
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

        protected override void OnInitServices(IServiceContainer serviceContainer)
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

        protected override void OnInitServices(IServiceContainer serviceContainer)
        {
            base.OnInitServices(serviceContainer);
            serviceContainer.RegisterService(new FlyoutDetailFormDocumentManagerService(ModuleType.ModifierFérier));
        }
    }
}