using PensioenSysteem.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Application.ProcesManagers.Commands
{
    public class WerknemerGegevens
    {
        public Guid Id { get; set; }
        public string Naam { get; set; }
        public string EmailAdres { get; set; }
        public string Straat { get; set; }
        public int Huisnummer { get; set; }
        public string HuisnummerToevoeging { get; set; }
        public string Postcode { get; set; }
        public string Plaats { get; set; }
    }

    public class WerkgeverGegevens
    {
        public Guid Id { get; set; }
        public string BedrijfsNaam { get; set; }
        public string NaamContactPersoon { get; set; }
        public string EmailAdres { get; set; }
        public string Straat { get; set; }
        public int Huisnummer { get; set; }
        public string HuisnummerToevoeging { get; set; }
        public string Postcode { get; set; }
        public string Plaats { get; set; }
    }

    public class RegistreerAanmeldingCommand : DomainCommand
    {
        public WerknemerGegevens WerknemerGegevens { get; set; }
        public WerkgeverGegevens WerkgeverGegevens { get; set; }
        public DateTime IngangsDatum { get; set; }
        public DateTime? EindDatum { get; set; }
    }
}
