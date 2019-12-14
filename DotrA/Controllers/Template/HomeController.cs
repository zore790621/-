using DotrA_Lab.InternalDataService.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotrA.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IAdminRepository adminrepo) : base(adminrepo)
        {
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
    }
}
