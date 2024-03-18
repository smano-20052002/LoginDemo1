using System.Net;
using System.Net.Mail;
using System.Net.Mime;
namespace LoginDemo1.OtherOperation
{
    public static class EmailGenerator
    {
        public static bool SendEmail(string Username,string Mail,string Password)
        {

            string fromMail = "smano8312@gmail.com";
            string senderPass = "mktt mzmx pasy gdgl";
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.To.Add(Mail);
            message.Subject = $"Confidential! New Password for Your {Mail} Accounts";
            
            message.Body = $"Dear {Username},\r\n\r\nThis is a notification from the management. Your new password for {Mail} accounts has been generated. Please take a moment to update your password.\r\n\r\nNew Password: {Password}\r\n\r\nRemember to change your password promptly for security reasons.\r\n\r\nThank you, Management Team";

       
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(fromMail, senderPass);
            smtpClient.EnableSsl = true;
            try
            {
                smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
          

        }
    }
}
