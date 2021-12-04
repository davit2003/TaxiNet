using MailKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Security;
using TaxiNet.DataLayer;
using MimeKit;

namespace TaxiNet.Services
{
    public static class MailService
    {
        public static void SendMail(Email email)
        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress(email.Name, email.EmailAddress));
            mailMessage.To.Add(new MailboxAddress("Davit Berulava", "davitberulava2003@gmail.com"));
            mailMessage.Subject = "Subject";
            mailMessage.Body = new TextPart("plain")
            {
                Text = email.Text.Trim().ToString()
            };

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 587);
                smtpClient.Authenticate("santapanta95@gmail.com", "SantaDeveloper321");
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
            }
        }
    }
}
