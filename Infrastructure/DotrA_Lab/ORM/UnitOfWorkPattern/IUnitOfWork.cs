using DotrA_Lab.ORM.RepositoryPattern;
using System;
using System.Threading.Tasks;

namespace DotrA_Lab.ORM.UnitOfWorkPattern
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        Task<int> SaveChangesAsync();
        IGenericRepository<T> Repository<T>() where T : class;
    }
}
