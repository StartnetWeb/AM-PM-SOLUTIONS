using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace am_pm_solutions.Web.Controllers
{
    public class BolsaTrabajoController : Controller
    {
        // GET: BolsaTrabajo
        public ActionResult IndexEn()
        {
            return View();
        }

        public ActionResult IndexEs()
        {
            return View();
        }
    }
}