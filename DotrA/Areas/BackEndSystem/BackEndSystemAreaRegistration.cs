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
                "BackEndSystem_Product",
                "admin/Product/{action}",
                new { controller = "Product", action = "Index" },
                namespaces: new string[] { "DotrA.Areas.BackEndSystem.Controllers" }
                );
            context.MapRoute(
                "BackEndSystem_Category",
                "admin/Category/{action}",
                new { controller = "Categories", action = "Index" },
                namespaces: new string[] { "DotrA.Areas.BackEndSystem.Controllers" }
                );
            context.MapRoute(
                "BackEndSystem_Home",
                "admin/Home/{action}",
                new { controller = "Home", action = "Index" },
                namespaces: new string[] { "DotrA.Areas.BackEndSystem.Controllers" }
            );
            context.MapRoute(
                "BackEndSystem_default",
                "admin/{controller}/{action}",
                new { controller = "Lander", action = "Login" },
                namespaces: new string[] { "DotrA.Areas.BackEndSystem.Controllers" }
            );
        }
    }
}