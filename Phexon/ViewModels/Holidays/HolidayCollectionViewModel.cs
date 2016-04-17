﻿using PHRMS.Data;

namespace PHRMS.ViewModels
{
    /// <summary>
    ///     Represents the Absences collection view model.
    /// </summary>
    public class HolidayCollectionViewModel : CollectionViewModel<Holiday, long, IPhexonDbUnitOfWork>
    {
        /// <summary>
        ///     Initializes a new instance of the EvaluationCollectionViewModel class.
        ///     This constructor is declared protected to avoid undesired instantiation of the EvaluationCollectionViewModel type
        ///     without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected HolidayCollectionViewModel(IUnitOfWorkFactory<IPhexonDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Holidays)
        {
        }

        public HolidayCollectionViewModel()
            : this(DbUnitOfWorkFactory.Instance)
        {
        }
    }
}