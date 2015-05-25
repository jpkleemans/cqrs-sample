using PensioenSysteem.Domain.Core;
using PensioenSysteem.Domain.Deelnemer.Commands;
using PensioenSysteem.Domain.Deelnemer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Domain.Deelnemer
{
    public class Deelnemer : AggregateRoot, IHandle<DeelnemerGeregistreerd>, IHandle<DeelnemerVerhuisd>
    {
        private Guid _id;
        private string _nummer;
        private string _naam;
        private string _emailAdres;
        private Adres _woonadres;

        public override Guid Id
        {
            get
            {
                return _id;
            }
        }

        public string Nummer
        {
            get
            {
                return _nummer;
            }
        }

        public string Naam
        {
            get
            {
                return _naam;
            }
        }

        public string emailAdres
        {
            get
            {
                return _emailAdres;
            }
        }

        public Adres Woonadres
        {
            get
            {
                return _woonadres;
            }
        }

        public void Registreer(RegistreerDeelnemerCommand command)
        {
            ApplyChange(new DeelnemerGeregistreerd
            {
                RoutingKey = "Deelnemer.Geregistreerd",
                CorrelationId = command.CorrelationId,
                Id = command.Id, 
                Nummer = GenereerDeelnemerNummer(),
                Naam = command.Naam, 
                EmailAdres = command.EmailAdres, 
                Straat = command.Straat, 
                Huisnummer = command.Huisnummer, 
                HuisnummerToevoeging = command.HuisnummerToevoeging, 
                Postcode = command.Postcode, 
                Plaats = command.Plaats
            });
        }

        public void Verhuis(VerhuisDeelnemerCommand command)
        {
            ApplyChange(new DeelnemerVerhuisd
            {
                RoutingKey = "Deelnemer.Verhuisd",
                CorrelationId = command.CorrelationId,
                Id = command.Id,
                Nummer = this.Nummer,
                Straat = command.Straat, 
                Huisnummer = command.Huisnummer, 
                HuisnummerToevoeging = command.HuisnummerToevoeging,
                Postcode = command.Postcode, 
                Plaats = command.Plaats
            });
        }

        public void Handle(DeelnemerGeregistreerd e)
        {
            _id = e.Id;
            _nummer = e.Nummer;
            _naam = e.Naam;
            _emailAdres = e.EmailAdres;
            _woonadres = new Adres(e.Straat, e.Huisnummer, e.HuisnummerToevoeging, e.Postcode, e.Plaats);
        }

        public void Handle(DeelnemerVerhuisd e)
        {
            _woonadres = new Adres(e.Straat, e.Huisnummer, e.HuisnummerToevoeging, e.Postcode, e.Plaats);
        }
        private string GenereerDeelnemerNummer()
        {
            return DateTime.Now.ToString("DNyyyyMMddhhMMssffffff");
        }
    }
}
