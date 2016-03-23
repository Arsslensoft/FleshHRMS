using System.Windows.Forms;

namespace FHRMS.Widgets{
    public partial class NotificationItem : DevExpress.XtraLayout.LayoutControl {

        public NotificationItem(FHRMS.Data.Notification notif)
        {
            InitializeComponent();
            notificationdate.Text = notif.Date.ToLongDateString() + " "+ notif.Date.ToLongTimeString();
            notificationinfo.Text = notif.Message;
        }
    }
}
