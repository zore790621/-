using DotrA_Lab.Business.DomainClasses;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface ISuppliersRepository
    {
        void AddSuppliers(Suppliers suppliers);
        Suppliers GetSuppliers(long id);
        IEnumerable<Suppliers> GetSuppliers();
        void RemoveSuppliers(Suppliers suppliers);
        void UpdateSuppliers(Suppliers suppliers);
    }
}
