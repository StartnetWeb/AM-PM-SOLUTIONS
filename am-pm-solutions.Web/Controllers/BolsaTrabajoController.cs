using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using am_pm_solutions.Entities;
using am_pm_solutions.DAL;
using System.IO;
using am_pm_solutions.Entities.Utilities;
using System.Net;
using Newtonsoft.Json;

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
            CaptchaResponse response = ValidateCaptcha(Request["g-recaptcha-response"]);

            bolsaTrabajo.Fecha = DateTime.Now;
            if (response.Success && ModelState.IsValid)
            {
                if(bolsaTrabajo.ArchivoCV != null)
                {
                    bolsaTrabajo.NombreArchivoCV = Path.GetFileName(bolsaTrabajo.ArchivoCV.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Content/ArchivosCV"), bolsaTrabajo.NombreArchivoCV);
                    bolsaTrabajo.ArchivoCV.SaveAs(_path);
                }

                db.BolsaTrabajo.Add(bolsaTrabajo);
                db.SaveChanges();

                string to = "info@am-pmsolutions.com";
                string from = "no-reply@am-pmsolutions.com";
                string user = "no-reply@am-pmsolutions.com";
                string password = "zQj*HKe4fE";
                string subject = "Mensaje desde la pagina web";
                var emailBody = "Buenas, tiene una nueva bolsa de trabajo en el ContentAdmin de su pagina web. Saludos";

                Email email = new Email();
                email.sendEmail(to, from, user, password, subject, emailBody);

                if (!string.IsNullOrEmpty(bolsaTrabajo.Email))
                {
                    string to2 = bolsaTrabajo.Email;
                    string from2 = "no-reply@am-pmsolutions.com";
                    string user2 = "no-reply@am-pmsolutions.com";
                    string password2 = "zQj*HKe4fE";
                    string subject2 = "Gracias por su mensaje";
                    string emailBody2 = "Thanks a lot for your message! Your CV was sent successfully! <br /> AM-PM SOLUTIONS<br /><br />Please, do not answer this message, it is an automatic sending";

                    Email email2 = new Email();
                    email2.sendEmail(to2, from2, user2, password2, subject2, emailBody2);
                }

                return RedirectToAction("SendCVConfirmedEn");
            }
            else
            {
                return Content("Recaptcha denegado.Bolsa de trabajo no enviada.Error de Google ReCaptcha: " + response.ErrorMessage[0].ToString());
            }

            //return RedirectToAction("IndexEn");
        }

        public ActionResult IndexEs()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IndexEs([Bind(Include = "Id,Fecha,NombreApellido,Localidad,Provincia,País,Email,NombreArchivoCV,ArchivoCV")] BolsaTrabajo bolsaTrabajo)
        {
            CaptchaResponse response = ValidateCaptcha(Request["g-recaptcha-response"]);

            bolsaTrabajo.Fecha = DateTime.Now;
            if (response.Success && ModelState.IsValid)
            {
                if (bolsaTrabajo.ArchivoCV != null)
                {
                    bolsaTrabajo.NombreArchivoCV = Path.GetFileName(bolsaTrabajo.ArchivoCV.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Content/ArchivosCV"), bolsaTrabajo.NombreArchivoCV);
                    bolsaTrabajo.ArchivoCV.SaveAs(_path);
                }

                db.BolsaTrabajo.Add(bolsaTrabajo);
                db.SaveChanges();

                //string to = "info@am-pmsolutions.com";
                string to = "javisicardi94@gmail.com";
                string from = "no-reply@am-pmsolutions.com";
                string user = "no-reply@am-pmsolutions.com";
                string password = "zQj*HKe4fE";
                string subject = "Mensaje desde la pagina web";
                var emailBody = "Buenas, tiene una nueva bolsa de trabajo en el ContentAdmin de su pagina web. Saludos";

                Email email = new Email();
                email.sendEmail(to, from, user, password, subject, emailBody);

                if (!string.IsNullOrEmpty(bolsaTrabajo.Email))
                {
                    string to2 = bolsaTrabajo.Email;
                    string from2 = "no-reply@am-pmsolutions.com";
                    string user2 = "no-reply@am-pmsolutions.com";
                    string password2 = "zQj*HKe4fE";
                    string subject2 = "Thank you for your message";
                    string emailBody2 = "Su mensaje nos ha llegado correctamente. Saludos. <br /> AM-PM SOLUTIONS<br /><br />Por favor, no responda a este mensaje, es un envío automático.";

                    Email email2 = new Email();
                    email2.sendEmail(to2, from2, user2, password2, subject2, emailBody2);
                }

                return RedirectToAction("SendCVConfirmedEs");
            }
            else
            {
                return Content("Recaptcha denegado. Bolsa de trabajo no enviada. Error de Google ReCaptcha : " + response.ErrorMessage[0].ToString());
            }
        } 
        
        public ActionResult SendCVConfirmedEn()
        {
            return View();
        }

        public ActionResult SendCVConfirmedEs()
        {
            return View();
        }

        public static CaptchaResponse ValidateCaptcha(string response)
        {
            string secret = System.Web.Configuration.WebConfigurationManager.AppSettings["recaptchaPrivateKey"];
            var client = new WebClient();
            var jsonResult = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            return JsonConvert.DeserializeObject<CaptchaResponse>(jsonResult.ToString());
        }

    }
}