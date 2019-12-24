using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface ICategoryService : IService<Category>
    {
        int CreateCategoryForImages<TViewModel>(TViewModel source);
    }
    public class CategoryService
        : GenericService<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork db) : base(db) { }

        public int CreateCategoryForImages<TViewModel>(TViewModel source)
        {
            var result = new Category();
            db.Repository<Category>().Create(DataModelToViewModel.GenericMapper(source, result));
            db.SaveChanges();
            return result.CategoryID;
        }

        public override void Delete(Expression<Func<Category, bool>> wherePredicate)
        {
            var data = db.Repository<Category>().Read(wherePredicate);
            var imagebase1 = db.Repository<ImageBase>().Reads().Where(x => x.CatgoryID == data.CategoryID);
            foreach (var dimage in imagebase1)
                db.Repository<ImageBase>().Delete(dimage);
            var target1 = db.Repository<Product>().Reads().Where(x => x.CategoryID == data.CategoryID);
            foreach (var a in target1)
            {
                var imagebase2 = db.Repository<ImageBase>().Reads().Where(x => x.ProductID == a.ProductID);
                foreach (var dimage in imagebase2)
                    db.Repository<ImageBase>().Delete(dimage);
                var target2 = db.Repository<OrderDetail>().Reads().Where(x => x.ProductID == a.ProductID);
                foreach (var b in target2)
                    db.Repository<OrderDetail>().Delete(b);
                db.Repository<Product>().Delete(a);
            }
            db.Repository<Category>().Delete(data);
            db.SaveChanges();
        }
    }
}
