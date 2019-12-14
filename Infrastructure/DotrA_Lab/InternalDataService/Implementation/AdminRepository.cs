using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.RepositoryPattern;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public class AdminRepository : Service<Admin>, IAdminRepository
    {
        private readonly IGenericRepository<Admin> _AdminRepository;

        public AdminRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._AdminRepository = unitOfWork.Repository<Admin>();
        }

        public Admin GetAdmin(long id)
        {
            return _AdminRepository.Get(id);
        }

        public IEnumerable<Admin> GetAdmin()
        {
            return _AdminRepository.GetAll();
        }

        public void AddAdmin(Admin admin)
        {
            _AdminRepository.Add(admin);
            _unitOfWork.SaveChanges();
        }

        public void UpdateAdmin(Admin admin)
        {
            this._AdminRepository.Update(admin);
            _unitOfWork.SaveChanges();
        }

        public void RemoveAdmin(Admin admin)
        {
            this._AdminRepository.Remove(admin);
            _unitOfWork.SaveChanges();
        }
    }
}
