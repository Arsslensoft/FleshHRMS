﻿using System;
using System.Linq;
using FHRMS.Data;
using FHRMS.ViewModels;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.Mvvm;

namespace FHRMS.Modules {
    public partial class ModifierAbsence : BaseModuleControl {
        public ModifierAbsence()
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
                InitNew(AbsenceOwner,AbsenceCreator);
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
            imageComboBoxEdit1.Properties.Items.AddEnum<FHRMS.Data.AbsenceType>();
            assignedToLookUpEdit.Properties.DataSource = ViewModel.GetEmployees().ToList();
             lookUpEdit1.Properties.DataSource = ViewModel.GetEmployees().ToList();
        }
        void UpdateEditors(Absence note) {
            if(note == null) return;
            noteBindingSource.DataSource = note;
        }
        public static Employee AbsenceOwner { get; set; }
        public static Employee AbsenceCreator { get; set; }
    }
    public class Notes : BaseModuleControl {
        public Notes()
            : base(CreateViewModel<EvaluationCollectionViewModel>) {
        }
        protected override void OnInitServices( DevExpress.Mvvm.IServiceContainer serviceContainer) {
            base.OnInitServices(serviceContainer);
            serviceContainer.RegisterService(new FlyoutDetailFormDocumentManagerService(ModuleType.ModifierAbsence));
        }
    }
    public class Shifts : BaseModuleControl
    {
        public Shifts()
            : base(CreateViewModel<ScheduleCollectionViewModel>)
        {
        }
        protected override void OnInitServices(DevExpress.Mvvm.IServiceContainer serviceContainer)
        {
            base.OnInitServices(serviceContainer);
         serviceContainer.RegisterService(new FlyoutDetailFormDocumentManagerService(ModuleType.ModifierPlaning));
        }
    }

}
