using DotrA.Filters;
using DotrA.Models.Member;
using DotrA.Service.Security.Web;
using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.InternalDataService;
using DotrA_Lab.InternalDataService.Implementation;
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
        public MemberController(IAllService all) : base(all) { }

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
                if (All.MS().CheckNullable(x => x.Email == source.Email))
                {
                    ModelState.AddModelError("EmailExist", "Email已經存在請更換!! This Email already exist");
                    return View();
                }
                #endregion
                #region //檢查帳號是否已經存在
                if (All.MS().CheckNullable(x => x.MemberAccount.Equals(source.MemberAccount)))
                {
                    ModelState.AddModelError("AccountExist", "此帳號已經存在，請更換帳號!! This Account already registered.");
                    //ViewBag.Message = "此帳號已經存在，請更換帳號!!";
                    return View();
                }
                #endregion

                string ActivationCode = All.MS().AddMember(source, source.Password);

                #region //寄送帳號啟用信 Send Email to Account
                SendVerifyOrResetEmail(source.Email, ActivationCode);
                message = "註冊成功，驗證帳號連結已寄到您的信箱. Registration successfully done. Account activation link " +
                    " has been sent to your Email : " + source.Email; /*"恭喜!!  " + member.MemberAccount + "  已成功註冊"*/
                #endregion

                ModelState.Clear();//清除 (包含錯誤訊息與模型繫結的資料都會被清空)
                ViewBag.Message = message;
                //return RedirectToAction("Login");
            }
            return View();
        }
        #region ===寄送驗證Email/重設密碼Email SendVerificationLinkEmailorSendResetPasswordLinkEmail===
        [NonAction]
        public void SendVerifyOrResetEmail(string Email, string activationCode, string emailFor = "VerifyAccount")
        {
            var verifyUrl = "/Member/" + emailFor + "/" + activationCode;
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
            if (Guid.TryParse(id, out Guid go))
            {
                if (All.MS().CheckNullable(x => x.ActivationCode == go))
                {
                    var Account = All.MS().GetFirst(x => x.ActivationCode == go);
                    All.MS().VerifyAccount(Account);
                    var role = All.MRS().GetUserRole(Account.RoleID);

                    AuthenticationHelper.CreateAuthCookie(Account.MemberID, Account.Name, Account.Email, Account.Password, role.RoleName);
                    Status = true;
                }
                else
                    ViewBag.Message = "無效的操作。Invalid Request.";
            }
            else
                ViewBag.Message = "無效的操作。Invalid Request.";

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
        public ActionResult Login(LoginViewModel source)
        {
            if (All.MS().CheckNullable(x => x.MemberAccount == source.MemberAccount && x.Password != null))
            {
                if (!All.MS().CheckEmailVerify(source.MemberAccount))
                {
                    TempData["Message"] = "請先到信箱啟動驗證. Please verify your email first.";
                    return Redirect(Request.UrlReferrer.ToString());
                }

                var Account = All.MS().UserLogin(source.MemberAccount, source.Password);

                if (Account != null)
                {
                    #region ===驗證票證===
                    var role = All.MRS().GetUserRole(Account.RoleID);

                    AuthenticationHelper.CreateAuthCookie(Account.MemberID, Account.Name, Account.Email, Account.Password, role.RoleName, source.RememberMe);
                    #endregion
                    return RedirectToAction<HomeController>(x => x.Index());
                }
                TempData["Message"] = "帳號或密碼輸入錯誤!! Invallid Account or Password.";
                return Redirect(Request.UrlReferrer.ToString());
            }
            TempData["Message"] = "帳號或密碼輸入錯誤!! Invallid Account or Password.";
            return Redirect(Request.UrlReferrer.ToString());
        }


        [SecuredOperationFilter(Roles = "admin")]
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
        #region ===修改會員資料===
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var member = All.MS().GetSpecificDetailToViewModel<MemberModifyViewModel>(x => x.MemberID == id, x => x.MemberRole);

            if (member == null)
                return HttpNotFound();

            return View(member);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MemberModifyViewModel source)
        {
            if (ModelState.IsValid)
            {
                var user = All.MS().GetFirst(x => x.MemberID == ((DotrA.Service.Security.Identity)User.Identity).Id);
                var hashpassword = Hash.EncodePassword(source.Password, user.HashCode);
                if (All.MS().CheckNullable(x => x.MemberAccount == source.MemberAccount && x.Password == hashpassword))
                {
                    if (source.RePassword == null)
                    {
                        source.Password = hashpassword;
                        All.MS().UpdateViewModelToDatabase(source, x => x.MemberID == ((DotrA.Service.Security.Identity)User.Identity).Id);
                    }
                    else
                        All.MS().MemberMoidfyPassword(source, ((DotrA.Service.Security.Identity)User.Identity).Id, source.RePassword);
                    return RedirectToAction<HomeController>(x => x.Index());
                }
                ModelState.AddModelError("Password", "原始密碼錯誤");
            }
            return View(source);
        }
        #endregion

    }
}