namespace EFCoreVezba.EmailSender;

using EFCoreVezba.Model;

public interface IEmailSender
{
    void SendEmail(string toEmail, string subject, string mailBody);
    string GenerateOrderMessage(Order order, bool forUser);
}