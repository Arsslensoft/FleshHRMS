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
    internal class EmployeeProfile : XtraReport
    {
        private BindingSource bindingSource1;
        private BindingSource bindingSource2;
        private BottomMarginBand bottomMarginBand1;
        private IContainer components;
        private DetailBand Detail;
        private DetailBand Detail1;
        private DetailBand Detail2;
        private DetailBand detailBand1;
        private DetailReportBand DetailReport;
        private DetailReportBand DetailReport1;
        private DetailReportBand DetailReport2;
        private Parameter parameterId;
        private ReportHeaderBand ReportHeader;
        private ReportHeaderBand ReportHeader1;
        private ReportHeaderBand ReportHeader2;
        private ReportHeaderBand ReportHeader3;
        private Parameter ShowEvaluationsParameter;
        private TopMarginBand topMarginBand1;
        private XRPageInfo xrPageInfo1;
        private XRPageInfo xrPageInfo2;
        private XRPictureBox xrPictureBox1;
        private XRPictureBox xrPictureBox2;
        private XRTable xrTable1;
        private XRTable xrTable2;
        private XRTable xrTable3;
        private XRTable xrTable4;
        private XRTable xrTable5;
        private XRTable xrTable6;
        private XRTable xrTable7;
        private XRTable xrTable8;
        private XRTable xrTable9;
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
        private XRTableCell xrTableCell27;
        private XRTableCell xrTableCell28;
        private XRTableCell xrTableCell29;
        private XRTableCell xrTableCell3;
        private XRTableCell xrTableCell30;
        private XRTableCell xrTableCell31;
        private XRTableCell xrTableCell32;
        private XRTableCell xrTableCell33;
        private XRTableCell xrTableCell34;
        private XRTableCell xrTableCell35;
        private XRTableCell xrTableCell37;
        private XRTableCell xrTableCell38;
        private XRTableCell xrTableCell4;
        private XRTableCell xrTableCell5;
        private XRTableCell xrTableCell6;
        private XRTableCell xrTableCell7;
        private XRTableCell xrTableCell8;
        private XRTableCell xrTableCell9;
        private XRTableRow xrTableRow1;
        private XRTableRow xrTableRow10;
        private XRTableRow xrTableRow11;
        private XRTableRow xrTableRow12;
        private XRTableRow xrTableRow13;
        private XRTableRow xrTableRow14;
        private XRTableRow xrTableRow15;
        private XRTableRow xrTableRow16;
        private XRTableRow xrTableRow17;
        private XRTableRow xrTableRow18;
        private XRTableRow xrTableRow2;
        private XRTableRow xrTableRow3;
        private XRTableRow xrTableRow4;
        private XRTableRow xrTableRow5;
        private XRTableRow xrTableRow6;
        private XRTableRow xrTableRow7;
        private XRTableRow xrTableRow8;
        private XRTableRow xrTableRow9;

        public EmployeeProfile()
        {
            InitializeComponent();
            BeforePrint += EmployeeProfile_BeforePrint;
        }

        private void EmployeeProfile_BeforePrint(object sender, PrintEventArgs e)
        {
            SetShowEvaluations((bool) Parameters["ShowEvaluationsParameter"].Value);
        }

        public void SetShowEvaluations(bool show)
        {
            if (DetailReport.Visible != show)
            {
                DetailReport.Visible = show;
            }
        }

        private void InitializeComponent()
        {
            components = new Container();
            var resources = new ComponentResourceManager(typeof(EmployeeProfile));
            topMarginBand1 = new TopMarginBand();
            xrPictureBox1 = new XRPictureBox();
            detailBand1 = new DetailBand();
            xrTable3 = new XRTable();
            xrTableRow13 = new XRTableRow();
            xrTableCell20 = new XRTableCell();
            xrTableCell21 = new XRTableCell();
            xrTableRow14 = new XRTableRow();
            xrTableCell22 = new XRTableCell();
            xrTableCell23 = new XRTableCell();
            xrTableRow15 = new XRTableRow();
            xrTableCell24 = new XRTableCell();
            xrTableCell25 = new XRTableCell();
            xrTableRow16 = new XRTableRow();
            xrTableCell26 = new XRTableCell();
            xrTableCell27 = new XRTableCell();
            xrTableRow17 = new XRTableRow();
            xrTableCell28 = new XRTableCell();
            xrTableCell29 = new XRTableCell();
            xrTable2 = new XRTable();
            xrTableRow8 = new XRTableRow();
            xrTableCell15 = new XRTableCell();
            xrTableRow7 = new XRTableRow();
            xrTableCell14 = new XRTableCell();
            xrTableRow9 = new XRTableRow();
            xrTableCell16 = new XRTableCell();
            xrPictureBox2 = new XRPictureBox();
            bottomMarginBand1 = new BottomMarginBand();
            xrPageInfo2 = new XRPageInfo();
            xrPageInfo1 = new XRPageInfo();
            parameterId = new Parameter();
            ReportHeader = new ReportHeaderBand();
            xrTable1 = new XRTable();
            xrTableRow1 = new XRTableRow();
            xrTableCell1 = new XRTableCell();
            xrTableCell2 = new XRTableCell();
            xrTableCell3 = new XRTableCell();
            DetailReport = new DetailReportBand();
            Detail = new DetailBand();
            xrTable5 = new XRTable();
            xrTableRow3 = new XRTableRow();
            xrTableCell7 = new XRTableCell();
            xrTableCell8 = new XRTableCell();
            xrTableRow4 = new XRTableRow();
            xrTableCell9 = new XRTableCell();
            xrTableCell10 = new XRTableCell();
            ReportHeader1 = new ReportHeaderBand();
            xrTable4 = new XRTable();
            xrTableRow2 = new XRTableRow();
            xrTableCell4 = new XRTableCell();
            xrTableCell5 = new XRTableCell();
            xrTableCell6 = new XRTableCell();
            bindingSource1 = new BindingSource(components);
            ShowEvaluationsParameter = new Parameter();
            bindingSource2 = new BindingSource(components);
            DetailReport1 = new DetailReportBand();
            Detail1 = new DetailBand();
            xrTable7 = new XRTable();
            xrTableRow6 = new XRTableRow();
            xrTableCell17 = new XRTableCell();
            xrTableCell18 = new XRTableCell();
            xrTableRow10 = new XRTableRow();
            xrTableCell19 = new XRTableCell();
            xrTableCell30 = new XRTableCell();
            ReportHeader2 = new ReportHeaderBand();
            xrTable6 = new XRTable();
            xrTableRow5 = new XRTableRow();
            xrTableCell11 = new XRTableCell();
            xrTableCell12 = new XRTableCell();
            xrTableCell13 = new XRTableCell();
            DetailReport2 = new DetailReportBand();
            Detail2 = new DetailBand();
            xrTable9 = new XRTable();
            xrTableRow12 = new XRTableRow();
            xrTableCell37 = new XRTableCell();
            xrTableCell34 = new XRTableCell();
            xrTableRow18 = new XRTableRow();
            xrTableCell35 = new XRTableCell();
            ReportHeader3 = new ReportHeaderBand();
            xrTable8 = new XRTable();
            xrTableRow11 = new XRTableRow();
            xrTableCell31 = new XRTableCell();
            xrTableCell32 = new XRTableCell();
            xrTableCell33 = new XRTableCell();
            xrTableCell38 = new XRTableCell();
            ((ISupportInitialize) xrTable3).BeginInit();
            ((ISupportInitialize) xrTable2).BeginInit();
            ((ISupportInitialize) xrTable1).BeginInit();
            ((ISupportInitialize) xrTable5).BeginInit();
            ((ISupportInitialize) xrTable4).BeginInit();
            ((ISupportInitialize) bindingSource1).BeginInit();
            ((ISupportInitialize) bindingSource2).BeginInit();
            ((ISupportInitialize) xrTable7).BeginInit();
            ((ISupportInitialize) xrTable6).BeginInit();
            ((ISupportInitialize) xrTable9).BeginInit();
            ((ISupportInitialize) xrTable8).BeginInit();
            ((ISupportInitialize) this).BeginInit();
            // 
            // topMarginBand1
            // 
            topMarginBand1.Controls.AddRange(new XRControl[]
            {
                xrPictureBox1
            });
            topMarginBand1.Font = new Font("Segoe UI", 9.75F);
            topMarginBand1.HeightF = 160F;
            topMarginBand1.Name = "topMarginBand1";
            topMarginBand1.StylePriority.UseFont = false;
            // 
            // xrPictureBox1
            // 
            xrPictureBox1.Image = (Image) resources.GetObject("xrPictureBox1.Image");
            xrPictureBox1.LocationFloat = new PointFloat(373.765F, 0F);
            xrPictureBox1.Name = "xrPictureBox1";
            xrPictureBox1.Padding = new PaddingInfo(0, 0, 0, 0, 100F);
            xrPictureBox1.SizeF = new SizeF(442.9017F, 160F);
            xrPictureBox1.Sizing = ImageSizeMode.Squeeze;
            xrPictureBox1.StylePriority.UsePadding = false;
            // 
            // detailBand1
            // 
            detailBand1.Controls.AddRange(new XRControl[]
            {
                xrTable3,
                xrTable2,
                xrPictureBox2
            });
            detailBand1.HeightF = 308.9286F;
            detailBand1.KeepTogether = true;
            detailBand1.Name = "detailBand1";
            // 
            // xrTable3
            // 
            xrTable3.LocationFloat = new PointFloat(179.1667F, 181.25F);
            xrTable3.Name = "xrTable3";
            xrTable3.Padding = new PaddingInfo(2, 0, 0, 0, 100F);
            xrTable3.Rows.AddRange(new[]
            {
                xrTableRow13,
                xrTableRow14,
                xrTableRow15,
                xrTableRow16,
                xrTableRow17
            });
            xrTable3.SizeF = new SizeF(461.5F, 114.1369F);
            xrTable3.StylePriority.UsePadding = false;
            // 
            // xrTableRow13
            // 
            xrTableRow13.Cells.AddRange(new[]
            {
                xrTableCell20,
                xrTableCell21
            });
            xrTableRow13.Name = "xrTableRow13";
            xrTableRow13.Weight = 0.65333328891811748D;
            // 
            // xrTableCell20
            // 
            xrTableCell20.ForeColor = Color.FromArgb(166, 166, 166);
            xrTableCell20.Name = "xrTableCell20";
            xrTableCell20.StylePriority.UseForeColor = false;
            xrTableCell20.Text = "ADRESSE";
            xrTableCell20.Weight = 1.5238964537134105D;
            // 
            // xrTableCell21
            // 
            xrTableCell21.ForeColor = Color.FromArgb(166, 166, 166);
            xrTableCell21.Name = "xrTableCell21";
            xrTableCell21.StylePriority.UseForeColor = false;
            xrTableCell21.Text = "TELEPHONE";
            xrTableCell21.Weight = 1.4761035462865895D;
            // 
            // xrTableRow14
            // 
            xrTableRow14.Cells.AddRange(new[]
            {
                xrTableCell22,
                xrTableCell23
            });
            xrTableRow14.Name = "xrTableRow14";
            xrTableRow14.Weight = 0.47484509486472504D;
            // 
            // xrTableCell22
            // 
            xrTableCell22.Name = "xrTableCell22";
            xrTableCell22.Text = "[Address.Line]";
            xrTableCell22.Weight = 1.5238964675999105D;
            // 
            // xrTableCell23
            // 
            xrTableCell23.Name = "xrTableCell23";
            xrTableCell23.Text = "[MobilePhone] (Mobile)";
            xrTableCell23.Weight = 1.4761035324000895D;
            // 
            // xrTableRow15
            // 
            xrTableRow15.Cells.AddRange(new[]
            {
                xrTableCell24,
                xrTableCell25
            });
            xrTableRow15.Name = "xrTableRow15";
            xrTableRow15.Weight = 1.2140452917989133D;
            // 
            // xrTableCell24
            // 
            xrTableCell24.Name = "xrTableCell24";
            xrTableCell24.Text = "[Address.CityLine]";
            xrTableCell24.Weight = 1.5238964514898998D;
            // 
            // xrTableCell25
            // 
            xrTableCell25.Name = "xrTableCell25";
            xrTableCell25.Text = "[HomePhone] (Fixe)";
            xrTableCell25.Weight = 1.4761035485101002D;
            // 
            // xrTableRow16
            // 
            xrTableRow16.Cells.AddRange(new[]
            {
                xrTableCell26,
                xrTableCell27
            });
            xrTableRow16.Name = "xrTableRow16";
            xrTableRow16.Weight = 0.56444328332196525D;
            // 
            // xrTableCell26
            // 
            xrTableCell26.ForeColor = Color.FromArgb(166, 166, 166);
            xrTableCell26.Name = "xrTableCell26";
            xrTableCell26.StylePriority.UseForeColor = false;
            xrTableCell26.Text = "EMAIL";
            xrTableCell26.Weight = 1.5238964900469829D;
            // 
            // xrTableCell27
            // 
            xrTableCell27.ForeColor = Color.FromArgb(166, 166, 166);
            xrTableCell27.Name = "xrTableCell27";
            xrTableCell27.StylePriority.UseForeColor = false;
            xrTableCell27.Text = "SKYPE";
            xrTableCell27.Weight = 1.4761035099530171D;
            // 
            // xrTableRow17
            // 
            xrTableRow17.Cells.AddRange(new[]
            {
                xrTableCell28,
                xrTableCell29
            });
            xrTableRow17.Name = "xrTableRow17";
            xrTableRow17.Weight = 0.50222112518535189D;
            // 
            // xrTableCell28
            // 
            xrTableCell28.Name = "xrTableCell28";
            xrTableCell28.Text = "[Email]";
            xrTableCell28.Weight = 1.523896534941128D;
            // 
            // xrTableCell29
            // 
            xrTableCell29.Name = "xrTableCell29";
            xrTableCell29.Text = "[Skype]";
            xrTableCell29.Weight = 1.476103465058872D;
            // 
            // xrTable2
            // 
            xrTable2.LocationFloat = new PointFloat(179.1667F, 14.58333F);
            xrTable2.Name = "xrTable2";
            xrTable2.Padding = new PaddingInfo(2, 0, 0, 0, 100F);
            xrTable2.Rows.AddRange(new[]
            {
                xrTableRow8,
                xrTableRow7,
                xrTableRow9
            });
            xrTable2.SizeF = new SizeF(462.5F, 129.6131F);
            xrTable2.StylePriority.UsePadding = false;
            // 
            // xrTableRow8
            // 
            xrTableRow8.Cells.AddRange(new[]
            {
                xrTableCell15
            });
            xrTableRow8.Name = "xrTableRow8";
            xrTableRow8.Weight = 1.3733330546061278D;
            // 
            // xrTableCell15
            // 
            xrTableCell15.Font = new Font("Segoe UI", 26.25F);
            xrTableCell15.ForeColor = Color.FromArgb(234, 178, 144);
            xrTableCell15.Name = "xrTableCell15";
            xrTableCell15.StylePriority.UseFont = false;
            xrTableCell15.StylePriority.UseForeColor = false;
            xrTableCell15.Text = "[Prefix].[FullName]";
            xrTableCell15.Weight = 3D;
            // 
            // xrTableRow7
            // 
            xrTableRow7.Cells.AddRange(new[]
            {
                xrTableCell14
            });
            xrTableRow7.Name = "xrTableRow7";
            xrTableRow7.Weight = 1.7263104059547862D;
            // 
            // xrTableCell14
            // 
            xrTableCell14.Font = new Font("Segoe UI", 14.25F);
            xrTableCell14.ForeColor = Color.FromArgb(127, 127, 127);
            xrTableCell14.Name = "xrTableCell14";
            xrTableCell14.StylePriority.UseFont = false;
            xrTableCell14.StylePriority.UseForeColor = false;
            xrTableCell14.Text = "[TItle]";
            xrTableCell14.Weight = 3D;
            // 
            // xrTableRow9
            // 
            xrTableRow9.Cells.AddRange(new[]
            {
                xrTableCell16
            });
            xrTableRow9.Name = "xrTableRow9";
            xrTableRow9.Weight = 0.57521688842586149D;
            // 
            // xrTableCell16
            // 
            xrTableCell16.Name = "xrTableCell16";
            xrTableCell16.Text = "[PersonalProfile]";
            xrTableCell16.Weight = 3D;
            // 
            // xrPictureBox2
            // 
            xrPictureBox2.BorderColor = Color.FromArgb(217, 217, 217);
            xrPictureBox2.Borders = BorderSide.Left | BorderSide.Top
                                    | BorderSide.Right
                                    | BorderSide.Bottom;
            xrPictureBox2.BorderWidth = 2F;
            xrPictureBox2.DataBindings.AddRange(new[]
            {
                new XRBinding("Image", null, "Photo")
            });
            xrPictureBox2.LocationFloat = new PointFloat(10.00001F, 10.00001F);
            xrPictureBox2.Name = "xrPictureBox2";
            xrPictureBox2.SizeF = new SizeF(154.5417F, 205F);
            xrPictureBox2.Sizing = ImageSizeMode.ZoomImage;
            xrPictureBox2.StylePriority.UseBorderColor = false;
            xrPictureBox2.StylePriority.UseBorders = false;
            xrPictureBox2.StylePriority.UseBorderWidth = false;
            // 
            // bottomMarginBand1
            // 
            bottomMarginBand1.Controls.AddRange(new XRControl[]
            {
                xrPageInfo2,
                xrPageInfo1
            });
            bottomMarginBand1.HeightF = 127F;
            bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // xrPageInfo2
            // 
            xrPageInfo2.ForeColor = Color.FromArgb(166, 166, 166);
            xrPageInfo2.Format = "{0:MMMM dd, yyyy}";
            xrPageInfo2.LocationFloat = new PointFloat(544.5415F, 18.00003F);
            xrPageInfo2.Name = "xrPageInfo2";
            xrPageInfo2.Padding = new PaddingInfo(2, 2, 0, 0, 100F);
            xrPageInfo2.PageInfo = PageInfo.DateTime;
            xrPageInfo2.SizeF = new SizeF(99.95856F, 23F);
            xrPageInfo2.StylePriority.UseForeColor = false;
            // 
            // xrPageInfo1
            // 
            xrPageInfo1.ForeColor = Color.FromArgb(166, 166, 166);
            xrPageInfo1.Format = "Page {0} of {1}";
            xrPageInfo1.LocationFloat = new PointFloat(2.000014F, 18.00003F);
            xrPageInfo1.Name = "xrPageInfo1";
            xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100F);
            xrPageInfo1.SizeF = new SizeF(102.0834F, 23.00008F);
            xrPageInfo1.StylePriority.UseForeColor = false;
            // 
            // parameterId
            // 
            parameterId.Description = "ParameterId";
            parameterId.Name = "parameterId";
            parameterId.Type = typeof(Guid);
            parameterId.Visible = false;
            // 
            // ReportHeader
            // 
            ReportHeader.Controls.AddRange(new XRControl[]
            {
                xrTable1
            });
            ReportHeader.HeightF = 41F;
            ReportHeader.Name = "ReportHeader";
            // 
            // xrTable1
            // 
            xrTable1.LocationFloat = new PointFloat(0F, 0F);
            xrTable1.Name = "xrTable1";
            xrTable1.Rows.AddRange(new[]
            {
                xrTableRow1
            });
            xrTable1.SizeF = new SizeF(647.9999F, 28.125F);
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
            xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            xrTableCell1.BackColor = Color.LimeGreen;
            xrTableCell1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableCell1.ForeColor = Color.White;
            xrTableCell1.Name = "xrTableCell1";
            xrTableCell1.Padding = new PaddingInfo(15, 0, 0, 0, 100F);
            xrTableCell1.StylePriority.UseBackColor = false;
            xrTableCell1.StylePriority.UseFont = false;
            xrTableCell1.StylePriority.UseForeColor = false;
            xrTableCell1.StylePriority.UsePadding = false;
            xrTableCell1.StylePriority.UseTextAlignment = false;
            xrTableCell1.Text = "Employé";
            xrTableCell1.TextAlignment = TextAlignment.MiddleLeft;
            xrTableCell1.Weight = 0.79745375929065565D;
            // 
            // xrTableCell2
            // 
            xrTableCell2.Name = "xrTableCell2";
            xrTableCell2.Weight = 0.036651192371484773D;
            // 
            // xrTableCell3
            // 
            xrTableCell3.BackColor = Color.FromArgb(217, 217, 217);
            xrTableCell3.Name = "xrTableCell3";
            xrTableCell3.StylePriority.UseBackColor = false;
            xrTableCell3.Weight = 2.1658950483378594D;
            // 
            // DetailReport
            // 
            DetailReport.Bands.AddRange(new Band[]
            {
                Detail,
                ReportHeader1
            });
            DetailReport.DataMember = "Absences";
            DetailReport.DataSource = bindingSource1;
            DetailReport.Expanded = false;
            DetailReport.Level = 0;
            DetailReport.Name = "DetailReport";
            // 
            // Detail
            // 
            Detail.Controls.AddRange(new XRControl[]
            {
                xrTable5
            });
            Detail.HeightF = 85.5F;
            Detail.KeepTogether = true;
            Detail.Name = "Detail";
            // 
            // xrTable5
            // 
            xrTable5.LocationFloat = new PointFloat(0F, 19.875F);
            xrTable5.Name = "xrTable5";
            xrTable5.Padding = new PaddingInfo(4, 0, 2, 0, 100F);
            xrTable5.Rows.AddRange(new[]
            {
                xrTableRow3,
                xrTableRow4
            });
            xrTable5.SizeF = new SizeF(647.9999F, 65.625F);
            xrTable5.StylePriority.UsePadding = false;
            // 
            // xrTableRow3
            // 
            xrTableRow3.Cells.AddRange(new[]
            {
                xrTableCell7,
                xrTableCell8
            });
            xrTableRow3.Name = "xrTableRow3";
            xrTableRow3.Weight = 0.52857141212930436D;
            // 
            // xrTableCell7
            // 
            xrTableCell7.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "Absences.StartDate", "{0:M/d/yyyy}")
            });
            xrTableCell7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableCell7.Name = "xrTableCell7";
            xrTableCell7.StylePriority.UseFont = false;
            xrTableCell7.Weight = 0.83410493056778723D;
            // 
            // xrTableCell8
            // 
            xrTableCell8.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "Absences.Comment")
            });
            xrTableCell8.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            xrTableCell8.Name = "xrTableCell8";
            xrTableCell8.StylePriority.UseFont = false;
            xrTableCell8.Weight = 2.1658950694322128D;
            // 
            // xrTableRow4
            // 
            xrTableRow4.Cells.AddRange(new[]
            {
                xrTableCell9,
                xrTableCell10
            });
            xrTableRow4.Name = "xrTableRow4";
            xrTableRow4.Weight = 0.37142861926020571D;
            // 
            // xrTableCell9
            // 
            xrTableCell9.Name = "xrTableCell9";
            xrTableCell9.Weight = 0.83410493056778723D;
            // 
            // xrTableCell10
            // 
            xrTableCell10.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "Absences.Comment")
            });
            xrTableCell10.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableCell10.Name = "xrTableCell10";
            xrTableCell10.StylePriority.UseFont = false;
            xrTableCell10.Weight = 2.1658950694322128D;
            // 
            // ReportHeader1
            // 
            ReportHeader1.Controls.AddRange(new XRControl[]
            {
                xrTable4
            });
            ReportHeader1.HeightF = 28.125F;
            ReportHeader1.Name = "ReportHeader1";
            // 
            // xrTable4
            // 
            xrTable4.LocationFloat = new PointFloat(0F, 0F);
            xrTable4.Name = "xrTable4";
            xrTable4.Rows.AddRange(new[]
            {
                xrTableRow2
            });
            xrTable4.SizeF = new SizeF(647.9999F, 28.125F);
            // 
            // xrTableRow2
            // 
            xrTableRow2.Cells.AddRange(new[]
            {
                xrTableCell4,
                xrTableCell5,
                xrTableCell6
            });
            xrTableRow2.Name = "xrTableRow2";
            xrTableRow2.Weight = 1D;
            // 
            // xrTableCell4
            // 
            xrTableCell4.BackColor = Color.LimeGreen;
            xrTableCell4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableCell4.ForeColor = Color.White;
            xrTableCell4.Name = "xrTableCell4";
            xrTableCell4.Padding = new PaddingInfo(15, 0, 0, 0, 100F);
            xrTableCell4.StylePriority.UseBackColor = false;
            xrTableCell4.StylePriority.UseFont = false;
            xrTableCell4.StylePriority.UseForeColor = false;
            xrTableCell4.StylePriority.UsePadding = false;
            xrTableCell4.StylePriority.UseTextAlignment = false;
            xrTableCell4.Text = "Absences";
            xrTableCell4.TextAlignment = TextAlignment.MiddleLeft;
            xrTableCell4.Weight = 0.79745375929065565D;
            // 
            // xrTableCell5
            // 
            xrTableCell5.Name = "xrTableCell5";
            xrTableCell5.Weight = 0.036651192371484773D;
            // 
            // xrTableCell6
            // 
            xrTableCell6.BackColor = Color.FromArgb(217, 217, 217);
            xrTableCell6.Name = "xrTableCell6";
            xrTableCell6.StylePriority.UseBackColor = false;
            xrTableCell6.Weight = 2.1658950483378594D;
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(Employee);
            // 
            // ShowEvaluationsParameter
            // 
            ShowEvaluationsParameter.Description = "ShowEvaluations";
            ShowEvaluationsParameter.Name = "ShowEvaluationsParameter";
            ShowEvaluationsParameter.Type = typeof(bool);
            ShowEvaluationsParameter.ValueInfo = "True";
            ShowEvaluationsParameter.Visible = false;
            // 
            // DetailReport1
            // 
            DetailReport1.Bands.AddRange(new Band[]
            {
                Detail1,
                ReportHeader2
            });
            DetailReport1.DataMember = "AssignedLeaves";
            DetailReport1.DataSource = bindingSource1;
            DetailReport1.Level = 1;
            DetailReport1.Name = "DetailReport1";
            // 
            // Detail1
            // 
            Detail1.Controls.AddRange(new XRControl[]
            {
                xrTable7
            });
            Detail1.HeightF = 65.625F;
            Detail1.Name = "Detail1";
            // 
            // xrTable7
            // 
            xrTable7.LocationFloat = new PointFloat(2.000014F, 0F);
            xrTable7.Name = "xrTable7";
            xrTable7.Padding = new PaddingInfo(4, 0, 2, 0, 100F);
            xrTable7.Rows.AddRange(new[]
            {
                xrTableRow6,
                xrTableRow10
            });
            xrTable7.SizeF = new SizeF(647.9999F, 65.625F);
            xrTable7.StylePriority.UsePadding = false;
            // 
            // xrTableRow6
            // 
            xrTableRow6.Cells.AddRange(new[]
            {
                xrTableCell17,
                xrTableCell18
            });
            xrTableRow6.Name = "xrTableRow6";
            xrTableRow6.Weight = 0.52857141212930436D;
            // 
            // xrTableCell17
            // 
            xrTableCell17.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "AssignedLeaves.StartDate", "{0:M/d/yyyy}")
            });
            xrTableCell17.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableCell17.Name = "xrTableCell17";
            xrTableCell17.StylePriority.UseFont = false;
            xrTableCell17.Weight = 0.83410493056778723D;
            // 
            // xrTableCell18
            // 
            xrTableCell18.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "AssignedLeaves.Subject")
            });
            xrTableCell18.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            xrTableCell18.Name = "xrTableCell18";
            xrTableCell18.StylePriority.UseFont = false;
            xrTableCell18.Weight = 2.1658950694322128D;
            // 
            // xrTableRow10
            // 
            xrTableRow10.Cells.AddRange(new[]
            {
                xrTableCell19,
                xrTableCell30
            });
            xrTableRow10.Name = "xrTableRow10";
            xrTableRow10.Weight = 0.37142861926020571D;
            // 
            // xrTableCell19
            // 
            xrTableCell19.Name = "xrTableCell19";
            xrTableCell19.Weight = 0.83410493056778723D;
            // 
            // xrTableCell30
            // 
            xrTableCell30.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "AssignedLeaves.Description")
            });
            xrTableCell30.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableCell30.Name = "xrTableCell30";
            xrTableCell30.StylePriority.UseFont = false;
            xrTableCell30.Weight = 2.1658950694322128D;
            // 
            // ReportHeader2
            // 
            ReportHeader2.Controls.AddRange(new XRControl[]
            {
                xrTable6
            });
            ReportHeader2.HeightF = 28.125F;
            ReportHeader2.Name = "ReportHeader2";
            // 
            // xrTable6
            // 
            xrTable6.LocationFloat = new PointFloat(2.000014F, 0F);
            xrTable6.Name = "xrTable6";
            xrTable6.Rows.AddRange(new[]
            {
                xrTableRow5
            });
            xrTable6.SizeF = new SizeF(647.9999F, 28.125F);
            // 
            // xrTableRow5
            // 
            xrTableRow5.Cells.AddRange(new[]
            {
                xrTableCell11,
                xrTableCell12,
                xrTableCell13
            });
            xrTableRow5.Name = "xrTableRow5";
            xrTableRow5.Weight = 1D;
            // 
            // xrTableCell11
            // 
            xrTableCell11.BackColor = Color.LimeGreen;
            xrTableCell11.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableCell11.ForeColor = Color.White;
            xrTableCell11.Name = "xrTableCell11";
            xrTableCell11.Padding = new PaddingInfo(15, 0, 0, 0, 100F);
            xrTableCell11.StylePriority.UseBackColor = false;
            xrTableCell11.StylePriority.UseFont = false;
            xrTableCell11.StylePriority.UseForeColor = false;
            xrTableCell11.StylePriority.UsePadding = false;
            xrTableCell11.StylePriority.UseTextAlignment = false;
            xrTableCell11.Text = "Demandes de congés";
            xrTableCell11.TextAlignment = TextAlignment.MiddleLeft;
            xrTableCell11.Weight = 0.79745375929065565D;
            // 
            // xrTableCell12
            // 
            xrTableCell12.Name = "xrTableCell12";
            xrTableCell12.Weight = 0.036651192371484773D;
            // 
            // xrTableCell13
            // 
            xrTableCell13.BackColor = Color.FromArgb(217, 217, 217);
            xrTableCell13.Name = "xrTableCell13";
            xrTableCell13.StylePriority.UseBackColor = false;
            xrTableCell13.Weight = 2.1658950483378594D;
            // 
            // DetailReport2
            // 
            DetailReport2.Bands.AddRange(new Band[]
            {
                Detail2,
                ReportHeader3
            });
            DetailReport2.DataMember = "Shifts";
            DetailReport2.DataSource = bindingSource1;
            DetailReport2.Level = 2;
            DetailReport2.Name = "DetailReport2";
            // 
            // Detail2
            // 
            Detail2.Controls.AddRange(new XRControl[]
            {
                xrTable9
            });
            Detail2.HeightF = 66.66666F;
            Detail2.Name = "Detail2";
            // 
            // xrTable9
            // 
            xrTable9.LocationFloat = new PointFloat(2.000014F, 0F);
            xrTable9.Name = "xrTable9";
            xrTable9.Padding = new PaddingInfo(4, 0, 2, 0, 100F);
            xrTable9.Rows.AddRange(new[]
            {
                xrTableRow12,
                xrTableRow18
            });
            xrTable9.SizeF = new SizeF(647.9999F, 65.625F);
            xrTable9.StylePriority.UsePadding = false;
            // 
            // xrTableRow12
            // 
            xrTableRow12.Cells.AddRange(new[]
            {
                xrTableCell37,
                xrTableCell34
            });
            xrTableRow12.Name = "xrTableRow12";
            xrTableRow12.Weight = 0.52857141212930436D;
            // 
            // xrTableCell37
            // 
            xrTableCell37.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "Shifts.Start", "{0:dddd HH:mm}")
            });
            xrTableCell37.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableCell37.Name = "xrTableCell37";
            xrTableCell37.StylePriority.UseFont = false;
            xrTableCell37.Text = "xrTableCell37";
            xrTableCell37.Weight = 0.41705246528389361D;
            // 
            // xrTableCell34
            // 
            xrTableCell34.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "Shifts.End", "{0:dddd HH:mm}")
            });
            xrTableCell34.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableCell34.Name = "xrTableCell34";
            xrTableCell34.StylePriority.UseFont = false;
            xrTableCell34.Weight = 0.41705246528389361D;
            // 
            // xrTableRow18
            // 
            xrTableRow18.Cells.AddRange(new[]
            {
                xrTableCell35
            });
            xrTableRow18.Name = "xrTableRow18";
            xrTableRow18.Weight = 0.37142861926020571D;
            // 
            // xrTableCell35
            // 
            xrTableCell35.DataBindings.AddRange(new[]
            {
                new XRBinding("Text", null, "Shifts.Subject")
            });
            xrTableCell35.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            xrTableCell35.Name = "xrTableCell35";
            xrTableCell35.StylePriority.UseFont = false;
            xrTableCell35.Weight = 3.6658950694322128D;
            // 
            // ReportHeader3
            // 
            ReportHeader3.Controls.AddRange(new XRControl[]
            {
                xrTable8
            });
            ReportHeader3.HeightF = 28.125F;
            ReportHeader3.Name = "ReportHeader3";
            // 
            // xrTable8
            // 
            xrTable8.LocationFloat = new PointFloat(2.000014F, 0F);
            xrTable8.Name = "xrTable8";
            xrTable8.Rows.AddRange(new[]
            {
                xrTableRow11
            });
            xrTable8.SizeF = new SizeF(647.9999F, 28.125F);
            // 
            // xrTableRow11
            // 
            xrTableRow11.Cells.AddRange(new[]
            {
                xrTableCell31,
                xrTableCell32,
                xrTableCell33
            });
            xrTableRow11.Name = "xrTableRow11";
            xrTableRow11.Weight = 1D;
            // 
            // xrTableCell31
            // 
            xrTableCell31.BackColor = Color.LimeGreen;
            xrTableCell31.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xrTableCell31.ForeColor = Color.White;
            xrTableCell31.Name = "xrTableCell31";
            xrTableCell31.Padding = new PaddingInfo(15, 0, 0, 0, 100F);
            xrTableCell31.StylePriority.UseBackColor = false;
            xrTableCell31.StylePriority.UseFont = false;
            xrTableCell31.StylePriority.UseForeColor = false;
            xrTableCell31.StylePriority.UsePadding = false;
            xrTableCell31.StylePriority.UseTextAlignment = false;
            xrTableCell31.Text = "Temps de travail";
            xrTableCell31.TextAlignment = TextAlignment.MiddleLeft;
            xrTableCell31.Weight = 0.79745375929065565D;
            // 
            // xrTableCell32
            // 
            xrTableCell32.Name = "xrTableCell32";
            xrTableCell32.Weight = 0.036651192371484773D;
            // 
            // xrTableCell33
            // 
            xrTableCell33.BackColor = Color.FromArgb(217, 217, 217);
            xrTableCell33.Name = "xrTableCell33";
            xrTableCell33.StylePriority.UseBackColor = false;
            xrTableCell33.Weight = 2.1658950483378594D;
            // 
            // xrTableCell38
            // 
            xrTableCell38.Name = "xrTableCell38";
            xrTableCell38.Text = "xrTableCell38";
            xrTableCell38.Weight = 1.5D;
            // 
            // EmployeeProfile
            // 
            Bands.AddRange(new Band[]
            {
                topMarginBand1,
                detailBand1,
                bottomMarginBand1,
                ReportHeader,
                DetailReport,
                DetailReport1,
                DetailReport2
            });
            DataSource = bindingSource1;
            FilterString = "[Id] = ?parameterId";
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margins = new Margins(100, 1, 160, 127);
            Parameters.AddRange(new[]
            {
                parameterId,
                ShowEvaluationsParameter
            });
            Version = "15.1";
            ((ISupportInitialize) xrTable3).EndInit();
            ((ISupportInitialize) xrTable2).EndInit();
            ((ISupportInitialize) xrTable1).EndInit();
            ((ISupportInitialize) xrTable5).EndInit();
            ((ISupportInitialize) xrTable4).EndInit();
            ((ISupportInitialize) bindingSource1).EndInit();
            ((ISupportInitialize) bindingSource2).EndInit();
            ((ISupportInitialize) xrTable7).EndInit();
            ((ISupportInitialize) xrTable6).EndInit();
            ((ISupportInitialize) xrTable9).EndInit();
            ((ISupportInitialize) xrTable8).EndInit();
            ((ISupportInitialize) this).EndInit();
        }
    }
}