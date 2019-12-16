﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotrA_Lab.InternalDataService.Implementation
{
    /// <summary>
    /// Service服務層內容的Interface
    /// </summary>
    /// <typeparam name="T">主要要儲存的Entity Type</typeparam>
    public interface IService<T>
        where T : class
    {


        /// <summary>
        /// 取得Entity並且轉成對應的ViewModel
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel的形態</typeparam>
        /// <returns></returns>
        List<TViewModel> GetListToViewModel<TViewModel>();

        /// <summary>
        /// 取得Entity並且轉成對應的ViewModel
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel的形態</typeparam>
        /// <param name="includes">需要Include的Entity</param>
        /// <returns>取得轉換過的ViewModel List</returns>
        List<TViewModel> GetListToViewModel<TViewModel>(params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// 取得符合條件的Entity並且轉成對應的ViewModel
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel的形態</typeparam>
        /// <param name="wherePredicate">過濾邏輯</param>
        /// <param name="includes">需要Include的Entity</param>
        /// <returns>取得轉換過的ViewModel List</returns>
        List<TViewModel> GetListToViewModel<TViewModel>(Expression<Func<T, bool>> wherePredicate, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// 取得某一個條件下面的某一筆Entity並且轉成對應的ViewModel
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel的形態</typeparam>
        /// <param name="wherePredicate">過濾邏輯</param>
        /// <param name="includes">需要Include的Entity</param>
        /// <returns>取得轉換過的ViewModel或者是null</returns>
        TViewModel GetSpecificDetailToViewModel<TViewModel>(Expression<Func<T, bool>> wherePredicate, params Expression<Func<T, object>>[] includes);


        /// <summary>
        /// 依照某一個ViewModel的值，產生對應的Entity並且新增到資料庫
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel的形態</typeparam>
        /// <param name="viewModel">ViewModel的Reference</param>
        /// <returns>是否儲存成功</returns>
        void CreateViewModelToDatabase<TViewModel>(TViewModel viewModel);

        /// <summary>
        /// 依照某一個ViewModel的值，更新對應的Entity
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel的形態</typeparam>
        /// <param name="viewModel">ViewModel的值</param>
        /// <param name="wherePredicate">過濾條件 - 要被更新的那一筆過濾調價</param>
        /// <returns>是否刪除成功</returns>
        void UpdateViewModelToDatabase<TViewModel>(TViewModel viewModel, Expression<Func<T, bool>> wherePredicate);

        /// <summary>
        /// 刪除某一筆Entity
        /// </summary>
        /// <param name="wherePredicate">過濾出要被刪除的Entity條件</param>
        /// <returns>是否刪除成功</returns>
        void Delete(Expression<Func<T, bool>> wherePredicate);
    }
}
