using DotrA_Lab.Business.DomainClasses;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface IShippersRepository
    {
        void AddShippers(Shippers shippers);
        Shippers GetShippers(long id);
        IEnumerable<Shippers> GetShippers();
        void RemoveShippers(Shippers shippers);
        void UpdateShippers(Shippers shippers);
    }
}
