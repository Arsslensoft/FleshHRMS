using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using PHRMS.Data;
using PHRMS.Helpers;
using PHRMS.Modules;
using PHRMS.ViewModels;

namespace PHRMS.Widgets
{
    public delegate void LoadDashboardAsyncDelegate(BoardViewModel b);

    internal interface IDashboardWidget
    {
        void LoadDashboard(BoardViewModel d);
    }

    public partial class HolidayWidget : UserControl, IDashboardWidget
    {
        public HolidayWidget()
        {
            InitializeComponent();
            Dashboard.holidaysGridControl = tasksGridControl;
        }

        public BoardViewModel BoardView { get; set; }

        public void LoadDashboard(BoardViewModel value)
        {
            BoardView = value;

            tasksBindingSource.SetItemsSource(value.HolidaysViewModel.Entities);
        }

        private void DoEditHoliday(Holiday task)
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