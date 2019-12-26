using DotrA_Lab.InternalDataService.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotrA.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(IAllService all) : base(all) { }

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
    }
}