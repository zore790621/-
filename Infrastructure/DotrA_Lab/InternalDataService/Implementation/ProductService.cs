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
        void ProductStatus(int id);
    }
    public class ProductService
        : GenericService<Product>, IProductService
    {
        public ProductService(IUnitOfWork db) : base(db) { }
        public void ProductStatus(int id)
        {
            var entity = db.Repository<Product>().Read(x => x.ProductID == id);
            entity.Status = !entity.Status;
            db.Repository<Product>().Update(entity);
            db.SaveChanges();
        }
        public override void Delete(Expression<Func<Product, bool>> wherePredicate)
        {
            var data = db.Repository<Product>().Read(wherePredicate);
            var imagebase = db.Repository<ImageBase>().Reads().Where(x => x.ProductID == data.ProductID);
            foreach (var dimage in imagebase)
                db.Repository<ImageBase>().Delete(dimage);
            var target1 = db.Repository<OrderDetail>().Reads().Where(x => x.ProductID == data.ProductID);
            foreach (var a in target1)
                db.Repository<OrderDetail>().Delete(a);
            db.Repository<Product>().Delete(data);
            db.SaveChanges();
        }
    }
}
