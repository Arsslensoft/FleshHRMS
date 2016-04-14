namespace PHRMS
{
    partial class AboutForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.warnlb = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.versionlb = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // warnlb
            // 
            this.warnlb.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warnlb.Appearance.ForeColor = System.Drawing.Color.Gainsboro;
            this.warnlb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.warnlb.Location = new System.Drawing.Point(0, 333);
            this.warnlb.Name = "warnlb";
            this.warnlb.Size = new System.Drawing.Size(482, 119);
            this.warnlb.TabIndex = 2;
            this.warnlb.Text = resources.GetString("warnlb.Text");
            this.warnlb.Click += new System.EventHandler(this.warnlb_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Silver;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelControl1.Location = new System.Drawing.Point(0, 316);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(219, 17);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "© 2016 SDL Team. All rights reserved";
            // 
            // versionlb
            // 
            this.versionlb.Appearance.ForeColor = System.Drawing.Color.Silver;
            this.versionlb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.versionlb.Location = new System.Drawing.Point(0, 296);
            this.versionlb.Name = "versionlb";
            this.versionlb.Size = new System.Drawing.Size(79, 20);
            this.versionlb.TabIndex = 4;
            this.versionlb.Text = "Version : 1.0";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(655, 452);
            this.Controls.Add(this.versionlb);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.warnlb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "À propos";
            this.Load += new System.EventHandler(this.AboutForm_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl warnlb;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl versionlb;
    }
}