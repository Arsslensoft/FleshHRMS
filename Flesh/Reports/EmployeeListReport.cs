using System;
using System.Collections.Generic;
using System.Linq;

namespace DevExpress.DevAV.Reports {
    internal class EmployeeList : DevExpress.XtraReports.UI.XtraReport {
        private XtraReports.UI.TopMarginBand topMarginBand1;
        private XtraReports.UI.DetailBand detailBand1;
        private XtraReports.UI.XRLabel xrLabel1;
        private XtraReports.UI.BottomMarginBand bottomMarginBand1;
        public EmployeeList() {
        }

        private void InitializeComponent() {
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.detailBand1 = new DevExpress.XtraReports.UI.DetailBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.topMarginBand1.Name = "topMarginBand1";
            this.detailBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1 });
            this.detailBand1.Name = "detailBand1";
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(36.45833F, 22.91667F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(354.1667F, 56.25F);
            this.xrLabel1.Text = "xrLabel1";
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.topMarginBand1,
            this.detailBand1,
            this.bottomMarginBand1 });
            this.Version = "14.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
