using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using am_pm_solutions.Entities;
using am_pm_solutions.Entities.Utilities;
using am_pm_solutions.DAL;
using System.Net;
using Newtonsoft.Json;

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

                //string to = "info@am-pmsolutions.com";
                string to = "javisicardi94@gmail.com";
                string from = "no-reply@am-pmsolutions.com";
                string user = "no-reply@am-pmsolutions.com";
                string password = "zQj*HKe4fE";
                string subject = "Mensaje desde la pagina web";
                var emailBody = "Fecha: " + contacto.FechaContacto + "<br /> Email: " + contacto.Email + "<br /> Telefono: " + contacto.Telefono + "<br /> Direccion: "+ contacto.Direccion + "<br /> País: " +contacto.Pais + "<br />" + contacto.NombreApellido + " le ha enviado el siguiente mensaje: " + contacto.Mensaje;

                Email email = new Email();
                email.sendEmail(to, from, user, password, subject, emailBody);

                if (!string.IsNullOrEmpty(contacto.Email))
                {
                    string to2 = contacto.Email;
                    string from2 = "no-reply@am-pmsolutions.com";
                    string user2 = "no-reply@am-pmsolutions.com";
                    string password2 = "zQj*HKe4fE";
                    string subject2 = "Thank you for your message";
                    string emailBody2 = "Thanks for contacting us; we will reply to you shortly <br /> AM-PM SOLUTIONS<br /><br />Please, do not answer this message, it is an automatic sending";

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

                string to = "info@am-pmsolutions.com";
                string from = "no-reply@am-pmsolutions.com";
                string user = "no-reply@am-pmsolutions.com";
                string password = "zQj*HKe4fE";
                string subject = "Mensaje desde la pagina web";
                var emailBody = "Fecha: " + contacto.FechaContacto + "<br /> Email: " + contacto.Email + "<br /> Telefono: " + contacto.Telefono + "<br /> Direccion: " + contacto.Direccion + "<br /> País: " + contacto.Pais + "<br />" + contacto.NombreApellido + " le ha enviado el siguiente mensaje: " + contacto.Mensaje;

                Email email = new Email();
                email.sendEmail(to, from, user, password, subject, emailBody);

                if (!string.IsNullOrEmpty(contacto.Email))
                {
                    string to2 = contacto.Email;
                    string from2 = "no-reply@am-pmsolutions.com";
                    string user2 = "no-reply@am-pmsolutions.com";
                    string password2 = "zQj*HKe4fE";
                    string subject2 = "Gracias por su mensaje";
                    string emailBody2 = "Gracias por su mensaje, le contestaremos en breve. <br /> AM-PM SOLUTIONS<br /><br />Por favor, no responda a este mensaje, es un envío automático.";

                    Email email2 = new Email();
                    email2.sendEmail(to2, from2, user2, password2, subject2, emailBody2);
                }

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        
        //public static CaptchaResponse ValidateCaptcha(string response)
        //{
        //    string secret = System.Web.Configuration.WebConfigurationManager.AppSettings["recaptchaPrivateKey"];
        //    var client = new WebClient();
        //    var jsonResult = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
        //    return JsonConvert.DeserializeObject<CaptchaResponse>(jsonResult.ToString());
        //}
    }
}
