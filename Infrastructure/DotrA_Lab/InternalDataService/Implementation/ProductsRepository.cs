using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.RepositoryPattern;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public class ProductsRepository : Service<Products>, IProductsRepository
    {
        private readonly IGenericRepository<Products> _ProductsRepository;

        public ProductsRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._ProductsRepository = unitOfWork.Repository<Products>();
        }

        public Products GetProducts(long id)
        {
            return _ProductsRepository.Get(id);
        }

        public IEnumerable<Products> GetProducts()
        {
            return _ProductsRepository.GetAll();
        }

        public void AddProducts(Products products)
        {
            _ProductsRepository.Add(products);
            _unitOfWork.SaveChanges();
        }

        public void UpdateProducts(Products products)
        {
            this._ProductsRepository.Update(products);
            _unitOfWork.SaveChanges();
        }

        public void RemoveProducts(Products products)
        {
            this._ProductsRepository.Remove(products);
            _unitOfWork.SaveChanges();
        }
    }
}
