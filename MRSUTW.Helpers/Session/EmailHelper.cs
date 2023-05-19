using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.Helpers.Session
{
    public class EmailHelper
    {
        public void SendEmail(string toEmail, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("utmconnect1@gmail.com", "nwbeyieroxsnsban"),
                EnableSsl = true,
            };

            smtpClient.Send("utmconnect1@gmail.com", toEmail, subject, body);
        }
    }
}
