namespace DevExpress.DevAV {
    using System.Drawing;
    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.DevAV.Common.ViewModel;
    using DevExpress.DevAV.Common.DataModel;

    internal class ColumnViewHelper<TEntity, TID, TUnitOfWork>
        where TEntity: class
        where TUnitOfWork : class, IUnitOfWork
        {
            private CollectionViewModel<TEntity, TID, TUnitOfWork> viewModel;
            private ColumnView view;
            public ColumnViewHelper(ColumnView view, CollectionViewModel<TEntity, TID, TUnitOfWork> viewModel) {
                this.view = view;
                this.viewModel = viewModel;
            }
            public bool ShowEntityMeny(Point pt, int rowHandle) {
                var entity = view.GetRow(rowHandle) as TEntity;
                if (entity != null) {
                    var rowMenu = CreateEntityMenu(entity);
                    DevExpress.Utils.Menu.MenuManagerHelper.ShowMenu(rowMenu, view.GridControl.LookAndFeel,
                    view.GridControl.MenuManager, view.GridControl, pt);
                    return true;
                }
                return false;
            }
            public bool EditEntity(int rowHandle) {
                var entity = view.GetRow(rowHandle) as TEntity;
                if (entity != null && viewModel.CanEdit(entity)) {
                    viewModel.Edit(entity);
                    return true;
                }
                return false;
            }
            protected Utils.Menu.DXPopupMenu CreateEntityMenu(TEntity entity) {
                var rowMenu = new Utils.Menu.DXPopupMenu();
                var newItem = new Utils.Menu.DXMenuItem();
                newItem.Caption = "New";
                newItem.BindCommand(() => viewModel.New(), viewModel);

                var editItem = new Utils.Menu.DXMenuItem();
                editItem.Caption = "Edit...";
                editItem.BindCommand((ee) => viewModel.Edit(ee), viewModel, () => entity);

                var deleteItem = new Utils.Menu.DXMenuItem();
                deleteItem.Caption = "Delete";
                deleteItem.BindCommand((ee) => viewModel.Delete(ee), viewModel, () => entity);

                rowMenu.Items.Add(newItem);
                rowMenu.Items.Add(editItem);
                rowMenu.Items.Add(deleteItem);
                return rowMenu;
            }
        }
    }
