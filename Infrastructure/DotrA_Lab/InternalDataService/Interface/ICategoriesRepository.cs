using DotrA_Lab.Business.DomainClasses;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface ICategoriesRepository
    {
        void AddCategories(Categories categories);
        Categories GetCategories(long id);
        IEnumerable<Categories> GetCategories();
        void RemoveCategories(Categories categories);
        void UpdateCategories(Categories categories);
    }
}
