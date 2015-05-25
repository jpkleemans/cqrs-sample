using PensioenSysteem.Application.ProcesManagers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Application.ProcesManagers
{
    internal static class TestCommandFactory
    {
        private static string[] Voornamen = new string[] { "Bert", "Klaas", "Erik", "Janet", "Maxime", "Patrick", "Bas", "Sander", "Edwin", "Martijn", "Beate", "Corry", "Sjoerd", "Jasper", "Fabian", "Debby", "Gerard", "Henk", "Jan", "Dirk", "Pascal", "Maarten", "Wim", "Rik", "Renate", "Lydia", "Linda", "Alex", "Olaf", "Niek", "Jeroen", "Roel", "Marco", "Cora", "Frank" };
        private static string[] Achternamen = new string[] { "Jansen", "de Rooij", "Pieterse", "van Veen", "Zwijgers", "Derksen", "de Vries", "Gerritsen", "Mensink", "de Ruiter", "Lensink", "van Oosten", "Smit", "van Gaal", "Duistermaat", "Robbers", "Zende", "de Boer", "van Velzen", "van Zundert", "Hendriksen", "de Smet", "Jongeneele", "Franken", "Keijser", "de Groot", "Damen", "de Vrij", "de Kort", "van der Zanden", "de Bie" };
        private static string[] Domeinnamen = new string[] { "hotmail.com", "live.nl", "outlook.com", "upcmail.nl", "xas4all.nl", "gmail.com", "yahoo.com", "kpn.nl", "ziggo.nl", "hetnet.nl" };
        private static string[] Straatnamen = new string[] { "Wilhelminastraat", "Hoofdstraat", "Zijstraat", "Rijksstraatweg", "Laan van Eerde", "Zandpad", "Breegraven", "Beatrixplantsoen", "Laan van de Vrede", "Berkenlaan", "Hofweg", "Beukenlaan", "Frederiksplein", "Bonendaal", "Rondweg", "Wijdesteeg", "Muntplein", "Hekelveld", "Duinstraat", "Nieuwe Markt", "Korte Oeverweg", "Kanaalstraat", "De Ruiterplein", "Kerkstraat", "Lange Straat", "Tichelstraat", "Bloemstraat" };
        private static string[] Plaatsnamen = new string[] { "Zutphen", "Arnem", "Amsterdam", "Zwolle", "Raamsdonkveer", "Rotterdam", "Sneek", "Venlo", "Zeist", "Bunnik", "Utrecht", "Houten", "Almere", "Groningen", "Hoogvliet", "Leeuwarden", "Apeldoorn", "Deventer", "Wageningen", "Breda", "Eindhoven", "Nijmegen", "Maastricht", "Oosterbeek", "Veenendaal", "Zoetermeer", "Den Haag", "Haarlem", "Zaandam", "Nieuwegein", "Amstelveen", "Dordrecht", "Abcoude", "Aalsmeer" };
        private static string[] Bedrijfsnamen = new string[] { "Thuiszorg Noord", "Fysiotherapie Janssen", "Gezondheidscentrum Rademakers", "Gezondheidscentrum De Wit", "Verpleeghuis Zonnegloed", "Psychologiecentrum Zuid", "Medisch Centrum West", "Thuiszorg West", "Ergotherapie centrum Move", "Medisch Centrum Noord-Oost", "Zorggroep Beemsterland", "Zorgtehuis Saphion", "Healthcenter Noord", "Zorgcentrum De Vrij", "Thuiszorg Nederland", "Healthcenter West", "GGZ Noord", "GGZ Zuid", "GGZ West", "GGZ Oost" };
        private static string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static RegistreerAanmeldingCommand MaakRegistreerAanmeldingCommand()
        {
            Random rnd = new Random();

            string voornaam = Voornamen[rnd.Next(0, Voornamen.Length - 1)];
            string achternaam = Achternamen[rnd.Next(0, Achternamen.Length - 1)];
            string voornaamContactpersoon = Voornamen[rnd.Next(0, Voornamen.Length - 1)];
            string achternaamContactpersoon = Achternamen[rnd.Next(0, Achternamen.Length - 1)];

            RegistreerAanmeldingCommand command = new RegistreerAanmeldingCommand
            {
                CorrelationId = Guid.NewGuid(),
                IngangsDatum = DateTime.Now,
                Version = 0,
                WerknemerGegevens = new WerknemerGegevens
                {
                    Id = Guid.NewGuid(),
                    Naam = string.Format("{0} {1}", voornaam, achternaam),
                    EmailAdres = string.Format("{0}.{1}@{2}", 
                        voornaam.ToLower(), achternaam.ToLower().Replace(" ", ""), 
                        Domeinnamen[rnd.Next(0, Domeinnamen.Length - 1)]),
                    Straat = Straatnamen[rnd.Next(0, Straatnamen.Length - 1)],
                    Huisnummer = rnd.Next(10, 250),
                    HuisnummerToevoeging = null,
                    Postcode = string.Format("{0} {1}{2}", rnd.Next(1000, 9999), letters[rnd.Next(25)], letters[rnd.Next(25)]),
                    Plaats = Plaatsnamen[rnd.Next(0, Plaatsnamen.Length - 1)]
                },
                WerkgeverGegevens = new WerkgeverGegevens
                {
                    Id = Guid.NewGuid(),
                    BedrijfsNaam = Bedrijfsnamen[rnd.Next(0, Bedrijfsnamen.Length - 1)],
                    NaamContactPersoon = string.Format("{0} {1}", voornaamContactpersoon, achternaamContactpersoon),
                    EmailAdres = string.Format("{0}.{1}@{2}", 
                        voornaamContactpersoon.ToLower(), achternaamContactpersoon.ToLower().Replace(" ", ""), 
                        Domeinnamen[rnd.Next(0, Domeinnamen.Length - 1)]),
                    Straat = Straatnamen[rnd.Next(0, Straatnamen.Length - 1)],
                    Huisnummer = rnd.Next(10, 250),
                    HuisnummerToevoeging = null,
                    Postcode = string.Format("{0} {1}{2}", rnd.Next(1000, 9999), letters[rnd.Next(25)], letters[rnd.Next(25)]),
                    Plaats = Plaatsnamen[rnd.Next(0, Plaatsnamen.Length - 1)]
                }
            };

            return command;
        }
    }
}
