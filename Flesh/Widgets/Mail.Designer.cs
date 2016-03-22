namespace FHRMS.Widgets{
    partial class Mail {
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.AllowHtmlString = true;
            this.labelControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelControl1.Location = new System.Drawing.Point(13, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "●  <href><b>Inbox(1)</href></b>";
            // 
            // labelControl2
            // 
            this.labelControl2.AllowHtmlString = true;
            this.labelControl2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelControl2.Location = new System.Drawing.Point(13, 22);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "●  <href>Outbox</href>";
            // 
            // labelControl3
            // 
            this.labelControl3.AllowHtmlString = true;
            this.labelControl3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelControl3.Location = new System.Drawing.Point(13, 41);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(65, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "●  <href>Sent Items</href>";
            // 
            // labelControl4
            // 
            this.labelControl4.AllowHtmlString = true;
            this.labelControl4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelControl4.Location = new System.Drawing.Point(13, 60);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(80, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "●  <href>Deleted Items</href>";
            // 
            // labelControl5
            // 
            this.labelControl5.AllowHtmlString = true;
            this.labelControl5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelControl5.Location = new System.Drawing.Point(13, 79);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(43, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "●  <href>Drafts</href>";
            // 
            // Mail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "Mail";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.Size = new System.Drawing.Size(144, 130);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;

    }
}
