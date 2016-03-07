using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.DevAV.Common.DataModel.EntityFramework;

namespace DevExpress.DevAV.DevAVDbDataModel {
    public class QuoteRepository : DbRepository<Quote, long, DevAVDb> {
        public QuoteRepository(DbUnitOfWork<DevAVDb> unitOfWork) : base(unitOfWork, x => x.Set<Quote>(), x => x.Id) { }
        protected override IQueryable<Quote> GetEntities() {
            return base.GetEntities().Where(o => o.Date < DateTime.Now);
        }
    }
}
