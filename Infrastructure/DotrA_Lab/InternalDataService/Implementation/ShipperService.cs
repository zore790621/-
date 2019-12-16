using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface IShipperService : IService<Shipper>
    {
    }
    public class ShipperService
        : GenericService<Shipper>, IShipperService
    {
        public ShipperService(IUnitOfWork db)
            : base(db) { }

        public override void Delete(Expression<Func<Shipper, bool>> wherePredicate)
        {
            var data = db.Repository<Shipper>().Read(wherePredicate);
            var target1 = db.Repository<Order>().Reads().Where(x => x.ShipperID == data.ShipperID);
            foreach (var a in target1)
            {
                var target2 = db.Repository<OrderDetail>().Reads().Where(x => x.OrderID == a.OrderID);
                foreach (var b in target2)
                    db.Repository<OrderDetail>().Delete(b);
                db.Repository<Order>().Delete(a);
            }
            db.Repository<Shipper>().Delete(data);
            db.SaveChanges();
        }
    }
}
