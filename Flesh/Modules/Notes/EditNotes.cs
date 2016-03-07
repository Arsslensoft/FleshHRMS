using System;
using System.Linq;
using DevExpress.DevAV;
using DevExpress.DevAV.ViewModels;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.Mvvm;

namespace DevExpress.DevAV.Modules {
    public partial class EditNotes : BaseModuleControl {
        public EditNotes()
            : base(CreateViewModel<EvaluationViewModel>) {
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
        public EvaluationViewModel ViewModel {
            get { return GetViewModel<EvaluationViewModel>(); }
        }
        protected override void UpdateViewModel() {
            ViewModel.ValidationErrors = errorProvider.HasErrors;
            ViewModel.Update();
        }
        protected override void OnParentViewModelAttached() {
            base.OnParentViewModelAttached();
            if(ViewModel.IsNew()) {
                InitNew(NewNoteOwner);
            }
        }
        void ViewModel_EntityChanged(object sender, EventArgs e) {
            UpdateEditors(ViewModel.Entity);
        }
        void InitNew(Employee employee) {
            ViewModel.Entity.CreatedOn = DateTime.Now;
            if(employee != null) {
                ViewModel.Entity.CreatedBy = ViewModel.FindEmployeeId(employee);
                ViewModel.Entity.CreatedById = employee.Id;
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
            assignedToLookUpEdit.Properties.DataSource = ViewModel.GetEmployees().ToList();
        }
        void UpdateEditors(Evaluation note) {
            if(note == null) return;
            noteBindingSource.DataSource = note;
        }
        public static Employee NewNoteOwner { get; set; }
    }
    public class Notes : BaseModuleControl {
        public Notes()
            : base(CreateViewModel<EvaluationCollectionViewModel>) {
        }
        protected override void OnInitServices(Mvvm.IServiceContainer serviceContainer) {
            base.OnInitServices(serviceContainer);
            serviceContainer.RegisterService(new FlyoutDetailFormDocumentManagerService(ModuleType.EditNotes));
        }
    }
}
