using DotrA.Controllers;
using DotrA.Filters;
using DotrA_Lab.InternalDataService.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotrA.Areas.BackEndSystem.Controllers
{
    [SecuredOperationFilter(Roles = "admin")]
    public class ImageController : BaseController
    {
        public ImageController(IAllService all) : base(all) { }

        [HttpPost]
        public ActionResult DeleteImage(int id)
        {
            All.IMGS().Delete(x => x.ImageID == id);
            return Content("OK");
        }
    }
}