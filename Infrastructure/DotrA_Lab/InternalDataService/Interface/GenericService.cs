using AutoMapper;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotrA_Lab.InternalDataService.Implementation
{
    /// <summary>
    /// 通用行的Service layer實作
    /// </summary>
    /// <typeparam name="T">主要的Entity形態</typeparam>
    public class GenericService<T> : IService<T>
        where T : class
    {
        protected IUnitOfWork db;

        /// <summary>
        /// 取得驗證資訊的字典
        /// </summary>
        /// <value>
        /// 驗證資訊的字典
        /// </value>
        public IValidationDictionary ValidationDictionary { get; private set; }

        /// <summary>
        /// 初始化IValidationDictionary
        /// </summary>
        /// <param name="inValidationDictionary">要用來儲存錯誤訊息的object</param>
        public void InitialiseIValidationDictionary
            (IValidationDictionary inValidationDictionary)
        {
            ValidationDictionary = inValidationDictionary;
        }

        public GenericService(IUnitOfWork db)
        {
            this.db = db;
        }

        /// <summary>
        /// 取得符合條件的Entity並且轉成對應的ViewModel
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel的形態</typeparam>
        /// <returns>取得轉換過的ViewModel List</returns>
        public virtual List<TViewModel> GetListToViewModel<TViewModel>()
        {
            var data = db.Repository<T>().Reads();

            return DataModelToViewModel.GenericListMapper<T, TViewModel>(data);
        }

        /// <summary>
        /// 取得符合條件的Entity並且轉成對應的ViewModel
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel的形態</typeparam>
        /// <param name="includes">需要Include的Entity</param>
        /// <returns>取得轉換過的ViewModel List</returns>
        public virtual List<TViewModel> GetListToViewModel<TViewModel>(params Expression<Func<T, object>>[] includes)
        {
            var data = db.Repository<T>().Reads();

            foreach (var item in includes)
            {
                data.Include(item);
            }

            return DataModelToViewModel.GenericListMapper<T, TViewModel>(data);
        }

        /// <summary>
        /// 取得符合條件的Entity並且轉成對應的ViewModel
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel的形態</typeparam>
        /// <param name="wherePredicate">過濾邏輯</param>
        /// <param name="includes">需要Include的Entity</param>
        /// <returns>取得轉換過的ViewModel List</returns>
        public virtual List<TViewModel> GetListToViewModel<TViewModel>(Expression<Func<T, bool>> wherePredicate, params Expression<Func<T, object>>[] includes)
        {
            var data = db.Repository<T>().Reads();

            foreach (var item in includes)
            {
                data.Include(item);
            }

            return DataModelToViewModel.GenericListMapper<T, TViewModel>(data.Where(wherePredicate));
        }

        /// <summary>
        /// 取得是否存在
        /// </summary>
        /// <param name="wherePredicate">過濾邏輯</param>
        /// <returns>取得是否存在</returns>
        public virtual bool CheckNullable(Expression<Func<T, bool>> wherePredicate)
        {
            var data = db.Repository<T>().Read(wherePredicate);

            return data != null;
        }

        /// <summary>
        /// 取得某一個條件下面的某一筆Entity並且轉成對應的ViewModel
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel的形態</typeparam>
        /// <param name="wherePredicate">過濾邏輯</param>
        /// <param name="includes">需要Include的Entity</param>
        /// <returns>取得轉換過的ViewModel或者是null</returns>
        public virtual TViewModel GetSpecificDetailToViewModel<TViewModel>(Expression<Func<T, bool>> wherePredicate, params Expression<Func<T, object>>[] includes)
        {
            var data = db.Repository<T>().Reads();
            foreach (var item in includes)
                data.Include(item);

            return DataModelToViewModel.GenericMapper<T, TViewModel>(data.Where(wherePredicate).FirstOrDefault());
        }


        /// <summary>
        /// 依照某一個ViewModel的值，更新對應的Entity
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel的形態</typeparam>
        /// <param name="viewModel">ViewModel的值</param>
        /// <param name="wherePredicate">過濾條件 - 要被更新的那一筆過濾條件</param>
        /// <returns>是否刪除成功</returns>
        public virtual void UpdateViewModelToDatabase<TViewModel>(TViewModel viewModel, Expression<Func<T, bool>> wherePredicate)
        {
            var entity = db.Repository<T>().Read(wherePredicate);

            var result = DataModelToViewModel.GenericMapper(viewModel, entity);

            db.Repository<T>().Update(result);

            db.SaveChanges();
        }


        /// <summary>
        /// 刪除某一筆Entity
        /// </summary>
        /// <param name="wherePredicate">過濾出要被刪除的Entity條件</param>
        /// <returns>是否刪除成功</returns>
        public virtual void Delete(Expression<Func<T, bool>> wherePredicate)
        {
            var data = db.Repository<T>().Read(wherePredicate);
            db.Repository<T>().Delete(data);
            db.SaveChanges();
        }


        /// <summary>
        /// 依照某一個ViewModel的值，產生對應的Entity並且新增到資料庫
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel的形態</typeparam>
        /// <param name="viewModel">ViewModel的Reference</param>
        /// <returns>是否儲存成功</returns>
        public void CreateViewModelToDatabase<TViewModel>(TViewModel viewModel)
        {
            var entity = DataModelToViewModel.GenericMapper<TViewModel, T>(viewModel);
            db.Repository<T>().Create(entity);

            db.SaveChanges();
        }
        public T GetFirst(Expression<Func<T, bool>> wherePredicate) => db.Repository<T>().Read(wherePredicate);
    }
}
