using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using PHRMS.Data;
using PHRMS.Helpers;
using PHRMS.Services;
using PHRMS.ViewModels;

namespace PHRMS.Modules
{
    public partial class ImprimerEmployé : BaseModuleControl
    {
        private XtraReport report;

        public ImprimerEmployé()
            : base(CreateViewModel<EmployeesReportViewModel>)
        {
            InitializeComponent();
            ViewModel.ReportTypeChanged += ViewModel_ReportTypeChanged;
            ViewModel.ReportEntityKeyChanged += ViewModel_ReportEntityKeyChanged;
            printSettingsControl.SelectedPrinterName =
                PageSettingsHelper.DefaultPageSettings.PrinterSettings.PrinterName;
            settingsLayout.Dock = DockStyle.Fill;
            settingsLayout.Parent = printSettingsControl.SettingsPanel;
        }

        public EmployeesReportViewModel ViewModel
        {
            get { return GetViewModel<EmployeesReportViewModel>(); }
        }

        public EmployeeCollectionViewModel CollectionViewModel
        {
            get { return GetParentViewModel<EmployeeCollectionViewModel>(); }
        }

        public EmployeeViewModel EmployeeViewModel
        {
            get { return GetParentViewModel<EmployeeViewModel>(); }
        }

        protected override void OnDisposing()
        {
            ViewModel.ReportEntityKeyChanged -= ViewModel_ReportEntityKeyChanged;
            ViewModel.ReportTypeChanged -= ViewModel_ReportTypeChanged;
            previewControl.DocumentSource = null;
            report = null;
            ReleaseModuleReports<EmployeeReportType>();
            base.OnDisposing();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ViewModel.OnLoad();
        }

        private void ViewModel_ReportEntityKeyChanged(object sender, EventArgs e)
        {
            if (!(report is EmployeeProfile))
            {
                return;
            }
            report.Parameters["parameterId"].Value = ViewModel.ReportEntityKey;
            CreateDocument(report);
        }

        private void ViewModel_ReportTypeChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void UpdatePreview()
        {
            report = CreateAndInitializeReport(ViewModel.ReportType);
            previewControl.DocumentSource = report;
            UpdateSettingsVisibility(report is EmployeeProfile);
        }

        private void UpdateSettingsVisibility(bool visible)
        {
            printSettingsControl.SettingsVisible = visible;
            printSettingsControl.PrintEnabled = false;
        }

        public override void Refresh()
        {
            base.Refresh();
            if (Parent != null)
            {
                UpdatePreview();
            }
        }

        protected internal override void OnTransitionCompleted()
        {
            base.OnTransitionCompleted();
            InitializeButtonPanel();
        }

        private void InitializeButtonPanel()
        {
            var listBI = new List<ButtonInfo>();
            listBI.Add(new ButtonInfo
            {
                Type = typeof(SimpleButton),
                Text = "Zoomer",
                Name = "1",
                Image = ImageHelper.GetImageFromToolbarResource("ZoomIn"),
                mouseEventHandler = zoomInClick
            });
            listBI.Add(new ButtonInfo
            {
                Type = typeof(SimpleButton),
                Text = "Dézoomer",
                Name = "2",
                Image = ImageHelper.GetImageFromToolbarResource("ZoomOut"),
                mouseEventHandler = zoomOutClick
            });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo
            {
                Type = typeof(SimpleButton),
                Text = "Imprimer",
                Name = "3",
                Image = ImageHelper.GetImageFromToolbarResource("Print")
            });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo
            {
                Type = typeof(SimpleButton),
                Text = "Options",
                Name = "4",
                Image = ImageHelper.GetImageFromToolbarResource("Settings"),
                mouseEventHandler = settingMouseClick
            });
            listBI.Add(new ButtonInfo
            {
                Type = typeof(SimpleButton),
                Text = "Fermer",
                Name = "5",
                Image = ImageHelper.GetImageFromToolbarResource("Cancel"),
                mouseEventHandler = closeButtonClick
            });
            BottomPanel.InitializeButtons(listBI, false);
        }

        private void zoomOutClick(object sender, EventArgs e)
        {
            previewControl.DocumentViewer.Zoom -= 0.1f;
        }

        private void settingMouseClick(object sender, EventArgs e)
        {
            previewControl.Visible = false;
            printSettingsControl.Visible = !printSettingsControl.Visible;
            previewControl.Visible = true;
        }

        private void zoomInClick(object sender, EventArgs e)
        {
            previewControl.DocumentViewer.Zoom += 0.1f;
        }

        private void closeButtonClick(object sender, EventArgs e)
        {
            if (Parent as Employés != null) (Parent as Employés).CloseSubModule();
            if (Parent as ModifierEmployé != null) (Parent as ModifierEmployé).CloseSubModule();
        }

        private XtraReport CreateAndInitializeReport(EmployeeReportType reportType)
        {
            var locator = GetService<IReportLocator>();
            var report = locator.GetReport(reportType) as XtraReport;
            if (reportType == EmployeeReportType.Profile)
            {
                report.Parameters["parameterId"].Value = ViewModel.ReportEntityKey;
                report.Parameters["ShowEvaluationsParameter"].Value = btnIncudeEvaluations.Checked;
            }
            if (CollectionViewModel != null) report.DataSource = CollectionViewModel.Entities;
            if (EmployeeViewModel != null)
            {
                var list = new List<Employee>();
                list.Add(EmployeeViewModel.Entity);
                report.DataSource = list;
            }
            CreateDocument(report);
            return report;
        }

        private void CreateDocument(XtraReport report)
        {
            if (report != null)
            {
                report.PrintingSystem.AfterBuildPages -= PrintingSystem_AfterBuildPages;
                report.PrintingSystem.AfterBuildPages += PrintingSystem_AfterBuildPages;
            }
        }

        private void PrintingSystem_AfterBuildPages(object sender, EventArgs e)
        {
            printSettingsControl.PrintEnabled = ((PrintingSystemBase) sender).PageCount > 0;
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            report.Parameters["ShowEvaluationsParameter"].Value = ReferenceEquals(sender, btnIncudeEvaluations);
            if (report != null) report.CreateDocument(true);
            CreateDocument(report);
        }

        private void settingsControl_PrintClick(object sender, EventArgs e)
        {
            using (var tool = new ReportPrintTool(report))
            {
                tool.Print(printSettingsControl.SelectedPrinterName);
            }
        }

        private void settingsControl_PrintOptionsClick(object sender, EventArgs e)
        {
            using (var tool = new ReportPrintTool(report))
            {
                var form = FindForm();
                tool.PrintDialog(FindForm(), LookAndFeel);
            }
        }
    }
}