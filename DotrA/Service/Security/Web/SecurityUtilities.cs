using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DotrA.Service.Security.Web
{
    public class SecurityUtilities
    {
        public Identity FormsAuthTicketToIdentity(FormsAuthenticationTicket ticket)
        {
            var identity = new Identity
            {
                Name = SetName(ticket),
                Id = SetId(ticket),
                MemberName = SetName(ticket),
                Email = SetEmail(ticket),
                Password = SetPassword(ticket),
                Role = SetRole(ticket),
                Status = SetStatus(ticket),
                Timeout = SetTimeout(ticket),
                AuthenticationType = SetAuthType(),
                IsAuthenticated = SetIsAuthenticated()
            };
            return identity;
        }
        private int SetId(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[0] == null ? 0 : Convert.ToInt32(data[0]);
        }
        private string SetName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[1];
        }


        private string SetEmail(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[2];
        }

        private string SetPassword(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[3];
        }
        private string SetRole(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[4].Trim();
        }
        private bool SetStatus(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            var status = data[5];
            if (status == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private int SetTimeout(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            int.TryParse(data[6], out int result);
            return result;
        }
        private string SetAuthType()
        {
            return "Forms";
        }
        private bool SetIsAuthenticated()
        {
            return true;
        }
    }
}