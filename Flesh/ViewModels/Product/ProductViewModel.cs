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
    /// Represents the single Product object view model.
    /// </summary>
    public partial class ProductViewModel : SingleObjectViewModel<Product, long, IDevAVDbUnitOfWork> {

        /// <summary>
        /// Initializes a new instance of the ProductViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the ProductViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected ProductViewModel(IUnitOfWorkFactory<IDevAVDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Products, x => x.Name) {
        }
        public ProductViewModel()
            : this(DbUnitOfWorkFactory.Instance) {
        }

        /// <summary>
        /// The look-up collection of Employees for the corresponding navigation property in the view.
        /// </summary>
        public IList<Employee> LookUpEmployees {
            get { return GetLookUpEntities(x => x.Employees); }
        }

        /// <summary>
        /// The look-up collection of Pictures for the corresponding navigation property in the view.
        /// </summary>
        public IList<Picture> LookUpPictures {
            get { return GetLookUpEntities(x => x.Pictures); }
        }

        protected override void RefreshLookUpCollections(long key) {
            ProductCatalogLookUp = CreateLookUpCollectionViewModel(x => x.ProductCatalogs, x => x.ProductId, (x, m) => x.Product = m, key);
            ProductOrderItemsLookUp = CreateLookUpCollectionViewModel(x => x.OrderItems, x => x.ProductId, (x, m) => x.Product = m, key);
            ProductImagesLookUp = CreateLookUpCollectionViewModel(x => x.ProductImages, x => x.ProductId, (x, m) => x.Product = m, key);
        }

        /// <summary>
        /// The view model for the ProductCatalog detail collection.
        /// </summary>
        public virtual CollectionViewModel<ProductCatalog, long, IDevAVDbUnitOfWork> ProductCatalogLookUp { get; set; }

        /// <summary>
        /// The view model for the ProductOrderItems detail collection.
        /// </summary>
        public virtual CollectionViewModel<OrderItem, long, IDevAVDbUnitOfWork> ProductOrderItemsLookUp { get; set; }

        /// <summary>
        /// The view model for the ProductImages detail collection.
        /// </summary>
        public virtual CollectionViewModel<ProductImage, long, IDevAVDbUnitOfWork> ProductImagesLookUp { get; set; }
    }
}
