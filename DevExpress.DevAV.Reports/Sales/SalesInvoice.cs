﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevExpress.DevAV.Reports {
    public class SalesInvoice : DevExpress.XtraReports.UI.XtraReport {
        private XtraReports.UI.TopMarginBand topMarginBand1;
        private XtraReports.UI.DetailBand detailBand1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.ComponentModel.IContainer components;
        private XtraReports.UI.ReportHeaderBand ReportHeader;
        private System.Diagnostics.EventLog eventLog1;
        private XtraReports.UI.ReportFooterBand ReportFooter1;
        private XtraReports.UI.XRTable xrTable2;
        private XtraReports.UI.XRTableRow xrTableRow2;
        private XtraReports.UI.XRTableCell xrTableCell4;
        private XtraReports.UI.XRTableCell xrTableCell5;
        private XtraReports.UI.XRTable xrTable1;
        private XtraReports.UI.XRTableRow xrTableRow1;
        private XtraReports.UI.XRTableCell xrTableCell1;
        private XtraReports.UI.XRTableRow xrTableRow3;
        private XtraReports.UI.XRTableCell xrTableCell3;
        private XtraReports.UI.XRPictureBox xrPictureBox1;
        private XtraReports.UI.XRTable xrTable3;
        private XtraReports.UI.XRTableRow xrTableRow4;
        private XtraReports.UI.XRTableCell xrTableCell2;
        private XtraReports.UI.XRTableCell xrTableCell6;
        private XtraReports.UI.XRTableRow xrTableRow5;
        private XtraReports.UI.XRTableCell xrTableCell7;
        private XtraReports.UI.XRTableCell xrTableCell8;
        private XtraReports.UI.XRTableRow xrTableRow6;
        private XtraReports.UI.XRTableCell xrTableCell9;
        private XtraReports.UI.XRTableCell xrTableCell10;
        private XtraReports.UI.XRTable xrTable4;
        private XtraReports.UI.XRTableRow xrTableRow7;
        private XtraReports.UI.XRTableCell xrTableCell11;
        private XtraReports.UI.XRTableCell xrTableCell12;
        private XtraReports.UI.XRTableCell xrTableCell14;
        private XtraReports.UI.XRTableCell xrTableCell15;
        private XtraReports.UI.XRTableCell xrTableCell16;
        private XtraReports.UI.XRTableCell xrTableCell17;
        private XtraReports.UI.XRTableRow xrTableRow8;
        private XtraReports.UI.XRTableCell xrTableCell13;
        private XtraReports.UI.XRTableCell xrTableCell18;
        private XtraReports.UI.XRTableCell xrTableCell19;
        private XtraReports.UI.XRTableCell xrTableCell20;
        private XtraReports.UI.XRTableCell xrTableCell21;
        private XtraReports.UI.XRTableCell xrTableCell22;
        private XtraReports.UI.XRTable xrTable6;
        private XtraReports.UI.XRTableRow xrTableRow10;
        private XtraReports.UI.XRTableCell xrTableCell28;
        private XtraReports.UI.XRTableCell xrTableCell29;
        private XtraReports.UI.XRTableRow xrTableRow11;
        private XtraReports.UI.XRTableCell xrTableCell30;
        private XtraReports.UI.XRTableCell xrTableCell31;
        private XtraReports.UI.XRTableRow xrTableRow12;
        private XtraReports.UI.XRTableCell xrTableCell32;
        private XtraReports.UI.XRTableCell xrTableCell33;
        private XtraReports.UI.GroupHeaderBand GroupHeader1;
        private XtraReports.UI.XRTable xrTable5;
        private XtraReports.UI.XRTableRow xrTableRow9;
        private XtraReports.UI.XRTableCell xrTableCell23;
        private XtraReports.UI.XRTableCell xrTableCell24;
        private XtraReports.UI.XRTableCell xrTableCell26;
        private XtraReports.UI.XRTableCell xrTableCell27;
        private XtraReports.UI.XRTableCell xrTableCell25;
        private XtraReports.UI.XRLabel xrLabel4;
        private XtraReports.UI.XRLabel xrLabel3;
        private XtraReports.UI.XRLabel xrLabel2;
        private XtraReports.UI.XRLabel xrLabel1;
        private XtraReports.UI.XRCrossBandBox xrCrossBandBox1;
        private XtraReports.UI.XRCrossBandLine xrCrossBandLine1;
        private XtraReports.UI.XRCrossBandLine xrCrossBandLine2;
        private XtraReports.UI.XRCrossBandLine xrCrossBandLine3;
        private XtraReports.UI.XRCrossBandLine xrCrossBandLine4;
        private XtraReports.Parameters.Parameter paramAscending;
        private XtraReports.UI.DetailBand Detail;
        private XtraReports.UI.XRLabel xrLabel6;
        private XtraReports.UI.DetailReportBand DetailReport;
        private XtraReports.UI.BottomMarginBand bottomMarginBand1;

        public SalesInvoice() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesInvoice));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.detailBand1 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.ReportFooter1 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrTable6 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow12 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrCrossBandBox1 = new DevExpress.XtraReports.UI.XRCrossBandBox();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCrossBandLine1 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine2 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine3 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine4 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.paramAscending = new DevExpress.XtraReports.Parameters.Parameter();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.topMarginBand1.HeightF = 48F;
            this.topMarginBand1.Name = "topMarginBand1";
            this.detailBand1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailBand1.HeightF = 0F;
            this.detailBand1.Name = "detailBand1";
            this.detailBand1.StylePriority.UseFont = false;
            this.detailBand1.StylePriority.UseForeColor = false;
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "OrderItems.Discount", "{0:$#,#}")});
            this.xrLabel4.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(511.9698F, 1.279825F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 6, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(92.11032F, 29.45825F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UsePadding = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "xrLabel4";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "OrderItems.ProductPrice", "{0:$#,#}")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(405.77F, 1.279825F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 8, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(105F, 29.45825F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UsePadding = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "xrLabel3";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "OrderItems.Product.Name")});
            this.xrLabel2.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(183.1908F, 1.279831F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(7, 0, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(220.9593F, 29.45824F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UsePadding = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "OrderItems.ProductUnits")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(2.4194F, 1.279825F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(178.6885F, 29.45825F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.bottomMarginBand1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bottomMarginBand1.HeightF = 125F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            this.bottomMarginBand1.StylePriority.UseFont = false;
            this.bindingSource1.DataSource = typeof(DevExpress.DevAV.Order);
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4,
            this.xrTable3,
            this.xrTable1,
            this.xrPictureBox1,
            this.xrTable2});
            this.ReportHeader.HeightF = 441.7458F;
            this.ReportHeader.Name = "ReportHeader";
            this.xrTable4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
            | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 337.4106F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7,
            this.xrTableRow8});
            this.xrTable4.SizeF = new System.Drawing.SizeF(738.0317F, 67.80725F);
            this.xrTable4.StylePriority.UseBorders = false;
            this.xrTable4.StylePriority.UseFont = false;
            this.xrTable4.StylePriority.UseTextAlignment = false;
            this.xrTable4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableRow7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell11,
            this.xrTableCell12,
            this.xrTableCell14,
            this.xrTableCell15,
            this.xrTableCell16,
            this.xrTableCell17});
            this.xrTableRow7.Name = "xrTableRow7";
            this.xrTableRow7.StylePriority.UseBackColor = false;
            this.xrTableRow7.Weight = 1.3351953125D;
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Text = "Sales Rep.";
            this.xrTableCell11.Weight = 0.87337124463981453D;
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Text = "PO #";
            this.xrTableCell12.Weight = 0.542657708540922D;
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Text = "Ship Date";
            this.xrTableCell14.Weight = 0.76259622302369945D;
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Text = "Ship Via";
            this.xrTableCell15.Weight = 0.74244572182261748D;
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Text = "FOB";
            this.xrTableCell16.Weight = 0.75802148176866191D;
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Text = "Terms";
            this.xrTableCell17.Weight = 0.78187486628821778D;
            this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell13,
            this.xrTableCell18,
            this.xrTableCell19,
            this.xrTableCell20,
            this.xrTableCell21,
            this.xrTableCell22});
            this.xrTableRow8.Name = "xrTableRow8";
            this.xrTableRow8.Weight = 1.3770947265625D;
            this.xrTableCell13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Employee.FullName")});
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Weight = 0.87337124463981453D;
            this.xrTableCell18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PONumber")});
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Weight = 0.54265752408010282D;
            this.xrTableCell19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ShipDate", "{0:MM/dd/yyyy}")});
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Weight = 0.76259663806054245D;
            this.xrTableCell20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ShipMethod")});
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Weight = 0.742445583477003D;
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Text = " - ";
            this.xrTableCell21.Weight = 0.75802138953825215D;
            this.xrTableCell22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "OrderTerms")});
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Weight = 0.7818748662882179D;
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 184.8101F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4,
            this.xrTableRow5,
            this.xrTableRow6});
            this.xrTable3.SizeF = new System.Drawing.SizeF(747.0001F, 100.1396F);
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell2,
            this.xrTableCell6});
            this.xrTableRow4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableRow4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.StylePriority.UseFont = false;
            this.xrTableRow4.StylePriority.UseForeColor = false;
            this.xrTableRow4.Weight = 0.8269312838050884D;
            this.xrTableCell2.CanGrow = false;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(7, 0, 0, 0, 100F);
            this.xrTableCell2.StylePriority.UsePadding = false;
            this.xrTableCell2.Text = "BILLING ADDRESS";
            this.xrTableCell2.Weight = 1.3551172785937633D;
            this.xrTableCell6.CanGrow = false;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(7, 0, 0, 0, 100F);
            this.xrTableCell6.StylePriority.UsePadding = false;
            this.xrTableCell6.Text = "SHIPPING ADDRESS";
            this.xrTableCell6.Weight = 1.6448827214062367D;
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7,
            this.xrTableCell8});
            this.xrTableRow5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.StylePriority.UseFont = false;
            this.xrTableRow5.Weight = 0.879773087130504D;
            this.xrTableCell7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Customer.Name")});
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(7, 0, 0, 0, 100F);
            this.xrTableCell7.StylePriority.UsePadding = false;
            this.xrTableCell7.Weight = 1.3551172785937633D;
            this.xrTableCell8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Customer.Name")});
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(7, 0, 0, 0, 100F);
            this.xrTableCell8.StylePriority.UsePadding = false;
            this.xrTableCell8.Weight = 1.6448827214062367D;
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell9,
            this.xrTableCell10});
            this.xrTableRow6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.StylePriority.UseFont = false;
            this.xrTableRow6.Weight = 2.2988821654829317D;
            this.xrTableCell9.Multiline = true;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(7, 0, 0, 0, 100F);
            this.xrTableCell9.StylePriority.UsePadding = false;
            this.xrTableCell9.Text = "Home Office\r\n[Customer.HomeOffice.Line]\r\n[Customer.HomeOffice.CityLine]";
            this.xrTableCell9.Weight = 1.3551172785937633D;
            this.xrTableCell10.Multiline = true;
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(7, 0, 0, 0, 100F);
            this.xrTableCell10.StylePriority.UsePadding = false;
            this.xrTableCell10.Text = "[Store.City] Store\r\n[Store.Address.Line]\r\n[Store.Address.CityLine]";
            this.xrTableCell10.Weight = 1.6448827214062367D;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 56.45351F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(7, 0, 0, 0, 100F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1,
            this.xrTableRow3});
            this.xrTable1.SizeF = new System.Drawing.SizeF(216.7917F, 55.01034F);
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UsePadding = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1});
            this.xrTableRow1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.StylePriority.UseFont = false;
            this.xrTableRow1.Weight = 11.5D;
            this.xrTableCell1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "OrderDate", "{0:MM/dd/yy}")});
            this.xrTableCell1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.xrTableCell1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UseForeColor = false;
            this.xrTableCell1.Text = "xrTableCell1";
            this.xrTableCell1.Weight = 0.3656307129798903D;
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell3});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 8.7438043212890619D;
            this.xrTableCell3.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.Text = "Invoice # [InvoiceNumber]";
            this.xrTableCell3.Weight = 0.3656307129798903D;
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(531.7613F, 60.41667F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(201.0721F, 59.53684F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(747F, 22.46094F);
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell5});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 0.81850549162585273D;
            this.xrTableCell4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(128)))), ((int)(((byte)(71)))));
            this.xrTableCell4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell4.ForeColor = System.Drawing.Color.White;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 0, 0, 0, 100F);
            this.xrTableCell4.StylePriority.UseBackColor = false;
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UseForeColor = false;
            this.xrTableCell4.StylePriority.UsePadding = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell4.Weight = 2.0743676514315035D;
            this.xrTableCell5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseBackColor = false;
            this.xrTableCell5.Weight = 0.89785498948665832D;
            this.ReportFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable6});
            this.ReportFooter1.HeightF = 138.7163F;
            this.ReportFooter1.Name = "ReportFooter1";
            this.ReportFooter1.PrintAtBottom = true;
            this.xrTable6.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
            | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable6.LocationFloat = new DevExpress.Utils.PointFloat(404.15F, 1F);
            this.xrTable6.Name = "xrTable6";
            this.xrTable6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow10,
            this.xrTableRow11,
            this.xrTableRow12});
            this.xrTable6.SizeF = new System.Drawing.SizeF(333.8817F, 120.0418F);
            this.xrTable6.StylePriority.UseBorders = false;
            this.xrTableRow10.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell28,
            this.xrTableCell29});
            this.xrTableRow10.Name = "xrTableRow10";
            this.xrTableRow10.StylePriority.UseBorders = false;
            this.xrTableRow10.Weight = 1.460894422478543D;
            this.xrTableCell28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.xrTableCell28.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.StylePriority.UseBackColor = false;
            this.xrTableCell28.StylePriority.UseFont = false;
            this.xrTableCell28.StylePriority.UseTextAlignment = false;
            this.xrTableCell28.Text = "SUB TOTAL";
            this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell28.Weight = 1.8420703793542417D;
            this.xrTableCell29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "OrderItems.Total")});
            this.xrTableCell29.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 6, 0, 0, 100F);
            this.xrTableCell29.StylePriority.UseFont = false;
            this.xrTableCell29.StylePriority.UsePadding = false;
            this.xrTableCell29.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:$#,#}";
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell29.Summary = xrSummary1;
            this.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell29.Weight = 1.2176832235359758D;
            this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell30,
            this.xrTableCell31});
            this.xrTableRow11.Name = "xrTableRow11";
            this.xrTableRow11.Weight = 1.460894422478543D;
            this.xrTableCell30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.xrTableCell30.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.StylePriority.UseBackColor = false;
            this.xrTableCell30.StylePriority.UseFont = false;
            this.xrTableCell30.StylePriority.UseTextAlignment = false;
            this.xrTableCell30.Text = "SHIPPING";
            this.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell30.Weight = 1.8420720573667064D;
            this.xrTableCell31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ShippingAmount", "{0:$#,#}")});
            this.xrTableCell31.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 6, 0, 0, 100F);
            this.xrTableCell31.StylePriority.UseFont = false;
            this.xrTableCell31.StylePriority.UsePadding = false;
            this.xrTableCell31.StylePriority.UseTextAlignment = false;
            this.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell31.Weight = 1.217681545523511D;
            this.xrTableRow12.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell32,
            this.xrTableCell33});
            this.xrTableRow12.Name = "xrTableRow12";
            this.xrTableRow12.Weight = 1.879889379747778D;
            this.xrTableCell32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.xrTableCell32.Font = new System.Drawing.Font("Arial Narrow", 18F);
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.StylePriority.UseBackColor = false;
            this.xrTableCell32.StylePriority.UseFont = false;
            this.xrTableCell32.StylePriority.UseTextAlignment = false;
            this.xrTableCell32.Text = "TOTAL DUE";
            this.xrTableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell32.Weight = 1.8420720573667064D;
            this.xrTableCell33.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalAmount", "{0:$#,#}")});
            this.xrTableCell33.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 6, 0, 0, 100F);
            this.xrTableCell33.StylePriority.UseFont = false;
            this.xrTableCell33.StylePriority.UsePadding = false;
            this.xrTableCell33.StylePriority.UseTextAlignment = false;
            this.xrTableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell33.Weight = 1.217681545523511D;
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable5});
            this.GroupHeader1.HeightF = 36F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.xrTable5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.xrTable5.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
            | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable5.Font = new System.Drawing.Font("Arial Narrow", 13F);
            this.xrTable5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(112)))), ((int)(((byte)(116)))));
            this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable5.Name = "xrTable5";
            this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow9});
            this.xrTable5.SizeF = new System.Drawing.SizeF(738.0317F, 35F);
            this.xrTable5.StylePriority.UseBackColor = false;
            this.xrTable5.StylePriority.UseBorders = false;
            this.xrTable5.StylePriority.UseFont = false;
            this.xrTable5.StylePriority.UseForeColor = false;
            this.xrTableRow9.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell23,
            this.xrTableCell24,
            this.xrTableCell26,
            this.xrTableCell27,
            this.xrTableCell25});
            this.xrTableRow9.Name = "xrTableRow9";
            this.xrTableRow9.StylePriority.UseBorders = false;
            this.xrTableRow9.Weight = 1.1553719643170166D;
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.StylePriority.UseTextAlignment = false;
            this.xrTableCell23.Text = "Quantity";
            this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell23.Weight = 0.74283632613826966D;
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.Padding = new DevExpress.XtraPrinting.PaddingInfo(7, 0, 0, 0, 100F);
            this.xrTableCell24.StylePriority.UsePadding = false;
            this.xrTableCell24.StylePriority.UseTextAlignment = false;
            this.xrTableCell24.Text = "Description";
            this.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell24.Weight = 0.90976289799882426D;
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 8, 0, 0, 100F);
            this.xrTableCell26.StylePriority.UsePadding = false;
            this.xrTableCell26.StylePriority.UseTextAlignment = false;
            this.xrTableCell26.Text = "Unit price";
            this.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell26.Weight = 0.4349010466082886D;
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 6, 0, 0, 100F);
            this.xrTableCell27.StylePriority.UsePadding = false;
            this.xrTableCell27.StylePriority.UseTextAlignment = false;
            this.xrTableCell27.Text = "Discount";
            this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell27.Weight = 0.38092685018935046D;
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 7, 0, 0, 100F);
            this.xrTableCell25.StylePriority.UsePadding = false;
            this.xrTableCell25.StylePriority.UseTextAlignment = false;
            this.xrTableCell25.Text = "Total";
            this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell25.Weight = 0.54199066346430813D;
            this.xrCrossBandBox1.BorderWidth = 1F;
            this.xrCrossBandBox1.EndBand = this.ReportFooter1;
            this.xrCrossBandBox1.EndPointFloat = new DevExpress.Utils.PointFloat(0F, 1.000002F);
            this.xrCrossBandBox1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 35F);
            this.xrCrossBandBox1.Name = "xrCrossBandBox1";
            this.xrCrossBandBox1.StartBand = this.GroupHeader1;
            this.xrCrossBandBox1.StartPointFloat = new DevExpress.Utils.PointFloat(0F, 35F);
            this.xrCrossBandBox1.WidthF = 738.0316F;
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6,
            this.xrLabel2,
            this.xrLabel1,
            this.xrLabel3,
            this.xrLabel4});
            this.Detail.HeightF = 32.02937F;
            this.Detail.Name = "Detail";
            this.Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("ProductUnits", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "OrderItems.Total", "{0:$#,#}")});
            this.xrLabel6.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(605.619F, 1.27982F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 7, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(129.8586F, 29.45824F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UsePadding = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "xrLabel5";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrCrossBandLine1.EndBand = this.ReportFooter1;
            this.xrCrossBandLine1.EndPointFloat = new DevExpress.Utils.PointFloat(510.77F, 0F);
            this.xrCrossBandLine1.LocationFloat = new DevExpress.Utils.PointFloat(510.77F, 0F);
            this.xrCrossBandLine1.Name = "xrCrossBandLine1";
            this.xrCrossBandLine1.StartBand = this.Detail;
            this.xrCrossBandLine1.StartPointFloat = new DevExpress.Utils.PointFloat(510.77F, 0F);
            this.xrCrossBandLine1.WidthF = 1F;
            this.xrCrossBandLine2.EndBand = this.ReportFooter1;
            this.xrCrossBandLine2.EndPointFloat = new DevExpress.Utils.PointFloat(181.11F, 0F);
            this.xrCrossBandLine2.LocationFloat = new DevExpress.Utils.PointFloat(181.11F, 0F);
            this.xrCrossBandLine2.Name = "xrCrossBandLine2";
            this.xrCrossBandLine2.StartBand = this.Detail;
            this.xrCrossBandLine2.StartPointFloat = new DevExpress.Utils.PointFloat(181.11F, 0F);
            this.xrCrossBandLine2.WidthF = 1.077576F;
            this.xrCrossBandLine3.EndBand = this.ReportFooter1;
            this.xrCrossBandLine3.EndPointFloat = new DevExpress.Utils.PointFloat(404.15F, 0F);
            this.xrCrossBandLine3.LocationFloat = new DevExpress.Utils.PointFloat(404.15F, 0F);
            this.xrCrossBandLine3.Name = "xrCrossBandLine3";
            this.xrCrossBandLine3.StartBand = this.Detail;
            this.xrCrossBandLine3.StartPointFloat = new DevExpress.Utils.PointFloat(404.15F, 0F);
            this.xrCrossBandLine3.WidthF = 1.041656F;
            this.xrCrossBandLine4.EndBand = this.ReportFooter1;
            this.xrCrossBandLine4.EndPointFloat = new DevExpress.Utils.PointFloat(604.08F, 0F);
            this.xrCrossBandLine4.LocationFloat = new DevExpress.Utils.PointFloat(604.08F, 0F);
            this.xrCrossBandLine4.Name = "xrCrossBandLine4";
            this.xrCrossBandLine4.StartBand = this.Detail;
            this.xrCrossBandLine4.StartPointFloat = new DevExpress.Utils.PointFloat(604.08F, 0F);
            this.xrCrossBandLine4.WidthF = 1.077576F;
            this.paramAscending.Description = "Ascending";
            this.paramAscending.Name = "paramAscending";
            this.paramAscending.Type = typeof(bool);
            this.paramAscending.ValueInfo = "True";
            this.paramAscending.Visible = false;
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail});
            this.DetailReport.DataMember = "OrderItems";
            this.DetailReport.DataSource = this.bindingSource1;
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.topMarginBand1,
            this.detailBand1,
            this.bottomMarginBand1,
            this.ReportHeader,
            this.ReportFooter1,
            this.GroupHeader1,
            this.DetailReport});
            this.CrossBandControls.AddRange(new DevExpress.XtraReports.UI.XRCrossBandControl[] {
            this.xrCrossBandLine4,
            this.xrCrossBandLine3,
            this.xrCrossBandLine2,
            this.xrCrossBandLine1,
            this.xrCrossBandBox1});
            this.DataSource = this.bindingSource1;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margins = new System.Drawing.Printing.Margins(58, 45, 48, 125);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.paramAscending});
            this.Version = "14.1";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.SalesInvoice_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        private void SalesInvoice_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
            if(Equals(true, paramAscending.Value)) {
                this.Detail.SortFields[0].SortOrder = XtraReports.UI.XRColumnSortOrder.Ascending;
            } else {
                this.Detail.SortFields[0].SortOrder = XtraReports.UI.XRColumnSortOrder.Descending;
            }
        }
    }
}
