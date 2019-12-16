using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface IMemberService : IService<Member>
    {
    }
    public class MemberService
        : GenericService<Member>, IMemberService
    {
        public MemberService(IUnitOfWork db)
            : base(db) { }

        public override void Delete(Expression<Func<Member, bool>> wherePredicate)
        {
            var data = db.Repository<Member>().Read(wherePredicate);
            var target1 = db.Repository<Order>().Reads().Where(x => x.MemberID == data.MemberID);
            foreach (var a in target1)
            {
                var target2 = db.Repository<OrderDetail>().Reads().Where(x => x.OrderID == a.OrderID);
                foreach (var b in target2)
                    db.Repository<OrderDetail>().Delete(b);
                db.Repository<Order>().Delete(a);
            }
            db.Repository<Member>().Delete(data);
            db.SaveChanges();
        }
    }
}
