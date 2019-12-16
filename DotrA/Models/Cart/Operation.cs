using DotrA_Lab.ORM.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace DotrA.Models.Cart
{
    public static class Operation
    {
        [WebMethod(EnableSession = true)]//啟用Session
        public static CartMath GetCurrentCart()//取得目前Session中的Cart物件
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Session["CartTestTest"] == null)
                {
                    var order = new CartMath();
                    HttpContext.Current.Session["CartTestTest"] = order;
                }
                return (CartMath)HttpContext.Current.Session["CartTestTest"];
            }
            else
            {
                throw new InvalidOperationException("System.Web.HttpContext.Current為空");
            }
        }
    }

}