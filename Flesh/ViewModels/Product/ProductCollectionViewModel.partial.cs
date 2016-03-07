namespace DevExpress.DevAV.ViewModels {
    using System;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.DevAV;
    using System.Linq;
    using DevExpress.DevAV.DevAVDbDataModel;
    using System.Collections.Generic;
    using DevExpress.Mvvm;

    partial class ProductCollectionViewModel {
        public ICollection<double> GetMonthlySalesByProduct(Product product) {
            var productSales = UnitOfWork.OrderItems.GetEntities().Where(o => o.Product.Id == product.Id);
            var productSalesByMonth = productSales.GroupBy(o => o.Order.OrderDate.Month);
            var productSalesSumByMonth = productSalesByMonth.Select(g => g.Select(i => (double?)i.Total).Sum() ?? 0);
            return productSalesSumByMonth.ToList();
        }
        public int AllCount {
            get {
                return GetAllCount();
            }
        }

        public int TelevisionsCount {
            get {
                return GetTelevisionsCount();
            }
        }
        public int ProjectorsCount {
            get {
                return GetProjectorsCount();
            }
        }
        public int VideoPlayersCount {
            get {
                return GetVideoPlayersCount();
            }
        }
        public int MonitorsCount {
            get {
                return GetMonitorsCount();
            }
        }
        public int AutomationCount {
            get {
                return GetAutomationCount();
            }
        }
        private int GetAllCount() {
            return Entities.Count();
        }
        private int GetAutomationCount() {
            return Entities.Where(e => e.Category == ProductCategory.Automation).Count();
        }
        private int GetMonitorsCount() {
            return Entities.Where(e => e.Category == ProductCategory.Monitors).Count();
        }
        private int GetVideoPlayersCount() {
            return Entities.Where(e => e.Category == ProductCategory.VideoPlayers).Count();
        }
        private int GetProjectorsCount() {
            return Entities.Where(e => e.Category == ProductCategory.Projectors).Count();
        }
        private int GetTelevisionsCount() {
            return Entities.Where(e => e.Category == ProductCategory.Televisions).Count();
        }
        public override void Delete(Product entity) {
            MessageBoxService.ShowMessage("To ensure data integrity, the Products module doesn't allow records to be deleted. Record deletion is supported by the Employees module.", "Delete Product", MessageButton.OK);
        }
    }
}
