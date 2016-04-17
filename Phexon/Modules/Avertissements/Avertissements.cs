using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Mvvm;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
using PHRMS.Data;
using PHRMS.Helpers;
using PHRMS.ViewModels;

namespace PHRMS.Modules
{
    public partial class Avertissements : BaseModuleControl
    {
        public Avertissements()
            : base(CreateViewModel<WarningsCollectionViewModel>)
        {
            InitializeComponent();
            UpdateData();
            ((ITileControl) tileControl1).Properties.LargeItemWidth = 200;
            tileControl1.UseParentAutoScaleFactor = false;
        }

        public WarningsCollectionViewModel ViewModel
        {
            get { return GetViewModel<WarningsCollectionViewModel>(); }
        }

        protected override void OnInitServices(IServiceContainer serviceContainer)
        {
            base.OnInitServices(serviceContainer);
            serviceContainer.RegisterService(new FlyoutDetailFormDocumentManagerService(ModuleType.ModifierAvertissement));
        }

        private void UpdateData()
        {
            tasksGridControl.SetItemsSource(ViewModel.Entities);
            TileItemsUpdateElementText();
        }

        private void TileItemsUpdateElementText()
        {
            if (ViewModel.Entities != null)
            {
                tileItemAll.Text = ViewModel.AllCount.ToString();
                tileItemLow.Text = ViewModel.LowCount.ToString();
                tileItemInconvenient.Text = ViewModel.InconvenientCount.ToString();

                tileItemSevere.Text = ViewModel.SevereCount.ToString();
                tileItemSerious.Text = ViewModel.SeriousCount.ToString();
            }
        }

        protected internal override void OnTransitionCompleted()
        {
            base.OnTransitionCompleted();
            InitializeButtonPanel();
        }

        private void InitializeButtonPanel()
        {
            var listBI = new List<ButtonInfo>();
            listBI.Add(new ButtonInfo
            {
                Type = typeof(SimpleButton),
                Text = "Nouvelle avertissement",
                Name = "1",
                Image = ImageHelper.GetImageFromToolbarResource("New"),
                mouseEventHandler = (s, e) => { NewButtonClick(); }
            });
            listBI.Add(new ButtonInfo
            {
                Type = typeof(SimpleButton),
                Text = "Modifier",
                Name = "2",
                Image = ImageHelper.GetImageFromToolbarResource("Edit"),
                mouseEventHandler = (s, e) => { EditButtonClick(); }
            });

            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo
            {
                Type = typeof(SimpleButton),
                Text = "Imprimer",
                Name = "4",
                Image = ImageHelper.GetImageFromToolbarResource("Print"),
                mouseEventHandler = (s, e) => { PrintButtonClick(); }
            });
            BottomPanel.InitializeButtons(listBI, false);
        }

        private void PrintButtonClick()
        {
            var main = GetParentViewModel<MainViewModel>();
            main.SelectModule(ModuleType.ImprimerAvertissements, x =>
            {
                ViewModelHelper.EnsureModuleViewModel(main.SelectedModule, main, tasksGridControl);
                ((BaseModuleControl) main.SelectedModule).Refresh();
            });
        }

        private void NewButtonClick()
        {
            ViewModel.New();
        }

        private void EditButtonClick()
        {
            Edit(ViewModel.SelectedEntity);
        }

        private void Edit(Warning task)
        {
            if (ViewModel.CanEdit(task) && MainViewModel.CurrentEmployee.Role >= EmployeeRole.Agent)
            {
                if (MainViewModel.CurrentEmployee.Role == EmployeeRole.Agent &&
                    MainViewModel.CurrentEmployee.Id != task.CreatedById)
                    XtraMessageBox.Show(" Accès refusé ", " Contrôle d'accès ", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                else
                    ViewModel.Edit(task);
            }
            else if (MainViewModel.CurrentEmployee.Role < EmployeeRole.Agent)
                XtraMessageBox.Show(" Accès refusé ", " Contrôle d'accès ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void collapseButton_Click(object sender, EventArgs e)
        {
            if (tileControlLCI.Visibility == LayoutVisibility.Always)
            {
                ItemsHideHelper.Hide(new object[] {tileControlLCI}, buttonHide);
                return;
            }
            if (tileControlLCI.Visibility == LayoutVisibility.Never)
            {
                ItemsHideHelper.Expand(new object[] {tileControlLCI}, buttonHide);
            }
        }

        private void TileClickFilter(string filter, TileItem tileItem)
        {
            tasksGridView.ActiveFilter.Clear();
            var fieldName = GetFieldName(filter);
            tasksGridView.ActiveFilter.Add(tasksGridView.Columns[fieldName], new ColumnFilterInfo(filter));
            tileItem.Text = tasksGridView.DataRowCount.ToString();
        }

        private static string GetFieldName(string filter)
        {
            if (filter.StartsWith("ADate"))
                return "ADate";
            return "Type";
        }

        private void tileItem_ItemClick(object sender, TileItemEventArgs e)
        {
            var filter = e.Item.Tag as string;
            TileClickFilter(filter, e.Item);
        }

        private void tasksGridView_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            ViewModel.SelectedEntity = e.Row as Warning;
        }

        private void tasksGridView_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks > 1 && e.RowHandle >= 0)
                Edit(GetTask(e.RowHandle));
        }

        private Warning GetTask(int rowHandle)
        {
            return tasksGridView.GetRow(rowHandle) as Warning;
        }
    }
}