using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.RepositoryPattern;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Collections.Generic;


namespace DotrA_Lab.InternalDataService.Implementation
{
    //public class MemberRepository : Service<Member>, IMemberRepository
    //{
    //    private readonly IGenericRepository<Member> _MembersRepository;

    //    public MemberRepository(IUnitOfWork unitOfWork)
    //        : base(unitOfWork)
    //    {
    //        this._MembersRepository = unitOfWork.Repository<Member>();
    //    }

    //    public Member GetMember(long id)
    //    {
    //        return _MembersRepository.Get(id);
    //    }

    //    public IEnumerable<Member> GetMembers()
    //    {
    //        return _MembersRepository.GetAll();
    //    }

    //    public void AddMember(Member member)
    //    {
    //        _MembersRepository.Add(member);
    //        _unitOfWork.SaveChanges();
    //    }

    //    public void UpdateMember(Member member)
    //    {
    //        this._MembersRepository.Update(member);
    //        _unitOfWork.SaveChanges();
    //    }

    //    public void RemoveMember(Member member)
    //    {
    //        this._MembersRepository.Remove(member);
    //        _unitOfWork.SaveChanges();
    //    }
    //}
}
