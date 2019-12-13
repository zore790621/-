﻿using DotrA_Lab.DotrA_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotrA_Lab.DotrA_UnitOfWork
{
    /// <summary>
    /// 實作Unit Of Work的interface。
    /// </summary>
    public interface IGenericUnitOfWork : IDisposable
    {
        /// <summary>
        /// 儲存所有異動。
        /// </summary>
        void SaveChange();

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
