using System;
using System.Windows.Forms;

namespace FHRMS.Widgets{
    public partial class Clock : UserControl {
        Timer timer = new Timer();
        public Clock() {
            InitializeComponent();
            timer.Interval = 1000;
            timer.Tick += OnTick;
            timer.Start();
            OnTick(null, null);
        }
        void OnTick(object sender, EventArgs e) {
            System.DateTime currentDate = System.DateTime.Now;
            labelControl1.Text = "<b>" + string.Format("{0:T}", currentDate) + "</b><br><size=10>" + currentDate.ToString("D");
        }
    }
}
