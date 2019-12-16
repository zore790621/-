using DotrA.Areas.BackEndSystem.ViewModels;
using DotrA.Controllers;
using DotrA_Lab.InternalDataService.Implementation;
using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DotrA.Filters;

namespace DotrA.Areas.BackEndSystem.Controllers
{

    [SecuredOperationFilter(Roles = "admin")]
    public class ProductController : BaseController
    {
        public ProductController(IAllService all) : base(all)
        {
        }

        //public ActionResult Index()
        //{
        //    var result = PS.GetListToViewModel<BESProductView>(x => x.Category, x => x.Supplier);

        //    return View(result);
        //}

        //public ActionResult Details(int? id)
        //{

        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    var result = PS.GetSpecificDetailToViewModel<BESProductView>(x => x.ProductID == id, x => x.Category, x => x.Supplier); 
            
        //    if (result == null)
        //        return HttpNotFound();

        //    return View(result);
        //}

        //// GET: BackEndSystem/Product/Create
        //public ActionResult Create()
        //{
        //    ViewBag.CategoryID = new SelectList(UOF.Repository<Category>().Reads(), "CategoryID", "CategoryName");
        //    ViewBag.SupplierID = new SelectList(UOF.Repository<Supplier>().Reads(), "SupplierID", "CompanyName");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(BESProductView source)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        PS.CreateViewModelToDatabase<BESProductView>(source);
        //        return RedirectToAction<ProductController>(x => x.Index());
        //    }

        //    ViewBag.CategoryID = new SelectList(UOF.Repository<Category>().Reads(), "CategoryID", "CategoryName", source.CategoryID);
        //    ViewBag.SupplierID = new SelectList(UOF.Repository<Supplier>().Reads(), "SupplierID", "CompanyName",source.SupplierID);
        //    return View(source);
        //}

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    var result = PS.GetSpecificDetailToViewModel<BESProductView>(x => x.ProductID == id, x => x.Category, x => x.Supplier);
            
        //    if (result == null)
        //        return HttpNotFound();

        //    ViewBag.CategoryID = new SelectList(UOF.Repository<Category>().Reads(), "CategoryID", "CategoryName",result.CategoryID);
        //    ViewBag.SupplierID = new SelectList(UOF.Repository<Supplier>().Reads(), "SupplierID", "CompanyName",result.SupplierID);
        //    return View(result);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(BESProductView source)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        PS.UpdateViewModelToDatabase<BESProductView>(source, x => x.ProductID == source.ProductID);
        //        return RedirectToAction<ProductController>(x => x.Index());
        //    }
        //    ViewBag.CategoryID = new SelectList(UOF.Repository<Category>().Reads(), "CategoryID", "CategoryName", source.CategoryID);
        //    ViewBag.SupplierID = new SelectList(UOF.Repository<Supplier>().Reads(), "SupplierID", "CompanyName", source.SupplierID);
        //    return View(source);
        //}

        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    var result = PS.GetSpecificDetailToViewModel<BESProductView>(x => x.ProductID == id, x => x.Category, x => x.Supplier);

        //    if (result == null)
        //        return HttpNotFound();

        //    return View(result);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int? id)
        //{
        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    PS.Delete(x => x.ProductID == id);

        //    return RedirectToAction<ProductController>(x => x.Index());
        //}
    }
}
