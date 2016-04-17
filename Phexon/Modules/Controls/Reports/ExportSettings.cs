using System;
using System.Windows.Forms;
using DevExpress.Utils.Menu;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPrinting;

namespace PHRMS.Preview
{
    public partial class ReportExportSettingsControl : UserControl
    {
        private readonly DXPopupMenu menuExport;

        public ReportExportSettingsControl()
        {
            InitializeComponent();
            SelectedExport = ExportTarget.Pdf;
            menuExport = new DXPopupMenu();
            AddExportTarget(ExportTarget.Pdf);
            AddExportTarget(ExportTarget.Html);
            AddExportTarget(ExportTarget.Mht);
            AddExportTarget(ExportTarget.Rtf);
            AddExportTarget(ExportTarget.Xls);
            AddExportTarget(ExportTarget.Xlsx);
            AddExportTarget(ExportTarget.Csv);
            AddExportTarget(ExportTarget.Text);
            AddExportTarget(ExportTarget.Image);
            btnExport.DropDownControl = menuExport;
            menuExport.BeforePopup += menuExport_BeforePopup;
        }

        public bool SettingsVisible
        {
            set
            {
                layoutControlItemSettings.Visibility = value
                    ? LayoutVisibility.Always
                    : LayoutVisibility.Never;
            }
        }

        public SettingPanel SettingsPanel { get; private set; }

        public bool ExportEnabled
        {
            set { btnExport.Enabled = value; }
        }

        public ExportTarget SelectedExport { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            throw new NotImplementedException();
        }

        private void menuExport_BeforePopup(object sender, EventArgs e)
        {
            foreach (DXMenuCheckItem item in menuExport.Items)
            {
                item.Checked = Equals(item.Tag, SelectedExport);
            }
        }

        private void AddExportTarget(ExportTarget target)
        {
            var exportItem = new DXMenuCheckItem
            {
                Caption = target.ToString(),
                Tag = target
            };
            menuExport.Items.Add(exportItem);
            exportItem.Click += exportItem_Click;
        }

        private void exportItem_Click(object sender, EventArgs e)
        {
            SelectedExport = (ExportTarget) ((DXMenuItem) sender).Tag;
        }

        public event EventHandler ExportClick;

        private void RaiseExportClick()
        {
            if (ExportClick != null)
            {
                ExportClick(this, EventArgs.Empty);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            RaiseExportClick();
        }
    }
}