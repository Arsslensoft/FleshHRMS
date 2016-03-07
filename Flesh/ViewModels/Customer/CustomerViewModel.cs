using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.DevAV.Common.Utils;
using DevExpress.DevAV.DevAVDbDataModel;
using DevExpress.DevAV.Common.DataModel;
using DevExpress.DevAV;
using DevExpress.DevAV.Common.ViewModel;

namespace DevExpress.DevAV.ViewModels {
    /// <summary>
    /// Represents the single Customer object view model.
    /// </summary>
    public abstract partial class CustomerViewModelBase : SingleObjectViewModel<Customer, long, IDevAVDbUnitOfWork> {

        /// <summary>
        /// Initializes a new instance of the CustomerViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the CustomerViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected CustomerViewModelBase(IUnitOfWorkFactory<IDevAVDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Customers, x => x.Name) {
        }

        protected override void RefreshLookUpCollections(long key) {
            CustomerEmployeesLookUp = CreateLookUpCollectionViewModel(x => x.CustomerEmployees, x => x.CustomerId, (x, m) => x.Customer = m, key);
            CustomerOrdersLookUp = CreateLookUpCollectionViewModel(x => x.Orders, x => x.CustomerId, (x, m) => x.Customer = m, key);
            CustomerQuotesLookUp = CreateLookUpCollectionViewModel(x => x.Quotes, x => x.CustomerId, (x, m) => x.Customer = m, key);
            CustomerCustomerStoresLookUp = CreateLookUpCollectionViewModel(x => x.CustomerStores, x => x.CustomerId, (x, m) => x.Customer = m, key);
        }

        /// <summary>
        /// The view model for the CustomerEmployees detail collection.
        /// </summary>
        public virtual CollectionViewModel<CustomerEmployee, long, IDevAVDbUnitOfWork> CustomerEmployeesLookUp { get; set; }

        /// <summary>
        /// The view model for the CustomerOrders detail collection.
        /// </summary>
        public virtual CollectionViewModel<Order, long, IDevAVDbUnitOfWork> CustomerOrdersLookUp { get; set; }

        /// <summary>
        /// The view model for the CustomerQuotes detail collection.
        /// </summary>
        public virtual CollectionViewModel<Quote, long, IDevAVDbUnitOfWork> CustomerQuotesLookUp { get; set; }

        /// <summary>
        /// The view model for the CustomerCustomerStores detail collection.
        /// </summary>
        public virtual CollectionViewModel<CustomerStore, long, IDevAVDbUnitOfWork> CustomerCustomerStoresLookUp { get; set; }
    }
}
