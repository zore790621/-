using DotrA_Lab.Business.DomainClasses;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface IOrderDetailsRepository
    {
        void AddOrderDetails(OrderDetails orderDetails);
        OrderDetails GetOrderDetails(long id);
        IEnumerable<OrderDetails> GetOrderDetails();
        void RemoveOrderDetails(OrderDetails orderDetails);
        void UpdateOrderDetails(OrderDetails orderDetails);
    }
}
