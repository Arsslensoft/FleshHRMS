using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using DevExpress.Printing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Preview;
using DevExpress.XtraLayout.Utils;

namespace PHRMS
{
    public partial class ReportPrintSettingsControl : XtraUserControl
    {
        private PrinterImagesContainer imagesContainer;
        private PrinterItemContainer printerItemContainer;

        public ReportPrintSettingsControl()
        {
            InitializeComponent();
            imagesContainer = new PrinterImagesContainer();
            printerItemContainer = new PrinterItemContainer();
        }

        public bool PrintEnabled
        {
            set { btnOptions.Enabled = btnPrint.Enabled = value; }
        }

        public bool SettingsVisible
        {
            set { layoutControlItemSettings.Visibility = value ? LayoutVisibility.Always : LayoutVisibility.Never; }
        }

        public SettingPanel SettingsPanel { get; private set; }

        public string SelectedPrinterName
        {
            get
            {
                var item = cbPrinters.EditValue as PrinterItem;
                return item != null ? item.FullName : string.Empty;
            }
            set { cbPrinters.EditValue = FindPrinterItem(value); }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cbPrinters.Properties.LargeImages = imagesContainer.LargeImages;
            cbPrinters.Properties.SmallImages = imagesContainer.SmallImages;
            foreach (var item in printerItemContainer.Items)
            {
                cbPrinters.Properties.Items.Add(new ImageComboBoxItem(item.DisplayName, item,
                    imagesContainer.GetImageIndex(item)));
            }
        }

        private PrinterItem FindPrinterItem(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            foreach (var printer in printerItemContainer.Items)
            {
                if (printer.FullName == value) return printer;
            }
            return null;
        }

        private void RaisePrintOptionsClick()
        {
            if (PrintOptionsClick != null) PrintOptionsClick(this, EventArgs.Empty);
        }

        private void RaisePrintClick()
        {
            if (PrintClick != null) PrintClick(this, EventArgs.Empty);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            RaisePrintClick();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            RaisePrintOptionsClick();
        }

        public event EventHandler PrintClick;
        public event EventHandler PrintOptionsClick;
    }

    [ToolboxItem(false),
     Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public class SettingPanel : XtraUserControl
    {
    }
}