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
    public class OrderDetailController : BaseController
    {
        public OrderDetailController(IAllService all) : base(all)
        {
        }

        //public ActionResult Index()
        //{

        //    var result = ODS.GetListToViewModel<BESOrderDetailView>(o => o.Order, o => o.Product);

        //    return View(result);
        //}

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    var result = ODS.GetSpecificDetailToViewModel<BESOrderDetailView>(x => x.ID == id, o => o.Order, o => o.Product);

        //    if (result == null)
        //        return HttpNotFound();

        //    return View(result);
        //}

        //public ActionResult Create()
        //{
        //    ViewBag.OrderID = new SelectList(UOF.Repository<Order>().Reads(), "OrderID", "RecipientName");
        //    ViewBag.ProductID = new SelectList(UOF.Repository<Product>().Reads(), "ProductID", "ProductName");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(BESOrderDetailView source)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        MS.CreateViewModelToDatabase<BESOrderDetailView>(source);
        //        return RedirectToAction<OrderDetailController>(x => x.Index());
        //    }

        //    ViewBag.OrderID = new SelectList(UOF.Repository<Order>().Reads(), "OrderID", "RecipientName",source.OrderID);
        //    ViewBag.ProductID = new SelectList(UOF.Repository<Product>().Reads(), "ProductID", "ProductName",source.ProductID);
        //    return View(source);
        //}

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var result = ODS.GetSpecificDetailToViewModel<BESOrderDetailView>(x => x.ID == id, o => o.Order, o => o.Product);
        //    if (result == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.OrderID = new SelectList(UOF.Repository<Order>().Reads(), "OrderID", "RecipientName", result.OrderID);
        //    ViewBag.ProductID = new SelectList(UOF.Repository<Product>().Reads(), "ProductID", "ProductName", result.ProductID);
        //    return View(result);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(BESOrderDetailView source)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ODS.UpdateViewModelToDatabase<BESOrderDetailView>(source, x => x.OrderID == source.OrderID);
        //        return RedirectToAction<OrderDetailController>(x => x.Index());
        //    }
        //    ViewBag.OrderID = new SelectList(UOF.Repository<Order>().Reads(), "OrderID", "RecipientName", source.OrderID);
        //    ViewBag.ProductID = new SelectList(UOF.Repository<Product>().Reads(), "ProductID", "ProductName", source.ProductID);
        //    return View(source);
        //}

        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    var result = ODS.GetSpecificDetailToViewModel<BESOrderDetailView>(x => x.ID == id, o => o.Order, o => o.Product);

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

        //    ODS.Delete(x => x.OrderID == id);

        //    return RedirectToAction<OrderDetailController>(x => x.Index());
        //}
    }
}
