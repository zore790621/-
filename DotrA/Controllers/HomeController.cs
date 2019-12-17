using DotrA_Lab.InternalDataService.Implementation;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotrA.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IAllService all) : base(all)
        {
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult About()
        {
            return View();
        }
    }
}
