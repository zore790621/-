using DotrA_Lab.InternalDataService.Implementation;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using Microsoft.Web.Mvc;
using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace DotrA.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUnitOfWork _uof;
        protected IUnitOfWork UOF { get { return _uof; } }

        public BaseController(IUnitOfWork uof) => _uof = uof;

        protected ActionResult RedirectToAction<TController>(Expression<Action<TController>> action) where TController : Controller
        {
            return ControllerExtensions.RedirectToAction(this, action);
        }
    }
}