using System;
using System.Reflection;
using DevExpress.XtraEditors;

namespace PHRMS
{
    public partial class AboutForm : XtraForm
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
            versionlb.Text = "Version : " + Assembly.GetExecutingAssembly().GetName().Version;
        }
    }
}