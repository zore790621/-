using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface IOrderService : IService<Order>
    {
    }
    public class OrderService
        : GenericService<Order>, IOrderService
    {
        public OrderService(IUnitOfWork db)
            : base(db) { }

        public override void Delete(Expression<Func<Order, bool>> wherePredicate)
        {
            var data = db.Repository<Order>().Read(wherePredicate);
            var target1 = db.Repository<OrderDetail>().Reads().Where(x => x.OrderID == data.OrderID);
            foreach (var a in target1)
                db.Repository<OrderDetail>().Delete(a);
            db.Repository<Order>().Delete(data);
            db.SaveChanges();
        }
    }
}
