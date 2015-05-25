using Dapper;
using PensioenSysteem.Application.Correspondentie.Model;
using PensioenSysteem.Domain.Deelnemer.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Application.Correspondentie
{
    static class DeelnemerRepository
    {
        public static void RegistreerDeelnemer(DeelnemerGeregistreerd deelnemerGeregistreerd)
        {
            Deelnemer deelnemer = new Deelnemer
            {
                Id = deelnemerGeregistreerd.Id,
                Nummer = deelnemerGeregistreerd.Nummer,
                Naam = deelnemerGeregistreerd.Naam,
                EmailAdres = deelnemerGeregistreerd.EmailAdres,
                Straat = deelnemerGeregistreerd.Straat,
                Huisnummer = deelnemerGeregistreerd.Huisnummer,
                HuisnummerToevoeging = deelnemerGeregistreerd.HuisnummerToevoeging,
                Postcode = deelnemerGeregistreerd.Postcode,
                Plaats = deelnemerGeregistreerd.Plaats
            };

            RegistreerDeelnemer(deelnemer);
        }

        public static void RegistreerDeelnemer(Deelnemer deelnemer)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Correspondentie"].ConnectionString))
            {
                string commandText = @"
                    INSERT INTO [dbo].[Deelnemer] ([Id], [Nummer], [Naam], [EmailAdres], [Straat], [Huisnummer], 
                                                   [HuisnummerToevoeging], [Postcode], [Plaats])
                    VALUES (@id, @Nummer, @Naam, @EmailAdres, @Straat, @Huisnummer, @HuisnummerToevoeging, @Postcode, @Plaats)";
                CommandDefinition cmd = new CommandDefinition(commandText, deelnemer);
                connection.Execute(cmd);
            }
        }

        public static Deelnemer RaadpleegDeelnemer(Guid id)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Correspondentie"].ConnectionString))
            {
                return connection.Query<Deelnemer>(
                    "SELECT * FROM Deelnemer WHERE id = @id",
                    new { id }).FirstOrDefault();
            }
        }
    }
}
