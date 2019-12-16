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
    public class PaymentController : BaseController
    {
        public PaymentController(IUnitOfWork uof, ICategoryService cs, IMemberService ms, IMemberRoloService mrs, IOrderService os, IOrderDetailService ods, IPaymentService pay, IProductService ps, IShipperService ships, ISupplierService sups) : base(uof, cs, ms, mrs, os, ods, pay, ps, ships, sups)
        {
        }

        public ActionResult Index()
        {
            var result = PAYS.GetListToViewModel<BESOrderView>();
            return View(result);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = PAYS.GetSpecificDetailToViewModel<BESOrderView>(x => x.PaymentID == id);

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
        public ActionResult Create(BESPaymentView source)
        {
            if (ModelState.IsValid)
            {
                PAYS.CreateViewModelToDatabase<BESPaymentView>(source);
                return RedirectToAction("Index");
            }

            return View(source);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = PAYS.GetSpecificDetailToViewModel<BESOrderView>(x => x.PaymentID == id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BESPaymentView source)
        {
            if (ModelState.IsValid)
            {
                PAYS.UpdateViewModelToDatabase<BESPaymentView>(source, x => x.PaymentID == source.PaymentID);
                return RedirectToAction<OrderController>(x => x.Index());
            }
            return View(source);
        }

        // GET: BackEndSystem/Payment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = PAYS.GetSpecificDetailToViewModel<BESOrderView>(x => x.PaymentID == id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // POST: BackEndSystem/Payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            PAYS.Delete(x => x.PaymentID == id);

            return RedirectToAction<OrderController>(x => x.Index());
        }
    }
}
