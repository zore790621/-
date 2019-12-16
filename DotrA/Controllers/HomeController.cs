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
        public HomeController(IUnitOfWork uof, ICategoryService cs, IMemberService ms, IMemberRoloService mrs, IOrderService os, IOrderDetailService ods, IPaymentService pay, IProductService ps, IShipperService ships, ISupplierService sups) : base(uof, cs, ms, mrs, os, ods, pay, ps, ships, sups)
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
