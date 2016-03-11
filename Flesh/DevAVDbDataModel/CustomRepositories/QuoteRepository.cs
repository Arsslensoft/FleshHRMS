using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHRMS.Common.DataModel.EntityFramework;
using FHRMS.Data;
namespace FHRMS.DevAVDbDataModel {
    public class QuoteRepository : DbRepository<Quote, long, DevAVDb> {
        public QuoteRepository(DbUnitOfWork<DevAVDb> unitOfWork) : base(unitOfWork, x => x.Set<Quote>(), x => x.Id) { }
        protected override IQueryable<Quote> GetEntities() {
            return base.GetEntities().Where(o => o.Date < DateTime.Now);
        }
    }
}
