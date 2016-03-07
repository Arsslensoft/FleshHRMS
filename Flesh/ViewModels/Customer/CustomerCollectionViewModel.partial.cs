namespace DevExpress.DevAV.ViewModels {
    using System;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.DevAV;
    using System.Linq;
    using System.Collections.Generic;
    using DevExpress.DevAV.DevAVDbDataModel;
    using DevExpress.Mvvm;

    partial class CustomerCollectionViewModel {
        public ICollection<double> GetMonthlySalesByCustomer(Customer customer) {
            if(customer == null || customer.Orders == null) return new double[0];
            return customer.Orders.GroupBy(o => o.OrderDate.Month).Select(g => (double)g.CustomSum(i => i.TotalAmount)).ToList();
        }
        public List<CustomerStore> GetCustomerStoresByCustomer(Customer customer) {
            var querableStores = DbUnitOfWorkFactory.Instance.CreateUnitOfWork().CustomerStores.GetEntities();
            return querableStores.Where(e => e.Customer.Id == customer.Id).ToList();
        }
        public override void Delete(Customer entity) {
            MessageBoxService.ShowMessage("To ensure data integrity, the Customers module doesn't allow records to be deleted. Record deletion is supported by the Employees module.", "Delete Customer", MessageButton.OK);
        }
    }
}
