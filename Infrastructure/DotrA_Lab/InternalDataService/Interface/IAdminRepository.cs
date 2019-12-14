using DotrA_Lab.Business.DomainClasses;
using System.Collections.Generic;

namespace DotrA_Lab.InternalDataService.Implementation
{
    public interface IAdminRepository
    {
        void AddAdmin(Admin admin);
        Admin GetAdmin(long id);
        IEnumerable<Admin> GetAdmin();
        void RemoveAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
    }
}
