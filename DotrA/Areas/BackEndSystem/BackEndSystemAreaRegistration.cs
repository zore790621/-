using System.Web.Mvc;

namespace DotrA.Areas.BackEndSystem
{
    public class BackEndSystemAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "BackEndSystem";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BackEndSystem_Category",
                "admin/Category/{action}/{id}",
                new { controller = "Category", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "DotrA.Areas.BackEndSystem.Controllers" }
                );
            context.MapRoute(
                "BackEndSystem_Member",
                "admin/Member/{action}/{id}",
                new { controller = "Member", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "DotrA.Areas.BackEndSystem.Controllers" }
                );
            context.MapRoute(
                "BackEndSystem_Orders",
                "admin/Orders/{action}/{id}",
                new { controller = "Order", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "DotrA.Areas.BackEndSystem.Controllers" }
                );
            context.MapRoute(
                "BackEndSystem_OrdersDetail",
                "admin/OrderDetail/{action}/{id}",
                new { controller = "OrderDetail", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "DotrA.Areas.BackEndSystem.Controllers" }
                );
            context.MapRoute(
                "BackEndSystem_Payment",
                "admin/Payment/{action}/{id}",
                new { controller = "Payment", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "DotrA.Areas.BackEndSystem.Controllers" }
                );
            context.MapRoute(
                "BackEndSystem_Product",
                "admin/Product/{action}/{id}",
                new { controller = "Product", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "DotrA.Areas.BackEndSystem.Controllers" }
                );
            context.MapRoute(
                "BackEndSystem_Shipper",
                "admin/Shipper/{action}/{id}",
                new { controller = "Shipper", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "DotrA.Areas.BackEndSystem.Controllers" }
                );
            context.MapRoute(
                "BackEndSystem_Supplier",
                "admin/Supplier/{action}/{id}",
                new { controller = "Supplier", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "DotrA.Areas.BackEndSystem.Controllers" }
            );
            context.MapRoute(
                "BackEndSystem_default",
                "admin/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "DotrA.Areas.BackEndSystem.Controllers" }
            );
        }
    }
}