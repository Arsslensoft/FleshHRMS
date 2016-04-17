using System.Drawing;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Base;
using PHRMS.Data;
using PHRMS.ViewModels;

namespace PHRMS
{
    internal class ColumnViewHelper<TEntity, TID, TUnitOfWork>
        where TEntity : class
        where TUnitOfWork : class, IUnitOfWork
    {
        private readonly ColumnView view;
        private readonly CollectionViewModel<TEntity, TID, TUnitOfWork> viewModel;

        public ColumnViewHelper(ColumnView view, CollectionViewModel<TEntity, TID, TUnitOfWork> viewModel)
        {
            this.view = view;
            this.viewModel = viewModel;
        }

        public bool ShowEntityMeny(Point pt, int rowHandle)
        {
            var entity = view.GetRow(rowHandle) as TEntity;
            if (entity != null)
            {
                var rowMenu = CreateEntityMenu(entity);
                MenuManagerHelper.ShowMenu(rowMenu, view.GridControl.LookAndFeel,
                    view.GridControl.MenuManager, view.GridControl, pt);
                return true;
            }
            return false;
        }

        public bool EditEntity(int rowHandle)
        {
            var entity = view.GetRow(rowHandle) as TEntity;
            if (entity != null && viewModel.CanEdit(entity))
            {
                viewModel.Edit(entity);
                return true;
            }
            return false;
        }

        protected DXPopupMenu CreateEntityMenu(TEntity entity)
        {
            var rowMenu = new DXPopupMenu();
            var newItem = new DXMenuItem();
            newItem.Caption = "New";
            newItem.BindCommand(() => viewModel.New(), viewModel);

            var editItem = new DXMenuItem();
            editItem.Caption = "Edit...";
            editItem.BindCommand(ee => viewModel.Edit(ee), viewModel, () => entity);

            var deleteItem = new DXMenuItem();
            deleteItem.Caption = "Delete";
            deleteItem.BindCommand(ee => viewModel.Delete(ee), viewModel, () => entity);

            rowMenu.Items.Add(newItem);
            rowMenu.Items.Add(editItem);
            rowMenu.Items.Add(deleteItem);
            return rowMenu;
        }
    }
}