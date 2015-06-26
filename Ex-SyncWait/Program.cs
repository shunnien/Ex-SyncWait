using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Ex_SyncWait.Interface;

namespace Ex_SyncWait
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Console.WriteLine("====== Ex Start ======");
            new ExC(new Email()).GameStartSave();
            Console.WriteLine("====== Ex End ======");

            Console.WriteLine("====== Ex002 Start ======");
            string content = await MyDownloadPage("http://huan-lin.blogspot.com");
            Console.WriteLine("網頁內容總共為 {0} 個字元。", content.Length);
            Console.WriteLine("====== Ex002 End ======");
            Console.ReadKey();
        }

        static async Task<string> MyDownloadPageAsync(string url)
        {
            var webClient = new WebClient();  // 須引用 System.Net 命名空間。
            var result = webClient.DownloadString(url);
            string content = await result;
            return content;
        }
    }

    public class ExC
    {
        private readonly IEmail _email;
        public ExC(IEmail email)
        {
            this._email = email;
        }

        public void GameStartSave()
        {
            Console.WriteLine("=== method Start ===");
            _email.Client.Host = ConfigurationManager.AppSettings["smtpServer"];
            _email.Client.Port = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]);
            _email.Message.From = new MailAddress(ConfigurationManager.AppSettings["fromEmail"]);
            _email.Message.Subject = ConfigurationManager.AppSettings["Subject"];

            _email.Message.IsBodyHtml = true;
            _email.Message.Body = "test";
            _email.Message.To.Add("test000@gamil");
            Task.Factory.StartNew(() => _email.Send());
        }
    }
}
