using DotrA.Service.Json;
using DotrA_Lab.InternalDataService.Implementation;
using DotrA_Lab.ORM.UnitOfWorkPattern;
using System.Collections.Generic;
using System.Web.Http;

namespace DotrA.Controllers
{
    public class ValuesController : BaseApiController
    {
        public ValuesController(IUnitOfWork uof, ICategoryService cs, IMemberService ms, IOrderService os, IOrderDetailService ods, IPaymentService pay, IProductService ps, IShipperService ships, ISupplierService sups) : base(uof, cs, ms, os, ods, pay, ps, ships, sups)
        {
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public CoreJsonResult Get([FromBody]object viewModel)
        {
            if (!ModelState.IsValid)
            {
                return JsonValidationError();
            }

            if (viewModel == null)
            {
                return JsonError("Id不能是空");
            }

            // 如果需要以Json格式返回viewModel的時候
            return JsonSuccess(viewModel);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
