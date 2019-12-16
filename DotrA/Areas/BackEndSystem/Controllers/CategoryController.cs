using DotrA.Areas.BackEndSystem.ViewModels;
using DotrA.Controllers;
using DotrA_Lab.InternalDataService.Implementation;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Net;
using System.Linq;
using System.Web.Mvc;
using DotrA.Filters;

namespace DotrA.Areas.BackEndSystem.Controllers
{

    [SecuredOperationFilter(Roles = "admin")]
    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork uof, ICategoryService cs, IMemberService ms, IMemberRoloService mrs, IOrderService os, IOrderDetailService ods, IPaymentService pay, IProductService ps, IShipperService ships, ISupplierService sups) : base(uof, cs, ms, mrs, os, ods, pay, ps, ships, sups)
        {
        }

        public ActionResult Index()
        {
            var result = CS.GetListToViewModel<BESCategoryView>();

            return View(result);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = CS.GetSpecificDetailToViewModel<BESCategoryView>(x => x.CategoryID == id);

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
        public ActionResult Create(BESCategoryView source)
        {
            if (ModelState.IsValid)
            {
                CS.CreateViewModelToDatabase<BESCategoryView>(source);
                return RedirectToAction<CategoryController>(x=> x.Index());
            }

            return View(source);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = CS.GetSpecificDetailToViewModel<BESCategoryView>(x => x.CategoryID == id);

            if (result == null)
                return HttpNotFound();

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BESCategoryView source)
        {
            if (ModelState.IsValid)
            {
                CS.UpdateViewModelToDatabase<BESCategoryView>(source, x => x.CategoryID == source.CategoryID);
                return RedirectToAction<CategoryController>(x => x.Index());
            }
            return View(source);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = CS.GetSpecificDetailToViewModel<BESCategoryView>(x => x.CategoryID == id);
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

            CS.Delete(x => x.CategoryID == id);

            return RedirectToAction<CategoryController>(x => x.Index());
        }
    }
}
