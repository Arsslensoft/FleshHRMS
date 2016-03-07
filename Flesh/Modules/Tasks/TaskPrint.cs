using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.DevAV.ViewModels;
using DevExpress.DevAV.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.DevAV.Common.ViewModel;

namespace DevExpress.DevAV.Modules {
    public partial class TaskPrint : BaseModuleControl {
        public TaskPrint()
            : base(CreateViewModel<TaskPrintView>) {
            InitializeComponent();
            ViewModel.ParameterChanged += ViewModel_ParameterChanged;
        }

        private void ViewModel_ParameterChanged(object sender, EventArgs e) {
            printableComponentLink.Component = ViewModel.GetParameter() as GridControl;
            printableComponentLink.CreateDocument();
        }
        protected override void Return() {
            GetParentViewModel<MainViewModel>().SelectModule(ModuleType.Tasks);
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
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Print", Name = "4", Image = ImageHelper.GetImageFromToolbarResource("Print"), mouseEventHandler = (e, s) => {
                DoPrint();
            } });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo() {
                Type = typeof(SimpleButton),
                Text = "Close",
                Name = "3",
                Image = ImageHelper.GetImageFromToolbarResource("Cancel"),
                mouseEventHandler = (e, s) => {
                    Cancel();
                }
            });

            BottomPanel.InitializeButtons(listBI, false);
        }
        public TaskPrintView ViewModel {
            get {
                return GetViewModel<TaskPrintView>();
            }
        }
        private void DoPrint() {
            documentViewer.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.PrintDirect);
        }
        private void zoomOutClick(object sender, EventArgs e) {
            documentViewer.Zoom -= 0.10f;
        }
        private void zoomInClick(object sender, EventArgs e) {
            documentViewer.Zoom += 0.10f;
        }
    }


    public class TaskPrintView : EmployeeTaskCollectionViewModel {
        internal object GetParameter() {
            return Parameter;
        }
        public override DevAV.EmployeeTask SelectedEntity {
            get {return null;}
        }
    }
}
