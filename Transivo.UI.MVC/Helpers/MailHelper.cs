using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Transivo.UI.MVC.Helpers
{
    public class MailHelper
    {
        public static bool SendMail(string mailAddress, Guid code)
        {
            MailAddress from = new MailAddress("transivotransportation@gmail.com");
            MailAddress to = new MailAddress(mailAddress);

            MailMessage mailMassage = new MailMessage();
            mailMassage.From = from;
            mailMassage.To.Add(to);
            mailMassage.Subject = "Transivo Üyelik Aktivasyon";
            mailMassage.Body = string.Format("<a href='http://localhost:50137//Account/Activate?code={0}'> Aktivasyon için tıklayınız</a>", code);
            mailMassage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(from.Address, "Transivo123");
            smtpClient.EnableSsl = true;

            bool result = false;
            try
            {
                smtpClient.Send(mailMassage);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
    }
}