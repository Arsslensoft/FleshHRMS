using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using PHRMS.Data;
using PHRMS.ViewModels;

namespace PHRMS.Modules
{
    public partial class ModifierFérier : BaseModuleControl
    {
        private DXErrorProvider errorProvider;

        public ModifierFérier()
            : base(CreateViewModel<HolidayViewModel>)
        {
            InitializeComponent();
            ViewModel.EntityChanged += ViewModel_EntityChanged;
            InitLookupEditors();
            BindCommands();
            BindEditors();
        }

        public HolidayViewModel ViewModel
        {
            get { return GetViewModel<HolidayViewModel>(); }
        }

        public static Employee HolidayOwner { get; set; }

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
                InitNew(HolidayOwner);
            }
        }

        private void ViewModel_EntityChanged(object sender, EventArgs e)
        {
            UpdateEditors(ViewModel.Entity);
        }

        private void InitNew(Employee employee)
        {
            ViewModel.Entity.StartDate = DateTime.Now;

            if (employee != null)
            {
                ViewModel.Entity.CreatedBy = ViewModel.FindEmployeeId(employee);
                ViewModel.Entity.CreatedById = employee.Id;
            }
        }

        private void BindEditors()
        {
            fullNameLabelControl.DataBindings.Add("Text", memoEdit2, "Text", true,
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
        }

        private void UpdateEditors(Holiday note)
        {
            if (note == null) return;
            noteBindingSource.DataSource = note;
        }
    }
}