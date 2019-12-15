using DotrA_Lab.ORM.RepositoryPattern;
using System;
using System.Threading.Tasks;

namespace DotrA_Lab.ORM.UnitOfWorkPattern
{
    /// <summary>
    /// 實作Unit Of Work的interface。
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 儲存所有異動。
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// 取得某一個Entity的Repository。
        /// 如果沒有取過，會initialise一個
        /// 如果有就取得之前initialise的那個。
        /// </summary>
        /// <typeparam name="T">此Context裡面的Entity Type</typeparam>
        /// <returns>Entity的Repository</returns>
        IGenericRepository<T> Repository<T>() where T : class;
    }
}
