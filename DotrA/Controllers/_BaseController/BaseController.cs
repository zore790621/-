using DotrA_Lab.InternalDataService.Implementation;
using Microsoft.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace DotrA.Controllers
{
    public class BaseController : Controller
    {
        private readonly IAdminRepository _adminrepo;

        public BaseController(IAdminRepository adminrepo)
        {
            _adminrepo = adminrepo;
        }

        protected ActionResult RedirectToAction<TController>(Expression<Action<TController>> action) where TController : Controller
        {
            return ControllerExtensions.RedirectToAction(this, action);
        }
    }
}