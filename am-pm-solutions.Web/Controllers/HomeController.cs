using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace am_pm_solutions.Web.Controllers
{
    public class HomeController : Controller
    {
        //CONTROLADORES DE VISTAS EN INGLES
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CompanyEn()
        {
            return View();
        }

        public ActionResult ServicesEn()
        {
            return View();
        }

        public ActionResult ServicesProjectMangementEn()
        {
            return View();
        }

        public ActionResult ServicesConsultancyEn()
        {
            return View();
        }

        public ActionResult IndustriesEn()
        {
            return View();
        }

        public ActionResult IndustriesGeneralEn()
        {
            return View();
        }

        public ActionResult IndustriesTraslationEn()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}