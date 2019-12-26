using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotrA.Models;
using DotrA_Lab.InternalDataService.Implementation;
using PagedList;

namespace DotrA.Controllers
{
    [Authorize]
    public class ShopController : BaseController
    {
        public ShopController(IAllService all) : base(all) { }

        // GET: Shop
        public ActionResult Index(int? pid, int page = 1)
        {
            bool IsInt_pid = int.TryParse(pid.ToString(), out int id);

            var result = All.PS().GetListToViewModel<ProductView>(x => x.Status == true && (!IsInt_pid || x.ProductID == id));

            ViewBag.MyPageList = result.ToPagedList(page, 9);

            return View();
        }

        [ChildActionOnly]
        public ActionResult ProductList()
        {
            return PartialView(All.CS().GetListToViewModel<ProductListView>());
        }
    }
}