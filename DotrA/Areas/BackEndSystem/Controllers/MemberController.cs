using DotrA.Areas.BackEndSystem.ViewModels;
using DotrA.Controllers;
using DotrA.Service;
using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.InternalDataService.Implementation;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Linq;
using System;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using DotrA.Filters;

namespace DotrA.Areas.BackEndSystem.Controllers
{
    [SecuredOperationFilter(Roles = "admin,custmer")]
    public class MemberController : BaseController
    {
        public MemberController(IAllService all) : base(all) { }
        #region 會員首頁
        public ActionResult Index()
        {
            var result = All.MS().GetListToViewModel<BESMemberView>(o => o.MemberRole);

            return View(result);
        }
        #endregion
        #region 會員詳細 !暫時覺得不需要
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = All.MS().GetSpecificDetailToViewModel<BESMemberView>(x => x.MemberID == id, o => o.MemberRole);

            if (result == null)
                return HttpNotFound();

            return View(result);
        }
        #endregion
        #region 會員修改
        [SecuredOperationFilter(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = All.MS().GetSpecificDetailToViewModel<BESMemberView>(x => x.MemberID == id, o => o.MemberRole);

            if (result == null)
                return HttpNotFound();

            ViewBag.RoleNumber = new SelectList(All.UOF().Repository<MemberRole>().Reads(), "RoleID", "RoleName", result.RoleID);

            return View(result);
        }

        [SecuredOperationFilter(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BESMemberView source)
        {
            if (ModelState.IsValid)
            {
                All.MS().UpdateViewModelToDatabase(source, x => x.MemberID == source.MemberID);
                return RedirectToAction<MemberController>(x => x.Index());
            }
            ViewBag.RoloNumber = new SelectList(All.UOF().Repository<MemberRole>().Reads(), "RoloID", "RoloName", source.RoleID);
            return View(source);
        }
        #endregion
        #region 會員刪除
        [SecuredOperationFilter(Roles = "admin")]
        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            All.MS().Delete(x => x.MemberID == id);
            return Content("OK");
        }
        #endregion
    }
}
