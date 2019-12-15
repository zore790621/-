using DotrA.Areas.BackEndSystem.ViewModels;
using DotrA.Controllers;
using DotrA.Service.Mapper;
using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DotrA.Areas.BackEndSystem.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork uof) : base(uof)
        {
        }

        // GET: BackEndSystem/Product
        public ActionResult Index()
        {
            var source = UOF.Repository<Product>().GetAll();
            IEnumerable<BESProductView> result = DataModelToViewModel.GenericListMapper<Product, BESProductView>(source);
            
            return View(result);
        }

        // GET: BackEndSystem/Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            bool find = int.TryParse(id.ToString(), out int findid);
            Product category = UOF.Repository<Product>().Get(findid);
            if (find == false || category == null)
                return HttpNotFound();

            BESProductView result = DataModelToViewModel.GenericMapper<Product, BESProductView>(category);

            return View(result);
        }

        // GET: BackEndSystem/Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(UOF.Repository<Category>().GetAll(), "CategoryID", "CategoryName");
            ViewBag.SupplierID = new SelectList(UOF.Repository<Supplier>().GetAll(), "SupplierID", "CompanyName");
            return View();
        }

        // POST: BackEndSystem/Product/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BESProductView product)
        {
            if (ModelState.IsValid)
            {
                Product intput = DataModelToViewModel.GenericMapper<BESProductView, Product>(product);
                UOF.Repository<Product>().Add(intput);
                UOF.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(UOF.Repository<Category>().GetAll(), "CategoryID", "CategoryName");
            ViewBag.SupplierID = new SelectList(UOF.Repository<Supplier>().GetAll(), "SupplierID", "CompanyName");
            return View(product);
        }

        // GET: BackEndSystem/Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            bool find = int.TryParse(id.ToString(), out int findid);
            Product category = UOF.Repository<Product>().Get(findid);
            if (find == false || category == null)
                return HttpNotFound();

            BESProductView result = DataModelToViewModel.GenericMapper<Product, BESProductView>(category);

            ViewBag.CategoryID = new SelectList(UOF.Repository<Category>().GetAll(), "CategoryID", "CategoryName");
            ViewBag.SupplierID = new SelectList(UOF.Repository<Supplier>().GetAll(), "SupplierID", "CompanyName");

            return View(result);
        }

        // POST: BackEndSystem/Product/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BESProductView product)
        {
            if (ModelState.IsValid)
            {
                Product intput = DataModelToViewModel.GenericMapper<BESProductView, Product>(product);

                UOF.Repository<Product>().Update(intput);
                UOF.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: BackEndSystem/Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            bool find = int.TryParse(id.ToString(), out int findid);
            Product category = UOF.Repository<Product>().Get(findid);
            if (find == false || category == null)
                return HttpNotFound();

            BESProductView result = DataModelToViewModel.GenericMapper<Product, BESProductView>(category);

            return View(result);
        }

        // POST: BackEndSystem/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool find = int.TryParse(id.ToString(), out int findid);
            if (find == true)
            {
                UOF.Repository<Product>().Remove(UOF.Repository<Product>().Get(findid));
                UOF.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
