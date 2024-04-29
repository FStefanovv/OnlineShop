namespace EFCoreVezba.EmailSender;

using System.Net.Mail;
using System.Net;
using System.Text;

using EFCoreVezba.Model;

public class EmailSender : IEmailSender
    {
        public void SendEmail(string toEmail, string subject, string mailBody)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("fstefanov000@gmail.com", "detelinara13");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("fstefanov000@gmail.com");
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = mailBody;

            client.Send(mailMessage);
        }

        public string GenerateOrderMessage(Order order, bool forUser) {

            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat("<h1>Order info</h1>");
            mailBody.AppendFormat("<br />");
            if(forUser){
                mailBody.AppendFormat("<p>You have successfully ordered {0}</p>", order.Product.Name);
                mailBody.AppendFormat("<p>Order Id: {0}</p>", order.Id); 
                mailBody.AppendFormat("<p>Price per unit: {0}</p>", order.PricePerUnit); 
                mailBody.AppendFormat("<p>Number of units: {0}</p>", order.Quantity); 
                mailBody.AppendFormat("<p>Total price: {0}</p>", order.TotalPrice); 

            }
            else {

            }
            return mailBody.ToString();
        }
    }