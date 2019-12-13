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
                "BackEndSystem",
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