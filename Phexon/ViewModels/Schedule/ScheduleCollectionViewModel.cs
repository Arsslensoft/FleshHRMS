using System;
using System.Linq;
using DevExpress.Mvvm.POCO;
using PHRMS.Utils;
using PHRMS.Data;

using PHRMS.ViewModels;

namespace PHRMS.ViewModels {
    /// <summary>
    /// Represents the Absences collection view model.
    /// </summary>
    public partial class ScheduleCollectionViewModel : CollectionViewModel<Shift, long, IPhexonDbUnitOfWork> {

        /// <summary>
        /// Initializes a new instance of the EvaluationCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the EvaluationCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected ScheduleCollectionViewModel(IUnitOfWorkFactory<IPhexonDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Shifts) {
        }
        public ScheduleCollectionViewModel()
            : this(DbUnitOfWorkFactory.Instance) {
        }
    }
}
