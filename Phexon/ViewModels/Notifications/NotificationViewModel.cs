﻿using System.Collections.Generic;
using PHRMS.Data;

namespace PHRMS.ViewModels
{
    /// <summary>
    ///     Represents the single Order object view model.
    /// </summary>
    public partial class NotificationViewModel : SingleObjectViewModel<Notification, long, IPhexonDbUnitOfWork>
    {
        /// <summary>
        ///     Initializes a new instance of the OrderViewModel class.
        ///     This constructor is declared protected to avoid undesired instantiation of the OrderViewModel type without the POCO
        ///     proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected NotificationViewModel(IUnitOfWorkFactory<IPhexonDbUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory, x => x.Notifications, x => x.Id)
        {
        }

        public NotificationViewModel()
            : this(DbUnitOfWorkFactory.Instance)
        {
        }


        /// <summary>
        ///     The look-up collection of Employés for the corresponding navigation property in the view.
        /// </summary>
        public IList<Employee> LookUpEmployees
        {
            get { return GetLookUpEntities(x => x.Employees); }
        }

        protected override void RefreshLookUpCollections(long key)
        {
            //    OrderOrderItemsLookUp = CreateLookUpCollectionViewModel(x => x.OrderItems, x => x.OrderId, (x, m) => x.Order = m, key);
        }
    }
}