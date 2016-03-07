namespace DevExpress.DevAV.Modules {
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Reflection;
    using DevExpress.DevAV;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.Map;
    using DevExpress.XtraEditors;
    using DevExpress.XtraMap;

    public partial class CustomerMapView : XtraUserControl {
        List<StoreProductSale> listStores;
        protected VectorItemsLayer Background {
            get {
                return (VectorItemsLayer)(mapControl.Layers[0]);
            }
        }
        protected VectorItemsLayer HomeLayer {
            get {
                return (VectorItemsLayer)(mapControl.Layers[2]);
            }
        }
        protected VectorItemsLayer StoresLayer {
            get {
                return (VectorItemsLayer)(mapControl.Layers[1]);
            }
        }
        protected MapItemStorage HomeData {
            get {
                return (MapItemStorage)HomeLayer.Data;
            }
        }
        protected BubbleChartDataAdapter StoreData {
            get {
                return (BubbleChartDataAdapter)StoresLayer.Data;
            }
        }


        public CustomerMapView() {
            InitializeComponent();
            InitMap();
        }

        void InitMap() {
            var adapter = new ShapefileDataAdapter();
            Background.Data = adapter;
            if(DesignMode || Assembly.GetEntryAssembly() == null) {
                return;
            }
            var mapStreamDbf = Assembly.GetEntryAssembly().GetManifestResourceStream("DevExpress.DevAV.Resources.Map.NorthAmerica.dbf");
            var mapStream = Assembly.GetEntryAssembly().GetManifestResourceStream("DevExpress.DevAV.Resources.Map.NorthAmerica.shp");
            adapter.LoadFromStream(mapStream, mapStreamDbf);
        }
        CustomerViewModel viewModelCore = null;
        public CustomerViewModel ViewModel {
            get {
                return viewModelCore;
            }
            set {
                viewModelCore = value;
                viewModel_EntityChanged(this, null);
            }
        }
        void viewModel_EntityChanged(object sender, System.EventArgs e) {
            UpdateUI(ViewModel);
        }
        public void UpdateUI(CustomerViewModel customerVM) {
            if(customerVM == null) {
                return;
            }
            if(customerVM.Entity == null) {
                return;
            }
            var customer = customerVM.Entity;
            bindingSource.DataSource = customerVM.Entity;
            HomeData.Items.Clear();
            listStores = CreateStoreItems(customerVM);
            if(listStores.Count == 0) return;
            HomeData.Items.Add(listStores.Last().MapItem);
            mapControl.CenterPoint = new GeoPoint(listStores.Last().Latitude,listStores.Last().Longitude);
            StoreData.DataSource = listStores;
            StoreData.ItemMaxSize = 50;
            StoreData.ItemMinSize = 20;
            mapControl.SelectionMode = ElementSelectionMode.None;
            StoresLayer.SelectedItem = listStores.Last();
        }
        List<StoreProductSale> CreateStoreItems(CustomerViewModel customerVM) {
            var cities = new HashSet<string>();
            var result = new List<StoreProductSale>();
            if(customerVM.Entity.CustomerStores == null) return result;
            foreach(CustomerStore s in customerVM.Entity.CustomerStores) {
                var city = s.Address.City;
                if(!cities.Contains(city)) {
                    cities.Add(city);
                    decimal totalSales = customerVM.GetOrdersTotal(s, customerVM.Minimum, customerVM.Maximum);
                    if(totalSales != 0M) {
                        var item = new StoreProductSale(s);
                        decimal opportunities = customerVM.GetQuotesTotal(s, customerVM.Minimum, customerVM.Maximum);
                        item.Total = totalSales;
                        item.MapItem = CreateHomeOfficeItem(string.Format("TOTAL SALES{3}<color=47,81,165><b><size=+4>{0:c}</color></size></b>{3}TOTAL OPPORTUNITIES{3}<color=206,113,0><b><size=+4>{1:c}</color></size></b>{3}{2}", totalSales, opportunities, s.City, "<br>"), new GeoPoint(s.Address.Latitude, s.Address.Longitude));
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        DevExpress.XtraMap.MapItem CreateHomeOfficeItem(string city, GeoPoint location) {
            var home = new MapCallout();
            home.Location = location;
            home.Text = city;
            home.AllowHtmlText = true;
            home.TextAlignment = TextAlignment.TopCenter;
            home.Font = new System.Drawing.Font("Segoe UI", 13);
            home.TextColor = Color.FromArgb(145, 145, 145);
            return home;
        }

        void toolTipController1_BeforeShow(object sender, Utils.ToolTipControllerShowEventArgs e) {
        }

        void mapControl_MapItemClick(object sender, MapItemClickEventArgs e) {
            MapBubble bubble = e.Item as MapBubble;
            if(bubble != null) {
                StoresLayer.SelectedItem = e.Item;
                HomeData.Items.Clear();
                var last = listStores.FindLast(q => q.Latitude == bubble.Location.GetY());
                if(last != null)
                    HomeData.Items.Add(last.MapItem);
            }
        }
    }
    internal class StoreProductSale {
        CustomerStore store;
        public DevExpress.XtraMap.MapItem MapItem { get; set; }
        public StoreProductSale(CustomerStore store) {
            this.store = store;
        }
        public string City {
            get {
                return store.Address.City;
            }
        }
        public double Longitude {
            get {
                return store.Address.Longitude;
            }
        }
        public double Latitude {
            get {
                return store.Address.Latitude;
            }
        }

        public decimal Total { get; set; }
    }
}
