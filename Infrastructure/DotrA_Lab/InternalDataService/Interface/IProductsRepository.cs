using DotrA_Lab.Business.DomainClasses;
using System.Collections.Generic;


namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface IProductsRepository
    {
        void AddProducts(Products products);
        Products GetProducts(long id);
        IEnumerable<Products> GetProducts();
        void RemoveProducts(Products products);
        void UpdateProducts(Products products);
    }
}
