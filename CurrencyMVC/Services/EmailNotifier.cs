using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CurrencyProj.Services
{
    public class EmailNotifier : IEmailNotifier
    {
        public void MailSender(string body)
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = 25;
            sc.Host = "mail.pulver.com.tr";
            sc.EnableSsl = false;

            sc.Credentials = new System.Net.NetworkCredential("kur@pulver.com.tr", "pulver1234");

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("noreply_pulverkur@pulver.com.tr", "Haktan Dneme");

            mail.To.Add("Haktan.Bicer@pulver.com.tr");
            
            mail.Subject = "Saatlik Kur Bilgileri"; mail.IsBodyHtml = true; mail.Body = body;



            sc.Send(mail);
        }
    }
}
