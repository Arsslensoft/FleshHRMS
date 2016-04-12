using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHRMS.Common.DataModel.EntityFramework;
using FHRMS.Data;
namespace FHRMS.DevAVDbDataModel {
    public class OrderRepository : DbRepository<Order, long, DevAVDb> {
        public OrderRepository(DbUnitOfWork<DevAVDb> unitOfWork) : base(unitOfWork, x => x.Set<Order>(), x => x.Id) { }
        protected override IQueryable<Order> GetEntities() {
            return base.GetEntities().Where(o => o.OrderDate < DateTime.Now);
        }
    }
}
