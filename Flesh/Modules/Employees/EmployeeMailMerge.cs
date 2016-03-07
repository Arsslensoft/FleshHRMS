namespace DevExpress.DevAV.Modules {
    using System;
    using DevExpress.DevAV;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.XtraLayout.Utils;
    using DevExpress.DevAV.Helpers;
    using System.Collections.Generic;
    using DevExpress.XtraEditors;
    using DevExpress.DevAV.Common.Utils;

    public partial class EmployeeMailMerge : BaseModuleControl {
        public EmployeeMailMerge()
            : base(CreateViewModel<EmployeeMailMergeViewModel>) {
            InitializeComponent();
            BindEditors();
            UpdateSelectTemplateUI();
            ViewModel.MailTemplateChanged += ViewModel_MailTemplateChanged;
            ViewModel.MailTemplateSelectedChanged += ViewModel_MailTemplateSelectedChanged;
        }
        protected override void OnDisposing() {
            ViewModel.MailTemplateChanged -= ViewModel_MailTemplateChanged;
            ViewModel.MailTemplateSelectedChanged -= ViewModel_MailTemplateSelectedChanged;
            base.OnDisposing();
        }
        void ViewModel_MailTemplateSelectedChanged(object sender, EventArgs e) {
            UpdateSelectTemplateUI();
        }
        void ViewModel_MailTemplateChanged(object sender, EventArgs e) {
            UpdateEditor(ViewModel.MailTemplate.GetValueOrDefault());
        }
        void UpdateEditor(EmployeeMailTemplate mailTemplate) {
            cbMailTemplate.EditValue = mailTemplate;
            LoadTemplate(mailTemplate);
            SynchronyzeCurrentRecordWithSnap();
        }
        public override void Refresh() {
            base.Refresh();
            if(Parent != null) {
                InitializeButtonPanel();
            }
        }
        void LoadTemplate(EmployeeMailTemplate mailTemplate) {
            var template = (mailTemplate.ToFileName() + ".snx");
            using(var stream = MailMergeTemplatesHelper.GetTemplateStream(template)) {
                snapControl.LoadDocumentTemplate(stream, DevExpress.Snap.Core.API.SnapDocumentFormat.Snap);
            }
        }
        void UpdateSelectTemplateUI() {
            lcgMailMergeSetting.Visibility = (ViewModel.IsMailTemplateSelected) ?
                LayoutVisibility.Never : LayoutVisibility.Always;
        }
        public EmployeeMailMergeViewModel ViewModel {
            get {
                return GetViewModel<EmployeeMailMergeViewModel>();
            }
        }
        public EmployeeCollectionViewModel CollectionViewModel {
            get {
                return GetParentViewModel<EmployeeCollectionViewModel>();
            }
        }
        public EmployeeViewModel EmployeeViewModel {
            get {
                return GetParentViewModel<EmployeeViewModel>();
            }
        }
        protected override void OnLoad(EventArgs ea) {
            base.OnLoad(ea);
            if(CollectionViewModel != null) {
                bindingSource.DataSource = CollectionViewModel.SelectedEntity;
                employeesList.SetItemsSource(CollectionViewModel.Entities);
                gridView.FocusedRowHandle = gridView.LocateByValue("Id", CollectionViewModel.SelectedEntity.Id);
                if(snapControl.Document.IsEmpty) {
                    LoadTemplate(ViewModel.MailTemplate.GetValueOrDefault());
                }
                snapControl.SetItemsSource(CollectionViewModel.Entities);
            }

            if(EmployeeViewModel != null) {
                List<Employee> employeeList = new List<Employee>();
                employeeList.Add(EmployeeViewModel.Entity);
                bindingSource.DataSource = EmployeeViewModel.Entity;
                employeesList.DataSource = employeeList;
                gridView.FocusedRowHandle = gridView.LocateByValue("Id", EmployeeViewModel.Entity.Id);
                if(snapControl.Document.IsEmpty) {
                    LoadTemplate(ViewModel.MailTemplate.GetValueOrDefault());
                }
                snapControl.DataSource = employeeList;
            }
            SynchronyzeCurrentRecordWithSnap();
        }
        protected internal override void OnTransitionCompleted() {
            base.OnTransitionCompleted();
            InitializeButtonPanel();
        }
        void InitializeButtonPanel() {
            var listBI = new List<ButtonInfo>();
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Zoom In", Name = "1", Image = ImageHelper.GetImageFromToolbarResource("ZoomIn"), mouseEventHandler = ZoomInClick });
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Zoom Out", Name = "2", Image = ImageHelper.GetImageFromToolbarResource("ZoomOut"), mouseEventHandler = ZoomOutClick });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Print", Name = "3", Image = ImageHelper.GetImageFromToolbarResource("Print"), mouseEventHandler = PrintMouseClick });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Close", Name = "5", Image = ImageHelper.GetImageFromToolbarResource("Cancel"), mouseEventHandler = CloseButtonClick });
            BottomPanel.InitializeButtons(listBI, false);
        }

        void ZoomInClick(object sender, EventArgs e) {
            snapControl.ActiveView.ZoomFactor += 0.1f;
        }

        void ZoomOutClick(object sender, EventArgs e) {
            snapControl.ActiveView.ZoomFactor -= 0.1f;
        }

        void PrintMouseClick(object sender, EventArgs e) {
            snapControl.Print();
        }

        void CloseButtonClick(object sender, EventArgs e) {
            if(Parent as Employees != null) (Parent as Employees).CloseSubModule();
            if(Parent as EmployeeEdit != null) (Parent as EmployeeEdit).CloseSubModule();
        }
        void BindEditors() {
            gridView.FocusedRowObjectChanged += gridView_FocusedRowObjectChanged;

            cbMailTemplate.Properties.Items.AddEnum<EmployeeMailTemplate>();
            cbMailTemplate.EditValue = ViewModel.MailTemplate.GetValueOrDefault();
            cbMailTemplate.EditValueChanged += cbMailTemplate_EditValueChanged;
        }
        void gridView_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e) {
            bindingSource.DataSource = e.Row as Employee;
            SynchronyzeCurrentRecordWithSnap();
        }
        void SynchronyzeCurrentRecordWithSnap() {
            snapControl.Options.SnapMailMergeVisualOptions.CurrentRecordIndex = gridView.GetDataSourceRowIndex(gridView.FocusedRowHandle);
        }
        void cbMailTemplate_EditValueChanged(object sender, EventArgs e) {
            ViewModel.MailTemplate = (EmployeeMailTemplate)cbMailTemplate.EditValue;
        }

        void searchControl_QueryIsSearchColumn(object sender, QueryIsSearchColumnEventArgs args) {
            var column = sender as DevExpress.XtraEditors.Filtering.FilterColumn;
            if(column == null) {
                return;
            }
            if(column.FieldName != string.Empty) {
                args.IsSearchColumn = true;
            } else {
                args.IsSearchColumn = false;
            }
        }
    }
}
