using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.RepositoryPattern;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public class ShippersRepository : Service<Shippers>, IShippersRepository
    {
        private readonly IGenericRepository<Shippers> _ShippersRepository;

        public ShippersRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._ShippersRepository = unitOfWork.Repository<Shippers>();
        }

        public Shippers GetShippers(long id)
        {
            return _ShippersRepository.Get(id);
        }

        public IEnumerable<Shippers> GetShippers()
        {
            return _ShippersRepository.GetAll();
        }

        public void AddShippers(Shippers Shippers)
        {
            _ShippersRepository.Add(Shippers);
            _unitOfWork.SaveChanges();
        }

        public void UpdateShippers(Shippers Shippers)
        {
            this._ShippersRepository.Update(Shippers);
            _unitOfWork.SaveChanges();
        }

        public void RemoveShippers(Shippers Shippers)
        {
            this._ShippersRepository.Remove(Shippers);
            _unitOfWork.SaveChanges();
        }
    }
}
