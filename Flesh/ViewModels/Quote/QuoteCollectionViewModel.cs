using System;
using System.Linq;
using DevExpress.Mvvm.POCO;
using DevExpress.DevAV.Common.Utils;
using DevExpress.DevAV.DevAVDbDataModel;
using DevExpress.DevAV.Common.DataModel;
using DevExpress.DevAV;
using DevExpress.DevAV.Common.ViewModel;
using System.Collections.Generic;
using System.Linq.Expressions;
using DevExpress.Mvvm;
using System.Data.Entity;

namespace DevExpress.DevAV.ViewModels {
    /// <summary>
    /// Represents the Quotes collection view model.
    /// </summary>
    public partial class QuoteCollectionViewModel : CollectionViewModel<Quote, long, IDevAVDbUnitOfWork> {

        /// <summary>
        /// Initializes a new instance of the QuoteCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the QuoteCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected QuoteCollectionViewModel(IUnitOfWorkFactory<IDevAVDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Quotes) {
        }
        public QuoteCollectionViewModel()
            : this(DbUnitOfWorkFactory.Instance) {
        }
    }
}
