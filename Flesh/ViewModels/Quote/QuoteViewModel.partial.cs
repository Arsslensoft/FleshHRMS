namespace DevExpress.DevAV.ViewModels {
    using System;
    using DevExpress.DevAV;
    using DevExpress.DevAV.ViewModels;
    using System.Linq;
    using System.Collections.Generic;
    using DevExpress.DevAV.DevAVDbDataModel;

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
