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
    [SecuredOperationFilter(Roles = "admin,custmer")]
    public class HomeController : BaseController
    {
        public HomeController(IAllService all) : base(all)
        {
        }
        // GET: BackEndSystem/Home
        public ActionResult Index()
        {
            ViewBag.ProCount = All.PS().GetListToViewModel<Product>().Count;
            ViewBag.CatCount = All.CS().GetListToViewModel<Category>().Count;
            ViewBag.OrdCount = All.UOF().Repository<Order>().Reads().Count();
            ViewBag.Selltotal = All.UOF().Repository<Order>().Reads().Where(x => x.OrderDate.Month == DateTime.Now.Month).SingleOrDefault();


            return View();
        }
    }
}