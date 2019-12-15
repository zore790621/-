using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.RepositoryPattern;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{
    //public class ProductRepository : Service<Product>, IProductRepository
    //{
    //    private readonly IGenericRepository<Product> _ProductsRepository;

    //    public ProductRepository(IUnitOfWork unitOfWork)
    //        : base(unitOfWork)
    //    {
    //        this._ProductsRepository = unitOfWork.Repository<Product>();
    //    }

    //    public Product GetProduct(long id)
    //    {
    //        return _ProductsRepository.Get(id);
    //    }

    //    public IEnumerable<Product> GetProducts()
    //    {
    //        return _ProductsRepository.GetAll();
    //    }

    //    public void AddProduct(Product product)
    //    {
    //        _ProductsRepository.Add(product);
    //        _unitOfWork.SaveChanges();
    //    }

    //    public void UpdateProduct(Product product)
    //    {
    //        this._ProductsRepository.Update(product);
    //        _unitOfWork.SaveChanges();
    //    }

    //    public void RemoveProduct(Product product)
    //    {
    //        this._ProductsRepository.Remove(product);
    //        _unitOfWork.SaveChanges();
    //    }
    //}
}
