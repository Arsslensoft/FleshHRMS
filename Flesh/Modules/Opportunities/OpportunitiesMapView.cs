namespace DevExpress.DevAV.Modules {
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Reflection;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.Map;
    using DevExpress.XtraEditors;
    using DevExpress.XtraMap;

    public partial class OpportunitiesMapView : XtraUserControl, DevExpress.XtraPrinting.IBasePrintableProvider {
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
        public OpportunitiesMapView() {
            InitializeComponent();
            InitMap();
        }

        private void InitMap() {
            var adapter = new ShapefileDataAdapter();
            Background.Data = adapter;
            if (DesignMode || Assembly.GetEntryAssembly() == null) {
                return;
            }
            var mapStreamDbf = Assembly.GetEntryAssembly().GetManifestResourceStream("DevExpress.DevAV.Resources.Map.NorthAmerica.dbf");
            var mapStream = Assembly.GetEntryAssembly().GetManifestResourceStream("DevExpress.DevAV.Resources.Map.NorthAmerica.shp");
            adapter.LoadFromStream(mapStream, mapStreamDbf);
        }
        private QuoteCollectionViewModel quoteCore = null;
        public QuoteCollectionViewModel Quote {
            get {
                return quoteCore;
            }
            set {
                quoteCore = value;
                viewModel_EntityChanged(this, null);
            }
        }
        private void viewModel_EntityChanged(object sender, System.EventArgs e) {
            UpdateUI(Quote);
        }
        private void UpdateUI(QuoteCollectionViewModel quote) {
            if (quote == null) {
                return;
            }
            HomeData.Items.Clear();
            listStores = CreateStoreItems(quote.GetStoreInfo());
            HomeData.Items.Add(listStores.Last().MapItem);
            mapControl.CenterPoint = new GeoPoint(listStores.Last().Latitude,listStores.Last().Longitude);
            StoreData.DataSource = listStores;
            StoreData.ItemMaxSize = 50;
            StoreData.ItemMinSize = 20;
            mapControl.SelectionMode = ElementSelectionMode.None;
            StoresLayer.SelectedItem = listStores.Last();
        }

        private List<StoreProductSale> CreateStoreItems(List<StoreQuoteInfo> quote) {
            var cities = new HashSet<string>();
            var result = new List<StoreProductSale>();
            foreach(StoreQuoteInfo s in quote) {
                var city = s.Store.City;
                if (!cities.Contains(city)) {
                    if(s.Opportunities != 0M) {
                        cities.Add(city);
                        var item = new StoreProductSale(s.Store);
                        item.Total = s.Opportunities;
                        item.MapItem = CreateHomeOfficeItem(string.Format("TOTAL OPPORTUNITIES{2}<color=206,113,0><b><size=+4>{0:c}</color></size></b>{2}{1}", s.Opportunities, s.Store.City, "<br>"), new GeoPoint(s.Store.Address.Latitude, s.Store.Address.Longitude));
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        private MapItem CreateHomeOfficeItem(string city, GeoPoint location) {
            var home = new MapCallout();
            home.Location = location;
            home.Text = city;
            home.AllowHtmlText = true;
            home.TextAlignment = TextAlignment.TopCenter;
            home.Font = new System.Drawing.Font("Segoe UI", 13);
            home.TextColor = Color.FromArgb(145, 145, 145);
            return home;
        }

        private void toolTipController1_BeforeShow(object sender, Utils.ToolTipControllerShowEventArgs e) {
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
        object XtraPrinting.IBasePrintableProvider.GetIPrintableImplementer() {
            return mapControl;
        }
    }
}
