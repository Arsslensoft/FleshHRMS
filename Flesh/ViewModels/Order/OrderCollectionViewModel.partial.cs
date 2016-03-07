using DevExpress.DevAV.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.DevAV.DevAVDbDataModel;
using DevExpress.DevAV;
using DevExpress.Mvvm;

namespace DevExpress.DevAV.ViewModels {
    partial class OrderCollectionViewModel {
        public List<SalesInfo> GetSales() {
            var salesInfoList = new List<SalesInfo>();
            var sortedOrders = GetSortedOrders();
            var startDate = sortedOrders[0].Order.OrderDate;
            var endDate = sortedOrders[sortedOrders.Count - 1].Order.OrderDate;
            for (var time = startDate; time.Year <= endDate.Year; time = time.AddYears(1)) {
                salesInfoList.Add(new SalesInfo() { time = time, ListProductInfo = GetSalesByYear(time)});
            }
            return salesInfoList;
        }
        private List<DevExpress.DevAV.OrderItem> GetSortedOrders() {
            var orderItems = GetOrders();
            return orderItems.OrderBy(e => e.Order.OrderDate).ToList();
        }

        private IQueryable<DevAV.OrderItem> GetOrders() {
            var unit = ((IDevAVDbUnitOfWork)Repository.UnitOfWork);
            var orderItems = unit.OrderItems.GetEntities();
            return orderItems;
        }
        protected string CorrectCamelCase(string input) {
            if(input == "VideoPlayers") return "Video Players";
            else return input;
        }
        private List<SalesProductInfo> GetSalesByYear(DateTime dateTime) {
            var unit = ((IDevAVDbUnitOfWork)Repository.UnitOfWork);
            var orderItems = unit.OrderItems.GetEntities();
            var sales = orderItems
                .Where(io => io.Order.OrderDate.Year == dateTime.Year)
                .GroupBy(oi => oi.Product.Category)
                .ToDictionary(g => g.Key, g => g.CustomSum(io => io.Total));
            return sales.Select(s => new SalesProductInfo { Name = CorrectCamelCase(s.Key.ToString()), Value = s.Value }).ToList();
        }
        private List<SalesProductInfo> GetSalesByMonth(DateTime dateTime) {
            var unit = ((IDevAVDbUnitOfWork)Repository.UnitOfWork);
            var orderItems = unit.OrderItems.GetEntities();
            var sales = orderItems
                .Where(io => io.Order.OrderDate.Year == dateTime.Year && io.Order.OrderDate.Month == dateTime.Month)
                .GroupBy(oi => oi.Product.Category)
                .ToDictionary(g => g.Key, g => g.CustomSum(io => io.Total));
            return sales.Select(s => new SalesProductInfo { Name = CorrectCamelCase(s.Key.ToString()), Value = s.Value }).ToList();
        }
        private List<SalesProductInfo> GetSalesToday(DateTime dateTime) {
            var unit = ((IDevAVDbUnitOfWork)Repository.UnitOfWork);
            var orderItems = unit.OrderItems.GetEntities();
            var sales = orderItems
                .Where(io => io.Order.OrderDate.Year == dateTime.Year && io.Order.OrderDate.Month == dateTime.Month && io.Order.OrderDate.Day == dateTime.Day)
                .GroupBy(oi => oi.Product.Category)
                .ToDictionary(g => g.Key, g => g.CustomSum(io => io.Total));
            return sales.Select(s => new SalesProductInfo { Name = CorrectCamelCase(s.Key.ToString()), Value = s.Value }).ToList();
        }

        private List<CostProductInfo> GetCostByYear(DateTime dateTime) {
            var unit = ((IDevAVDbUnitOfWork)Repository.UnitOfWork);
            var orderItems = unit.OrderItems.GetEntities();
            var cost = orderItems
                .Where(io => io.Order.OrderDate.Year == dateTime.Year)
                .GroupBy(oi => oi.Product.Category)
                .ToDictionary(g => g.Key, g => g.Average(io => io.ProductPrice));
            return cost.Select(s => new CostProductInfo { Name = CorrectCamelCase(s.Key.ToString()), Value = s.Value }).ToList();
        }
        private List<CostProductInfo> GetCostByMonth(DateTime dateTime) {
            var unit = ((IDevAVDbUnitOfWork)Repository.UnitOfWork);
            var orderItems = unit.OrderItems.GetEntities();
            var cost = orderItems
                .Where(io => io.Order.OrderDate.Year == dateTime.Year && io.Order.OrderDate.Month == dateTime.Month)
                .GroupBy(oi => oi.Product.Category)
                .ToDictionary(g => g.Key, g => g.Average(io => io.ProductPrice));
            return cost.Select(s => new CostProductInfo { Name = CorrectCamelCase(s.Key.ToString()), Value = s.Value }).ToList();
        }
        private List<CostProductInfo> GetCostToday(DateTime dateTime) {
            var unit = ((IDevAVDbUnitOfWork)Repository.UnitOfWork);
            var orderItems = unit.OrderItems.GetEntities();
            var cost = orderItems
                .Where(io => io.Order.OrderDate.Year == dateTime.Year && io.Order.OrderDate.Month == dateTime.Month && io.Order.OrderDate.Day == dateTime.Day)
                .GroupBy(oi => oi.Product.Category)
                .ToDictionary(g => g.Key, g => g.Average(io => io.ProductPrice));
            return cost.Select(s => new CostProductInfo { Name = CorrectCamelCase(s.Key.ToString()), Value = s.Value }).ToList();
        }

        public List<SalesInfo> GetSalesForDashboard() {
            var salesInfoList = new List<SalesInfo>();
            salesInfoList.Add(new SalesInfo() { ListProductInfo = GetSalesByYear(DateTime.Now) });
            salesInfoList.Add(new SalesInfo() { ListProductInfo = GetSalesByMonth(DateTime.Now) });
            salesInfoList.Add(new SalesInfo() { ListProductInfo = GetSalesToday(DateTime.Now) });
            return salesInfoList;
        }

        public List<CostInfo> GetCostForDashboard() {
            var salesInfoList = new List<CostInfo>();
            salesInfoList.Add(new CostInfo() { ListProductInfo = GetCostByYear(DateTime.Now) });
            salesInfoList.Add(new CostInfo() { ListProductInfo = GetCostByMonth(DateTime.Now) });
            salesInfoList.Add(new CostInfo() { ListProductInfo = GetCostToday(DateTime.Now) });
            return salesInfoList;
        }
        public override void Delete(Order entity) {
            MessageBoxService.ShowMessage("To ensure data integrity, the Sales module doesn't allow records to be deleted. Record deletion is supported by the Employees module.", "Delete Sale", MessageButton.OK);
        }
    }
    public class CostInfo {
        public List<CostProductInfo> ListProductInfo { get; set; }
        public CostInfo() {
            ListProductInfo = new List<CostProductInfo>();
        }
    }

    public class CostProductInfo {
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
    public class SalesInfo {
        public string Caption { get; set; }
        public List<SalesProductInfo> ListProductInfo { get; set; }
        public DateTime time { get; set; }
        public SalesInfo() {
            ListProductInfo = new List<SalesProductInfo>();
        }
    }
    public class SalesProductInfo {
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
