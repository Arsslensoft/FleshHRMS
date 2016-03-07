namespace DevExpress.DevAV.ViewModels {
    using System;
    using DevExpress.DevAV.ViewModels;
    using System.Linq;
    using System.Collections.Generic;
    using DevExpress.DevAV.DevAVDbDataModel;
    using DevExpress.DevAV;
    using DevExpress.Mvvm;

    partial class QuoteCollectionViewModel {
        IEnumerable<CustomerStore> stores;
        internal object GetQuoteInfos() {
            return QueriesHelper.GetSummaryOpportunities(Entities.AsQueryable()).ToList();
        }
        public List<StoreQuoteInfo> GetStoreInfo() {
            List<StoreQuoteInfo> result = new List<StoreQuoteInfo>();
            if(stores == null)
                stores = Entities.GroupBy(e => e.CustomerStore.City).Select(v => v.First()).Select(r => r.CustomerStore);
            foreach(CustomerStore s in stores) {
                result.Add(new StoreQuoteInfo() { Store = s, Opportunities = Entities.Where(r => r.CustomerStore.City == s.City).CustomSum(q => q.Total) });
            }
            return result;
        }
        public override void Delete(Quote entity) {
            MessageBoxService.ShowMessage("To ensure data integrity, the Opportunities module doesn't allow records to be deleted. Record deletion is supported by the Employees module.", "Delete Opportunity", MessageButton.OK);
        }
    }

    public class StoreQuoteInfo {
        public CustomerStore Store { get; set; }
        public decimal Opportunities { get; set; }
    }
}
