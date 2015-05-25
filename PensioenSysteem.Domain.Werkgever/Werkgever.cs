using PensioenSysteem.Domain.Core;
using PensioenSysteem.Domain.Werkgever.Commands;
using PensioenSysteem.Domain.Werkgever.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Domain.Werkgever
{
    public class Werkgever : AggregateRoot, IHandle<WerkgeverGeregistreerd>
    {
        private Guid _id;
        private string _nummer;
        private string _bedrijfsNaam;
        private string _naamContactPersoon;
        private string _emailAdres;
        private Adres _hoofdvestigingAdres;

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

        public string bedrijfsNaam
        {
            get
            {
                return _bedrijfsNaam;
            }
        }

        public string NaamContactPersoon
        {
            get
            {
                return _naamContactPersoon;
            }
        }

        public string emailAdres
        {
            get
            {
                return _emailAdres;
            }
        }

        public Adres HoofdvestigingAdres
        {
            get
            {
                return _hoofdvestigingAdres;
            }
        }

        public void Registreer(RegistreerWerkgeverCommand command)
        {
            ApplyChange(new WerkgeverGeregistreerd
            {
                RoutingKey = "Werkgever.Geregistreerd",
                CorrelationId = command.CorrelationId,
                Id = command.Id,
                Nummer = GenereerWerkgeverNummer(),
                BedrijfsNaam = command.BedrijfsNaam,
                NaamContactPersoon = command.NaamContactPersoon,
                EmailAdres = command.EmailAdres,
                Straat = command.Straat,
                Huisnummer = command.Huisnummer,
                HuisnummerToevoeging = command.HuisnummerToevoeging,
                Postcode = command.Postcode,
                Plaats = command.Plaats
            });
        }

        public void Handle(WerkgeverGeregistreerd e)
        {
            _id = e.Id;
            _nummer = e.Nummer;
            _bedrijfsNaam = e.BedrijfsNaam;
            _naamContactPersoon = e.NaamContactPersoon;
            _emailAdres = e.EmailAdres;
            _hoofdvestigingAdres = new Adres(e.Straat, e.Huisnummer, e.HuisnummerToevoeging, e.Postcode, e.Plaats);
        }

        private string GenereerWerkgeverNummer()
        {
            return DateTime.Now.ToString("WGyyyyMMddhhMMssffffff");
        }
    }
}
