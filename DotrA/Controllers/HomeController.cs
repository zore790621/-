using DotrA.Models;
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
        public HomeController(IAllService all) : base(all) { }

        public ActionResult Index()
        {
            return View(All.PS().GetListToViewModel<ProductView>().Where(x => x.Status == true));
        }
        public ActionResult About()
        {
            return View();
        }
    }
}
