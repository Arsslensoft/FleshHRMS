using System;
using System.Windows.Forms;

namespace PHRMS.Widgets
{
    public partial class Clock : UserControl
    {
        private readonly Timer timer = new Timer();

        public Clock()
        {
            InitializeComponent();
            timer.Interval = 1000;
            timer.Tick += OnTick;
            timer.Start();
            OnTick(null, null);
        }

        private void OnTick(object sender, EventArgs e)
        {
            var currentDate = DateTime.Now;
            labelControl1.Text = "<b>" + string.Format("{0:T}", currentDate) + "</b><br><size=10>" +
                                 currentDate.ToString("D");
        }
    }
}