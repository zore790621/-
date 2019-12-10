using System.Web.Mvc;

namespace DotrA.Areas.ElaAdmin
{
    public class ElaAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ElaAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ElaAdmin_default",
                "ElaAdmin/{action}",
                new { controller = "ElaAdmin", action = "Index" }
            );
        }
    }
}