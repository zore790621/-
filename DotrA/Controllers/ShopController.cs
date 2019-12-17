using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotrA_Lab.InternalDataService.Implementation;

namespace DotrA.Controllers
{
    public class ShopController : BaseController
    {
        public ShopController(IAllService all) : base(all)
        {
        }

        // GET: Shop
        public ActionResult Index()
        {
            return View();
        }
    }
}