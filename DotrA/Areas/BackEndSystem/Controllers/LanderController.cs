using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotrA.Areas.BackEndSystem.Controllers
{
    public class LanderController : Controller
    {
        // GET: BackEndSystem/BackLander
        public ActionResult Login()
        {
            return View();
        }
    }
}