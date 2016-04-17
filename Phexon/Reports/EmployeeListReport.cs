using System.ComponentModel;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace PHRMS
{
    internal class EmployeeList : XtraReport
    {
        private BottomMarginBand bottomMarginBand1;
        private DetailBand detailBand1;
        private TopMarginBand topMarginBand1;
        private XRLabel xrLabel1;

        private void InitializeComponent()
        {
            topMarginBand1 = new TopMarginBand();
            detailBand1 = new DetailBand();
            bottomMarginBand1 = new BottomMarginBand();
            xrLabel1 = new XRLabel();
            ((ISupportInitialize) this).BeginInit();
            topMarginBand1.Name = "topMarginBand1";
            detailBand1.Controls.AddRange(new XRControl[]
            {
                xrLabel1
            });
            detailBand1.Name = "detailBand1";
            bottomMarginBand1.Name = "bottomMarginBand1";
            xrLabel1.LocationFloat = new PointFloat(36.45833F, 22.91667F);
            xrLabel1.Name = "xrLabel1";
            xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 96F);
            xrLabel1.SizeF = new SizeF(354.1667F, 56.25F);
            xrLabel1.Text = "xrLabel1";
            Bands.AddRange(new Band[]
            {
                topMarginBand1,
                detailBand1,
                bottomMarginBand1
            });
            Version = "14.1";
            ((ISupportInitialize) this).EndInit();
        }
    }
}