using System;
using System.Linq;
using DevExpress.Mvvm.POCO;
using FHRMS.Common.Utils;
using FHRMS.DevAVDbDataModel;
using FHRMS.Common.DataModel;
using FHRMS.Data;
using FHRMS.Common.ViewModel;
using System.Collections.Generic;
using DevExpress.Mvvm;

namespace FHRMS.ViewModels {
    /// <summary>
    /// Represents the Products collection view model.
    /// </summary>
    public partial class ProductCollectionViewModel : CollectionViewModel<Product, long, IDevAVDbUnitOfWork> {

        /// <summary>
        /// Initializes a new instance of the ProductCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the ProductCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected ProductCollectionViewModel(IUnitOfWorkFactory<IDevAVDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Products) {
        }
        public ProductCollectionViewModel()
            : this(DbUnitOfWorkFactory.Instance) {
        }
    }
}
