using PensioenSysteem.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Domain.Deelnemer.Events
{
    [Serializable] // nodig voor serialisatie door FileEventStore
    public class DeelnemerGeregistreerd : DomainEvent
    {
        public string Nummer { get; set; }
        public string Naam { get; set; }
        public string EmailAdres { get; set; }
        public string Straat { get; set; }
        public int Huisnummer { get; set; }
        public string HuisnummerToevoeging { get; set; }
        public string Postcode { get; set; }
        public string Plaats { get; set; }
    }
}
