using DotrA.Areas.BackEndSystem.ViewModels;
using DotrA.Controllers;
using DotrA.Filters;
using DotrA_Lab.InternalDataService.Implementation;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DotrA.Areas.BackEndSystem.Controllers
{

    [SecuredOperationFilter(Roles = "admin")]
    public class SupplierController : BaseController
    {
        public SupplierController(IAllService all) : base(all) { }

        public ActionResult Index()
        {
            var result = All.SUPS().GetListToViewModel<BESSupplierView>(x=>x.Product);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BESSupplierCreateAndEditView source)
        {
            if (ModelState.IsValid)
            {
                All.SUPS().CreateViewModelToDatabase<BESSupplierCreateAndEditView>(source);
                return RedirectToAction<SupplierController>(x => x.Index());
            }
            return View(source);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = All.SUPS().GetSpecificDetailToViewModel<BESSupplierCreateAndEditView>(x => x.SupplierID == id);

            if (result == null)
                return HttpNotFound();
            ViewBag.Product = All.PS().GetListToViewModel<BESProductView>(x => x.SupplierID == id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BESSupplierCreateAndEditView source)
        {
            if (ModelState.IsValid)
            {
                All.SUPS().UpdateViewModelToDatabase<BESSupplierCreateAndEditView>(source, x => x.SupplierID == source.SupplierID);
                return RedirectToAction<SupplierController>(x => x.Index());
            }
            return View(source);
        }

        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            All.SUPS().Delete(x => x.SupplierID == id);
            return Content("OK");
        }
    }
}
