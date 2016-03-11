namespace FHRMS.ViewModels {
    using System;
    using FHRMS.Data;
    using FHRMS.ViewModels;
    using System.Linq;
    using System.Collections.Generic;
    using FHRMS.DevAVDbDataModel;

    partial class QuoteViewModel : IBaseViewModel {
        public event EventHandler EntityChanged;
        protected override void OnEntityChanged() {
            base.OnEntityChanged();
            EventHandler handler = EntityChanged;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }
        public IEnumerable<CustomerStore> GetStores() {
            return Entity.Customer.CustomerStores;
        }
    }
}
