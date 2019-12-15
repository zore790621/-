using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.RepositoryPattern;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{
    //public class OrderRepository : Service<Order>, IOrderRepository
    //{
    //    private readonly IGenericRepository<Order> _OrdersRepository;

    //    public OrderRepository(IUnitOfWork unitOfWork)
    //        : base(unitOfWork)
    //    {
    //        this._OrdersRepository = unitOfWork.Repository<Order>();
    //    }

    //    public Order GetOrder(long id)
    //    {
    //        return _OrdersRepository.Get(id);
    //    }

    //    public IEnumerable<Order> GetOrders()
    //    {
    //        return _OrdersRepository.GetAll();
    //    }

    //    public void AddOrder(Order order)
    //    {
    //        _OrdersRepository.Add(order);
    //        _unitOfWork.SaveChanges();
    //    }

    //    public void UpdateOrder(Order order)
    //    {
    //        this._OrdersRepository.Update(order);
    //        _unitOfWork.SaveChanges();
    //    }

    //    public void RemoveOrder(Order order)
    //    {
    //        this._OrdersRepository.Remove(order);
    //        _unitOfWork.SaveChanges();
    //    }
    //}
}
