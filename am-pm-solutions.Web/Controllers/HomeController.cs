using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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

        //CONTROLADORES DE VISTAS EN ESPAÑOL
        public ActionResult IndexEs()
        {
            return View();
        }

        public ActionResult CompanyEs()
        {
            return View();
        }

        public ActionResult ServicesEs()
        {
            return View();
        }

        public ActionResult ServicesProjectMangementEs()
        {
            return View();
        }

        public ActionResult ServicesConsultancyEs()
        {
            return View();
        }

        public ActionResult IndustriesEs()
        {
            return View();
        }

        public ActionResult IndustriesGeneralEs()
        {
            return View();
        }

        public ActionResult IndustriesTraslationEs()
        {
            return View();
        }

        public ActionResult ExportarOdontogramas()
        {
            #region Headers
            var re = Request;
            var headers = re.Headers;
            string authorizationHeader = "";

            //Request.Headers.GetValues("authorization");
            try
            {
                authorizationHeader = headers.GetValues("authorization").First();
            }
            catch (Exception e)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            #endregion
            //Prueba 
            //Produccion ewogICAgIlVzZXIiOiAiQ0FNSSAtIEFTT0MuTVVULkNFTlRSTyBNRURJQ08gU0FOIEZDTy4iLAogICAgIklkIjoiMTI0IiwKICAgICJBY3Rpb24iOiAiR2V0T2RvbnRvZ3JhbWFzIiwKICAgICJTZWNyZXQiOiAiYUhSMGNEb3ZMMjlrYjI1MGIzQnlaWE11WTI5dExtRnlMdz09Igp9
            if (authorizationHeader == "ewogICAgIlVzZXIiOiAiQ0FNSSAtIEFTT0MuTVVULkNFTlRSTyBNRURJQ08gU0FOIEZDTy4iLAogICAgIklkIjoiMTI0IiwKICAgICJBY3Rpb24iOiAiR2V0T2RvbnRvZ3JhbWFzUHJ1ZWJhIiwKICAgICJTZWNyZXQiOiAiYUhSMGNEb3ZMMjlrYjI1MGIzQnlaWE11WTI5dExtRnlMMUJ5ZFdWaVlRPT0iCn0=")
            {
                string path = Server.MapPath("~/Areas/ContentAdmin/Content/ListadoOdontogramas/ListadoOdontograma.txt");
                return File(path, "text/plain", "ListadoOdontograma.txt");
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
    }
}