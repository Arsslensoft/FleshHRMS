using System;
using System.ComponentModel;
using System.Drawing;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Preview;

namespace PHRMS
{
    public partial class ReportPreviewControl : XtraUserControl
    {
        public ReportPreviewControl()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public object DocumentSource
        {
            get { return DocumentViewer.DocumentSource; }
            set
            {
                if (!ReferenceEquals(DocumentViewer.DocumentSource, value))
                {
                    DocumentViewer.DocumentSource = value;
                }
            }
        }

        public DocumentViewer DocumentViewer { get; private set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DocumentViewer.BackColor = LookAndFeelHelper.GetSystemColor(LookAndFeel, SystemColors.Control);
        }
    }
}