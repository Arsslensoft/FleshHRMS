using DevExpress.XtraLayout;
using PHRMS.Data;

namespace PHRMS.Widgets
{
    public partial class NotificationItem : LayoutControl
    {
        public NotificationItem(Notification notif)
        {
            InitializeComponent();
            notificationdate.Text = notif.Date.ToLongDateString() + " " + notif.Date.ToLongTimeString();
            notificationinfo.Text = notif.Message;
        }
    }
}