using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface IMemberRoloService : IService<MemberRolo>
    {
    }
    public class MemberRoloService
        : GenericService<MemberRolo>, IMemberRoloService
    {
        public MemberRoloService(IUnitOfWork db)
            : base(db) { }

        public override void Delete(Expression<Func<MemberRolo, bool>> wherePredicate)
        {
            var data = db.Repository<MemberRolo>().Read(wherePredicate);
            var target1 = db.Repository<Member>().Reads().Where(x => x.RoloID == data.RoloID);
            foreach (var a in target1)
            {
                var target2 = db.Repository<Order>().Reads().Where(x => x.MemberID == a.MemberID);
                foreach (var b in target2)
                {
                    var target3 = db.Repository<OrderDetail>().Reads().Where(x => x.OrderID == b.OrderID);
                    foreach (var c in target3)
                    {
                        db.Repository<OrderDetail>().Delete(c);
                    }
                    db.Repository<Order>().Delete(b);
                }
                db.Repository<Member>().Delete(a);
            }
            db.Repository<MemberRolo>().Delete(data);
            db.SaveChanges();
        }
    }
}
