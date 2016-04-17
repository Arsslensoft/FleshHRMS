using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using PHRMS.Data;

namespace PHRMS
{
    internal class EmployeeSummary : XtraReport
    {
        private BindingSource bindingSource1;
        private BottomMarginBand bottomMarginBand1;
        private IContainer components;
        private DetailBand detailBand1;
        private ReportHeaderBand ReportHeader;
        private TopMarginBand topMarginBand1;
        private XRLine xrLine1;
        private XRPageInfo xrPageInfo1;
        private XRPageInfo xrPageInfo2;
        private XRPictureBox xrPictureBox1;
        private XRPictureBox xrPictureBox2;
        private XRTable xrTable1;
        private XRTable xrTable2;
        private XRTableCell xrTableCell1;
        private XRTableCell xrTableCell10;
        private XRTableCell xrTableCell11;
        private XRTableCell xrTableCell12;
        private XRTableCell xrTableCell13;
        private XRTableCell xrTableCell14;
        private XRTableCell xrTableCell15;
        private XRTableCell xrTableCell16;
        private XRTableCell xrTableCell17;
        private XRTableCell xrTableCell2;
        private XRTableCell xrTableCell3;
        private XRTableCell xrTableCell4;
        private XRTableCell xrTableCell5;
        private XRTableCell xrTableCell6;
        private XRTableCell xrTableCell7;
        private XRTableCell xrTableCell8;
        private XRTableCell xrTableCell9;
        private XRTableRow xrTableRow1;
        private XRTableRow xrTableRow10;
        private XRTableRow xrTableRow2;
        private XRTableRow xrTableRow3;
        private XRTableRow xrTableRow4;
        private XRTableRow xrTableRow5;
        private XRTableRow xrTableRow6;
        private XRTableRow xrTableRow7;
        private XRTableRow xrTableRow8;
        private XRTableRow xrTableRow9;

        public EmployeeSummary()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            components = new Container();
            var resources = new ComponentResourceManager(typeof(EmployeeSummary));
            topMarginBand1 = new TopMarginBand();
            xrPictureBox2 = new XRPictureBox();
            detailBand1 = new DetailBand();
            xrTable1 = new XRTable();
            xrTableRow1 = new XRTableRow();
            xrTableCell1 = new XRTableCell();
            xrTableRow2 = new XRTableRow();
            xrTableCell2 = new XRTableCell();
            xrTableRow4 = new XRTableRow();
            xrTableCell5 = new XRTableCell();
            xrLine1 = new XRLine();
            xrTableRow3 = new XRTableRow();
            xrTableCell4 = new XRTableCell();
            xrTableCell3 = new XRTableCell();
            xrTableRow5 = new XRTableRow();
            xrTableCell6 = new XRTableCell();
            xrTableCell7 = new XRTableCell();
            xrTableRow6 = new XRTableRow();
            xrTableCell8 = new XRTableCell();
            xrTableCell9 = new XRTableCell();
            xrTableRow7 = new XRTableRow();
            xrTableCell10 = new XRTableCell();
            xrTableRow8 = new XRTableRow();
            xrTableCell12 = new XRTableCell();
            xrTableCell11 = new XRTableCell();
            xrTableRow9 = new XRTableRow();
            xrTableCell13 = new XRTableCell();
            xrTableCell14 = new XRTableCell();
            xrPictureBox1 = new XRPictureBox();
            bottomMarginBand1 = new BottomMarginBand();
            xrPageInfo2 = new XRPageInfo();
            xrPageInfo1 = new XRPageInfo();
            ReportHeader = new ReportHeaderBand();
            xrTable2 = new XRTable();
            xrTableRow10 = new XRTableRow();
            xrTableCell15 = new XRTableCell();
            xrTableCell16 = new XRTableCell();
            xrTableCell17 = new XRTableCell();
            bindingSource1 = new BindingSource(components);
            ((ISupportInitialize) xrTable1).BeginInit();
            ((ISupportInitialize) xrTable2).BeginInit();
            ((ISupportInitialize) bindingSource1).BeginInit();
            ((ISupportInitialize) this).BeginInit();
            // 
            // topMarginBand1
            // 
            topMarginBand1.Controls.AddRange(new XRControl[]
            {
                xrPictureBox2
            });
            topMarginBand1.HeightF = 125F;
            topMarginBand1.Name = "topMarginBand1";
            // 
            // xrPictureBox2
            // 
            xrPictureBox2.Image = (Image) resources.GetObject("xrPictureBox2.Image");
            xrPictureBox2.LocationFloat = new PointFloat(382.6075F, 10.00001F);
            xrPictureBox2.Name = "xrPictureBox2";
            xrPictureBox2.SizeF = new SizeF(337.5175F, 115F);
            xrPictureBox2.Sizing = ImageSizeMode.StretchImage;
            // 
            // detailBand1
            // 
            detailBand1.Controls.AddRange(new XRControl[]
            {
                xrTable1,
                xrPictureBox1
            });
            detailBand1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            detailBand1.HeightF = 256F;
            detailBand1.Name = "detailBand1";
            detailBand1.StylePriority.UseFont = false;
            detailBand1.StylePriority.UseForeColor = false;
            // 
            // xrTable1
            // 
            xrTable1.LocationFloat = new PointFloat(179.8967F, 17.82827F);
            xrTable1.Name = "xrTable1";
            xrTable1.Rows.AddRange(new[]
            {
                xrTableRow1,
                xrTableRow2,
                xrTableRow4,
                xrTableRow3,
                xrTableRow5,
                xrTableRow6,
                xrTableRow7,
                xrTableRow8,
                xrTableRow9
            });
            xrTable1.SizeF = new SizeF(461.77F, 217.2385F);
            // 
            // xrTableRow1
            // 
            xrTableRow1.Cells.AddRange(new[]
            {
                xrTableCell1
            });
            xrTableRow1.Name = "xrTableRow1";
            xrTableRow1.Weight = 0.63958756585072929D;
            // 
            // xrTableCell1
            // 
            xrTableCell1.CanGrow = false;
            xrTableCell1.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "FullName")
            });
            xrTableCell1.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableCell1.ForeColor = Color.LawnGreen;
            xrTableCell1.Name = "xrTableCell1";
            xrTableCell1.StylePriority.UseFont = false;
            xrTableCell1.StylePriority.UseForeColor = false;
            xrTableCell1.StylePriority.UsePadding = false;
            xrTableCell1.StylePriority.UseTextAlignment = false;
            xrTableCell1.TextAlignment = TextAlignment.BottomLeft;
            xrTableCell1.Weight = 3D;
            // 
            // xrTableRow2
            // 
            xrTableRow2.Cells.AddRange(new[]
            {
                xrTableCell2
            });
            xrTableRow2.Name = "xrTableRow2";
            xrTableRow2.Weight = 0.4068930757754366D;
            // 
            // xrTableCell2
            // 
            xrTableCell2.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "Title")
            });
            xrTableCell2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableCell2.ForeColor = Color.FromArgb(127, 127, 127);
            xrTableCell2.Name = "xrTableCell2";
            xrTableCell2.StylePriority.UseFont = false;
            xrTableCell2.StylePriority.UseForeColor = false;
            xrTableCell2.StylePriority.UsePadding = false;
            xrTableCell2.StylePriority.UseTextAlignment = false;
            xrTableCell2.TextAlignment = TextAlignment.TopLeft;
            xrTableCell2.Weight = 3D;
            // 
            // xrTableRow4
            // 
            xrTableRow4.Cells.AddRange(new[]
            {
                xrTableCell5
            });
            xrTableRow4.Name = "xrTableRow4";
            xrTableRow4.Weight = 0.47679215639238742D;
            // 
            // xrTableCell5
            // 
            xrTableCell5.Controls.AddRange(new XRControl[]
            {
                xrLine1
            });
            xrTableCell5.Name = "xrTableCell5";
            xrTableCell5.Weight = 3D;
            // 
            // xrLine1
            // 
            xrLine1.ForeColor = Color.FromArgb(218, 218, 218);
            xrLine1.LocationFloat = new PointFloat(0F, 3.973643E-05F);
            xrLine1.Name = "xrLine1";
            xrLine1.SizeF = new SizeF(461.77F, 32.59834F);
            xrLine1.StylePriority.UseForeColor = false;
            // 
            // xrTableRow3
            // 
            xrTableRow3.Cells.AddRange(new[]
            {
                xrTableCell4,
                xrTableCell3
            });
            xrTableRow3.ForeColor = Color.FromArgb(166, 166, 166);
            xrTableRow3.Name = "xrTableRow3";
            xrTableRow3.StylePriority.UseForeColor = false;
            xrTableRow3.Weight = 0.27799953466570859D;
            // 
            // xrTableCell4
            // 
            xrTableCell4.CanGrow = false;
            xrTableCell4.Name = "xrTableCell4";
            xrTableCell4.StylePriority.UseBorderColor = false;
            xrTableCell4.StylePriority.UseForeColor = false;
            xrTableCell4.StylePriority.UsePadding = false;
            xrTableCell4.Text = "ADRESSE";
            xrTableCell4.Weight = 1.4636767710884846D;
            // 
            // xrTableCell3
            // 
            xrTableCell3.CanGrow = false;
            xrTableCell3.Name = "xrTableCell3";
            xrTableCell3.Text = "TELEPHONE";
            xrTableCell3.Weight = 1.5363232289115154D;
            // 
            // xrTableRow5
            // 
            xrTableRow5.Cells.AddRange(new[]
            {
                xrTableCell6,
                xrTableCell7
            });
            xrTableRow5.Name = "xrTableRow5";
            xrTableRow5.Weight = 0.27270867469998472D;
            // 
            // xrTableCell6
            // 
            xrTableCell6.CanGrow = false;
            xrTableCell6.Multiline = true;
            xrTableCell6.Name = "xrTableCell6";
            xrTableCell6.RowSpan = 2;
            xrTableCell6.Text = "[Address.Line]\r\n[Address.CityLine]";
            xrTableCell6.Weight = 1.4636768842199621D;
            xrTableCell6.WordWrap = false;
            // 
            // xrTableCell7
            // 
            xrTableCell7.CanGrow = false;
            xrTableCell7.Name = "xrTableCell7";
            xrTableCell7.StylePriority.UsePadding = false;
            xrTableCell7.Text = "[MobilePhone] (Mobile)";
            xrTableCell7.Weight = 1.5363231157800379D;
            xrTableCell7.WordWrap = false;
            // 
            // xrTableRow6
            // 
            xrTableRow6.Cells.AddRange(new[]
            {
                xrTableCell8,
                xrTableCell9
            });
            xrTableRow6.Name = "xrTableRow6";
            xrTableRow6.Weight = 0.296050406027006D;
            // 
            // xrTableCell8
            // 
            xrTableCell8.CanGrow = false;
            xrTableCell8.Name = "xrTableCell8";
            xrTableCell8.Text = "xrTableCell8";
            xrTableCell8.Weight = 1.4636768842199621D;
            // 
            // xrTableCell9
            // 
            xrTableCell9.CanGrow = false;
            xrTableCell9.Name = "xrTableCell9";
            xrTableCell9.Text = "[HomePhone] (Fixe)";
            xrTableCell9.Weight = 1.5363231157800379D;
            xrTableCell9.WordWrap = false;
            // 
            // xrTableRow7
            // 
            xrTableRow7.Cells.AddRange(new[]
            {
                xrTableCell10
            });
            xrTableRow7.Name = "xrTableRow7";
            xrTableRow7.Weight = 0.20932491335747283D;
            // 
            // xrTableCell10
            // 
            xrTableCell10.Name = "xrTableCell10";
            xrTableCell10.Weight = 3D;
            // 
            // xrTableRow8
            // 
            xrTableRow8.Cells.AddRange(new[]
            {
                xrTableCell12,
                xrTableCell11
            });
            xrTableRow8.ForeColor = Color.FromArgb(166, 166, 166);
            xrTableRow8.Name = "xrTableRow8";
            xrTableRow8.StylePriority.UseForeColor = false;
            xrTableRow8.Weight = 0.27782294316403405D;
            // 
            // xrTableCell12
            // 
            xrTableCell12.Name = "xrTableCell12";
            xrTableCell12.Text = "EMAIL";
            xrTableCell12.Weight = 1.4636771502088639D;
            // 
            // xrTableCell11
            // 
            xrTableCell11.Name = "xrTableCell11";
            xrTableCell11.Text = "SKYPE";
            xrTableCell11.Weight = 1.5363228497911361D;
            // 
            // xrTableRow9
            // 
            xrTableRow9.Cells.AddRange(new[]
            {
                xrTableCell13,
                xrTableCell14
            });
            xrTableRow9.Name = "xrTableRow9";
            xrTableRow9.Weight = 0.32020800489844209D;
            // 
            // xrTableCell13
            // 
            xrTableCell13.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "Email")
            });
            xrTableCell13.Name = "xrTableCell13";
            xrTableCell13.Weight = 1.4636770897901221D;
            // 
            // xrTableCell14
            // 
            xrTableCell14.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "Skype")
            });
            xrTableCell14.Name = "xrTableCell14";
            xrTableCell14.Weight = 1.5363229102098779D;
            // 
            // xrPictureBox1
            // 
            xrPictureBox1.DataBindings.AddRange(new[]
            {
                new XRBinding("Image", null, "Photo")
            });
            xrPictureBox1.LocationFloat = new PointFloat(7.65625F, 19.91159F);
            xrPictureBox1.Name = "xrPictureBox1";
            xrPictureBox1.SizeF = new SizeF(152.3728F, 208.25F);
            xrPictureBox1.Sizing = ImageSizeMode.ZoomImage;
            // 
            // bottomMarginBand1
            // 
            bottomMarginBand1.Controls.AddRange(new XRControl[]
            {
                xrPageInfo2,
                xrPageInfo1
            });
            bottomMarginBand1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bottomMarginBand1.HeightF = 102F;
            bottomMarginBand1.Name = "bottomMarginBand1";
            bottomMarginBand1.StylePriority.UseFont = false;
            // 
            // xrPageInfo2
            // 
            xrPageInfo2.ForeColor = Color.FromArgb(166, 166, 166);
            xrPageInfo2.Format = "{0:MMMM d, yyyy}";
            xrPageInfo2.LocationFloat = new PointFloat(485.4167F, 0F);
            xrPageInfo2.Name = "xrPageInfo2";
            xrPageInfo2.Padding = new PaddingInfo(2, 2, 0, 0, 100F);
            xrPageInfo2.PageInfo = PageInfo.DateTime;
            xrPageInfo2.SizeF = new SizeF(156.25F, 23F);
            xrPageInfo2.StylePriority.UseForeColor = false;
            xrPageInfo2.StylePriority.UseTextAlignment = false;
            xrPageInfo2.TextAlignment = TextAlignment.TopRight;
            // 
            // xrPageInfo1
            // 
            xrPageInfo1.ForeColor = Color.FromArgb(166, 166, 166);
            xrPageInfo1.Format = "Page {0} of {1}";
            xrPageInfo1.LocationFloat = new PointFloat(0F, 0F);
            xrPageInfo1.Name = "xrPageInfo1";
            xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100F);
            xrPageInfo1.SizeF = new SizeF(156.25F, 23F);
            xrPageInfo1.StylePriority.UseForeColor = false;
            // 
            // ReportHeader
            // 
            ReportHeader.Controls.AddRange(new XRControl[]
            {
                xrTable2
            });
            ReportHeader.HeightF = 30F;
            ReportHeader.Name = "ReportHeader";
            // 
            // xrTable2
            // 
            xrTable2.LocationFloat = new PointFloat(0F, 0F);
            xrTable2.Name = "xrTable2";
            xrTable2.Rows.AddRange(new[]
            {
                xrTableRow10
            });
            xrTable2.SizeF = new SizeF(641.6667F, 29.69642F);
            // 
            // xrTableRow10
            // 
            xrTableRow10.Cells.AddRange(new[]
            {
                xrTableCell15,
                xrTableCell16,
                xrTableCell17
            });
            xrTableRow10.Name = "xrTableRow10";
            xrTableRow10.Weight = 1D;
            // 
            // xrTableCell15
            // 
            xrTableCell15.BackColor = Color.LimeGreen;
            xrTableCell15.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableCell15.ForeColor = Color.White;
            xrTableCell15.Name = "xrTableCell15";
            xrTableCell15.Padding = new PaddingInfo(8, 0, 0, 0, 100F);
            xrTableCell15.StylePriority.UseBackColor = false;
            xrTableCell15.StylePriority.UseFont = false;
            xrTableCell15.StylePriority.UseForeColor = false;
            xrTableCell15.StylePriority.UsePadding = false;
            xrTableCell15.StylePriority.UseTextAlignment = false;
            xrTableCell15.Text = "Liste des employés";
            xrTableCell15.TextAlignment = TextAlignment.MiddleLeft;
            xrTableCell15.Weight = 0.7808441558441559D;
            // 
            // xrTableCell16
            // 
            xrTableCell16.Name = "xrTableCell16";
            xrTableCell16.Weight = 0.043932629870129913D;
            // 
            // xrTableCell17
            // 
            xrTableCell17.BackColor = Color.FromArgb(218, 218, 218);
            xrTableCell17.Name = "xrTableCell17";
            xrTableCell17.StylePriority.UseBackColor = false;
            xrTableCell17.Weight = 2.1752232142857144D;
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(Employee);
            // 
            // EmployeeSummary
            // 
            Bands.AddRange(new Band[]
            {
                topMarginBand1,
                detailBand1,
                bottomMarginBand1,
                ReportHeader
            });
            DataSource = bindingSource1;
            DrawWatermark = true;
            Margins = new Margins(104, 54, 125, 102);
            Version = "15.1";
            ((ISupportInitialize) xrTable1).EndInit();
            ((ISupportInitialize) xrTable2).EndInit();
            ((ISupportInitialize) bindingSource1).EndInit();
            ((ISupportInitialize) this).EndInit();
        }
    }
}