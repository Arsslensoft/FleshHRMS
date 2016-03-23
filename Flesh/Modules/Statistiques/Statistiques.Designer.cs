using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010.Views.Widget;
namespace FHRMS.Modules
{
    partial class Statistiques
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.widgetView1 = new DevExpress.XtraBars.Docking2010.Views.Widget.WidgetView(this.components);
            this.columnDefinition1 = new DevExpress.XtraBars.Docking2010.Views.Widget.ColumnDefinition();
            this.columnDefinition2 = new DevExpress.XtraBars.Docking2010.Views.Widget.ColumnDefinition();
            this.columnDefinition3 = new DevExpress.XtraBars.Docking2010.Views.Widget.ColumnDefinition();
            this.calendarDocument = new DevExpress.XtraBars.Docking2010.Views.Widget.Document(this.components);
            this.dateTimeDocument = new DevExpress.XtraBars.Docking2010.Views.Widget.Document(this.components);
            this.mailDocument = new DevExpress.XtraBars.Docking2010.Views.Widget.Document(this.components);
            this.weatherDocument = new DevExpress.XtraBars.Docking2010.Views.Widget.Document(this.components);
            this.newsDocument = new DevExpress.XtraBars.Docking2010.Views.Widget.Document(this.components);
            this.warnDocument = new DevExpress.XtraBars.Docking2010.Views.Widget.Document(this.components);
            employeestatsDocument = new Document(this.components);
            this.rowDefinition1 = new DevExpress.XtraBars.Docking2010.Views.Widget.RowDefinition();
            this.rowDefinition2 = new DevExpress.XtraBars.Docking2010.Views.Widget.RowDefinition();
            this.rowDefinition3 = new DevExpress.XtraBars.Docking2010.Views.Widget.RowDefinition();
            this.stackGroup1 = new DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup(this.components);
            this.stackGroup3 = new DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup(this.components);
            this.stackGroup2 = new DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widgetView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDefinition1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDefinition2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDefinition3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calendarDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mailDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weatherDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newsDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warnDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowDefinition1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowDefinition2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowDefinition3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup2)).BeginInit();
            this.SuspendLayout();
            // 
            // documentManager1
            // 
            this.documentManager1.ContainerControl = this;
            this.documentManager1.ShowThumbnailsInTaskBar = DevExpress.Utils.DefaultBoolean.False;
            this.documentManager1.View = this.widgetView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.widgetView1});
            // 
            // widgetView1
            // 
            this.widgetView1.AllowDocumentStateChangeAnimation = DevExpress.Utils.DefaultBoolean.False;
            this.widgetView1.AllowResizeAnimation = DevExpress.Utils.DefaultBoolean.False;
            this.widgetView1.Columns.AddRange(new DevExpress.XtraBars.Docking2010.Views.Widget.ColumnDefinition[] {
            this.columnDefinition1,
            this.columnDefinition2,
            this.columnDefinition3});
            this.widgetView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.calendarDocument,
            this.dateTimeDocument,
            this.mailDocument,
            this.weatherDocument,
            this.newsDocument,
            this.warnDocument,
            employeestatsDocument});
            this.widgetView1.DocumentSpacing = 3;
            this.widgetView1.Rows.AddRange(new DevExpress.XtraBars.Docking2010.Views.Widget.RowDefinition[] {
            this.rowDefinition1,
            this.rowDefinition2,
            this.rowDefinition3});
            this.widgetView1.StackGroups.AddRange(new DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup[] {
            this.stackGroup1,
            this.stackGroup3,
            this.stackGroup2});
            this.widgetView1.QueryControl += new DevExpress.XtraBars.Docking2010.Views.QueryControlEventHandler(this.OnQueryControl);
            // 
            // calendarDocument
            // 
            this.calendarDocument.Caption = "Classification d\'absences par date";
            this.calendarDocument.ColumnIndex = 1;
            this.calendarDocument.ControlName = "AbsenceByDateWidget";
            this.calendarDocument.ControlTypeName = "FHRMS.Widgets.AbsenceByDateWidget";
            // 
            // dateTimeDocument
            // 
            this.dateTimeDocument.Caption = "Classification des congés par status";
            this.dateTimeDocument.ColumnIndex = 1;
            this.dateTimeDocument.ControlName = "LeaveByStatusWidget";
            this.dateTimeDocument.ControlTypeName = "FHRMS.Widgets.LeaveByStatusWidget";
            this.dateTimeDocument.Height = 125;
            this.dateTimeDocument.RowIndex = 1;
            this.dateTimeDocument.Width = 276;
            // 
            // mailDocument
            // 
            this.mailDocument.Caption = "Classification d\'absences par type";
            this.mailDocument.ControlName = "AbsenceWidget";
            this.mailDocument.ControlTypeName = "FHRMS.Widgets.AbsenceWidget";
            this.mailDocument.Height = 176;
            this.mailDocument.RowIndex = 1;
            this.mailDocument.Width = 276;
            // 
            // weatherDocument
            // 
            this.weatherDocument.Caption = "Statistiques globaux";
            this.weatherDocument.ColumnIndex = 2;
            this.weatherDocument.ControlName = "GlobalStatsWidget";
            this.weatherDocument.ControlTypeName = "FHRMS.Widgets.GlobalStatsWidget";
            this.weatherDocument.Height = 400;
            this.weatherDocument.Width = 414;
            // 
            // employeestatsDocument
            // 
            this.employeestatsDocument.Caption = "Statistiques d'employé";
            this.employeestatsDocument.ColumnIndex = 2;
            this.employeestatsDocument.ControlName = "EmployeeStatsWidget";
            this.employeestatsDocument.ControlTypeName = "FHRMS.Widgets.EmployeeStatsWidget";
            this.employeestatsDocument.Height = 400;
            this.employeestatsDocument.Width = 414;
            // 
            // newsDocument
            // 
            this.newsDocument.Caption = "Classification des congés par type";
            this.newsDocument.ColumnIndex = 2;
            this.newsDocument.ControlName = "LeaveByTypeWidget";
            this.newsDocument.ControlTypeName = "FHRMS.Widgets.LeaveByTypeWidget";
            this.newsDocument.Height = 290;
            this.newsDocument.RowIndex = 1;
            this.newsDocument.Width = 496;
            // 
            // warnDocument
            // 
            this.warnDocument.Caption = "Classification des avertissements par sévérité";
            this.warnDocument.ControlName = "WarningsWidget";
            this.warnDocument.ControlTypeName = "FHRMS.Widgets.WarningsWidget";
            this.warnDocument.Height = 176;
            this.warnDocument.RowIndex = 1;
            this.warnDocument.Width = 276;
            // 
            // stackGroup1
            // 
            this.stackGroup1.Caption = "Statistiques";
            this.stackGroup1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Widget.Document[] {
            this.weatherDocument,
            employeestatsDocument});
            this.stackGroup1.Length.UnitValue = 2.5D;
            // 
            // stackGroup3
            // 
            this.stackGroup3.Caption = "Work";
            this.stackGroup3.Length.UnitValue = 0D;
            // 
            // stackGroup2
            // 
            this.stackGroup2.Caption = "Classification";
            this.stackGroup2.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Widget.Document[] {
            this.dateTimeDocument,
            this.newsDocument,
            this.calendarDocument,
            this.mailDocument,
            this.warnDocument});
            // 
            // Statistiques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Statistiques";
            this.Size = new System.Drawing.Size(1832, 606);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widgetView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDefinition1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDefinition2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDefinition3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calendarDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mailDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weatherDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newsDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warnDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowDefinition1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowDefinition2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowDefinition3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Widget.WidgetView widgetView1;
        private DevExpress.XtraBars.Docking2010.Views.Widget.Document calendarDocument;
        private DevExpress.XtraBars.Docking2010.Views.Widget.Document dateTimeDocument;
        private DevExpress.XtraBars.Docking2010.Views.Widget.Document mailDocument;
        private DevExpress.XtraBars.Docking2010.Views.Widget.Document weatherDocument;
        private DevExpress.XtraBars.Docking2010.Views.Widget.Document newsDocument;
        private DevExpress.XtraBars.Docking2010.Views.Widget.Document warnDocument;
        private DevExpress.XtraBars.Docking2010.Views.Widget.Document employeestatsDocument;
        private ColumnDefinition columnDefinition1;
        private ColumnDefinition columnDefinition2;
        private ColumnDefinition columnDefinition3;
        private RowDefinition rowDefinition1;
        private RowDefinition rowDefinition2;
        private RowDefinition rowDefinition3;
        private StackGroup stackGroup1;
        private StackGroup stackGroup2;
        private StackGroup stackGroup3;
    }
}
