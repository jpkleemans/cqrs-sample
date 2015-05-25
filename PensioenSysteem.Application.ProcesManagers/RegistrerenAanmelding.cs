using Newtonsoft.Json;
using PensioenSysteem.Application.ProcesManagers.Commands;
using PensioenSysteem.Domain.Core;
using PensioenSysteem.Domain.Arbeidsverhouding.Commands;
using PensioenSysteem.Domain.Arbeidsverhouding.Events;
using PensioenSysteem.Domain.Deelnemer.Commands;
using PensioenSysteem.Domain.Deelnemer.Events;
using PensioenSysteem.Domain.Werkgever.Commands;
using PensioenSysteem.Domain.Werkgever.Events;
using PensioenSysteem.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;

namespace PensioenSysteem.Application.ProcesManagers
{
    public class RegistrerenAanmelding
    {
        private class ProcesState
        {
            public Guid CorrelationId { get; set; }
            public RegistreerAanmeldingCommand InitierendCommand { get; set; }
            public string Status { get; set; }
            public string DeelnemerNummer { get; set; }
            public string WerkgeverNummer { get; set; }
            public DateTime StartTijdstip { get; set; }
            public string Foutmelding { get; set; }
        }

        private RabbitMQDomainEventHandler _eventHandler;

        public void Start()
        {
            // start de eventhandler om de events die binnen dit proces een rol spelen op te vangen
            _eventHandler = new RabbitMQDomainEventHandler("127.0.0.1", "cqrs_user", "SeeQueErEs", "PensioenSysteem.RegistreerAanmelding", HandleEvent);
            _eventHandler.Start();
        }

        public void Stop()
        {
            _eventHandler.Stop();
        }

        public void RegistreerAanmelding(RegistreerAanmeldingCommand command)
        {
            // registreer een nieuwe instantie van het RegistreerAanmelding proces 
            ProcesState state = new ProcesState
            {
                CorrelationId = command.CorrelationId,
                InitierendCommand = command,
                DeelnemerNummer = null,
                WerkgeverNummer = null,
                StartTijdstip = DateTime.Now,
                Status = "Actief"
            };
            RegistreerProcesStart(state);

            // controleer aanwezigheid deelnemer
            // TODO

            try
            {
                // registreer de werknemer als deelnemer
                WerknemerGegevens gegevens = command.WerknemerGegevens;
                RegistreerDeelnemerCommand registreerDeelnemerCommand = new RegistreerDeelnemerCommand
                {
                    CorrelationId = command.CorrelationId,
                    Id = gegevens.Id,
                    Version = 0,
                    Naam = gegevens.Naam,
                    EmailAdres = gegevens.EmailAdres,
                    Straat = gegevens.Straat,
                    Huisnummer = gegevens.Huisnummer,
                    HuisnummerToevoeging = gegevens.HuisnummerToevoeging,
                    Postcode = gegevens.Postcode,
                    Plaats = gegevens.Plaats
                };
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:29713");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync("/api/deelnemer", registreerDeelnemerCommand).Result;
                }
            }
            catch (Exception ex)
            {
                state.Status = "Fout";
                state.Foutmelding = ex.ToString();
                UpdateProcesState(state);
            }
        }

        private bool HandleEvent(string eventType, string eventData)
        {
            bool handled = false;
            switch (eventType)
            {
                case "DeelnemerGeregistreerd":
                    DeelnemerGeregistreerd deelnemerGeregistreerd = JsonConvert.DeserializeObject<DeelnemerGeregistreerd>(eventData);
                    handled = Handle(deelnemerGeregistreerd);
                    break;
                case "WerkgeverGeregistreerd":
                    WerkgeverGeregistreerd werkgeverGeregistreerd = JsonConvert.DeserializeObject<WerkgeverGeregistreerd>(eventData);
                    handled = Handle(werkgeverGeregistreerd);
                    break;
                case "ArbeidsverhoudingGeregistreerd":
                    ArbeidsverhoudingGeregistreerd arbeidsverhoudingGeregistreerd = JsonConvert.DeserializeObject<ArbeidsverhoudingGeregistreerd>(eventData);
                    handled = Handle(arbeidsverhoudingGeregistreerd);
                    break;
                default:
                    return false;
            }

            return handled;
        }

        private bool Handle(DeelnemerGeregistreerd e)
        {
            // zoek de bijbehorende instantie van het RegistreerAanmelding proces 
            ProcesState state = RaadpleegProcesState(e.CorrelationId);
            if (state == null)
            {
                return false;
            }

            // als de deelnemer al bekend is, beschouw het event als afgehandeld (idempotentie)
            if (!string.IsNullOrEmpty(state.DeelnemerNummer))
            {
                return true;
            }

            // werk het deelnemernummer bij
            state.DeelnemerNummer = e.Nummer;
            UpdateProcesState(state);

            // controleer aanwezigheid werkgever
            // TODO

            try {
                // registreer de werkgever
                WerkgeverGegevens gegevens = state.InitierendCommand.WerkgeverGegevens;
                RegistreerWerkgeverCommand registreerWerkgeverCommand = new RegistreerWerkgeverCommand
                {
                    CorrelationId = e.CorrelationId,
                    Id = gegevens.Id,
                    Version = 0,
                    BedrijfsNaam = gegevens.BedrijfsNaam,
                    NaamContactPersoon = gegevens.NaamContactPersoon,
                    EmailAdres = gegevens.EmailAdres,
                    Straat = gegevens.Straat,
                    Huisnummer = gegevens.Huisnummer,
                    HuisnummerToevoeging = gegevens.HuisnummerToevoeging,
                    Postcode = gegevens.Postcode,
                    Plaats = gegevens.Plaats
                };
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:24275");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync("/api/werkgever", registreerWerkgeverCommand).Result;
                }
            }
            catch (Exception ex)
            {
                state.Status = "Fout";
                state.Foutmelding = ex.ToString();
                UpdateProcesState(state);
                return false;
            }

            return true;
        }

        private bool Handle(WerkgeverGeregistreerd e)
        {
            // zoek de bijbehorende instantie van het RegistreerAanmelding proces 
            ProcesState state = RaadpleegProcesState(e.CorrelationId);
            if (state == null)
            {
                return false;
            }

            // als de werkgever al bekend is, beschouw het event als afgehandeld (idempotentie)
            if (!string.IsNullOrEmpty(state.WerkgeverNummer))
            {
                return true;
            }

            // werk het werkgevernummer bij
            state.WerkgeverNummer = e.Nummer;
            UpdateProcesState(state);

            try
            {
                // registreer de arbeidsverhouding
                RegistreerArbeidsverhoudingCommand registreerArbeidsverhoudingCommand = new RegistreerArbeidsverhoudingCommand
                {
                    CorrelationId = e.CorrelationId,
                    Id = Guid.NewGuid(),
                    Version = 0,
                    DeelnemerNummer = state.DeelnemerNummer,
                    WerkgeverNummer = state.WerkgeverNummer,
                    Ingangsdatum = state.InitierendCommand.IngangsDatum,
                    EindDatum = state.InitierendCommand.EindDatum
                };
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:24693");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync("/api/arbeidsverhouding", registreerArbeidsverhoudingCommand).Result;
                }
            }
            catch (Exception ex)
            {
                state.Status = "Fout";
                state.Foutmelding = ex.ToString();
                UpdateProcesState(state);
                return false;
            }

            return true;
        }

        private bool Handle(ArbeidsverhoudingGeregistreerd e)
        {
            // zoek de bijbehorende instantie van het RegistreerAanmelding proces 
            ProcesState state = RaadpleegProcesState(e.CorrelationId);
            if (state == null)
            {
                return false;
            }

            // TODO: einde proces melden aan DWS

            // proces administratie bijwerken
            state.Status = "Afgerond";
            UpdateProcesState(state);

            return true;
        }

        private void RegistreerProcesStart(ProcesState state)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProcesManagement"].ConnectionString))
            {
                string commandText = @"
                    INSERT INTO [dbo].[RegistrerenAanmelding]
                               ([CorrelationId]
                               ,[InitierendCommand]
                               ,[DeelnemerNummer]
                               ,[WerkgeverNummer]
                               ,[StartTijdstip]
                               ,[Status])
                         VALUES
                               (@CorrelationId
                               ,@InitierendCommand
                               ,@DeelnemerNummer
                               ,@WerkgeverNummer
                               ,@StartTijdstip
                               ,@Status)";

                dynamic parameters = new 
                {
                    CorrelationId = state.CorrelationId,
                    InitierendCommand = JsonConvert.SerializeObject(state.InitierendCommand),
                    DeelnemerNummer = state.DeelnemerNummer,
                    WerkgeverNummer = state.WerkgeverNummer,
                    Status = state.Status,
                    StartTijdstip = state.StartTijdstip
                };
                CommandDefinition cmd = new CommandDefinition(commandText, parameters);
                connection.Execute(cmd);
            }
        }

        private ProcesState RaadpleegProcesState(Guid correlationId)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProcesManagement"].ConnectionString))
            {
                string commandText = @"
                    SELECT *
                    FROM   [RegistrerenAanmelding]
                    WHERE  [CorrelationId] = @CorrelationId";
                dynamic state = connection.Query(commandText, new { CorrelationId = correlationId }).FirstOrDefault();
                if (state != null)
                {
                    return new ProcesState
                    {
                        CorrelationId = state.CorrelationId,
                        InitierendCommand = JsonConvert.DeserializeObject<RegistreerAanmeldingCommand>(state.InitierendCommand),
                        Status = state.Status,
                        DeelnemerNummer = state.DeelnemerNummer,
                        WerkgeverNummer = state.WerkgeverNummer,
                        StartTijdstip = state.StartTijdstip,
                        Foutmelding = state.Foutmelding
                    };
                }
            }

            return null;
        }

        private void UpdateProcesState(ProcesState state)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProcesManagement"].ConnectionString))
            {
                string commandText = @"
                    UPDATE [dbo].[RegistrerenAanmelding]
                       SET [DeelnemerNummer] = @DeelnemerNummer
                          ,[WerkgeverNummer] = @WerkgeverNummer
                          ,[Status] = @Status
                          ,[Foutmelding] = @Foutmelding
                     WHERE [CorrelationId] = @CorrelationId";
                CommandDefinition cmd = new CommandDefinition(commandText, state);
                connection.Execute(cmd);
            }
        }
    }
}
