namespace DevExpress.DevAV.ViewModels {
    using System;
    using DevExpress.DevAV.ViewModels;
    using System.Linq;
    using System.Collections.Generic;
    using DevExpress.DevAV.DevAVDbDataModel;
    using DevExpress.DevAV;
    using DevExpress.Mvvm;

    public partial class CustomerViewModel : CustomerViewModelBase, IBaseViewModel {
        public CustomerViewModel()
            : base(DbUnitOfWorkFactory.Instance) {
        }
        public DateTime Minimum { get; set; }
        public DateTime Maximum { get; set; }
        public decimal GetOrdersTotal(CustomerStore store, DateTime begin, DateTime end) {
            var orders = from order in store.Customer.Orders
                         where order.StoreId == store.Id && order.OrderDate >= begin && order.OrderDate <= end
                         select order;
            return orders.CustomSum(order => order.TotalAmount);
        }
        public decimal GetQuotesTotal(CustomerStore store, DateTime begin, DateTime end) {
            return QueriesHelper.GetQuotesTotal(UnitOfWork.Quotes.GetEntities(), store, begin, end);
        }
        public override void Delete() {
            MessageBoxService.ShowMessage("To ensure data integrity, the Customers module doesn't allow records to be deleted. Record deletion is supported by the Employees module.", "Delete Customer", MessageButton.OK);
        }
    }
}
