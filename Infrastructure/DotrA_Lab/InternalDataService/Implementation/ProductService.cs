using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface IProductService : IService<Product>
    {
    }
    public class ProductService
        : GenericService<Product>, IProductService
    {
        public ProductService(IUnitOfWork db)
            : base(db) { }

        public override void Delete(Expression<Func<Product, bool>> wherePredicate)
        {
            var data = db.Repository<Product>().Read(wherePredicate);
            var target1 = db.Repository<OrderDetail>().Reads().Where(x => x.ProductID == data.ProductID);
            foreach (var a in target1)
                db.Repository<OrderDetail>().Delete(a);
            db.Repository<Product>().Delete(data);
            db.SaveChanges();
        }
    }
}
