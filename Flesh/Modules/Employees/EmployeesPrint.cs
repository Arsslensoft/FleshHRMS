namespace DevExpress.DevAV.Modules {
    using System;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.DevAV.Reports;
    using DevExpress.XtraPrinting;
    using DevExpress.XtraReports.UI;
    using System.Collections.Generic;
    using DevExpress.DevAV.Helpers;
    using DevExpress.XtraEditors;
    using DevExpress.DevAV;
    using DevExpress.LookAndFeel;
    using DevExpress.DevAV.ViewModel;

    public partial class EmployeesPrint : BaseModuleControl {
        private XtraReport report;
        public EmployeesPrint()
            : base(CreateViewModel<EmployeesReportViewModel>) {
            InitializeComponent();
            ViewModel.ReportTypeChanged += ViewModel_ReportTypeChanged;
            ViewModel.ReportEntityKeyChanged += ViewModel_ReportEntityKeyChanged;
            printSettingsControl.SelectedPrinterName = PageSettingsHelper.DefaultPageSettings.PrinterSettings.PrinterName;
            settingsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            settingsLayout.Parent = printSettingsControl.SettingsPanel;
        }
        protected override void OnDisposing() {
            ViewModel.ReportEntityKeyChanged -= ViewModel_ReportEntityKeyChanged;
            ViewModel.ReportTypeChanged -= ViewModel_ReportTypeChanged;
            previewControl.DocumentSource = null;
            report = null;
            ReleaseModuleReports<EmployeeReportType>();
            base.OnDisposing();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            ViewModel.OnLoad();
        }
        public EmployeesReportViewModel ViewModel {
            get {
                return GetViewModel<EmployeesReportViewModel>();
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
        private void ViewModel_ReportEntityKeyChanged(object sender, EventArgs e) {
            if (!(report is EmployeeProfile)) {
                return;
            }
            report.Parameters["parameterId"].Value = ViewModel.ReportEntityKey;
            CreateDocument(report);
        }
        private void ViewModel_ReportTypeChanged(object sender, System.EventArgs e) {
            UpdatePreview();
        }
        private void UpdatePreview() {
            report = CreateAndInitializeReport(ViewModel.ReportType);
            previewControl.DocumentSource = report;
            UpdateSettingsVisibility(report is EmployeeProfile);
        }
        private void UpdateSettingsVisibility(bool visible) {
            printSettingsControl.SettingsVisible = visible;
            printSettingsControl.PrintEnabled = false;
        }
        public override void Refresh() {
            base.Refresh();
            if (Parent != null) {
                UpdatePreview();
            }
        }
        protected internal override void OnTransitionCompleted() {
            base.OnTransitionCompleted();
            InitializeButtonPanel();
        }
        private void InitializeButtonPanel() {
            var listBI = new List<ButtonInfo>();
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Zoom In", Name = "1", Image = ImageHelper.GetImageFromToolbarResource("ZoomIn"), mouseEventHandler = zoomInClick });
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Zoom Out", Name = "2", Image = ImageHelper.GetImageFromToolbarResource("ZoomOut"), mouseEventHandler = zoomOutClick });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Print", Name = "3", Image = ImageHelper.GetImageFromToolbarResource("Print") });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Settings", Name = "4", Image = ImageHelper.GetImageFromToolbarResource("Settings"), mouseEventHandler = settingMouseClick });
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Close", Name = "5", Image = ImageHelper.GetImageFromToolbarResource("Cancel"), mouseEventHandler =  closeButtonClick });
            BottomPanel.InitializeButtons(listBI, false);
        }

        private void zoomOutClick(object sender, EventArgs e) {
            previewControl.DocumentViewer.Zoom -= 0.1f;
        }

        private void settingMouseClick(object sender, EventArgs e) {
            previewControl.Visible = false;
            printSettingsControl.Visible = !printSettingsControl.Visible;
            previewControl.Visible = true;
        }

        private void zoomInClick(object sender, EventArgs e) {
            previewControl.DocumentViewer.Zoom += 0.1f;
        }
        private void closeButtonClick(object sender, EventArgs e) {
            if(Parent as Employees != null) (Parent as Employees).CloseSubModule();
            if(Parent as EmployeeEdit != null) (Parent as EmployeeEdit).CloseSubModule();
        }
        private XtraReport CreateAndInitializeReport(EmployeeReportType reportType) {
            var locator = GetService<Services.IReportLocator>();
            var report = locator.GetReport(reportType) as XtraReport;
            if (reportType == EmployeeReportType.Profile) {
                report.Parameters["parameterId"].Value = ViewModel.ReportEntityKey;
                report.Parameters["ShowEvaluationsParameter"].Value = btnIncudeEvaluations.Checked;
            }
            if(CollectionViewModel != null)report.DataSource = CollectionViewModel.Entities;
            if(EmployeeViewModel != null) {
                List<Employee> list = new List<Employee>();
                list.Add(EmployeeViewModel.Entity);
                report.DataSource = list;
            }
            CreateDocument(report);
            return report;
        }
        private void CreateDocument(XtraReport report) {
            if (report != null) {
                report.PrintingSystem.AfterBuildPages -= PrintingSystem_AfterBuildPages;
                report.PrintingSystem.AfterBuildPages += PrintingSystem_AfterBuildPages;
            }
        }
        private void PrintingSystem_AfterBuildPages(object sender, EventArgs e) {
            printSettingsControl.PrintEnabled = ((PrintingSystemBase)sender).PageCount > 0;
        }
        private void buttonSettings_Click(object sender, EventArgs e) {
            report.Parameters["ShowEvaluationsParameter"].Value = object.ReferenceEquals(sender, btnIncudeEvaluations);
            if(report != null) report.CreateDocument(true);
            CreateDocument(report);
        }
        private void settingsControl_PrintClick(object sender, EventArgs e) {
            using (var tool = new ReportPrintTool(report)) {
                tool.Print(printSettingsControl.SelectedPrinterName);
            }
        }
        private void settingsControl_PrintOptionsClick(object sender, EventArgs e) {
            using (var tool = new ReportPrintTool(report)) {
                System.Windows.Forms.Form form = FindForm();
                tool.PrintDialog(FindForm(), LookAndFeel);
            }
        }
    }
}
