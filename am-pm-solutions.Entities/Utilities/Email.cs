using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace am_pm_solutions.Entities.Utilities
{
    public class Email
    {
        private string smtpServer;
        private int smtpPort;
        private bool smtpCredentials;
        private bool enableSsl;

        public Email()
        {
            smtpServer = "smtp.gmail.com";
            smtpPort = 587;
            smtpCredentials = true;
            enableSsl = true;
        }

        public string sendEmail(string to, string from, string user, string password, string subject, string emailBody)
        {
            try
            {
                WebMail.SmtpServer = smtpServer;
                WebMail.SmtpPort = smtpPort;
                WebMail.SmtpUseDefaultCredentials = smtpCredentials;
                WebMail.EnableSsl = enableSsl;
                WebMail.UserName = user;
                WebMail.Password = password;
                WebMail.From = from;
                WebMail.Send(to, subject: subject, body: emailBody, isBodyHtml: true);

                return "Enviado correctamente";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }

        }
    }
}
