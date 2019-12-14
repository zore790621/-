using DotrA_Lab.Business.DomainClasses;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface IOrdersRepository
    {
        void AddOrders(Orders orders);
        Orders GetOrders(long id);
        IEnumerable<Orders> GetOrders();
        void RemoveOrders(Orders orders);
        void UpdateOrders(Orders orders);
    }
}
