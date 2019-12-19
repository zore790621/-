using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface ISupplierService : IService<Supplier>
    {
    }
    class SupplierService
        : GenericService<Supplier>, ISupplierService
    {
        public SupplierService(IUnitOfWork db)
            : base(db) { }
        public override void Delete(Expression<Func<Supplier, bool>> wherePredicate)
        {
            var data = db.Repository<Supplier>().Read(wherePredicate);
            var target1 = db.Repository<Product>().Reads().Where(x => x.SupplierID == data.SupplierID);
            foreach (var a in target1)
            {
                var imagebase = db.Repository<ImageBase>().Reads().Where(x => x.ProductID == a.ProductID);
                foreach (var dimage in imagebase)
                    db.Repository<ImageBase>().Delete(dimage);
                var target2 = db.Repository<OrderDetail>().Reads().Where(x => x.ProductID == a.ProductID);
                foreach (var b in target2)
                    db.Repository<OrderDetail>().Delete(b);
                db.Repository<Product>().Delete(a);
            }
            db.Repository<Supplier>().Delete(data);

            db.SaveChanges();
        }
    }
}
