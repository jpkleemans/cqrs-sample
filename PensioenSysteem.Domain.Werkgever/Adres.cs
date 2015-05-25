using PensioenSysteem.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensioenSysteem.Domain.Werkgever
{
    public class Adres : ValueObject 
    {
        private string _straat;
        private int _huisnummer;
        private string _huisnummerToevoeging;
        private string _postcode;
        private string _plaats;

        public string Straat
        {
            get { return _straat; }
        }

        public int Huisnummer
        {
            get { return _huisnummer; }
        }

        public string HuisnummerToevoeging
        {
            get { return _huisnummerToevoeging; }
        }

        public string Postcode
        {
            get { return _postcode; }
        }

        public string Plaats
        {
            get { return _plaats; }
        }

        public Adres(string straat, int huisnummer, string huisnummerToevoeging, string postcode, string plaats)
        {
            _straat = straat;
            _huisnummer = huisnummer;
            _huisnummerToevoeging = huisnummerToevoeging;
            _postcode = postcode;
            _plaats = plaats;
        }
    }
}
