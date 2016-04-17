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
    internal class EmployeeDirectory : XtraReport
    {
        private BindingSource bindingSource1;
        private BottomMarginBand bottomMarginBand1;
        private IContainer components;
        private DetailBand detailBand1;
        private CalculatedField FirstLetter;
        private PageHeaderBand PageHeader;
        private TopMarginBand topMarginBand1;
        private XRLabel xrLabel1;
        private XRLine xrLine1;
        private XRPageInfo xrPageInfo1;
        private XRPageInfo xrPageInfo2;
        private XRPictureBox xrPictureBox1;
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

        public EmployeeDirectory()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            components = new Container();
            var resources = new ComponentResourceManager(typeof(EmployeeDirectory));
            topMarginBand1 = new TopMarginBand();
            xrPictureBox1 = new XRPictureBox();
            detailBand1 = new DetailBand();
            xrLabel1 = new XRLabel();
            xrTable2 = new XRTable();
            xrTableRow2 = new XRTableRow();
            xrTableCell4 = new XRTableCell();
            xrTableRow3 = new XRTableRow();
            xrTableCell5 = new XRTableCell();
            xrTableRow4 = new XRTableRow();
            xrTableCell6 = new XRTableCell();
            xrLine1 = new XRLine();
            xrTableRow5 = new XRTableRow();
            xrTableCell7 = new XRTableCell();
            xrTableCell8 = new XRTableCell();
            xrTableRow6 = new XRTableRow();
            xrTableCell9 = new XRTableCell();
            xrTableCell10 = new XRTableCell();
            xrTableRow7 = new XRTableRow();
            xrTableCell11 = new XRTableCell();
            xrTableCell12 = new XRTableCell();
            xrTableRow8 = new XRTableRow();
            xrTableCell13 = new XRTableCell();
            xrTableRow9 = new XRTableRow();
            xrTableCell14 = new XRTableCell();
            xrTableCell15 = new XRTableCell();
            xrTableRow10 = new XRTableRow();
            xrTableCell16 = new XRTableCell();
            xrTableCell17 = new XRTableCell();
            bottomMarginBand1 = new BottomMarginBand();
            xrPageInfo2 = new XRPageInfo();
            xrPageInfo1 = new XRPageInfo();
            bindingSource1 = new BindingSource(components);
            PageHeader = new PageHeaderBand();
            xrTable1 = new XRTable();
            xrTableRow1 = new XRTableRow();
            xrTableCell1 = new XRTableCell();
            xrTableCell2 = new XRTableCell();
            xrTableCell3 = new XRTableCell();
            FirstLetter = new CalculatedField();
            ((ISupportInitialize) xrTable2).BeginInit();
            ((ISupportInitialize) bindingSource1).BeginInit();
            ((ISupportInitialize) xrTable1).BeginInit();
            ((ISupportInitialize) this).BeginInit();
            // 
            // topMarginBand1
            // 
            topMarginBand1.Controls.AddRange(new XRControl[]
            {
                xrPictureBox1
            });
            topMarginBand1.Dpi = 96F;
            topMarginBand1.HeightF = 120F;
            topMarginBand1.Name = "topMarginBand1";
            // 
            // xrPictureBox1
            // 
            xrPictureBox1.Dpi = 96F;
            xrPictureBox1.Image = (Image) resources.GetObject("xrPictureBox1.Image");
            xrPictureBox1.LocationFloat = new PointFloat(369F, 10F);
            xrPictureBox1.Name = "xrPictureBox1";
            xrPictureBox1.SizeF = new SizeF(345.528F, 110F);
            xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
            // 
            // detailBand1
            // 
            detailBand1.Controls.AddRange(new XRControl[]
            {
                xrLabel1,
                xrTable2
            });
            detailBand1.Dpi = 96F;
            detailBand1.HeightF = 215.2001F;
            detailBand1.KeepTogether = true;
            detailBand1.Name = "detailBand1";
            detailBand1.SortFields.AddRange(new[]
            {
                new GroupField("LastName", XRColumnSortOrder.Ascending)
            });
            // 
            // xrLabel1
            // 
            xrLabel1.CanGrow = false;
            xrLabel1.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "FirstLetter")
            });
            xrLabel1.Dpi = 96F;
            xrLabel1.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            xrLabel1.LocationFloat = new PointFloat(0F, 16.58599F);
            xrLabel1.Name = "xrLabel1";
            xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 96F);
            xrLabel1.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
            xrLabel1.SizeF = new SizeF(53.25F, 73.39456F);
            xrLabel1.StylePriority.UseFont = false;
            xrLabel1.StylePriority.UseTextAlignment = false;
            xrLabel1.TextAlignment = TextAlignment.TopCenter;
            xrLabel1.WordWrap = false;
            // 
            // xrTable2
            // 
            xrTable2.Dpi = 96F;
            xrTable2.LocationFloat = new PointFloat(172.8822F, 16.1875F);
            xrTable2.Name = "xrTable2";
            xrTable2.Rows.AddRange(new[]
            {
                xrTableRow2,
                xrTableRow3,
                xrTableRow4,
                xrTableRow5,
                xrTableRow6,
                xrTableRow7,
                xrTableRow8,
                xrTableRow9,
                xrTableRow10
            });
            xrTable2.SizeF = new SizeF(441.6458F, 169.6342F);
            // 
            // xrTableRow2
            // 
            xrTableRow2.Cells.AddRange(new[]
            {
                xrTableCell4
            });
            xrTableRow2.Dpi = 96F;
            xrTableRow2.Name = "xrTableRow2";
            xrTableRow2.Weight = 0.48150076635820022D;
            // 
            // xrTableCell4
            // 
            xrTableCell4.CanGrow = false;
            xrTableCell4.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "FullName")
            });
            xrTableCell4.Dpi = 96F;
            xrTableCell4.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableCell4.ForeColor = Color.LawnGreen;
            xrTableCell4.Name = "xrTableCell4";
            xrTableCell4.StylePriority.UseFont = false;
            xrTableCell4.StylePriority.UseForeColor = false;
            xrTableCell4.StylePriority.UsePadding = false;
            xrTableCell4.StylePriority.UseTextAlignment = false;
            xrTableCell4.TextAlignment = TextAlignment.BottomLeft;
            xrTableCell4.Weight = 3D;
            // 
            // xrTableRow3
            // 
            xrTableRow3.Cells.AddRange(new[]
            {
                xrTableCell5
            });
            xrTableRow3.Dpi = 96F;
            xrTableRow3.Name = "xrTableRow3";
            xrTableRow3.Weight = 0.34068025346384434D;
            // 
            // xrTableCell5
            // 
            xrTableCell5.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "Title")
            });
            xrTableCell5.Dpi = 96F;
            xrTableCell5.ForeColor = Color.FromArgb(127, 127, 127);
            xrTableCell5.Name = "xrTableCell5";
            xrTableCell5.StylePriority.UseFont = false;
            xrTableCell5.StylePriority.UseForeColor = false;
            xrTableCell5.StylePriority.UsePadding = false;
            xrTableCell5.StylePriority.UseTextAlignment = false;
            xrTableCell5.TextAlignment = TextAlignment.TopLeft;
            xrTableCell5.Weight = 3D;
            // 
            // xrTableRow4
            // 
            xrTableRow4.Cells.AddRange(new[]
            {
                xrTableCell6
            });
            xrTableRow4.Dpi = 96F;
            xrTableRow4.Name = "xrTableRow4";
            xrTableRow4.Weight = 0.37828530166861157D;
            // 
            // xrTableCell6
            // 
            xrTableCell6.Controls.AddRange(new XRControl[]
            {
                xrLine1
            });
            xrTableCell6.Dpi = 96F;
            xrTableCell6.Name = "xrTableCell6";
            xrTableCell6.Weight = 3D;
            // 
            // xrLine1
            // 
            xrLine1.Dpi = 96F;
            xrLine1.ForeColor = Color.FromArgb(218, 218, 218);
            xrLine1.LocationFloat = new PointFloat(1.525879E-05F, 0F);
            xrLine1.Name = "xrLine1";
            xrLine1.SizeF = new SizeF(441.6458F, 12.20348F);
            xrLine1.StylePriority.UseForeColor = false;
            // 
            // xrTableRow5
            // 
            xrTableRow5.Cells.AddRange(new[]
            {
                xrTableCell7,
                xrTableCell8
            });
            xrTableRow5.Dpi = 96F;
            xrTableRow5.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableRow5.ForeColor = Color.FromArgb(166, 166, 166);
            xrTableRow5.Name = "xrTableRow5";
            xrTableRow5.StylePriority.UseFont = false;
            xrTableRow5.StylePriority.UseForeColor = false;
            xrTableRow5.Weight = 0.21567219504415658D;
            // 
            // xrTableCell7
            // 
            xrTableCell7.CanGrow = false;
            xrTableCell7.Dpi = 96F;
            xrTableCell7.Name = "xrTableCell7";
            xrTableCell7.StylePriority.UseBorderColor = false;
            xrTableCell7.StylePriority.UseForeColor = false;
            xrTableCell7.StylePriority.UsePadding = false;
            xrTableCell7.Text = "ADRESSE";
            xrTableCell7.Weight = 1.4868341453229292D;
            // 
            // xrTableCell8
            // 
            xrTableCell8.CanGrow = false;
            xrTableCell8.Dpi = 96F;
            xrTableCell8.Name = "xrTableCell8";
            xrTableCell8.Text = "MOBILE";
            xrTableCell8.Weight = 1.5131658546770708D;
            // 
            // xrTableRow6
            // 
            xrTableRow6.Cells.AddRange(new[]
            {
                xrTableCell9,
                xrTableCell10
            });
            xrTableRow6.Dpi = 96F;
            xrTableRow6.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableRow6.Name = "xrTableRow6";
            xrTableRow6.StylePriority.UseFont = false;
            xrTableRow6.Weight = 0.22076846350092508D;
            // 
            // xrTableCell9
            // 
            xrTableCell9.CanGrow = false;
            xrTableCell9.Dpi = 96F;
            xrTableCell9.Multiline = true;
            xrTableCell9.Name = "xrTableCell9";
            xrTableCell9.RowSpan = 2;
            xrTableCell9.Text = "[Address.Line]\r\n[Address.CityLine]";
            xrTableCell9.Weight = 1.4868341548048936D;
            xrTableCell9.WordWrap = false;
            // 
            // xrTableCell10
            // 
            xrTableCell10.CanGrow = false;
            xrTableCell10.Dpi = 96F;
            xrTableCell10.Name = "xrTableCell10";
            xrTableCell10.StylePriority.UsePadding = false;
            xrTableCell10.Text = "[MobilePhone] (Mobile)";
            xrTableCell10.Weight = 1.5131658451951064D;
            xrTableCell10.WordWrap = false;
            // 
            // xrTableRow7
            // 
            xrTableRow7.Cells.AddRange(new[]
            {
                xrTableCell11,
                xrTableCell12
            });
            xrTableRow7.Dpi = 96F;
            xrTableRow7.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableRow7.Name = "xrTableRow7";
            xrTableRow7.StylePriority.UseFont = false;
            xrTableRow7.Weight = 0.25449824869166587D;
            // 
            // xrTableCell11
            // 
            xrTableCell11.CanGrow = false;
            xrTableCell11.Dpi = 96F;
            xrTableCell11.Name = "xrTableCell11";
            xrTableCell11.Text = "xrTableCell8";
            xrTableCell11.Weight = 1.4868341548048936D;
            // 
            // xrTableCell12
            // 
            xrTableCell12.CanGrow = false;
            xrTableCell12.Dpi = 96F;
            xrTableCell12.Name = "xrTableCell12";
            xrTableCell12.Text = "[HomePhone] (Fixe)";
            xrTableCell12.Weight = 1.5131658451951064D;
            xrTableCell12.WordWrap = false;
            // 
            // xrTableRow8
            // 
            xrTableRow8.Cells.AddRange(new[]
            {
                xrTableCell13
            });
            xrTableRow8.Dpi = 96F;
            xrTableRow8.Name = "xrTableRow8";
            xrTableRow8.Weight = 0.12622171748791217D;
            // 
            // xrTableCell13
            // 
            xrTableCell13.Dpi = 96F;
            xrTableCell13.Name = "xrTableCell13";
            xrTableCell13.Weight = 3D;
            // 
            // xrTableRow9
            // 
            xrTableRow9.Cells.AddRange(new[]
            {
                xrTableCell14,
                xrTableCell15
            });
            xrTableRow9.Dpi = 96F;
            xrTableRow9.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableRow9.ForeColor = Color.FromArgb(166, 166, 166);
            xrTableRow9.Name = "xrTableRow9";
            xrTableRow9.StylePriority.UseFont = false;
            xrTableRow9.StylePriority.UseForeColor = false;
            xrTableRow9.Weight = 0.22588296444312883D;
            // 
            // xrTableCell14
            // 
            xrTableCell14.Dpi = 96F;
            xrTableCell14.Name = "xrTableCell14";
            xrTableCell14.Text = "EMAIL";
            xrTableCell14.Weight = 1.486834109845256D;
            // 
            // xrTableCell15
            // 
            xrTableCell15.Dpi = 96F;
            xrTableCell15.Name = "xrTableCell15";
            xrTableCell15.Text = "SKYPE";
            xrTableCell15.Weight = 1.513165890154744D;
            // 
            // xrTableRow10
            // 
            xrTableRow10.Cells.AddRange(new[]
            {
                xrTableCell16,
                xrTableCell17
            });
            xrTableRow10.Dpi = 96F;
            xrTableRow10.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableRow10.Name = "xrTableRow10";
            xrTableRow10.StylePriority.UseFont = false;
            xrTableRow10.Weight = 0.34098411262588169D;
            // 
            // xrTableCell16
            // 
            xrTableCell16.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "Email")
            });
            xrTableCell16.Dpi = 96F;
            xrTableCell16.Name = "xrTableCell16";
            xrTableCell16.Weight = 1.4868337384779746D;
            // 
            // xrTableCell17
            // 
            xrTableCell17.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "Skype")
            });
            xrTableCell17.Dpi = 96F;
            xrTableCell17.Name = "xrTableCell17";
            xrTableCell17.Weight = 1.5131662615220254D;
            // 
            // bottomMarginBand1
            // 
            bottomMarginBand1.Controls.AddRange(new XRControl[]
            {
                xrPageInfo2,
                xrPageInfo1
            });
            bottomMarginBand1.Dpi = 96F;
            bottomMarginBand1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bottomMarginBand1.HeightF = 100F;
            bottomMarginBand1.Name = "bottomMarginBand1";
            bottomMarginBand1.StylePriority.UseFont = false;
            // 
            // xrPageInfo2
            // 
            xrPageInfo2.Dpi = 96F;
            xrPageInfo2.ForeColor = Color.FromArgb(166, 166, 166);
            xrPageInfo2.Format = "{0:MMMM d, yyyy}";
            xrPageInfo2.LocationFloat = new PointFloat(466F, 0F);
            xrPageInfo2.Name = "xrPageInfo2";
            xrPageInfo2.Padding = new PaddingInfo(2, 2, 0, 0, 96F);
            xrPageInfo2.PageInfo = PageInfo.DateTime;
            xrPageInfo2.SizeF = new SizeF(150F, 22.08F);
            xrPageInfo2.StylePriority.UseForeColor = false;
            xrPageInfo2.StylePriority.UseTextAlignment = false;
            xrPageInfo2.TextAlignment = TextAlignment.TopRight;
            // 
            // xrPageInfo1
            // 
            xrPageInfo1.Dpi = 96F;
            xrPageInfo1.ForeColor = Color.FromArgb(166, 166, 166);
            xrPageInfo1.Format = "Page {0} of {1}";
            xrPageInfo1.LocationFloat = new PointFloat(0F, 0F);
            xrPageInfo1.Name = "xrPageInfo1";
            xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 96F);
            xrPageInfo1.SizeF = new SizeF(150F, 22.08F);
            xrPageInfo1.StylePriority.UseForeColor = false;
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(Employee);
            // 
            // PageHeader
            // 
            PageHeader.Controls.AddRange(new XRControl[]
            {
                xrTable1
            });
            PageHeader.Dpi = 96F;
            PageHeader.HeightF = 29.5198F;
            PageHeader.Name = "PageHeader";
            PageHeader.StylePriority.UseFont = false;
            // 
            // xrTable1
            // 
            xrTable1.Dpi = 96F;
            xrTable1.LocationFloat = new PointFloat(0F, 0F);
            xrTable1.Name = "xrTable1";
            xrTable1.Rows.AddRange(new[]
            {
                xrTableRow1
            });
            xrTable1.SizeF = new SizeF(616F, 28.50856F);
            // 
            // xrTableRow1
            // 
            xrTableRow1.Cells.AddRange(new[]
            {
                xrTableCell1,
                xrTableCell2,
                xrTableCell3
            });
            xrTableRow1.Dpi = 96F;
            xrTableRow1.Name = "xrTableRow1";
            xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            xrTableCell1.BackColor = Color.LimeGreen;
            xrTableCell1.Dpi = 96F;
            xrTableCell1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableCell1.ForeColor = Color.White;
            xrTableCell1.Multiline = true;
            xrTableCell1.Name = "xrTableCell1";
            xrTableCell1.Padding = new PaddingInfo(8, 0, 0, 0, 96F);
            xrTableCell1.StylePriority.UseBackColor = false;
            xrTableCell1.StylePriority.UseFont = false;
            xrTableCell1.StylePriority.UseForeColor = false;
            xrTableCell1.StylePriority.UsePadding = false;
            xrTableCell1.StylePriority.UseTextAlignment = false;
            xrTableCell1.Text = "Répertoire";
            xrTableCell1.TextAlignment = TextAlignment.MiddleLeft;
            xrTableCell1.Weight = 0.7808441558441559D;
            // 
            // xrTableCell2
            // 
            xrTableCell2.Dpi = 96F;
            xrTableCell2.Name = "xrTableCell2";
            xrTableCell2.Weight = 0.043932629870129913D;
            // 
            // xrTableCell3
            // 
            xrTableCell3.BackColor = Color.FromArgb(218, 218, 218);
            xrTableCell3.Dpi = 96F;
            xrTableCell3.Name = "xrTableCell3";
            xrTableCell3.StylePriority.UseBackColor = false;
            xrTableCell3.Weight = 2.1752232142857144D;
            // 
            // FirstLetter
            // 
            FirstLetter.Expression = "Substring([LastName], 0, 1)";
            FirstLetter.Name = "FirstLetter";
            // 
            // EmployeeDirectory
            // 
            Bands.AddRange(new Band[]
            {
                topMarginBand1,
                detailBand1,
                bottomMarginBand1,
                PageHeader
            });
            CalculatedFields.AddRange(new[]
            {
                FirstLetter
            });
            DataSource = bindingSource1;
            Dpi = 96F;
            DrawWatermark = true;
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margins = new Margins(100, 34, 120, 100);
            PageHeight = 1056;
            PageWidth = 816;
            ReportUnit = ReportUnit.Pixels;
            Version = "15.1";
            ((ISupportInitialize) xrTable2).EndInit();
            ((ISupportInitialize) bindingSource1).EndInit();
            ((ISupportInitialize) xrTable1).EndInit();
            ((ISupportInitialize) this).EndInit();
        }
    }
}