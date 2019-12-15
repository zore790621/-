using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.RepositoryPattern;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{
    //public class CategoryRepository : Service<Category>, ICategoryRepository
    //{
    //    private readonly IGenericRepository<Category> _CategoriesRepository;

    //    public CategoryRepository(IUnitOfWork unitOfWork)
    //        : base(unitOfWork)
    //    {
    //        this._CategoriesRepository = unitOfWork.Repository<Category>();
    //    }

    //    public Category GetCategory(long id)
    //    {
    //        return _CategoriesRepository.Get(id);
    //    }

    //    public IEnumerable<Category> GetCategories()
    //    {
    //        return _CategoriesRepository.GetAll();
    //    }

    //    public void AddCategory(Category category)
    //    {
    //        _CategoriesRepository.Add(category);
    //        _unitOfWork.SaveChanges();
    //    }

    //    public void UpdateCategory(Category category)
    //    {
    //        this._CategoriesRepository.Update(category);
    //        _unitOfWork.SaveChanges();
    //    }

    //    public void RemoveCategory(Category category)
    //    {
    //        this._CategoriesRepository.Remove(category);
    //        _unitOfWork.SaveChanges();
    //    }
    //}
}
