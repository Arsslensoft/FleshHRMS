using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using PHRMS.Data;

namespace PHRMS
{
    internal class LeaveList : XtraReport
    {
        private BindingSource bindingSource1;
        private BottomMarginBand bottomMarginBand1;
        private IContainer components;
        private DetailBand detailBand1;
        private GroupFooterBand GroupFooter1;
        private GroupHeaderBand GroupHeader1;
        private Parameter parameter1;
        private ReportHeaderBand ReportHeader;
        private CalculatedField statusCompleted;
        private CalculatedField statusDeferred;
        private CalculatedField statusInProgress;
        private CalculatedField statusNeedAssistance;
        private CalculatedField statusNotStarted;
        private TopMarginBand topMarginBand1;
        private XRLabel xrLabel1;
        private XRLabel xrLabel2;
        private XRLabel xrLabel3;
        private XRPageInfo xrPageInfo1;
        private XRPageInfo xrPageInfo2;
        private XRPictureBox xrPictureBox1;
        private XRTable xrTable1;
        private XRTable xrTable2;
        private XRTable xrTable3;
        private XRTable xrTable4;
        private XRTableCell xrTableCell1;
        private XRTableCell xrTableCell10;
        private XRTableCell xrTableCell11;
        private XRTableCell xrTableCell12;
        private XRTableCell xrTableCell13;
        private XRTableCell xrTableCell14;
        private XRTableCell xrTableCell15;
        private XRTableCell xrTableCell16;
        private XRTableCell xrTableCell17;
        private XRTableCell xrTableCell18;
        private XRTableCell xrTableCell19;
        private XRTableCell xrTableCell2;
        private XRTableCell xrTableCell20;
        private XRTableCell xrTableCell21;
        private XRTableCell xrTableCell22;
        private XRTableCell xrTableCell23;
        private XRTableCell xrTableCell24;
        private XRTableCell xrTableCell25;
        private XRTableCell xrTableCell26;
        private XRTableCell xrTableCell3;
        private XRTableCell xrTableCell4;
        private XRTableCell xrTableCell5;
        private XRTableCell xrTableCell6;
        private XRTableCell xrTableCell7;
        private XRTableCell xrTableCell8;
        private XRTableCell xrTableCell9;
        private XRTableRow xrTableRow1;
        private XRTableRow xrTableRow2;
        private XRTableRow xrTableRow3;
        private XRTableRow xrTableRow4;
        private XRTableRow xrTableRow5;
        private XRTableRow xrTableRow6;
        private XRTableRow xrTableRow7;
        private XRTableRow xrTableRow8;

        public LeaveList()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            components = new Container();
            var resources = new ComponentResourceManager(typeof(LeaveList));
            topMarginBand1 = new TopMarginBand();
            xrPictureBox1 = new XRPictureBox();
            detailBand1 = new DetailBand();
            xrTable4 = new XRTable();
            xrTableRow6 = new XRTableRow();
            xrTableCell15 = new XRTableCell();
            xrTableCell17 = new XRTableCell();
            xrTableCell18 = new XRTableCell();
            xrTableCell22 = new XRTableCell();
            xrTableCell24 = new XRTableCell();
            xrTableRow7 = new XRTableRow();
            xrTableCell19 = new XRTableCell();
            xrTableCell20 = new XRTableCell();
            xrTableCell21 = new XRTableCell();
            xrTableCell23 = new XRTableCell();
            xrTableCell25 = new XRTableCell();
            xrTableRow8 = new XRTableRow();
            xrTableCell26 = new XRTableCell();
            xrLabel2 = new XRLabel();
            xrTable3 = new XRTable();
            xrTableRow4 = new XRTableRow();
            xrTableCell14 = new XRTableCell();
            xrTableRow5 = new XRTableRow();
            xrTableCell16 = new XRTableCell();
            xrLabel1 = new XRLabel();
            bottomMarginBand1 = new BottomMarginBand();
            xrPageInfo2 = new XRPageInfo();
            xrPageInfo1 = new XRPageInfo();
            bindingSource1 = new BindingSource(components);
            xrTable1 = new XRTable();
            xrTableRow1 = new XRTableRow();
            xrTableCell1 = new XRTableCell();
            xrTableCell2 = new XRTableCell();
            xrTableCell3 = new XRTableCell();
            xrTable2 = new XRTable();
            xrTableRow2 = new XRTableRow();
            xrTableCell4 = new XRTableCell();
            xrTableCell5 = new XRTableCell();
            xrTableCell7 = new XRTableCell();
            xrTableCell8 = new XRTableCell();
            xrTableCell6 = new XRTableCell();
            xrTableRow3 = new XRTableRow();
            xrTableCell9 = new XRTableCell();
            xrTableCell10 = new XRTableCell();
            xrTableCell11 = new XRTableCell();
            xrTableCell12 = new XRTableCell();
            xrTableCell13 = new XRTableCell();
            ReportHeader = new ReportHeaderBand();
            GroupHeader1 = new GroupHeaderBand();
            xrLabel3 = new XRLabel();
            statusCompleted = new CalculatedField();
            statusNotStarted = new CalculatedField();
            statusInProgress = new CalculatedField();
            statusNeedAssistance = new CalculatedField();
            statusDeferred = new CalculatedField();
            parameter1 = new Parameter();
            GroupFooter1 = new GroupFooterBand();
            ((ISupportInitialize) xrTable4).BeginInit();
            ((ISupportInitialize) xrTable3).BeginInit();
            ((ISupportInitialize) bindingSource1).BeginInit();
            ((ISupportInitialize) xrTable1).BeginInit();
            ((ISupportInitialize) xrTable2).BeginInit();
            ((ISupportInitialize) this).BeginInit();
            // 
            // topMarginBand1
            // 
            topMarginBand1.Controls.AddRange(new XRControl[]
            {
                xrPictureBox1
            });
            topMarginBand1.HeightF = 138F;
            topMarginBand1.Name = "topMarginBand1";
            // 
            // xrPictureBox1
            // 
            xrPictureBox1.Image = (Image) resources.GetObject("xrPictureBox1.Image");
            xrPictureBox1.LocationFloat = new PointFloat(392.7083F, 6.243578F);
            xrPictureBox1.Name = "xrPictureBox1";
            xrPictureBox1.SizeF = new SizeF(344.7917F, 125.1618F);
            xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
            // 
            // detailBand1
            // 
            detailBand1.Controls.AddRange(new XRControl[]
            {
                xrTable4,
                xrLabel2,
                xrTable3,
                xrLabel1
            });
            detailBand1.HeightF = 179.1667F;
            detailBand1.Name = "detailBand1";
            detailBand1.SortFields.AddRange(new[]
            {
                new GroupField("DueDate", XRColumnSortOrder.Ascending)
            });
            // 
            // xrTable4
            // 
            xrTable4.KeepTogether = true;
            xrTable4.LocationFloat = new PointFloat(0F, 106.875F);
            xrTable4.Name = "xrTable4";
            xrTable4.Rows.AddRange(new[]
            {
                xrTableRow6,
                xrTableRow7,
                xrTableRow8
            });
            xrTable4.SizeF = new SizeF(650F, 56.87504F);
            // 
            // xrTableRow6
            // 
            xrTableRow6.Cells.AddRange(new[]
            {
                xrTableCell15,
                xrTableCell17,
                xrTableCell18,
                xrTableCell22,
                xrTableCell24
            });
            xrTableRow6.ForeColor = Color.FromArgb(175, 175, 175);
            xrTableRow6.Name = "xrTableRow6";
            xrTableRow6.StylePriority.UseForeColor = false;
            xrTableRow6.Weight = 0.45665942772890605D;
            // 
            // xrTableCell15
            // 
            xrTableCell15.Name = "xrTableCell15";
            xrTableCell15.Padding = new PaddingInfo(17, 0, 0, 0, 100F);
            xrTableCell15.StylePriority.UseFont = false;
            xrTableCell15.StylePriority.UseForeColor = false;
            xrTableCell15.StylePriority.UsePadding = false;
            xrTableCell15.Text = "DATE DE RETOUR";
            xrTableCell15.Weight = 0.60771602766636823D;
            // 
            // xrTableCell17
            // 
            xrTableCell17.Name = "xrTableCell17";
            xrTableCell17.Padding = new PaddingInfo(4, 0, 0, 0, 100F);
            xrTableCell17.StylePriority.UseForeColor = false;
            xrTableCell17.StylePriority.UsePadding = false;
            xrTableCell17.Text = "CRÉE PAR";
            xrTableCell17.Weight = 0.62980608396886717D;
            // 
            // xrTableCell18
            // 
            xrTableCell18.Name = "xrTableCell18";
            xrTableCell18.Padding = new PaddingInfo(4, 0, 0, 0, 100F);
            xrTableCell18.StylePriority.UsePadding = false;
            xrTableCell18.Text = "EMPLOYÉ";
            xrTableCell18.Weight = 0.58008992577285823D;
            // 
            // xrTableCell22
            // 
            xrTableCell22.Name = "xrTableCell22";
            xrTableCell22.Padding = new PaddingInfo(4, 0, 0, 0, 100F);
            xrTableCell22.StylePriority.UsePadding = false;
            xrTableCell22.Text = "PROGRESSION";
            xrTableCell22.Weight = 0.70420532486194742D;
            // 
            // xrTableCell24
            // 
            xrTableCell24.Name = "xrTableCell24";
            xrTableCell24.Padding = new PaddingInfo(0, 4, 0, 0, 100F);
            xrTableCell24.StylePriority.UsePadding = false;
            xrTableCell24.StylePriority.UseTextAlignment = false;
            xrTableCell24.Text = "PRIORITÉ";
            xrTableCell24.TextAlignment = TextAlignment.TopRight;
            xrTableCell24.Weight = 0.47818263772995884D;
            // 
            // xrTableRow7
            // 
            xrTableRow7.Cells.AddRange(new[]
            {
                xrTableCell19,
                xrTableCell20,
                xrTableCell21,
                xrTableCell23,
                xrTableCell25
            });
            xrTableRow7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableRow7.Name = "xrTableRow7";
            xrTableRow7.StylePriority.UseFont = false;
            xrTableRow7.Weight = 0.45665943679824827D;
            // 
            // xrTableCell19
            // 
            xrTableCell19.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "DueDate", "{0:d}")
            });
            xrTableCell19.Name = "xrTableCell19";
            xrTableCell19.Padding = new PaddingInfo(17, 0, 0, 0, 100F);
            xrTableCell19.StylePriority.UseFont = false;
            xrTableCell19.StylePriority.UsePadding = false;
            xrTableCell19.Text = "12/17/2013";
            xrTableCell19.Weight = 0.60771602766636823D;
            // 
            // xrTableCell20
            // 
            xrTableCell20.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "AssignedEmployee.FullName")
            });
            xrTableCell20.Name = "xrTableCell20";
            xrTableCell20.Padding = new PaddingInfo(4, 0, 0, 0, 100F);
            xrTableCell20.StylePriority.UsePadding = false;
            xrTableCell20.Text = "John Hansen";
            xrTableCell20.Weight = 0.62980636210376506D;
            // 
            // xrTableCell21
            // 
            xrTableCell21.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "Owner.FullName")
            });
            xrTableCell21.Name = "xrTableCell21";
            xrTableCell21.Padding = new PaddingInfo(4, 0, 0, 0, 100F);
            xrTableCell21.StylePriority.UsePadding = false;
            xrTableCell21.Text = "Jane Mitchell";
            xrTableCell21.Weight = 0.58008964763796045D;
            // 
            // xrTableCell23
            // 
            xrTableCell23.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "Completion")
            });
            xrTableCell23.Name = "xrTableCell23";
            xrTableCell23.Padding = new PaddingInfo(4, 0, 0, 0, 100F);
            xrTableCell23.StylePriority.UsePadding = false;
            xrTableCell23.Text = "xrTableCell23";
            xrTableCell23.Weight = 0.70420532486194742D;
            // 
            // xrTableCell25
            // 
            xrTableCell25.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "Priority")
            });
            xrTableCell25.ForeColor = Color.FromArgb(221, 128, 71);
            xrTableCell25.Name = "xrTableCell25";
            xrTableCell25.Padding = new PaddingInfo(0, 4, 0, 0, 100F);
            xrTableCell25.StylePriority.UseForeColor = false;
            xrTableCell25.StylePriority.UsePadding = false;
            xrTableCell25.StylePriority.UseTextAlignment = false;
            xrTableCell25.Text = "High";
            xrTableCell25.TextAlignment = TextAlignment.TopRight;
            xrTableCell25.Weight = 0.47818263772995884D;
            // 
            // xrTableRow8
            // 
            xrTableRow8.BorderColor = Color.FromArgb(175, 175, 175);
            xrTableRow8.Borders = BorderSide.Bottom;
            xrTableRow8.Cells.AddRange(new[]
            {
                xrTableCell26
            });
            xrTableRow8.Name = "xrTableRow8";
            xrTableRow8.StylePriority.UseBorderColor = false;
            xrTableRow8.StylePriority.UseBorders = false;
            xrTableRow8.Weight = 0.45665943679824827D;
            // 
            // xrTableCell26
            // 
            xrTableCell26.Name = "xrTableCell26";
            xrTableCell26.Weight = 3D;
            // 
            // xrLabel2
            // 
            xrLabel2.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "Description")
            });
            xrLabel2.Font = new Font("Segoe UI", 10F, FontStyle.Italic, GraphicsUnit.Point, 0);
            xrLabel2.KeepTogether = true;
            xrLabel2.LocationFloat = new PointFloat(128.125F, 53.66668F);
            xrLabel2.Name = "xrLabel2";
            xrLabel2.Padding = new PaddingInfo(7, 2, 0, 0, 100F);
            xrLabel2.SizeF = new SizeF(342.7083F, 40.625F);
            xrLabel2.StylePriority.UseFont = false;
            xrLabel2.StylePriority.UsePadding = false;
            xrLabel2.Text = "Artwork is ready. The printer’s address is 100 Main Rd. We need to see the proofs" +
                            " before we go to print.";
            // 
            // xrTable3
            // 
            xrTable3.LocationFloat = new PointFloat(0F, 53.66668F);
            xrTable3.Name = "xrTable3";
            xrTable3.Padding = new PaddingInfo(17, 0, 0, 0, 100F);
            xrTable3.Rows.AddRange(new[]
            {
                xrTableRow4,
                xrTableRow5
            });
            xrTable3.SizeF = new SizeF(109.6389F, 40.625F);
            xrTable3.StylePriority.UsePadding = false;
            // 
            // xrTableRow4
            // 
            xrTableRow4.Cells.AddRange(new[]
            {
                xrTableCell14
            });
            xrTableRow4.Name = "xrTableRow4";
            xrTableRow4.Weight = 0.79591859610841031D;
            // 
            // xrTableCell14
            // 
            xrTableCell14.ForeColor = Color.FromArgb(175, 175, 175);
            xrTableCell14.Name = "xrTableCell14";
            xrTableCell14.StylePriority.UseForeColor = false;
            xrTableCell14.Text = "DATE DÉBUT";
            xrTableCell14.Weight = 3D;
            // 
            // xrTableRow5
            // 
            xrTableRow5.Cells.AddRange(new[]
            {
                xrTableCell16
            });
            xrTableRow5.Name = "xrTableRow5";
            xrTableRow5.Weight = 0.79591820772148691D;
            // 
            // xrTableCell16
            // 
            xrTableCell16.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "StartDate", "{0:d}")
            });
            xrTableCell16.Name = "xrTableCell16";
            xrTableCell16.Text = "12/15/2013";
            xrTableCell16.Weight = 3D;
            // 
            // xrLabel1
            // 
            xrLabel1.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "Subject")
            });
            xrLabel1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            xrLabel1.LocationFloat = new PointFloat(0F, 16F);
            xrLabel1.Name = "xrLabel1";
            xrLabel1.Padding = new PaddingInfo(17, 2, 0, 0, 100F);
            xrLabel1.SizeF = new SizeF(649.4167F, 22.91667F);
            xrLabel1.StylePriority.UseFont = false;
            xrLabel1.StylePriority.UsePadding = false;
            // 
            // bottomMarginBand1
            // 
            bottomMarginBand1.Controls.AddRange(new XRControl[]
            {
                xrPageInfo2,
                xrPageInfo1
            });
            bottomMarginBand1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bottomMarginBand1.HeightF = 100F;
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
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(Leave);
            // 
            // xrTable1
            // 
            xrTable1.LocationFloat = new PointFloat(0F, 22F);
            xrTable1.Name = "xrTable1";
            xrTable1.Rows.AddRange(new[]
            {
                xrTableRow1
            });
            xrTable1.SizeF = new SizeF(650F, 29.69642F);
            // 
            // xrTableRow1
            // 
            xrTableRow1.Cells.AddRange(new[]
            {
                xrTableCell1,
                xrTableCell2,
                xrTableCell3
            });
            xrTableRow1.Name = "xrTableRow1";
            xrTableRow1.StylePriority.UseTextAlignment = false;
            xrTableRow1.TextAlignment = TextAlignment.MiddleRight;
            xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            xrTableCell1.BackColor = Color.LimeGreen;
            xrTableCell1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableCell1.ForeColor = Color.White;
            xrTableCell1.Name = "xrTableCell1";
            xrTableCell1.Padding = new PaddingInfo(8, 0, 0, 0, 100F);
            xrTableCell1.StylePriority.UseBackColor = false;
            xrTableCell1.StylePriority.UseFont = false;
            xrTableCell1.StylePriority.UseForeColor = false;
            xrTableCell1.StylePriority.UsePadding = false;
            xrTableCell1.StylePriority.UseTextAlignment = false;
            xrTableCell1.Text = "Congés";
            xrTableCell1.TextAlignment = TextAlignment.MiddleLeft;
            xrTableCell1.Weight = 0.80032469757233127D;
            // 
            // xrTableCell2
            // 
            xrTableCell2.Name = "xrTableCell2";
            xrTableCell2.Weight = 0.024452088141954528D;
            // 
            // xrTableCell3
            // 
            xrTableCell3.BackColor = Color.FromArgb(218, 218, 218);
            xrTableCell3.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableCell3.Name = "xrTableCell3";
            xrTableCell3.Padding = new PaddingInfo(0, 8, 0, 0, 100F);
            xrTableCell3.StylePriority.UseBackColor = false;
            xrTableCell3.StylePriority.UseFont = false;
            xrTableCell3.StylePriority.UsePadding = false;
            xrTableCell3.Text = "Grouped by Status | Sorted by Due Date";
            xrTableCell3.Weight = 2.2141840142121296D;
            // 
            // xrTable2
            // 
            xrTable2.LocationFloat = new PointFloat(0F, 73.70834F);
            xrTable2.Name = "xrTable2";
            xrTable2.Rows.AddRange(new[]
            {
                xrTableRow2,
                xrTableRow3
            });
            xrTable2.SizeF = new SizeF(648.9583F, 148.9583F);
            xrTable2.StylePriority.UseBorders = false;
            xrTable2.StylePriority.UseTextAlignment = false;
            xrTable2.TextAlignment = TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            xrTableRow2.Cells.AddRange(new[]
            {
                xrTableCell4,
                xrTableCell5,
                xrTableCell7,
                xrTableCell8,
                xrTableCell6
            });
            xrTableRow2.Font = new Font("Microsoft Sans Serif", 36F);
            xrTableRow2.Name = "xrTableRow2";
            xrTableRow2.StylePriority.UseFont = false;
            xrTableRow2.StylePriority.UseTextAlignment = false;
            xrTableRow2.Weight = 1D;
            // 
            // xrTableCell4
            // 
            xrTableCell4.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "statusNotStarted")
            });
            xrTableCell4.Name = "xrTableCell4";
            xrTableCell4.Weight = 1D;
            xrTableCell4.WordWrap = false;
            // 
            // xrTableCell5
            // 
            xrTableCell5.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "statusInProgress")
            });
            xrTableCell5.Name = "xrTableCell5";
            xrTableCell5.Weight = 1D;
            xrTableCell5.WordWrap = false;
            // 
            // xrTableCell7
            // 
            xrTableCell7.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "statusCompleted")
            });
            xrTableCell7.Name = "xrTableCell7";
            xrTableCell7.StylePriority.UseTextAlignment = false;
            xrTableCell7.Weight = 1D;
            xrTableCell7.WordWrap = false;
            // 
            // xrTableCell8
            // 
            xrTableCell8.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "statusNeedAssistance")
            });
            xrTableCell8.Name = "xrTableCell8";
            xrTableCell8.Weight = 1D;
            xrTableCell8.WordWrap = false;
            // 
            // xrTableCell6
            // 
            xrTableCell6.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "statusDeferred")
            });
            xrTableCell6.Name = "xrTableCell6";
            xrTableCell6.Weight = 1D;
            xrTableCell6.WordWrap = false;
            // 
            // xrTableRow3
            // 
            xrTableRow3.BorderColor = Color.FromArgb(175, 175, 175);
            xrTableRow3.Borders = BorderSide.Bottom;
            xrTableRow3.Cells.AddRange(new[]
            {
                xrTableCell9,
                xrTableCell10,
                xrTableCell11,
                xrTableCell12,
                xrTableCell13
            });
            xrTableRow3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableRow3.ForeColor = Color.FromArgb(175, 175, 175);
            xrTableRow3.Name = "xrTableRow3";
            xrTableRow3.StylePriority.UseBorderColor = false;
            xrTableRow3.StylePriority.UseBorders = false;
            xrTableRow3.StylePriority.UseFont = false;
            xrTableRow3.StylePriority.UseForeColor = false;
            xrTableRow3.StylePriority.UseTextAlignment = false;
            xrTableRow3.Weight = 0.5423728813559322D;
            // 
            // xrTableCell9
            // 
            xrTableCell9.Name = "xrTableCell9";
            xrTableCell9.Text = "NOT STARTED";
            xrTableCell9.Weight = 1D;
            // 
            // xrTableCell10
            // 
            xrTableCell10.Name = "xrTableCell10";
            xrTableCell10.Text = "IN PROGRESS";
            xrTableCell10.Weight = 1D;
            // 
            // xrTableCell11
            // 
            xrTableCell11.Name = "xrTableCell11";
            xrTableCell11.Text = "COMPLETED";
            xrTableCell11.Weight = 1D;
            // 
            // xrTableCell12
            // 
            xrTableCell12.Name = "xrTableCell12";
            xrTableCell12.Text = "ASSISTANCE";
            xrTableCell12.Weight = 1D;
            // 
            // xrTableCell13
            // 
            xrTableCell13.Name = "xrTableCell13";
            xrTableCell13.Text = "DEFERRED";
            xrTableCell13.Weight = 1D;
            // 
            // ReportHeader
            // 
            ReportHeader.Controls.AddRange(new XRControl[]
            {
                xrTable2,
                xrTable1
            });
            ReportHeader.HeightF = 246.8749F;
            ReportHeader.Name = "ReportHeader";
            // 
            // GroupHeader1
            // 
            GroupHeader1.Controls.AddRange(new XRControl[]
            {
                xrLabel3
            });
            GroupHeader1.GroupFields.AddRange(new[]
            {
                new GroupField("Status", XRColumnSortOrder.Ascending)
            });
            GroupHeader1.HeightF = 26.04167F;
            GroupHeader1.Name = "GroupHeader1";
            // 
            // xrLabel3
            // 
            xrLabel3.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "Status")
            });
            xrLabel3.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            xrLabel3.ForeColor = Color.LawnGreen;
            xrLabel3.LocationFloat = new PointFloat(0F, 0F);
            xrLabel3.Name = "xrLabel3";
            xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 100F);
            xrLabel3.SizeF = new SizeF(648.9583F, 26.04167F);
            xrLabel3.StylePriority.UseFont = false;
            xrLabel3.StylePriority.UseForeColor = false;
            xrLabel3.StylePriority.UseTextAlignment = false;
            xrLabel3.TextAlignment = TextAlignment.BottomCenter;
            // 
            // statusCompleted
            // 
            statusCompleted.Expression = "[][ToStr([Status]) = \'Completed\'].Count()";
            statusCompleted.FieldType = FieldType.Int32;
            statusCompleted.Name = "statusCompleted";
            // 
            // statusNotStarted
            // 
            statusNotStarted.Expression = "[][ToStr([Status]) = \'NotStarted\'].Count()";
            statusNotStarted.FieldType = FieldType.Int32;
            statusNotStarted.Name = "statusNotStarted";
            // 
            // statusInProgress
            // 
            statusInProgress.Expression = "[][ToStr([Status]) = \'InProgress\'].Count()";
            statusInProgress.FieldType = FieldType.Int32;
            statusInProgress.Name = "statusInProgress";
            // 
            // statusNeedAssistance
            // 
            statusNeedAssistance.Expression = "[][ToStr([Status]) = \'NeedAssistance\'].Count()";
            statusNeedAssistance.FieldType = FieldType.Int32;
            statusNeedAssistance.Name = "statusNeedAssistance";
            // 
            // statusDeferred
            // 
            statusDeferred.Expression = "[][ToStr([Status]) = \'Deferred\'].Count()";
            statusDeferred.FieldType = FieldType.Int32;
            statusDeferred.Name = "statusDeferred";
            // 
            // parameter1
            // 
            parameter1.Description = "Parameter1";
            parameter1.Name = "parameter1";
            parameter1.Type = typeof(bool);
            parameter1.ValueInfo = "True";
            parameter1.Visible = false;
            // 
            // GroupFooter1
            // 
            GroupFooter1.HeightF = 0F;
            GroupFooter1.Name = "GroupFooter1";
            GroupFooter1.PageBreak = PageBreak.AfterBand;
            // 
            // LeaveList
            // 
            Bands.AddRange(new Band[]
            {
                topMarginBand1,
                detailBand1,
                bottomMarginBand1,
                ReportHeader,
                GroupHeader1,
                GroupFooter1
            });
            CalculatedFields.AddRange(new[]
            {
                statusCompleted,
                statusNotStarted,
                statusInProgress,
                statusNeedAssistance,
                statusDeferred
            });
            DataSource = bindingSource1;
            DesignerOptions.ShowExportWarnings = false;
            DrawWatermark = true;
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margins = new Margins(100, 82, 138, 100);
            Parameters.AddRange(new[]
            {
                parameter1
            });
            SnappingMode = SnappingMode.SnapToGrid;
            SnapToGrid = false;
            Version = "15.1";
            DataSourceDemanded += LeaveList_DataSourceDemanded;
            ((ISupportInitialize) xrTable4).EndInit();
            ((ISupportInitialize) xrTable3).EndInit();
            ((ISupportInitialize) bindingSource1).EndInit();
            ((ISupportInitialize) xrTable1).EndInit();
            ((ISupportInitialize) xrTable2).EndInit();
            ((ISupportInitialize) this).EndInit();
        }

        private void LeaveList_DataSourceDemanded(object sender, EventArgs e)
        {
            if (Equals(true, parameter1.Value))
            {
                xrTableCell3.Text = "Grouped by Status | Sorted by Due Date";
                detailBand1.SortFields[0].FieldName = "DueDate";
            }
            else
            {
                xrTableCell3.Text = "Grouped by Status | Sorted by Start Date";
                detailBand1.SortFields[0].FieldName = "StartDate";
            }
        }
    }
}