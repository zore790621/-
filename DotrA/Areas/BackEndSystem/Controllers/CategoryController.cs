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
        public CategoryController(IAllService all) : base(all) { }

        public ActionResult Index()
        {
            var result = All.CS().GetListToViewModel<BESCategoryView>(x => x.ImageBase);

            return View(result);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = All.CS().GetSpecificDetailToViewModel<BESCategoryView>(x => x.CategoryID == id);

            if (result == null)
                return HttpNotFound();

            return View(result);
        }

        #region 新增類型
        #region 移至 Modaldial
        [NonAction]
        public ActionResult Create()
        {
            return View();
        }
        #endregion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BESCategoryView source)
        {
            if (ModelState.IsValid)
            {
                All.CS().CreateViewModelToDatabase<BESCategoryView>(source);
                return RedirectToAction<CategoryController>(x => x.Index());
            }

            return View(source);
        }
        #endregion

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = All.CS().GetSpecificDetailToViewModel<BESCategoryView>(x => x.CategoryID == id);

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
                All.CS().UpdateViewModelToDatabase<BESCategoryView>(source, x => x.CategoryID == source.CategoryID);
                return RedirectToAction<CategoryController>(x => x.Index());
            }
            return View(source);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = All.CS().GetSpecificDetailToViewModel<BESCategoryView>(x => x.CategoryID == id);
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

            All.CS().Delete(x => x.CategoryID == id);

            return RedirectToAction<CategoryController>(x => x.Index());
        }
    }
}
