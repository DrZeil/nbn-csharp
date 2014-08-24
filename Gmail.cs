/*
Author:  Marek Bar 33808
Contact: marekbar1985@gmail.com
Wyższa Szkoła Informatyki i Zarządzania w Rzeszowie
 */
using LearnByError;
namespace LearnByErrorLibrary
{
    /// <summary>
    /// Sending mails from gmail account
    /// </summary>
    public class Gmail
    {
        /// <summary>
        /// Sender mail address object
        /// </summary>
        public System.String MailAddress { get; set; }

        /// <summary>
        /// Receiver mail address object
        /// </summary>
        public System.String MailAddressName { get; set;}

        /// <summary>
        /// Sender gmail login
        /// </summary>
        public System.String Login { get; set; }

        /// <summary>
        /// Sender gmail password
        /// </summary>
        public System.String Password { get; set; }

        /// <summary>
        /// Sender mail address
        /// </summary>
        public System.String From { get; set; }

        /// <summary>
        /// Sender mail name
        /// </summary>
        public System.String FromName {get; set; }

        /// <summary>
        /// Mail message
        /// </summary>
        public System.String Message { get; set; }

        /// <summary>
        /// Mail subject
        /// </summary>
        public System.String Subject { get; set; }

        /// <summary>
        /// Send mail
        /// </summary>
        public void send()
        {
            
            var fromAddress = new System.Net.Mail.MailAddress(From, FromName );
            var toAddress = new System.Net.Mail.MailAddress(MailAddress, MailAddressName);

            var smtp = new System.Net.Mail.SmtpClient
               {
                   Host = "smtp.gmail.com",
                   Port = 587,
                   EnableSsl = true,
                   DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                   UseDefaultCredentials = false,
                   Credentials = new System.Net.NetworkCredential(fromAddress.Address, Password)
               };
                
            using (var message = new System.Net.Mail.MailMessage(fromAddress, toAddress)
            {
                Subject = Subject,
                Body = Message
            })
            {
                smtp.Send(message);
            }
     }

        /// <summary>
        /// Send simple message
        /// </summary>
        /// <param name="subject">String - message subject</param>
        /// <param name="message">String - message</param>
        /// <param name="address">String - receiver</param>
        public static void Send(string subject, string message, string address)
        {
            try
            {
                Gmail mail = new Gmail();
                mail.Login = "nbn.neural.network";
                mail.Password = "qqlka123";
                mail.Subject = subject;
                mail.MailAddress = address;                
                mail.From = "nbn.neural.network@gmail.com";
                mail.FromName = LearnByError.Internazional.Resource.Inst.Get("r38");

                mail.Message = message;
                
                mail.send();
            }
            catch (System.Exception ex)
            {
                ex.ToLog();
            }
        }
  }
}
