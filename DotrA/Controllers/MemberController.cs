using DotrA.Filters;
using DotrA.Models.Member;
using DotrA.Service;
using DotrA.Service.Security.Web;
using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.InternalDataService;
using DotrA_Lab.InternalDataService.Implementation;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DotrA.Controllers
{
    public class MemberController : BaseController
    {
        public MemberController(IUnitOfWork uof, ICategoryService cs, IMemberService ms, IMemberRoloService mrs, IOrderService os, IOrderDetailService ods, IPaymentService pay, IProductService ps, IShipperService ships, ISupplierService sups) : base(uof, cs, ms, mrs, os, ods, pay, ps, ships, sups)
        {
        }

        [Authorize(Users = "admin")]//必須有授權/認證才能進入
        public ActionResult Index()
        {
            return View(UOF.Repository<Member>().Reads());
        }
        #region ===註冊 Register===
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(MemberRegisterViewModel source)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                #region //檢查信箱是否已經存在
                var isExist = IsEmailExist(source.Email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email已經存在請更換!! This Email already exist");
                    return View();
                }
                #endregion
                #region //檢查帳號是否已經存在
                //var registerAccount = (from m in db.Members where m.MemberAccount.Equals(member.MemberAccount) select m).SingleOrDefault();
                var registerAccount = MS.GetSpecificDetailToViewModel<MemberRegisterViewModel>(x => x.MemberAccount.Equals(source.MemberAccount), o => o.MemberRolo);
                if (registerAccount != null)
                {
                    ModelState.AddModelError("AccountExist", "此帳號已經存在，請更換帳號!! This Account already registered.");
                    //ViewBag.Message = "此帳號已經存在，請更換帳號!!";
                    return View();
                }

                #endregion
                var member = new Member();

                #region //產生 Activation Code 
                member.ActivationCode = Guid.NewGuid();
                //var keyNew = hash.GeneratePassword(10);
                #endregion
                #region //hash 加密
                var keyNew = hash.GeneratePassword(10);
                member.HashCode = keyNew;
                var password = hash.EncodePassword(member.Password, keyNew);
                member.Password = password;
                #endregion
                member.EmailVerified = false;//註冊時將Email認證設為false

                DataModelToViewModel.GenericMapper(source, member);

                member.RoloID = 4;

                MS.CreateViewModelToDatabase<Member>(member);
                #region //寄送帳號啟用信 Send Email to Account
                SendVerifyOrResetEmail(member.Email, member.ActivationCode.ToString());
                message = "註冊成功，驗證帳號連結已寄到您的信箱. Registration successfully done. Account activation link " +
                    " has been sent to your Email : " + member.Email; /*"恭喜!!  " + member.MemberAccount + "  已成功註冊"*/
                #endregion

                ModelState.Clear();//清除 (包含錯誤訊息與模型繫結的資料都會被清空)
                ViewBag.Message = message;
                //return RedirectToAction("Login");
            }
            return View();
        }
        #region ===判斷Email存在 IsEmailExist===
        [NonAction]
        public bool IsEmailExist(string email)
        {
            var isExist = MS.GetSpecificDetailToViewModel<MemberRegisterViewModel>(x => x.Email == email, o => o.MemberRolo);
            return isExist != null;
        }
        #endregion
        #region ===寄送驗證Email/重設密碼Email SendVerificationLinkEmailorSendResetPasswordLinkEmail===
        [NonAction]
        public void SendVerifyOrResetEmail(string Email, string activationCode, string emailFor = "VerifyAccount")
        {
            var verifyUrl = "/Members/" + emailFor + "/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("minishopbs@gmail.com", "MiniShop");
            var toEmail = new MailAddress(Email);
            var fromEmailPassword = "edaybsazwbmogabr"; // Replace with actual password

            string subject = "";
            string body = "";
            if (emailFor == "VerifyAccount")
            {
                subject = "您的會員帳號已成功建立! Your account is successfully created!";
                body = "親愛的會員您好，很高興告訴您，您的MiniShop帳號已成功建立，請點擊下方連結進行帳號驗證.<br/><br/>" +
                    "Hi,<br/><br/>We are excited to tell you that your MiniShop account is" +
                    " successfully created. Please click on the below link to verify your account" +
                    " <br/><br/><a href=" + link + ">請點此驗證帳號. Account activation link</a> ";

            }
            else if (emailFor == "ResetPassword")
            {
                subject = "重設密碼! Reset Password!";
                body = "親愛的會員您好,我們收到您重設密碼的請求，請點擊下方連結重設密碼.<br/><br/>" +
                    "Hi,<br/><br/>We got request for reset your account password. Please click on the below link to reset your password" +
                    "<br/><br/><a href=" + link + ">請點此重設密碼. Reset Password link</a>";
            }


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }
        #endregion
        #endregion
        #region ===驗證帳號 VerifyAccount===
        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;

            var v = MS.GetSpecificDetailToViewModel<Member>(x => x.ActivationCode == new Guid(id));
            if (v != null)
            {
                v.EmailVerified = true;
                MS.UpdateViewModelToDatabase<Member>(v, x => x.EmailVerified);
                Status = true;
            }
            else
            {
                ViewBag.Message = "無效的操作。Invalid Request.";
            }

            ViewBag.Status = Status;
            return View();
        }
        #endregion
        #region ===登入Login/登出Logout===
        // GET: Members/Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login)
        {
            var user = MS.GetSpecificDetailToViewModel<Member>(x => x.MemberAccount == login.MemberAccount && x.Password != null);
            if (user != null)
            {
                if (!user.EmailVerified)
                {
                    TempData["Message"] = "請先到信箱啟動驗證. Please verify your email first.";
                    return Redirect(Request.UrlReferrer.ToString());
                }

                #region 加密比較
                var HCode = user.HashCode;
                var encodingPasswordString = hash.EncodePassword(login.Password, HCode);

                var Account = MS.GetSpecificDetailToViewModel<Member>(x => x.MemberAccount == login.MemberAccount && x.Password.Equals(encodingPasswordString));
                #endregion
                if (Account != null)
                {
                    #region ===驗證票證===
                    var role = MRS.GetSpecificDetailToViewModel<MemberRolo>(x => x.RoloID == Account.RoloID);

                    AuthenticationHelper.CreateAuthCookie(Account.MemberID, Account.Name, Account.Email, Account.Password, role.RoloName, login.RememberMe);
                    #endregion
                    return RedirectToAction<HomeController>(x => x.Index());
                }
                TempData["Message"] = "帳號或密碼輸入錯誤!! Invallid Account or Password.";
                return Redirect(Request.UrlReferrer.ToString());
            }
            TempData["Message"] = "帳號或密碼輸入錯誤!! Invallid Account or Password.";
            return Redirect(Request.UrlReferrer.ToString());
        }



        public ActionResult LoggedIn()
        {
            if (User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            AuthenticationHelper.Logout();
            return RedirectToAction("Index", "Home");
        }
        #endregion

    }
}