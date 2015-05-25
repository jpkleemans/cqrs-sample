using Newtonsoft.Json;
using PensioenSysteem.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Application.AuditLog
{
    class Program
    {
        private static string _auditLogFolder;

        static void Main(string[] args)
        {
            _auditLogFolder = ConfigurationManager.AppSettings["AuditLogFolder"];

            var eventHandler = new RabbitMQDomainEventHandler("127.0.0.1", "cqrs_user", "SeeQueErEs", "PensioenSysteem.AuditLog", HandleEvent);
            eventHandler.Start();

            Console.WriteLine("AuditLog viewer gestart. Druk een toets om te stoppen.");
            Console.ReadKey(true);

            eventHandler.Stop();
        }

        private static bool HandleEvent(string eventType, string eventData)
        {
            string filename = Path.Combine(_auditLogFolder, DateTime.Now.ToString("yyyyMMdd") + ".txt");
            if (!Directory.Exists(_auditLogFolder))
            {
                Directory.CreateDirectory(_auditLogFolder);
            }
            string logEntry = string.Format("{0} - {1} - {2}{3}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), eventType, eventData, Environment.NewLine);
            File.AppendAllText(filename, logEntry);
            Console.WriteLine(logEntry);
            return true;
        }
    }
}
