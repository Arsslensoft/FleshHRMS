using System;
using System.Linq;
using PHRMS.Data;
using PHRMS.ViewModels;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.Mvvm;

namespace PHRMS.Modules {
    public partial class ModifierFérier : BaseModuleControl {
        public ModifierFérier()
            : base(CreateViewModel<HolidayViewModel>) {
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
        public HolidayViewModel ViewModel
        {
            get { return GetViewModel<HolidayViewModel>(); }
        }
        protected override void UpdateViewModel() {
            ViewModel.ValidationErrors = errorProvider.HasErrors;
            ViewModel.Update();
        }
        protected override void OnParentViewModelAttached() {
            base.OnParentViewModelAttached();
            if(ViewModel.IsNew()) {
                InitNew(HolidayOwner);
            }
        }
        void ViewModel_EntityChanged(object sender, EventArgs e) {
            UpdateEditors(ViewModel.Entity);
        }
        void InitNew(Employee employee)
        {
            ViewModel.Entity.StartDate = DateTime.Now;
        
            if (employee != null)
            {
                ViewModel.Entity.CreatedBy = ViewModel.FindEmployeeId(employee);
                ViewModel.Entity.CreatedById = employee.Id;
            }
        }
        DXErrorProvider errorProvider;
        void BindEditors() {
            fullNameLabelControl.DataBindings.Add("Text", memoEdit2, "Text", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
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
  
        }
        void UpdateEditors(Holiday note) {
            if(note == null) return;
            noteBindingSource.DataSource = note;
        }
        public static Employee HolidayOwner { get; set; }
      
    }
  
}
