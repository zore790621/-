using DotrA_Lab.DotrA_EF;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DotrA_Lab.DotrA_Repository
{
    /// <summary>
    /// 實作Entity Framework Generic Repository 的 Class。
    /// </summary>
    /// <typeparam name="TEntity">EF Model 裡面的Type</typeparam>
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DotrADbContext _context;
        protected DotrADbContext Context { get { return _context; } }

        /// <summary>
        /// 建構EF一個Entity的Repository，需傳入此Entity的Context。
        /// </summary>
        /// <param name="inContext">Entity所在的Context</param>
        public GenericRepository(DotrADbContext inContext) => _context = inContext;

        /// <summary>
        /// 新增一筆資料到資料庫。
        /// </summary>
        /// <param name="entity">要新增到資料的庫的Entity</param>
        public void Create(TEntity entity) => _context.Set<TEntity>().Add(entity);

        /// <summary>
        /// 取得第一筆符合條件的內容。如果符合條件有多筆，也只取得第一筆。
        /// </summary>
        /// <param name="predicate">要取得的Where條件。</param>
        /// <returns>取得第一筆符合條件的內容。</returns>
        public TEntity Read(Expression<Func<TEntity, bool>> predicate) => _context.Set<TEntity>().Where(predicate).FirstOrDefault();

        /// <summary>
        /// 取得Entity全部筆數的IQueryable。
        /// </summary>
        /// <returns>Entity全部筆數的IQueryable。</returns>
        public IQueryable<TEntity> Reads() => _context.Set<TEntity>().AsQueryable();

        /// <summary>
        /// 更新一筆Entity內容。
        /// </summary>
        /// <param name="entity">要更新的內容</param>
        public void Update(TEntity entity) => _context.Entry<TEntity>(entity).State = EntityState.Modified;

        /// <summary>
        /// 更新一筆Entity的內容。只更新有指定的Property。
        /// </summary>
        /// <param name="entity">要更新的內容。</param>
        /// <param name="updateProperties">需要更新的欄位。</param>
        public void Update(TEntity entity, Expression<Func<TEntity, object>>[] updateProperties)
        {
            _context.Configuration.ValidateOnSaveEnabled = false;

            _context.Entry<TEntity>(entity).State = EntityState.Unchanged;
            if (updateProperties != null)
            {
                foreach (Expression<Func<TEntity, object>> property in updateProperties)
                {
                    _context.Entry<TEntity>(entity).Property(property).IsModified = true;
                }
            }
        }

        /// <summary>
        /// 刪除一筆資料內容。
        /// </summary>
        /// <param name="entity">要被刪除的Entity。</param>
        public void Delete(TEntity entity) => _context.Entry<TEntity>(entity).State = EntityState.Deleted;

        /// <summary>
        /// 儲存異動。
        /// </summary>
        public void SaveChanges()
        {
            Context.SaveChanges();

            // 因為Update 單一model需要先關掉validation，因此重新打開
            if (_context.Configuration.ValidateOnSaveEnabled == false)
            {
                _context.Configuration.ValidateOnSaveEnabled = true;
            }
        }
    }
}
