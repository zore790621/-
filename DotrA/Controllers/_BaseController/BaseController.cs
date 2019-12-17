using DotrA.Service.Json;
using DotrA_Lab.InternalDataService.Implementation;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using Microsoft.Web.Mvc;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace DotrA.Controllers
{
    public class BaseController : Controller
    {
        private readonly IAllService _all;
        protected IAllService All { get { return _all; } }
        public BaseController(
            IAllService all
            )
        {
            this._all = all;
        }
        protected CoreJsonResult JsonValidationError()
        {
            var result = new CoreJsonResult();

            foreach (var validationError in
                    ModelState.Values.SelectMany(v => v.Errors))
            {
                result.AddError(validationError.ErrorMessage);
            }

            return result;
        }

        protected CoreJsonResult JsonError(string errorMessage)
        {
            var result = new CoreJsonResult();

            result.AddError(errorMessage);

            return result;
        }
        protected CoreJsonResult<T> JsonSuccess<T>(T data)
        {
            return new CoreJsonResult<T> { Data = data };
        }

        protected ActionResult RedirectToAction<TController>(Expression<Action<TController>> action) where TController : Controller
        {
            return ControllerExtensions.RedirectToAction(this, action);
        }
    }
}