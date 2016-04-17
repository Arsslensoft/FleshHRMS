using PHRMS.Data;

namespace PHRMS.ViewModels
{
    /// <summary>
    ///     Represents the Congés collection view model.
    /// </summary>
    public partial class WarningsCollectionViewModel : CollectionViewModel<Warning, long, IPhexonDbUnitOfWork>
    {
        /// <summary>
        ///     Initializes a new instance of the LeaveCollectionViewModel class.
        ///     This constructor is declared protected to avoid undesired instantiation of the LeaveCollectionViewModel type
        ///     without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected WarningsCollectionViewModel(IUnitOfWorkFactory<IPhexonDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Warnings)
        {
        }

        public WarningsCollectionViewModel()
            : this(DbUnitOfWorkFactory.Instance)
        {
        }
    }
}