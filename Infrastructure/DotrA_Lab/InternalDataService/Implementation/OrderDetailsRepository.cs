using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.RepositoryPattern;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public class OrderDetailsRepository : Service<OrderDetails>, IOrderDetailsRepository
    {
        private readonly IGenericRepository<OrderDetails> _OrderDetailsRepository;

        public OrderDetailsRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._OrderDetailsRepository = unitOfWork.Repository<OrderDetails>();
        }

        public OrderDetails GetOrderDetails(long id)
        {
            return _OrderDetailsRepository.Get(id);
        }

        public IEnumerable<OrderDetails> GetOrderDetails()
        {
            return _OrderDetailsRepository.GetAll();
        }

        public void AddOrderDetails(OrderDetails orderDetails)
        {
            _OrderDetailsRepository.Add(orderDetails);
            _unitOfWork.SaveChanges();
        }

        public void UpdateOrderDetails(OrderDetails orderDetails)
        {
            this._OrderDetailsRepository.Update(orderDetails);
            _unitOfWork.SaveChanges();
        }

        public void RemoveOrderDetails(OrderDetails orderDetails)
        {
            this._OrderDetailsRepository.Remove(orderDetails);
            _unitOfWork.SaveChanges();
        }
    }
}
