using PensioenSysteem.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Domain.Arbeidsverhouding.Events
{
    [Serializable] // nodig voor serialisatie door FileEventStore
    public class ArbeidsverhoudingGeregistreerd : DomainEvent
    {
        public string Nummer { get; set; }
        public string DeelnemerNummer { get; set; }
        public string WerkgeverNummer { get; set; }
        public DateTime Ingangsdatum { get; set; }
        public DateTime? EindDatum { get; set; }
    }
}
