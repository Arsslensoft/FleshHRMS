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
    /// Represents the single Quote object view model.
    /// </summary>
    public partial class QuoteViewModel : SingleObjectViewModel<Quote, long, IDevAVDbUnitOfWork> {

        /// <summary>
        /// Initializes a new instance of the QuoteViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the QuoteViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected QuoteViewModel(IUnitOfWorkFactory<IDevAVDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Quotes, x => x.Number) {
        }
        public QuoteViewModel()
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
            QuoteQuoteItemsLookUp = CreateLookUpCollectionViewModel(x => x.QuoteItems, x => x.QuoteId, (x, m) => x.Quote = m, key);
        }

        /// <summary>
        /// The view model for the QuoteQuoteItems detail collection.
        /// </summary>
        public virtual CollectionViewModel<QuoteItem, long, IDevAVDbUnitOfWork> QuoteQuoteItemsLookUp { get; set; }
    }
}
