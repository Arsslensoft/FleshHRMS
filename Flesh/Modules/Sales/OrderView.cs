using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.DevAV.ViewModels;
using DevExpress.DevAV.Helpers;

namespace DevExpress.DevAV.Modules {
    public partial class OrderView : BaseModuleControl, ISupportNavigation {
        public OrderView()
            : base(CreateViewModel<OrderViewModel>) {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData() {
            var binding = new Binding("Text", order, "InvoiceNumber", true);
            binding.Format += (s, e) => {
                e.Value = "#" + Convert.ToString(e.Value);
            };
            lbInvoice.DataBindings.Add(binding);
        }
        protected internal override void OnTransitionCompleted() {
            base.OnTransitionCompleted();
            InitializeButtonPanel();
        }
        private void InitializeButtonPanel() {
            var listBI = new List<ButtonInfo>();
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Close", Name = "3", Image = ImageHelper.GetImageFromToolbarResource("Cancel"), mouseEventHandler = (e, s) => {
                Cancel();
            } });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Zoom In", Name = "1", Image = ImageHelper.GetImageFromToolbarResource("ZoomIn"), mouseEventHandler = zoomInClick });
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Zoom Out", Name = "2", Image = ImageHelper.GetImageFromToolbarResource("ZoomOut"), mouseEventHandler = zoomOutClick });

            BottomPanel.InitializeButtons(listBI, false);
        }
        private void zoomOutClick(object sender, EventArgs e) {
            snapControl.ActiveView.ZoomFactor -= 0.10f;
        }
        private void zoomInClick(object sender, EventArgs e) {
            snapControl.ActiveView.ZoomFactor += 0.10f;
        }

        private void lciBackPicture_Click(object sender, EventArgs e) {
            if(CheckSave()) Return();
        }
        protected override void Return() {
            GetParentViewModel<MainViewModel>().SelectModule(ModuleType.Sales);
        }
        public OrderViewModel ViewModel {
            get {
                return GetViewModel<OrderViewModel>();
            }
        }
        public override void Refresh() {
            if (ViewModel.Entity != null) {
                order.DataSource = ViewModel.Entity;

                if (snapControl.Document.IsEmpty) {
                    LoadTemplate();
                }
                snapControl.DataSource = order;
                snapControl.Document.Fields.Update();
            }
            base.Refresh();
        }
        private void LoadTemplate() {
            var template = "Order.snx";
            using (var stream = DevExpress.DevAV.ViewModels.MailMergeTemplatesHelper.GetTemplateStream(template)) {
                if (stream != null) {
                    snapControl.LoadDocumentTemplate(stream, DevExpress.Snap.Core.API.SnapDocumentFormat.Snap);
                }
            }
        }

        public virtual void OnNavigatedFrom(INavigationArgs args) {
        }
        public virtual void OnNavigatedTo(INavigationArgs args) {
        }
    }
}
