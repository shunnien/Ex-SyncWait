using System.Net.Mail;

namespace Ex_SyncWait.Interface
{
    public interface IEmail
    {
        //string SmtpServer { get; set; }
        //int SmtpPort { get; set; }
        //MailAddress FromEmail { get; set; }
        //string ToEmail { get; set; }
        //string Subject { get; set; }
        //string Body { get; set; }
        //string UserName { get; set; }
        //string Passwork { get; set; }
        //void Send();

        MailMessage Message { get; set; }
        SmtpClient Client { get; set; }
        void Send();
    }
}