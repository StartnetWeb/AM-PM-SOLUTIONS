using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using am_pm_solutions.Entities;
using am_pm_solutions.DAL;
using System.IO;
using am_pm_solutions.Entities.Utilities;

namespace am_pm_solutions.Web.Controllers
{
    public class BolsaTrabajoController : Controller
    {
        private AmPmContext db = new AmPmContext();
        // GET: BolsaTrabajo
        public ActionResult IndexEn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IndexEn([Bind(Include = "Id,Fecha,NombreApellido,Localidad,Provincia,País,Email,NombreArchivoCV,ArchivoCV")] BolsaTrabajo bolsaTrabajo)
        {
            bolsaTrabajo.Fecha = DateTime.Now;
            if (ModelState.IsValid)
            {
                if(bolsaTrabajo.ArchivoCV != null)
                {
                    bolsaTrabajo.NombreArchivoCV = Path.GetFileName(bolsaTrabajo.ArchivoCV.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Content/ArchivosCV"), bolsaTrabajo.NombreArchivoCV);
                    bolsaTrabajo.ArchivoCV.SaveAs(_path);
                }

                db.BolsaTrabajo.Add(bolsaTrabajo);
                db.SaveChanges();

                string to = "javisicardi94@gmail.com";
                string from = "no-reply@w220010.ferozo.com";
                string user = "no-reply@w220010.ferozo.com";
                string password = "holachau";
                string subject = "Mensaje desde la pagina web";
                var emailBody = "Buenas, tiene una nueva bolsa de trabajo en el ContentAdmin de su pagina web. Saludos";

                Email email = new Email();
                email.sendEmail(to, from, user, password, subject, emailBody);

                if (!string.IsNullOrEmpty(bolsaTrabajo.Email))
                {
                    string to2 = bolsaTrabajo.Email;
                    string from2 = "emailprobando5@gmail.com";
                    string user2 = "emailprobando5@gmail.com";
                    string password2 = "holachau";
                    string subject2 = "Gracias por su mensaje";
                    string emailBody2 = "Su mensaje nos ha llegado correctamente. Saludos. <br /> AM-PM SOLUTIONS";

                    Email email2 = new Email();
                    email2.sendEmail(to2, from2, user2, password2, subject2, emailBody2);
                }

                return RedirectToAction("SendCVConfirmedEn");
            }

            return RedirectToAction("IndexEn");
        }

        public ActionResult IndexEs()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IndexEs([Bind(Include = "Id,Fecha,NombreApellido,Localidad,Provincia,País,Email,NombreArchivoCV,ArchivoCV")] BolsaTrabajo bolsaTrabajo)
        {
            bolsaTrabajo.Fecha = DateTime.Now;
            if (ModelState.IsValid)
            {
                if (bolsaTrabajo.ArchivoCV != null)
                {
                    bolsaTrabajo.NombreArchivoCV = Path.GetFileName(bolsaTrabajo.ArchivoCV.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Content/ArchivosCV"), bolsaTrabajo.NombreArchivoCV);
                    bolsaTrabajo.ArchivoCV.SaveAs(_path);
                }

                db.BolsaTrabajo.Add(bolsaTrabajo);
                db.SaveChanges();

                string to = "javisicardi94@gmail.com";
                string from = "no-reply@w220010.ferozo.com";
                string user = "no-reply@w220010.ferozo.com";
                string password = "mo67soGUru";
                string subject = "Mensaje desde la pagina web";
                var emailBody = "Buenas, tiene una nueva bolsa de trabajo en el ContentAdmin de su pagina web. Saludos";

                Email email = new Email();
                email.sendEmail(to, from, user, password, subject, emailBody);

                if (!string.IsNullOrEmpty(bolsaTrabajo.Email))
                {
                    string to2 = bolsaTrabajo.Email;
                    string from2 = "emailprobando5@gmail.com";
                    string user2 = "emailprobando5@gmail.com";
                    string password2 = "mo67soGUru";
                    string subject2 = "Thank you for your message";
                    string emailBody2 = "Thank you for your message, we will answer you shortly. <br /> AM-PM SOLUTIONS";

                    Email email2 = new Email();
                    email2.sendEmail(to2, from2, user2, password2, subject2, emailBody2);
                }

                return RedirectToAction("SendCVConfirmedEs");
            }

            return RedirectToAction("IndexEs");
        } 
        
        public ActionResult SendCVConfirmedEn()
        {
            return View();
        }

        public ActionResult SendCVConfirmedEs()
        {
            return View();
        }

    }
}