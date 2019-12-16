using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface IMemberRoleService : IService<MemberRole>
    {
    }
    public class MemberRoleService
        : GenericService<MemberRole>, IMemberRoleService
    {
        public MemberRoleService(IUnitOfWork db)
            : base(db) { }

        public override void Delete(Expression<Func<MemberRole, bool>> wherePredicate)
        {
            var data = db.Repository<MemberRole>().Read(wherePredicate);
            var target1 = db.Repository<Member>().Reads().Where(x => x.RoleID == data.RoleID);
            foreach (var a in target1)
            {
                var target2 = db.Repository<Order>().Reads().Where(x => x.MemberID == a.MemberID);
                foreach (var b in target2)
                {
                    var target3 = db.Repository<OrderDetail>().Reads().Where(x => x.OrderID == b.OrderID);
                    foreach (var c in target3)
                        db.Repository<OrderDetail>().Delete(c);
                    db.Repository<Order>().Delete(b);
                }
                db.Repository<Member>().Delete(a);
            }
            db.Repository<MemberRole>().Delete(data);
            db.SaveChanges();
        }
    }
}
