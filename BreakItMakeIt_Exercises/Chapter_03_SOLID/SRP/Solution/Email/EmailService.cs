using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BreakItMakeIt_Exercises.Chapter_03_SRP.SRP.Solution.Email
{

    public interface IEmailService
    {
        void Send(string toEmail, string subject, string body);
    }

    public class SmtpEmailService : IEmailService
    {
        public void Send(string toEmail, string subject, string body)
        {
            using var mail = new MailMessage("noreply@example.com", toEmail, subject, body);
            using var smtp = new SmtpClient("smtp.yourserver.com")
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential("username", "password"),
                EnableSsl = true
            };
            smtp.Send(mail);
        }
    }

}
