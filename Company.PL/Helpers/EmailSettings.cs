using System.Net.Mail;
using System.Net;

namespace Company.PL.Helpers
{
    public static class EmailSettings
    {
        public static bool SendEmail(Email email)
        {
            // Mail Server : Gmail
            // SMTP Server : smtp.gmail.com
            // Port : 587

            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("ahmedkhattaba221@gmail.com", "gayyscrnrhmghzza");
                client.Send("ahmedkhattaba221@gmail.com", email.To, email.Subject, email.Body);

                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
