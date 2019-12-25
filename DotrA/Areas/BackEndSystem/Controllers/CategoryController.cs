using DotrA.Areas.BackEndSystem.ViewModels;
using DotrA.Controllers;
using DotrA_Lab.InternalDataService.Implementation;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Net;
using System.Linq;
using System.Web.Mvc;
using DotrA.Filters;
using DotrA.Service;

namespace DotrA.Areas.BackEndSystem.Controllers
{

    [SecuredOperationFilter(Roles = "admin")]
    public class CategoryController : BaseController
    {
        public CategoryController(IAllService all) : base(all) { }

        public ActionResult Index()
        {
            return View(All.CS().GetListToViewModel<BESCategoryView>(x => x.Product, x => x.ImageBase));
        }

        #region 新增類型
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BESCategoryCreateView source)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = All.UOF().Transaction())
                {
                    Upload inputimg = new Upload(All.IMGS());
                    try
                    {
                        inputimg.UploadImage("~/Assets/Images/Category", All.CS().CreateViewModelToDatabaseReturnData<BESCategoryCreateView>(source).CategoryID, source.PictureLink);
                        transaction.Commit();
                    }
                    catch (System.Exception)
                    {
                        transaction.Rollback();
                    }
                }
                return RedirectToAction<CategoryController>(x => x.Index());
            }

            return View(source);
        }
        #endregion
        #region 修改
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = All.CS().GetSpecificDetailToViewModel<BESCategoryEditView>(x => x.CategoryID == id, x => x.ImageBase);

            if (result == null)
                return HttpNotFound();
            ViewBag.Product = All.PS().GetListToViewModel<BESProductView>(x => x.CategoryID == id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BESCategoryEditView source)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = All.UOF().Transaction())
                {
                    Upload inputimg = new Upload(All.IMGS());
                    try
                    {
                        All.CS().UpdateViewModelToDatabase<BESCategoryEditView>(source, x => x.CategoryID == source.CategoryID);
                        inputimg.UploadImage("~/Assets/Images/Category", source.CategoryID, source.PictureLink);
                        transaction.Commit();
                    }
                    catch (System.Exception)
                    {
                        transaction.Rollback();
                    }
                }
                return RedirectToAction<CategoryController>(x => x.Index());
            }
            return View(source);
        }
        #endregion

        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            All.CS().Delete(x => x.CategoryID == id);
            return Content("OK");
        }
    }
}
