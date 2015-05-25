using PensioenSysteem.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PensioenSysteem.Domain.Arbeidsverhouding.Commands
{
    public class RegistreerArbeidsverhoudingCommand : DomainCommand
    {
        public Guid Id { get; set; }
        public string DeelnemerNummer { get; set; }
        public string WerkgeverNummer { get; set; }
        public DateTime Ingangsdatum { get; set; }
        public DateTime? EindDatum { get; set; }
    }
}