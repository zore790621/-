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
        private readonly IUnitOfWork _uof;
        private readonly ICategoryService _cs;
        private readonly IMemberService _ms;
        private readonly IMemberRoloService _mrs;
        private readonly IOrderService _os;
        private readonly IOrderDetailService _ods;
        private readonly IPaymentService _pays;
        private readonly IProductService _ps;
        private readonly IShipperService _ships;
        private readonly ISupplierService _sups;
        protected IUnitOfWork UOF { get { return _uof; } }
        protected ICategoryService CS { get { return _cs; } }
        protected IMemberService MS { get { return _ms; } }
        protected IMemberRoloService MRS { get { return _mrs; } }
        protected IOrderService OS { get { return _os; } }
        protected IOrderDetailService ODS { get { return _ods; } }
        protected IPaymentService PAYS { get { return _pays; } }
        protected IProductService PS { get { return _ps; } }
        protected IShipperService SHIPS { get { return _ships; } }
        protected ISupplierService SUPS { get { return _sups; } }
        public BaseController(
            IUnitOfWork uof, ICategoryService cs,
            IMemberService ms, IMemberRoloService mrs,
            IOrderService os, IOrderDetailService ods,
            IPaymentService pay, IProductService ps,
            IShipperService ships, ISupplierService sups
            )
        {
            this._uof = uof; this._cs = cs;
            this._ms = ms; this._mrs = mrs;
            this._os = os; this._ods = ods;
            this._pays = pay; this._ps = ps;
            this._ships = ships; this._sups = sups;
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