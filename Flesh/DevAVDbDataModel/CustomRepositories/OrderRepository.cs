using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.DevAV.Common.DataModel.EntityFramework;

namespace DevExpress.DevAV.DevAVDbDataModel {
    public class OrderRepository : DbRepository<Order, long, DevAVDb> {
        public OrderRepository(DbUnitOfWork<DevAVDb> unitOfWork) : base(unitOfWork, x => x.Set<Order>(), x => x.Id) { }
        protected override IQueryable<Order> GetEntities() {
            return base.GetEntities().Where(o => o.OrderDate < DateTime.Now);
        }
    }
}
