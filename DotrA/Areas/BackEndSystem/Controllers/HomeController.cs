using DotrA.Areas.BackEndSystem.ViewModels;
using DotrA.Controllers;
using DotrA.Filters;
using DotrA_Lab.Business.DomainClasses;
using DotrA_Lab.InternalDataService.Implementation;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DotrA.Areas.BackEndSystem.Controllers
{
    [SecuredOperationFilter(Roles = "admin")]
    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork uof, ICategoryService cs, IMemberService ms, IMemberRoloService mrs, IOrderService os, IOrderDetailService ods, IPaymentService pay, IProductService ps, IShipperService ships, ISupplierService sups) : base(uof, cs, ms, mrs, os, ods, pay, ps, ships, sups)
        {
        }

        // GET: BackEndSystem/Home
        public ActionResult Index()
        {
            ViewBag.ProCount = PS.GetListToViewModel<Product>().Count;
            ViewBag.CatCount = CS.GetListToViewModel<Category>().Count;
            ViewBag.OrdCount = UOF.Repository<Order>().Reads().Count();
            ViewBag.Selltotal = UOF.Repository<Order>().Reads().Where(x => x.OrderDate.Month == DateTime.Now.Month).SingleOrDefault();
            

            return View();
        }
    }
}