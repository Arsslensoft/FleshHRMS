using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace PHRMS
{
    public partial class AboutForm : DevExpress.XtraEditors.XtraForm
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void warnlb_Click(object sender, EventArgs e)
        {

        }

      

        private void AboutForm_Load_1(object sender, EventArgs e)
        {
            versionlb.Text = "Version : " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
