using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.RepositoryPattern;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Collections.Generic;


namespace DotrA_Lab.InternalDataService.Implementation
{
    public class MembersRepository : Service<Members>, IMembersRepository
    {
        private readonly IGenericRepository<Members> _MembersRepository;

        public MembersRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._MembersRepository = unitOfWork.Repository<Members>();
        }

        public Members GetMembers(long id)
        {
            return _MembersRepository.Get(id);
        }

        public IEnumerable<Members> GetMembers()
        {
            return _MembersRepository.GetAll();
        }

        public void AddMembers(Members members)
        {
            _MembersRepository.Add(members);
            _unitOfWork.SaveChanges();
        }

        public void UpdateMembers(Members members)
        {
            this._MembersRepository.Update(members);
            _unitOfWork.SaveChanges();
        }

        public void RemoveMembers(Members members)
        {
            this._MembersRepository.Remove(members);
            _unitOfWork.SaveChanges();
        }
    }
}
