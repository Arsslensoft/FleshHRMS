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
    /// Represents the single Order object view model.
    /// </summary>
    public partial class OrderViewModel : SingleObjectViewModel<Order, long, IDevAVDbUnitOfWork> {

        /// <summary>
        /// Initializes a new instance of the OrderViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the OrderViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected OrderViewModel(IUnitOfWorkFactory<IDevAVDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Orders, x => x.InvoiceNumber) {
        }
        public OrderViewModel()
            : this(DbUnitOfWorkFactory.Instance) {
        }

        /// <summary>
        /// The look-up collection of Customers for the corresponding navigation property in the view.
        /// </summary>
        public IList<Customer> LookUpCustomers {
            get { return GetLookUpEntities(x => x.Customers); }
        }

        /// <summary>
        /// The look-up collection of CustomerStores for the corresponding navigation property in the view.
        /// </summary>
        public IList<CustomerStore> LookUpCustomerStores {
            get { return GetLookUpEntities(x => x.CustomerStores); }
        }

        /// <summary>
        /// The look-up collection of Employees for the corresponding navigation property in the view.
        /// </summary>
        public IList<Employee> LookUpEmployees {
            get { return GetLookUpEntities(x => x.Employees); }
        }

        protected override void RefreshLookUpCollections(long key) {
            OrderOrderItemsLookUp = CreateLookUpCollectionViewModel(x => x.OrderItems, x => x.OrderId, (x, m) => x.Order = m, key);
        }

        /// <summary>
        /// The view model for the OrderOrderItems detail collection.
        /// </summary>
        public virtual CollectionViewModel<OrderItem, long, IDevAVDbUnitOfWork> OrderOrderItemsLookUp { get; set; }
    }
}
