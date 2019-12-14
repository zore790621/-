using DotrA_Lab.Business.DomainClasses;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface IMembersRepository
    {
        void AddMembers(Members members);
        Members GetMembers(long id);
        IEnumerable<Members> GetMembers();
        void RemoveMembers(Members members);
        void UpdateMembers(Members members);
    }
}
