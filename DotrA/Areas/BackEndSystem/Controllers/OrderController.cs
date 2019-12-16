using DotrA.Areas.BackEndSystem.ViewModels;
using DotrA.Controllers;
using DotrA.Filters;
using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.InternalDataService.Implementation;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DotrA.Areas.BackEndSystem.Controllers
{

    [SecuredOperationFilter(Roles = "admin")]
    public class OrderController : BaseController
    {
        public OrderController(IAllService all) : base(all)
        {
        }

        //public ActionResult Index()
        //{
        //    var result = OS.GetListToViewModel<BESOrderView>(o => o.Payment, o => o.Shipper);

        //    return View(result);
        //}

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    var result = OS.GetSpecificDetailToViewModel<BESOrderView>(x => x.OrderID == id, o => o.Payment, o => o.Shipper);

        //    if (result == null)
        //        return HttpNotFound();

        //    return View(result);
        //}

        //public ActionResult Create()
        //{
        //    ViewBag.MemberID = new SelectList(UOF.Repository<Member>().Reads(), "MemberID", "MemberAccount");
        //    ViewBag.PaymentID = new SelectList(UOF.Repository<Payment>().Reads(), "PaymentID", "PaymentMethod");
        //    ViewBag.ShipperID = new SelectList(UOF.Repository<Shipper>().Reads(), "ShipperID", "ShipperName");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(BESOrderView source)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        MS.CreateViewModelToDatabase<BESOrderView>(source);
        //        return RedirectToAction<OrderController>(x => x.Index());
        //    }

        //    ViewBag.MemberID = new SelectList(UOF.Repository<Member>().Reads(), "MemberID", "MemberAccount", source.MemberID);
        //    ViewBag.PaymentID = new SelectList(UOF.Repository<Payment>().Reads(), "PaymentID", "PaymentMethod", source.PaymentID);
        //    ViewBag.ShipperID = new SelectList(UOF.Repository<Shipper>().Reads(), "ShipperID", "ShipperName", source.ShipperID);
        //    return View(source);
        //}

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    var result = OS.GetSpecificDetailToViewModel<BESOrderView>(x => x.OrderID == id, o => o.Payment, o => o.Shipper);

        //    if (result == null)
        //        return HttpNotFound();

        //    ViewBag.MemberID = new SelectList(UOF.Repository<Member>().Reads(), "MemberID", "MemberAccount", result.MemberID);
        //    ViewBag.PaymentID = new SelectList(UOF.Repository<Payment>().Reads(), "PaymentID", "PaymentMethod", result.PaymentID);
        //    ViewBag.ShipperID = new SelectList(UOF.Repository<Shipper>().Reads(), "ShipperID", "ShipperName", result.ShipperID);
        //    return View(result);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(BESOrderView source)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        OS.UpdateViewModelToDatabase<BESOrderView>(source, x => x.OrderID == source.OrderID);
        //        return RedirectToAction<OrderController>(x => x.Index());
        //    }
        //    ViewBag.MemberID = new SelectList(UOF.Repository<Member>().Reads(), "MemberID", "MemberAccount", source.MemberID);
        //    ViewBag.PaymentID = new SelectList(UOF.Repository<Payment>().Reads(), "PaymentID", "PaymentMethod", source.PaymentID);
        //    ViewBag.ShipperID = new SelectList(UOF.Repository<Shipper>().Reads(), "ShipperID", "ShipperName", source.ShipperID);
        //    return View(source);
        //}

        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    var result = OS.GetSpecificDetailToViewModel<BESOrderView>(x => x.OrderID == id, o => o.Payment, o => o.Shipper);
            
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

        //    OS.Delete(x => x.OrderID == id);

        //    return RedirectToAction<OrderController>(x => x.Index());
        //}
    }
}
