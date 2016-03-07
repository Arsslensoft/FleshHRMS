using System;
using System.Linq;
using DevExpress.Mvvm.POCO;
using DevExpress.DevAV.Common.Utils;
using DevExpress.DevAV.DevAVDbDataModel;
using DevExpress.DevAV.Common.DataModel;
using DevExpress.DevAV;
using DevExpress.DevAV.Common.ViewModel;
using System.Collections.Generic;
using DevExpress.Mvvm;

namespace DevExpress.DevAV.ViewModels {
    /// <summary>
    /// Represents the Customers collection view model.
    /// </summary>
    public partial class CustomerCollectionViewModel :CollectionViewModel<Customer, long, IDevAVDbUnitOfWork> {
        /// <summary>
        /// Initializes a new instance of the CustomerCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the CustomerCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected CustomerCollectionViewModel(IUnitOfWorkFactory<IDevAVDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Customers) {
        }
        public CustomerCollectionViewModel()
            : this(DbUnitOfWorkFactory.Instance) {

        }
        static DateTime dateBegin = new DateTime(2013, 01, 01);
        static DateTime dateEnd = new DateTime(2014, 01, 01);
        internal object GetTotalSales(System.Collections.IList list) {
            if(list.Count == 0) return 0;
            return Entities.Where(r => list.Contains(r)).SelectMany(q => q.Orders).Where(e => e.OrderDate > dateBegin && e.OrderDate < dateEnd).Sum(i => i.TotalAmount) * 10;
        }
    }
}
