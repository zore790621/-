using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.RepositoryPattern;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public class CategoriesRepository : Service<Categories>, ICategoriesRepository
    {
        private readonly IGenericRepository<Categories> _CategoriesRepository;

        public CategoriesRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._CategoriesRepository = unitOfWork.Repository<Categories>();
        }

        public Categories GetCategories(long id)
        {
            return _CategoriesRepository.Get(id);
        }

        public IEnumerable<Categories> GetCategories()
        {
            return _CategoriesRepository.GetAll();
        }

        public void AddCategories(Categories categories)
        {
            _CategoriesRepository.Add(categories);
            _unitOfWork.SaveChanges();
        }

        public void UpdateCategories(Categories categories)
        {
            this._CategoriesRepository.Update(categories);
            _unitOfWork.SaveChanges();
        }

        public void RemoveCategories(Categories categories)
        {
            this._CategoriesRepository.Remove(categories);
            _unitOfWork.SaveChanges();
        }
    }
}
