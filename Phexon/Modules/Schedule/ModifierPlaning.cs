﻿using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using PHRMS.Data;
using PHRMS.ViewModels;

namespace PHRMS.Modules
{
    public partial class ModifierPlaning : BaseModuleControl
    {
        private DXErrorProvider errorProvider;

        public ModifierPlaning()
            : base(CreateViewModel<ShiftsViewModel>)
        {
            InitializeComponent();
            ViewModel.EntityChanged += ViewModel_EntityChanged;
            InitLookupEditors();
            BindCommands();
            BindEditors();
        }

        public ShiftsViewModel ViewModel
        {
            get { return GetViewModel<ShiftsViewModel>(); }
        }

        public static Employee AbsenceOwner { get; set; }

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
                InitNew(AbsenceOwner);
            }
        }

        private void ViewModel_EntityChanged(object sender, EventArgs e)
        {
            UpdateEditors(ViewModel.Entity);
        }

        private void InitNew(Employee employee)
        {
            ViewModel.Entity.Start = DateTime.Now;

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
            imageComboBoxEdit1.Properties.Items.AddEnum<ShiftType>();
            imageComboBoxEdit2.Properties.Items.AddEnum<ReccuranceType>();
            assignedToLookUpEdit.Properties.DataSource = ViewModel.GetEmployees().ToList();
            imageComboBoxEdit3.Properties.Items.AddEnum<StatusType>();
            imageComboBoxEdit4.Properties.Items.AddEnum<LabelType>();
        }

        private void UpdateEditors(Shift note)
        {
            if (note == null) return;
            noteBindingSource.DataSource = note;
        }
    }
}