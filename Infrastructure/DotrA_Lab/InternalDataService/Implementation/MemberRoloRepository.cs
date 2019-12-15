using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.RepositoryPattern;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Collections.Generic;


namespace DotrA_Lab.InternalDataService.Implementation
{
    //public class MemberRoloRepository : Service<MemberRolo>, IMemberRoloRepository
    //{
    //    private readonly IGenericRepository<MemberRolo> _MemberRolosRepository;

    //    public MemberRoloRepository(IUnitOfWork unitOfWork)
    //        : base(unitOfWork)
    //    {
    //        this._MemberRolosRepository = unitOfWork.Repository<MemberRolo>();
    //    }

    //    public MemberRolo GetMemberRolo(long id)
    //    {
    //        return _MemberRolosRepository.Get(id);
    //    }

    //    public IEnumerable<MemberRolo> GetMemberRolos()
    //    {
    //        return _MemberRolosRepository.GetAll();
    //    }

    //    public void AddMemberRolo(MemberRolo memberRolo)
    //    {
    //        _MemberRolosRepository.Add(memberRolo);
    //        _unitOfWork.SaveChanges();
    //    }

    //    public void UpdateMemberRolo(MemberRolo memberRolo)
    //    {
    //        this._MemberRolosRepository.Update(memberRolo);
    //        _unitOfWork.SaveChanges();
    //    }

    //    public void RemoveMemberRolo(MemberRolo memberRolo)
    //    {
    //        this._MemberRolosRepository.Remove(memberRolo);
    //        _unitOfWork.SaveChanges();
    //    }
    //}
}
