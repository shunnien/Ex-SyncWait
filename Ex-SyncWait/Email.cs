using Ex_SyncWait.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Ex_SyncWait
{
    public class Email : IEmail
    {
        public MailMessage Message { get; set; }
        public SmtpClient Client { get; set; }

        public Email()
        {
            Message = new MailMessage();
            Client = new SmtpClient()
            {
                Port = 25
            };
        }

        public void Send()
        {
            if (Message.To.Any())
            {
                Client.SendMailAsync(Message);
                Console.WriteLine("send complete!!!");
            }
                
        }
    }
}
