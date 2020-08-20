using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace am_pm_solutions.Web.Areas.ContentAdmin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: ContentAdmin/HomeAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}