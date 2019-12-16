using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System;
using System.Linq;
using System.Linq.Expressions;


namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface IOrderDetailService : IService<OrderDetail>
    {
    }
    public class OrderDetailService
        : GenericService<OrderDetail>, IOrderDetailService
    {
        public OrderDetailService(IUnitOfWork db)
            : base(db) { }

        public override void Delete(Expression<Func<OrderDetail, bool>> wherePredicate)
        {
            var data = db.Repository<OrderDetail>().Read(wherePredicate);
            db.Repository<OrderDetail>().Delete(data);
            db.SaveChanges();
        }
    }
}
