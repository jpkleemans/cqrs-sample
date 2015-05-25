using PensioenSysteem.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PensioenSysteem.Domain.Deelnemer.Commands
{
    public class VerhuisDeelnemerCommand : DomainCommand
    {
        public Guid Id { get; set; }
        public string Straat { get; set; }
        public int Huisnummer { get; set; }
        public string HuisnummerToevoeging { get; set; }
        public string Postcode { get; set; }
        public string Plaats { get; set; }
    }
}