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
    [SecuredOperationFilter(Roles = "admin")]
    public class MemberController : BaseController
    {
        public MemberController(IUnitOfWork uof, ICategoryService cs, IMemberService ms, IMemberRoloService mrs, IOrderService os, IOrderDetailService ods, IPaymentService pay, IProductService ps, IShipperService ships, ISupplierService sups) : base(uof, cs, ms, mrs, os, ods, pay, ps, ships, sups)
        {
        }

        public ActionResult Index()
        {
            var result = MS.GetListToViewModel<BESMemberView>(o => o.MemberRolo);

            return View(result);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = MS.GetSpecificDetailToViewModel<BESMemberView>(x => x.MemberID == id, o => o.MemberRolo);

            if (result == null)
                return HttpNotFound();

            return View(result);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = MS.GetSpecificDetailToViewModel<BESMemberView>(x => x.MemberID == id, o => o.MemberRolo);

            if (result == null)
                return HttpNotFound();

            ViewBag.RoloNumber = new SelectList(UOF.Repository<MemberRolo>().Reads(), "RoloID", "RoloName", result.RoloID);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BESMemberView source)
        {
            if (ModelState.IsValid)
            {
                MS.UpdateViewModelToDatabase<BESMemberView>(source, x => x.MemberID == source.MemberID);
                return RedirectToAction<MemberController>(x => x.Index());
            }
            ViewBag.RoloNumber = new SelectList(UOF.Repository<MemberRolo>().Reads(), "RoloID", "RoloName", source.RoloID);
            return View(source);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = MS.GetSpecificDetailToViewModel<BESMemberView>(x => x.MemberID == id);
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

            MS.Delete(x => x.MemberID == id);

            return RedirectToAction<MemberController>(x => x.Index());
        }

        #region 會員新增塊
        //public ActionResult Create()
        //{

        //    ViewBag.RoloID = new SelectList(UOF.Repository<MemberRolo>().Reads(), "RoloID", "RoloName");

        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(BESMemberView source)
        //{
        //    string message = "";
        //    if (ModelState.IsValid)
        //    {
        //        #region //檢查信箱是否已經存在
        //        var isExist = IsEmailExist(source.Email);
        //        if (isExist)
        //        {
        //            ModelState.AddModelError("EmailExist", "Email已經存在請更換!! This Email already exist");
        //            return View();
        //        }
        //        #endregion
        //        #region //檢查帳號是否已經存在
        //        var registerAccount = MS.GetSpecificDetailToViewModel<BESMemberView>(x => x.MemberAccount.Equals(source.MemberAccount), o => o.MemberRolo);
        //        if (registerAccount != null)
        //        {
        //            ModelState.AddModelError("AccountExist", "此帳號已經存在，請更換帳號!! This Account already registered.");
        //            ViewBag.Message = "此帳號已經存在，請更換帳號!!";
        //            return View();
        //        }
        //        #endregion
        //        #region //產生 Activation Code 
        //        source.ActivationCode = Guid.NewGuid();
        //        #endregion
        //        #region //hash 加密
        //        var keyNew = hash.GeneratePassword(10);
        //        source.HashCode = keyNew;
        //        var password = hash.EncodePassword(source.Password, keyNew);
        //        source.Password = password;
        //        #endregion
        //        source.EmailVerified = false;


        //        MS.CreateViewModelToDatabase<BESMemberView>(source);

        //        #region //寄送帳號啟用信 Send Email to Account
        //        SendVerifyOrResetEmail(source.Email, source.ActivationCode.ToString());
        //        message = "註冊成功，驗證帳號連結已寄到您的信箱. Registration successfully done. Account activation link " +
        //            " has been sent to your Email : " + source.Email; /*"恭喜!!  " + member.MemberAccount + "  已成功註冊"*/
        //        #endregion
        //        ModelState.Clear();//清除 (包含錯誤訊息與模型繫結的資料都會被清空)
        //        ViewBag.Message = message;
        //        return RedirectToAction<MemberController>(x => x.Index());
        //    }

        //    ViewBag.RoloNumber = new SelectList(UOF.Repository<MemberRolo>().Reads(), "RoloID", "RoloName");

        //    return View(source);
        //}


        //#region ===判斷Email存在 IsEmailExist===
        //[NonAction]
        //public bool IsEmailExist(string email)
        //{
        //    var isExist = MS.GetSpecificDetailToViewModel<BESMemberView>(x => x.Email == email, o => o.MemberRolo);
        //    return isExist != null;
        //}
        //#endregion
        //#region ===寄送驗證Email/重設密碼Email SendVerificationLinkEmailorSendResetPasswordLinkEmail===
        //[NonAction]
        //public void SendVerifyOrResetEmail(string Email, string activationCode, string emailFor = "VerifyAccount")
        //{
        //    var verifyUrl = "/Members/" + emailFor + "/" + activationCode;
        //    var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

        //    var fromEmail = new MailAddress("minishopbs@gmail.com", "MiniShop");
        //    var toEmail = new MailAddress(Email);
        //    var fromEmailPassword = "edaybsazwbmogabr"; // Replace with actual password

        //    string subject = "";
        //    string body = "";
        //    if (emailFor == "VerifyAccount")
        //    {
        //        subject = "您的會員帳號已成功建立! Your account is successfully created!";
        //        body = "親愛的會員您好，很高興告訴您，您的MiniShop帳號已成功建立，請點擊下方連結進行帳號驗證.<br/><br/>" +
        //            "Hi,<br/><br/>We are excited to tell you that your MiniShop account is" +
        //            " successfully created. Please click on the below link to verify your account" +
        //            " <br/><br/><a href=" + link + ">請點此驗證帳號. Account activation link</a> ";

        //    }
        //    else if (emailFor == "ResetPassword")
        //    {
        //        subject = "重設密碼! Reset Password!";
        //        body = "親愛的會員您好,我們收到您重設密碼的請求，請點擊下方連結重設密碼.<br/><br/>" +
        //            "Hi,<br/><br/>We got request for reset your account password. Please click on the below link to reset your password" +
        //            "<br/><br/><a href=" + link + ">請點此重設密碼. Reset Password link</a>";
        //    }


        //    var smtp = new SmtpClient
        //    {
        //        Host = "smtp.gmail.com",
        //        Port = 587,
        //        EnableSsl = true,
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        UseDefaultCredentials = false,
        //        Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
        //    };

        //    using (var message = new MailMessage(fromEmail, toEmail)
        //    {
        //        Subject = subject,
        //        Body = body,
        //        IsBodyHtml = true
        //    })
        //        smtp.Send(message);
        //}
        //#endregion
        #endregion
    }
}
