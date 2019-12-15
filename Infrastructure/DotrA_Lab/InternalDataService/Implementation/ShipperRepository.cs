using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.RepositoryPattern;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{
    //public class ShipperRepository : Service<Shipper>, IShipperRepository
    //{
    //    private readonly IGenericRepository<Shipper> _ShippersRepository;

    //    public ShipperRepository(IUnitOfWork unitOfWork)
    //        : base(unitOfWork)
    //    {
    //        this._ShippersRepository = unitOfWork.Repository<Shipper>();
    //    }

    //    public Shipper GetShipper(long id)
    //    {
    //        return _ShippersRepository.Get(id);
    //    }

    //    public IEnumerable<Shipper> GetShippers()
    //    {
    //        return _ShippersRepository.GetAll();
    //    }

    //    public void AddShipper(Shipper shipper)
    //    {
    //        _ShippersRepository.Add(shipper);
    //        _unitOfWork.SaveChanges();
    //    }

    //    public void UpdateShipper(Shipper shipper)
    //    {
    //        this._ShippersRepository.Update(shipper);
    //        _unitOfWork.SaveChanges();
    //    }

    //    public void RemoveShipper(Shipper shipper)
    //    {
    //        this._ShippersRepository.Remove(shipper);
    //        _unitOfWork.SaveChanges();
    //    }
    //}
}
