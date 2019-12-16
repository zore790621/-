using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace DotrA.Service.Security.Web
{
    public class AuthenticationHelper
    {
        public static void CreateAuthCookie(int id, string name, string email, string password, string role, bool status)
        {
            int timeout = status ? 525600 : 20;
            var authTicket = new FormsAuthenticationTicket(1, name, DateTime.Now, DateTime.Now.AddDays(1), false, CreateAuthTags(id, name, email, password, role, status, timeout));
            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket)
            {
                Expires = DateTime.Now.AddMinutes(timeout),
                HttpOnly = true
            });
        }
        private static string CreateAuthTags(int id, string name, string email, string password, string role, bool status, int timeout)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(id);
            sb.Append("|");

            sb.Append(name);
            sb.Append("|");

            sb.Append(email);
            sb.Append("|");

            sb.Append(password);
            sb.Append("|");

            sb.Append(role);
            sb.Append('|');

            sb.Append(status);
            sb.Append('|');

            sb.Append(timeout);
            return sb.ToString();

        }
        public static void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}