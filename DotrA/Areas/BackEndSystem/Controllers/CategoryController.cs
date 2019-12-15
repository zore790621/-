using DotrA.Areas.BackEndSystem.ViewModels;
using DotrA.Controllers;
using DotrA.Service.Mapper;
using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

namespace DotrA.Areas.BackEndSystem.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork uof) : base(uof)
        {
        }

        // GET: BackEndSystem/Categories
        public ActionResult Index()
        {
            var source = UOF.Repository<Category>().GetAll();
            IEnumerable<BESCategoryView> result = DataModelToViewModel.GenericListMapper<Category, BESCategoryView> (source);

            return View(result);
        }

        // GET: BackEndSystem/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            bool find = int.TryParse(id.ToString(), out int findid);
            Category category = UOF.Repository<Category>().Get(findid);
            if (find == false || category == null)
                return HttpNotFound();

            BESCategoryView result = DataModelToViewModel.GenericMapper<Category, BESCategoryView> (category);

            return View(result);
        }

        // GET: BackEndSystem/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackEndSystem/Categories/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BESCategoryView category)
        {
            if (ModelState.IsValid)
            {
                Category intput = DataModelToViewModel.GenericMapper<BESCategoryView, Category>(category);
                UOF.Repository<Category>().Add(intput);
                UOF.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: BackEndSystem/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            bool find = int.TryParse(id.ToString(), out int findid);
            Category category = UOF.Repository<Category>().Get(findid);
            if (find == false || category == null)
                return HttpNotFound();

            BESCategoryView result = DataModelToViewModel.GenericMapper<Category, BESCategoryView>(category);

            return View(result);
        }

        // POST: BackEndSystem/Categories/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BESCategoryView category)
        {
            if (ModelState.IsValid)
            {
                Category intput = DataModelToViewModel.GenericMapper<BESCategoryView, Category>(category);

                UOF.Repository<Category>().Update(intput);
                UOF.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: BackEndSystem/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            bool find = int.TryParse(id.ToString(), out int findid);
            Category category = UOF.Repository<Category>().Get(findid);
            if (find == false || category == null)
                return HttpNotFound();

            BESCategoryView result = DataModelToViewModel.GenericMapper<Category, BESCategoryView>(category);

            return View(result);
        }

        // POST: BackEndSystem/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool find = int.TryParse(id.ToString(), out int findid);
            if (find == true)
            {
                UOF.Repository<Category>().Remove(UOF.Repository<Category>().Get(findid));
                UOF.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
