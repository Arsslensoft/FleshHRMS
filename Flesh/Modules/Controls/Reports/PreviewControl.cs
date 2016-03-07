using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Preview;

namespace DevExpress.DevAV {
    public partial class ReportPreviewControl : XtraUserControl {
        public ReportPreviewControl() {
            InitializeComponent();
        }
        protected override void OnLoad(System.EventArgs e) {
            base.OnLoad(e);
            DocumentViewer.BackColor = DevExpress.LookAndFeel.LookAndFeelHelper.GetSystemColor(LookAndFeel, SystemColors.Control);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public object DocumentSource {
            get { return documentViewer.DocumentSource; }
            set {
                if (!ReferenceEquals(documentViewer.DocumentSource, value)) {
                    documentViewer.DocumentSource = value;
                }
            }
        }
        public DocumentViewer DocumentViewer { get { return documentViewer; } }
    }
}
