using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.RepositoryPattern;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public class OrdersRepository : Service<Orders>, IOrdersRepository
    {
        private readonly IGenericRepository<Orders> _OrdersRepository;

        public OrdersRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._OrdersRepository = unitOfWork.Repository<Orders>();
        }

        public Orders GetOrders(long id)
        {
            return _OrdersRepository.Get(id);
        }

        public IEnumerable<Orders> GetOrders()
        {
            return _OrdersRepository.GetAll();
        }

        public void AddOrders(Orders orders)
        {
            _OrdersRepository.Add(orders);
            _unitOfWork.SaveChanges();
        }

        public void UpdateOrders(Orders orders)
        {
            this._OrdersRepository.Update(orders);
            _unitOfWork.SaveChanges();
        }

        public void RemoveOrders(Orders orders)
        {
            this._OrdersRepository.Remove(orders);
            _unitOfWork.SaveChanges();
        }
    }
}
