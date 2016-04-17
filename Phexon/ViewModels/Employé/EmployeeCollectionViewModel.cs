using PHRMS.Data;

namespace PHRMS.ViewModels
{
    /// <summary>
    ///     Represents the Employés collection view model.
    /// </summary>
    public partial class EmployeeCollectionViewModel : CollectionViewModel<Employee, long, IPhexonDbUnitOfWork>
    {
        /// <summary>
        ///     Initializes a new instance of the EmployeeCollectionViewModel class.
        ///     This constructor is declared protected to avoid undesired instantiation of the EmployeeCollectionViewModel type
        ///     without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected EmployeeCollectionViewModel(IUnitOfWorkFactory<IPhexonDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Employees)
        {
        }

        public EmployeeCollectionViewModel()
            : this(DbUnitOfWorkFactory.Instance)
        {
        }
    }
}