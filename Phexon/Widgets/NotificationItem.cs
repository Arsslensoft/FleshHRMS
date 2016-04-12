using System.Windows.Forms;

namespace PHRMS.Widgets{
    public partial class NotificationItem : DevExpress.XtraLayout.LayoutControl {

        public NotificationItem(PHRMS.Data.Notification notif)
        {
            InitializeComponent();
            notificationdate.Text = notif.Date.ToLongDateString() + " "+ notif.Date.ToLongTimeString();
            notificationinfo.Text = notif.Message;
        }
    }
}
