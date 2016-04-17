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
            Dashboard.holidaysGridControl = tasksGridControl;

        }

        void DoEditHoliday(Holiday task)
        {
            if (BoardView.HolidaysViewModel.CanEdit(task))
                BoardView.HolidaysViewModel.Edit(task);
        }
        private void tasksGridView_RowClick(object sender, RowClickEventArgs e)
        {
            BoardView.HolidaysViewModel.SelectedEntity = tasksGridView.GetFocusedRow() as Holiday;
            if (e.Clicks > 1 && e.RowHandle >= 0)
                DoEditHoliday(tasksGridView.GetFocusedRow() as Holiday);
            
        }
    }
}
