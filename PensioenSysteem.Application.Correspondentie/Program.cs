using Dapper;
using Newtonsoft.Json;
using PensioenSysteem.Application.Correspondentie.Model;
using PensioenSysteem.Domain.Deelnemer.Events;
using PensioenSysteem.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Application.Correspondentie
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventHandler = new RabbitMQDomainEventHandler("127.0.0.1", "cqrs_user", "SeeQueErEs", "PensioenSysteem.Correspondentie", HandleEvent);
            eventHandler.Start();

            Console.WriteLine("Correspondentie service gestart. Druk een toets om te stoppen.");
            Console.ReadKey(true);

            eventHandler.Stop();
        }

        private static bool HandleEvent(string eventType, string eventData)
        {
            bool handled = true;
            switch (eventType)
            {
                case "DeelnemerGeregistreerd":
                    DeelnemerGeregistreerd deelnemerGeregistreerd = JsonConvert.DeserializeObject<DeelnemerGeregistreerd>(eventData);
                    handled = Handle(deelnemerGeregistreerd);
                    break;
                case "DeelnemerVerhuisd":
                    DeelnemerVerhuisd deelnemerVerhuisd = JsonConvert.DeserializeObject<DeelnemerVerhuisd>(eventData);
                    handled = Handle(deelnemerVerhuisd);
                    break;
            }

            return handled;
        }

        private static bool Handle(DeelnemerGeregistreerd deelnemerGeregistreerd)
        {
            DeelnemerRepository.RegistreerDeelnemer(deelnemerGeregistreerd);

            Console.WriteLine("Deelnemer {0} geregistreerd", deelnemerGeregistreerd.Naam);

            return true;
        }

        private static bool Handle(DeelnemerVerhuisd deelnemerVerhuisd)
        {
            // deelnemer gegevens ophalen
            Deelnemer deelnemer = RaadpleegDeelnemer(deelnemerVerhuisd.Id);
            if (deelnemer == null)
            {
                Console.WriteLine("Deelnemer met id '{0}' niet gevonden", deelnemerVerhuisd.Id);
                return false; // deelnemer niet gevonden, event niet als afgehandeld markeren
            }

            // brief genereren
            Verhuisbrief.Genereer(deelnemer, deelnemerVerhuisd);

            Console.WriteLine("Brief inzake verhuizing verstuurd naar deelnemer {0}", deelnemer.Naam);

            return true;
        }

        private static Deelnemer RaadpleegDeelnemer(Guid id)
        {
            Deelnemer deelnemer;

            // kijk eest in de local cache
            deelnemer = DeelnemerRepository.RaadpleegDeelnemer(id);

            // als niet gevonden in local cache: 
            // roep Deelnemer API aan om de deelnemer op te halen 
            if (deelnemer == null)
            {
                deelnemer = RaadpleegDeelnemerUitService(id);
                if (deelnemer != null)
                {
                    // sla op in de local cache
                    DeelnemerRepository.RegistreerDeelnemer(deelnemer);
                }
            }

            return deelnemer;
        }

        private static Deelnemer RaadpleegDeelnemerUitService(Guid id)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://localhost:29713"); // TODO: make location transparent
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.GetAsync("/api/deelnemer/" + id.ToString("D")).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var deelnemerJson = response.Content.ReadAsStringAsync().Result;
                        var deelnemer = JsonConvert.DeserializeObject<Deelnemer>(deelnemerJson);
                        return deelnemer;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fout bij raadplegen deelnemer: {0}", ex.Message);
                }
            }

            return null;
        }
    }
}
