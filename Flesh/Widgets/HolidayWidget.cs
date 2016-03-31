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

    public partial class HolidayWidget : UserControl, IDashboardWidget
    {
        public BoardViewModel BoardView { get; set; }
        public void LoadDashboard(BoardViewModel value)
        {
            BoardView = value;

            tasksBindingSource.SetItemsSource(value.HolidaysViewModel.Entities);

        }


        public HolidayWidget()
        {
            InitializeComponent();
     
    
        }

        void DoEditHoliday(Holiday task)
        {
            if (BoardView.HolidaysViewModel.CanEdit(task))
                BoardView.HolidaysViewModel.Edit(task);
        }
        private void tasksGridView_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks > 1 && e.RowHandle >= 0)
                DoEditHoliday(tasksGridView.GetFocusedRow() as Holiday);
            
        }
    }
}
