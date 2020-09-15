using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using am_pm_solutions.Entities;
using am_pm_solutions.Entities.Utilities;
using am_pm_solutions.DAL;

namespace am_pm_solutions.Web.Controllers
{
    public class ContactoController : Controller
    {
        private AmPmContext db = new AmPmContext();
        // GET: Contacto
        public ActionResult IndexEn()
        {
            return View();
        }

        [HttpPost]
        public JsonResult IndexEn([Bind(Include = "Id,FechaContacto,NombreApellido,Telefono,Email,Mensaje,Direccion,Pais")] Contacto contacto)
        {
            contacto.FechaContacto = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Contacto.Add(contacto);
                db.SaveChanges();

                string to = "javisicardi94@gmail.com";
                string from = "emailprobando5@gmail.com";
                string user = "emailprobando5@gmail.com";
                string password = "holachau";
                string subject = "Mensaje desde la pagina web";
                var emailBody = "Fecha: " + contacto.FechaContacto + "<br /> Email: " + contacto.Email + "<br /> Telefono: " + contacto.Telefono + "<br /> Direccion: "+ contacto.Direccion + "<br /> País: " +contacto.Pais + "<br />" + contacto.NombreApellido + " le ha enviado el siguiente mensaje: " + contacto.Mensaje;

                Email email = new Email();
                email.sendEmail(to, from, user, password, subject, emailBody);

                if (!string.IsNullOrEmpty(contacto.Email))
                {
                    string to2 = contacto.Email;
                    string from2 = "emailprobando5@gmail.com";
                    string user2 = "emailprobando5@gmail.com";
                    string password2 = "holachau";
                    string subject2 = "Gracias por su mensaje";
                    string emailBody2 = "Gracias por su mensaje, le contestaremos en breve. <br /> AM-PM SOLUTIONS";

                    Email email2 = new Email();
                    email2.sendEmail(to2, from2, user2, password2, subject2, emailBody2);
                }

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IndexEs()
        {
            return View();
        }

        [HttpPost]
        public JsonResult IndexEs([Bind(Include = "Id,FechaContacto,NombreApellido,Telefono,Email,Mensaje,Direccion,Pais")] Contacto contacto)
        {
            contacto.FechaContacto = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Contacto.Add(contacto);
                db.SaveChanges();

                string to = "javisicardi94@gmail.com";
                string from = "emailprobando5@gmail.com";
                string user = "emailprobando5@gmail.com";
                string password = "holachau";
                string subject = "Mensaje desde la pagina web";
                var emailBody = "Fecha: " + contacto.FechaContacto + "<br /> Email: " + contacto.Email + "<br /> Telefono: " + contacto.Telefono + "<br /> Direccion: " + contacto.Direccion + "<br /> País: " + contacto.Pais + "<br />" + contacto.NombreApellido + " le ha enviado el siguiente mensaje: " + contacto.Mensaje;

                Email email = new Email();
                email.sendEmail(to, from, user, password, subject, emailBody);

                if (!string.IsNullOrEmpty(contacto.Email))
                {
                    string to2 = contacto.Email;
                    string from2 = "emailprobando5@gmail.com";
                    string user2 = "emailprobando5@gmail.com";
                    string password2 = "holachau";
                    string subject2 = "Gracias por su mensaje";
                    string emailBody2 = "Gracias por su mensaje, le contestaremos en breve. <br /> AM-PM SOLUTIONS";

                    Email email2 = new Email();
                    email2.sendEmail(to2, from2, user2, password2, subject2, emailBody2);
                }

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}
