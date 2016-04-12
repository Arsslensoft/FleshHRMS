using System;
using System.Collections.Generic;
using PHRMS.Data;

using PHRMS.ViewModels;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using PHRMS.Utils;
using DevExpress.Mvvm;
using PHRMS.Modules;
using System.Windows.Forms;
using PHRMS.Helpers;
namespace PHRMS.Widgets
{
 
    public partial class NotificationWidget : UserControl, IDashboardWidget
    {
        public void LoadDashboard(BoardViewModel value)
        {
            this.Controls.Clear();
            foreach (Notification n in value.NotificationsViewModel.Entities)
            {
                NotificationItem ni = new NotificationItem(n);
                ni.Dock = DockStyle.Top;
                this.Controls.Add(ni);
            }
        }
   
  
        public NotificationWidget()
        {
            InitializeComponent();
     
    
        }
    }
}
