using PensioenSysteem.Domain.Core;
using PensioenSysteem.Domain.Deelnemer.Commands;
using PensioenSysteem.Domain.Deelnemer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Application.Correspondentie.Model
{
    public class Deelnemer
    {
        public Guid Id { get; set; }
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
