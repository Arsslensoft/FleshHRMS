using System;
using System.Collections.Generic;
using FHRMS.Data;

using FHRMS.ViewModels;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using FHRMS.Common.Utils;
using DevExpress.Mvvm;
using FHRMS.Modules;
using System.Windows.Forms;
using FHRMS.Helpers;
namespace FHRMS.Widgets
{
    public delegate void LoadDashboardAsyncDelegate(BoardViewModel b);
    interface IDashboardWidget
    {
       void LoadDashboard(BoardViewModel d);
    }

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
