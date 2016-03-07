namespace DevExpress.DevAV.Modules {
    partial class TaskPrint {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.documentViewer = new DevExpress.XtraPrinting.Preview.DocumentViewer();
            this.printingSystem = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).BeginInit();
            this.SuspendLayout();
            this.documentViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.documentViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentViewer.DocumentSource = this.printingSystem;
            this.documentViewer.IsMetric = false;
            this.documentViewer.Location = new System.Drawing.Point(0, 0);
            this.documentViewer.Name = "documentViewer";
            this.documentViewer.Size = new System.Drawing.Size(795, 585);
            this.documentViewer.TabIndex = 1;
            this.printingSystem.Links.AddRange(new object[] {
            this.printableComponentLink});
            this.printableComponentLink.Landscape = true;
            this.printableComponentLink.PrintingSystemBase = this.printingSystem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.documentViewer);
            this.Name = "TaskPrint";
            this.Size = new System.Drawing.Size(795, 585);
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private XtraPrinting.Preview.DocumentViewer documentViewer;
        private XtraPrinting.PrintingSystem printingSystem;
        private XtraPrinting.PrintableComponentLink printableComponentLink;

    }
}
