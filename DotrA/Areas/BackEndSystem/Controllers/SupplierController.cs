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
        public SupplierController(IUnitOfWork uof, ICategoryService cs, IMemberService ms, IMemberRoloService mrs, IOrderService os, IOrderDetailService ods, IPaymentService pay, IProductService ps, IShipperService ships, ISupplierService sups) : base(uof, cs, ms, mrs, os, ods, pay, ps, ships, sups)
        {
        }

        public ActionResult Index()
        {
            var result = SUPS.GetListToViewModel<BESSupplierView>();

            return View(result);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = SUPS.GetSpecificDetailToViewModel<BESSupplierView>(x => x.SupplierID == id);

            if (result == null)
                return HttpNotFound();

            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BESSupplierView source)
        {
            if (ModelState.IsValid)
            {
                SUPS.CreateViewModelToDatabase<BESSupplierView>(source);
                return RedirectToAction<CategoryController>(x => x.Index());
            }

            return View(source);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = SUPS.GetSpecificDetailToViewModel<BESSupplierView>(x => x.SupplierID == id);

            if (result == null)
                return HttpNotFound();

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BESSupplierView source)
        {
            if (ModelState.IsValid)
            {
                SUPS.UpdateViewModelToDatabase<BESSupplierView>(source, x => x.SupplierID == source.SupplierID);
                return RedirectToAction<CategoryController>(x => x.Index());
            }
            return View(source);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = SUPS.GetSpecificDetailToViewModel<BESSupplierView>(x => x.SupplierID == id);
            if (result == null)
                return HttpNotFound();

            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            SUPS.Delete(x => x.SupplierID == id);

            return RedirectToAction<CategoryController>(x => x.Index());
        }
    }
}
