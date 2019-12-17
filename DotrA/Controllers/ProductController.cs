using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotrA_Lab.InternalDataService.Implementation;

namespace DotrA.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IAllService all) : base(all)
        {
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
    }
}