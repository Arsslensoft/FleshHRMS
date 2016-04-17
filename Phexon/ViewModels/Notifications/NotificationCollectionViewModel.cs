using PHRMS.Data;

namespace PHRMS.ViewModels
{
    /// <summary>
    ///     Represents the Orders collection view model.
    /// </summary>
    public partial class NotificationCollectionViewModel : CollectionViewModel<Notification, long, IPhexonDbUnitOfWork>
    {
        /// <summary>
        ///     Initializes a new instance of the OrderCollectionViewModel class.
        ///     This constructor is declared protected to avoid undesired instantiation of the OrderCollectionViewModel type
        ///     without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected NotificationCollectionViewModel(IUnitOfWorkFactory<IPhexonDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Notifications)
        {
        }

        public NotificationCollectionViewModel()
            : this(DbUnitOfWorkFactory.Instance)
        {
        }
    }
}