using Application.Interfaces.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Email
{
    public class SMTPEmailSender : IEmailSender
    {
        public void Send(SendEmailDto sendEmail)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("jdoe88005@gmail.com", "'_e8$.vn@!2}fSN7")
            };

            var message = new MailMessage("jdoe88005@gmail.com", sendEmail.SendTo);
            message.Subject = sendEmail.Subject;
            message.Body = sendEmail.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);


        }
    }
}
