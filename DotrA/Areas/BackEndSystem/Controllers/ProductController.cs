using DotrA.Areas.BackEndSystem.ViewModels;
using DotrA.Controllers;
using DotrA_Lab.InternalDataService.Implementation;
using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DotrA.Filters;
using DotrA.Service;

namespace DotrA.Areas.BackEndSystem.Controllers
{

    [SecuredOperationFilter(Roles = "admin")]
    public class ProductController : BaseController
    {
        public ProductController(IAllService all) : base(all) { }

        public ActionResult Index()
        {
            var result = All.PS().GetListToViewModel<BESProductView>(x => x.Category, x => x.Supplier, x => x.ImageBase);

            ViewBag.Supplier = new SelectList(All.UOF().Repository<Supplier>().Reads(), "SupplierID", "CompanyName");
            ViewBag.Category = new SelectList(All.UOF().Repository<Category>().Reads(), "CategoryID", "CategoryName");
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BESProductCreateView source)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = All.UOF().Transaction())
                {
                    Upload inputimg = new Upload(All.IMGS());
                    try
                    {
                        inputimg.UploadImage("~/Assets/Images/Product", All.PS().CreateViewModelToDatabaseReturnData<BESProductCreateView>(source).ProductID, source.PictureLink);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
                return RedirectToAction<ProductController>(x => x.Index());
            }

            ViewBag.Supplier = new SelectList(All.UOF().Repository<Supplier>().Reads(), "SupplierID", "CompanyName", source.SupplierID);
            ViewBag.Category = new SelectList(All.UOF().Repository<Category>().Reads(), "CategoryID", "CategoryName", source.CategoryID);
            return View(source);
        }

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
        public ActionResult Status(int id)
        {
            All.PS().ChangeStatus(id);
            return Content("OK");
        }
    }
}
