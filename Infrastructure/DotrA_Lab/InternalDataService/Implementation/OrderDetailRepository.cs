using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.RepositoryPattern;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{
    //public class OrderDetailRepository : Service<OrderDetail>, IOrderDetailRepository
    //{
    //    private readonly IGenericRepository<OrderDetail> _OrderDetailsRepository;

    //    public OrderDetailRepository(IUnitOfWork unitOfWork)
    //        : base(unitOfWork)
    //    {
    //        this._OrderDetailsRepository = unitOfWork.Repository<OrderDetail>();
    //    }

    //    public OrderDetail GetOrderDetail(long id)
    //    {
    //        return _OrderDetailsRepository.Get(id
    //            , o => o.Orders
    //            , o => o.Product
    //            , o => o.OrderID == id);
    //    }

    //    public IEnumerable<OrderDetail> GetOrderDetails()
    //    {
    //        return _OrderDetailsRepository.GetAll();
    //    }

    //    public void AddOrderDetail(OrderDetail orderDetail)
    //    {
    //        _OrderDetailsRepository.Add(orderDetail);
    //        _unitOfWork.SaveChanges();
    //    }

    //    public void UpdateOrderDetail(OrderDetail orderDetail)
    //    {
    //        this._OrderDetailsRepository.Update(orderDetail);
    //        _unitOfWork.SaveChanges();
    //    }

    //    public void RemoveOrderDetail(OrderDetail orderDetail)
    //    {
    //        this._OrderDetailsRepository.Remove(orderDetail);
    //        _unitOfWork.SaveChanges();
    //    }
    //}
}
