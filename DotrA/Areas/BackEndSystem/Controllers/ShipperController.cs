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
    public class ShipperController : BaseController
    {
        public ShipperController(IAllService all) : base(all)
        {
        }

        //public ActionResult Index()
        //{
        //    var result = SHIPS.GetListToViewModel<BESShipperView>();

        //    return View(result);
        //}

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    var result = SHIPS.GetSpecificDetailToViewModel<BESShipperView>(x => x.ShipperID == id);

        //    if (result == null)
        //        return HttpNotFound();

        //    return View(result);
        //}

        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(BESShipperView source)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        SHIPS.CreateViewModelToDatabase<BESShipperView>(source);
        //        return RedirectToAction<ShipperController>(x => x.Index());
        //    }

        //    return View(source);
        //}

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    var result = SHIPS.GetSpecificDetailToViewModel<BESShipperView>(x => x.ShipperID == id);

        //    if (result == null)
        //        return HttpNotFound();

        //    return View(result);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(BESShipperView source)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        SHIPS.UpdateViewModelToDatabase<BESShipperView>(source, x => x.ShipperID == source.ShipperID);
        //        return RedirectToAction<ShipperController>(x => x.Index());
        //    }
        //    return View(source);
        //}

        //// GET: BackEndSystem/Shipper/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
        //    var result = SHIPS.GetSpecificDetailToViewModel<BESShipperView>(x => x.ShipperID == id);
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

        //    SHIPS.Delete(x => x.ShipperID == id);

        //    return RedirectToAction<ShipperController>(x => x.Index());
        //}
    }
}
