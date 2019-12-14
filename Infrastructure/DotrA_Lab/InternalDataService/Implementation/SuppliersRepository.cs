using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.RepositoryPattern;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{

    public class SuppliersRepository : Service<Suppliers>, ISuppliersRepository
    {
        private readonly IGenericRepository<Suppliers> _SuppliersRepository;

        public SuppliersRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._SuppliersRepository = unitOfWork.Repository<Suppliers>();
        }

        public Suppliers GetSuppliers(long id)
        {
            return _SuppliersRepository.Get(id);
        }

        public IEnumerable<Suppliers> GetSuppliers()
        {
            return _SuppliersRepository.GetAll();
        }

        public void AddSuppliers(Suppliers Suppliers)
        {
            _SuppliersRepository.Add(Suppliers);
            _unitOfWork.SaveChanges();
        }

        public void UpdateSuppliers(Suppliers Suppliers)
        {
            this._SuppliersRepository.Update(Suppliers);
            _unitOfWork.SaveChanges();
        }

        public void RemoveSuppliers(Suppliers Suppliers)
        {
            this._SuppliersRepository.Remove(Suppliers);
            _unitOfWork.SaveChanges();
        }
    }
}
