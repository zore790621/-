﻿using DotrA_Lab.ORM.RepositoryPattern;
using System;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DotrA_Lab.ORM.UnitOfWorkPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        private bool _disposed;
        private Hashtable _repositories;

        /// <summary>
        /// 設定此Unit of work(UOF)的Context。
        /// </summary>
        /// <param name="context">設定UOF的context</param>
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 儲存所有異動。
        /// </summary>
        public void SaveChanges()
        {
            var errors = _context.GetValidationErrors();
            if (!errors.Any())
            {
                _context.SaveChanges();
            }
            else
            {
                throw new DatabaseValidationErrors(errors);
            }
        }

        /// <summary>
        /// 清除此Class的資源。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 清除此Class的資源。
        /// </summary>
        /// <param name="disposing">是否在清理中？</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        /// <summary>
        /// 取得某一個Entity的Repository。
        /// 如果沒有取過，會initialise一個
        /// 如果有就取得之前initialise的那個。
        /// </summary>
        /// <typeparam name="T">此Context裡面的Entity Type</typeparam>
        /// <returns>Entity的Repository</returns>
        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                            .MakeGenericType(typeof(T)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<T>)_repositories[type];
        }
    }
}
