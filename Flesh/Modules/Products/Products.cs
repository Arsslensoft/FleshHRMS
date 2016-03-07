using System;
using System.Linq;
using System.Collections.Generic;
using DevExpress.DevAV.Helpers;
using DevExpress.DevAV.ViewModels;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.DevAV;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraGrid.Columns;
using System.Collections;
using DevExpress.DevAV.Common.ViewModel;
using DevExpress.XtraGrid;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Docking2010.Customization;
using System.Windows.Forms;

namespace DevExpress.DevAV.Modules {
    public enum ProductCustomFilter {
        HDVideoPlayer,
        Plasma,
        Monitor,
        RemoteControl,
        CdPlayer
    }
    public partial class Products : BaseModuleControl {
        BaseItemCollection hideItemCollection = new BaseItemCollection();
        SearchControl searchControl;
        TileBar productTileBar;
        public Products()
            : base(CreateViewModel<ProductCollectionViewModel>) {
            InitializeComponent();
            ((ITileControl)tileControl).Properties.LargeItemWidth = 200;
            tileControl.UseParentAutoScaleFactor = false;
            LoadData();
            UpdateTileAndItems();
            viewProducts.DataController.Refreshed += DataController_Refreshed;

        }
        bool lockRefreshed = false;
        void DataController_Refreshed(object sender, EventArgs e) {
            if(!lockRefreshed) {
                lockRefreshed = true;
                UpdateTileFilter(tileItemAll);
                UpdateTileFilter(tileItemAutomation);
                UpdateTileFilter(tileItemMonitors);
                UpdateTileFilter(tileItemProjectors);
                UpdateTileFilter(tileItemTelevisions);
                UpdateTileFilter(tileItemVideoPlayers);
                UpdateTileFilter(tileControl.SelectedItem);
                lockRefreshed = false;
            }
        }

        void UpdateTileAndItems() {
            tileItemAll.Text = ViewModel.AllCount.ToString();
            tileItemAutomation.Text = ViewModel.AutomationCount.ToString();
            tileItemMonitors.Text = ViewModel.MonitorsCount.ToString();
            tileItemProjectors.Text = ViewModel.ProjectorsCount.ToString();
            tileItemTelevisions.Text = ViewModel.TelevisionsCount.ToString();
            tileItemVideoPlayers.Text = ViewModel.VideoPlayersCount.ToString();
            hideItemCollection.Clear();
            hideItemCollection.AddRange(new XtraLayout.BaseLayoutItem[] { tileControlLCI });

        }
        protected override void OnParentChanged(System.EventArgs e) {
            base.OnParentChanged(e);
            if(Parent != null) {
                SubscribeTileBarProductsFilter();
            } else {
                if(productTileBar != null) productTileBar.ItemClick -= ProductTileBar_ItemClick;
                if(searchControl != null)searchControl.QueryIsSearchColumn -= searchControl_AllowSearchColumn;
            }
        }
        protected internal override void OnTransitionCompleted() {
            base.OnTransitionCompleted();
            InitializeButtonPanel();
        }

        void SubscribeTileBarProductsFilter() {
            if(ProductTileBar == null) return;
            productTileBar = ProductTileBar;
            productTileBar.ItemClick += ProductTileBar_ItemClick;
        }

        void ProductTileBar_ItemClick(object sender, TileItemEventArgs e) {
            lockRefreshed = true;
            if(e.Item.Tag is ProductCustomFilter) {
                ProductCustomFilter filter = (ProductCustomFilter)e.Item.Tag;
                switch(filter) {
                    case ProductCustomFilter.HDVideoPlayer:
                        SetCustomFilter("HD", ProductCategory.VideoPlayers);
                        break;
                    case ProductCustomFilter.Plasma:
                        SetCustomFilter("50", ProductCategory.Televisions);
                        break;
                    case ProductCustomFilter.Monitor:
                        SetCustomFilter("21", ProductCategory.Monitors);
                        break;
                    case ProductCustomFilter.RemoteControl:
                        SetCustomFilter("remote", ProductCategory.Automation);
                        break;
                    case ProductCustomFilter.CdPlayer:
                        SetCustomFilter("CD", ProductCategory.VideoPlayers);
                        break;
                }
            }
            if(e.Item.Tag is string) {
                SetFilterString((string)e.Item.Tag);
            }
            lockRefreshed = false;
        }

        bool SetFilterString(string filterString) {
            viewProducts.ActiveFilter.Clear();
            try {
                viewProducts.ActiveFilterCriteria = CriteriaOperator.TryParse(filterString);
                return true;
            } catch {
                return false;
            }
        }

        private void SetCustomFilter(string temp, ProductCategory category) {
            viewProducts.ActiveFilter.Clear();
            viewProducts.ActiveFilter.Add(viewProducts.Columns["Name"], new ColumnFilterInfo(CriteriaOperator.Parse(String.Format("Name like '%{0}%'", temp))));
            viewProducts.ActiveFilter.Add(viewProducts.Columns["Category"], new ColumnFilterInfo(CriteriaOperator.Parse("Category == ?", category)));
        }
        public ProductCollectionViewModel ViewModel {
            get {
                return GetViewModel<ProductCollectionViewModel>();
            }
        }
        void LoadData() {
            productsSource.SetItemsSource(ViewModel.Entities);
            viewProducts.BestFitColumns();
        }

        Hashtable cachedSales = new Hashtable();
        ICollection<double> ShapeUnboundDataForSparkline(ICollection<double> collection) {
            while(collection.Count != 12) {
                if(collection.Count > 12) collection.Remove(collection.Count - 1);
                if(collection.Count < 12) collection.Add(0);
            }
            return collection;
        }

        void gridView1_CustomUnboundColumnData(object sender, XtraGrid.Views.Base.CustomColumnDataEventArgs e) {
            if(e.Column.ColumnEdit is RepositoryItemSparklineEdit) {
                var product = (Product)e.Row;
                var cached = cachedSales[product];
                if(cached == null) {
                    cached = cachedSales[product] = ShapeUnboundDataForSparkline(ViewModel.GetMonthlySalesByProduct(product));
                }
                e.Value = cached;
            }
        }
        void InitializeButtonPanel() {
            var listBI = new List<ButtonInfo>();
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "New", Name = "2", Image = ImageHelper.GetImageFromToolbarResource("New"), mouseEventHandler = newProduct });
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Edit", Name = "3", Image = ImageHelper.GetImageFromToolbarResource("Edit"), mouseEventHandler = editProduct });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Custom Filter", Name = "6", Image = ImageHelper.GetImageFromToolbarResource("CustomFilter"), mouseEventHandler = customFilterClick });
            BottomPanel.InitializeButtons(listBI);
            searchControl = BottomPanel.searchControl;
            BottomPanel.searchControl.Client = gridProducts;
            BottomPanel.searchControl.QueryIsSearchColumn += new QueryIsSearchColumnEventHandler(searchControl_AllowSearchColumn);
        }


        private void customFilterClick(object sender, EventArgs e) {
            ProductCustomFilterModule customFilter = new ProductCustomFilterModule(ViewModel.Entities.ToBindingList());
            DialogResult result = FlyoutDialog.Show(FindForm(), customFilter);
            if(result == DialogResult.OK) {
                if(customFilter.checkEdit.Checked) {
                    if(SetFilterString(customFilter.filterControl.FilterString))
                        ProductTileBar.Groups[0].Items.Add(new TileBarItem() { TextAlignment = TileItemContentAlignment.MiddleCenter, Text = customFilter.textEdit.Text, Tag = customFilter.filterControl.FilterString });
                } else {
                    SetFilterString(customFilter.filterControl.FilterString);
                }

            }
        }
        void searchControl_AllowSearchColumn(object sender, QueryIsSearchColumnEventArgs e) {
            var column = sender as DevExpress.XtraEditors.Filtering.FilterColumn;
            if(column == null) {
                return;
            }
            if(column.FieldName != string.Empty) {
                e.IsSearchColumn = true;
            } else {
                e.IsSearchColumn = false;
            }
        }
        void editProduct(object sender, EventArgs e) {
            ShowEditModuleForFocusedRow();
        }
        void newProduct(object sender, EventArgs e) {
            ShowEditModule(null);
            UpdateTileAndItems();
        }
        void ShowEditModuleForFocusedRow() {
            var product = viewProducts.GetFocusedRow() as Product;
            if(product == null) return;
            ShowEditModule(product);
        }
        void viewProducts_RowClick(object sender, XtraGrid.Views.Grid.RowClickEventArgs e) {
            if(e.Clicks > 1 && e.RowHandle >= 0) {
                ShowEditModuleForFocusedRow();
            }
        }

        void ShowEditModule(Product productToEdit) {
            var main = GetParentViewModel<MainViewModel>();
            main.SelectModule(ModuleType.ProductsEditableView, (x) => {
                if(productToEdit != null) {
                    ViewModelHelper.EnsureModuleViewModel(main.SelectedModule, GetParentViewModel<MainViewModel>(), productToEdit.Id);
                }
                else {
                    ViewModelHelper.EnsureModuleViewModel(main.SelectedModule, GetParentViewModel<MainViewModel>(), new DefaultEntityInitializer<Product, DevAV.DevAVDbDataModel.IDevAVDbUnitOfWork>());
                }
                ((BaseModuleControl)main.SelectedModule).Refresh();
            });
        }
        string currentFilter = null;
        void UpdateTileFilter(TileItem tileItem) {
            string filter = (string)tileItem.Tag;
            if(filter == currentFilter) return;
            currentFilter = filter;

            ProductCategory category = ProductCategory.Automation;
            if(!Enum.TryParse<ProductCategory>(currentFilter, out category)) {
                currentFilter = null;
            }
            viewProducts.ActiveFilter.Clear();
            if(currentFilter != null) viewProducts.ActiveFilter.Add(viewProducts.Columns["Category"], new ColumnFilterInfo(CriteriaOperator.Parse("Category == ?", category)));
            tileItem.Text = viewProducts.RowCount.ToString();
        }
        private void tileControl_ItemClick(object sender, TileItemEventArgs e) {
            UpdateTileFilter(e.Item);
        }


        void hideButton_Click(object sender, EventArgs e) {
            if(tileControlLCI.Visibility == XtraLayout.Utils.LayoutVisibility.Always) {
                ItemsHideHelper.Hide(hideItemCollection, hideButton);
                productsSLI.Padding = new XtraLayout.Utils.Padding(25, 2, 10, 10);

                return;
            }
            if(tileControlLCI.Visibility == XtraLayout.Utils.LayoutVisibility.Never) {
                ItemsHideHelper.Expand(hideItemCollection, hideButton);
                productsSLI.Padding = new XtraLayout.Utils.Padding(2, 2, 10, 10);
                return;
            }
        }

        private void viewProducts_FocusedRowObjectChanged(object sender, XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e) {
            ViewModel.SelectedEntity = e.Row as Product;
        }

    }
}
