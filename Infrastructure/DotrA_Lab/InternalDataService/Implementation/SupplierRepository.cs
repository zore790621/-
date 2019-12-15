using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.RepositoryPattern;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{

    //public class SupplierRepository : Service<Supplier>, ISupplierRepository
    //{
    //    private readonly IGenericRepository<Supplier> _SuppliersRepository;

    //    public SupplierRepository(IUnitOfWork unitOfWork)
    //        : base(unitOfWork)
    //    {
    //        this._SuppliersRepository = unitOfWork.Repository<Supplier>();
    //    }

    //    public Supplier GetSupplier(long id)
    //    {
    //        return _SuppliersRepository.Get(id);
    //    }

    //    public IEnumerable<Supplier> GetSuppliers()
    //    {
    //        return _SuppliersRepository.GetAll();
    //    }

    //    public void AddSupplier(Supplier supplier)
    //    {
    //        _SuppliersRepository.Add(supplier);
    //        _unitOfWork.SaveChanges();
    //    }

    //    public void UpdateSupplier(Supplier supplier)
    //    {
    //        this._SuppliersRepository.Update(supplier);
    //        _unitOfWork.SaveChanges();
    //    }

    //    public void RemoveSupplier(Supplier supplier)
    //    {
    //        this._SuppliersRepository.Remove(supplier);
    //        _unitOfWork.SaveChanges();
    //    }
    //}
}
