using System.Windows.Forms;
using PHRMS.ViewModels;

namespace PHRMS.Widgets
{
    public partial class NotificationWidget : UserControl, IDashboardWidget
    {
        public NotificationWidget()
        {
            InitializeComponent();
        }

        public void LoadDashboard(BoardViewModel value)
        {
            Controls.Clear();
            foreach (var n in value.NotificationsViewModel.Entities)
            {
                var ni = new NotificationItem(n);
                ni.Dock = DockStyle.Top;
                Controls.Add(ni);
            }
        }
    }
}