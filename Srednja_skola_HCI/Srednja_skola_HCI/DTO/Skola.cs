using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srednja_skola_HCI.DTO
{
    public class Skola
    {
        public string JIB { get; set; }

        public string Naziv { get; set; }

        public string MailAdresa { get; set; }

        public string Vrsta { get; set; }

        public string Adresa { get; set; }

        public string Telefon { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Skola skola &&
                   JIB == skola.JIB &&
                   Naziv == skola.Naziv &&
                   MailAdresa == skola.MailAdresa &&
                   Vrsta == skola.Vrsta &&
                   Adresa == skola.Adresa &&
                   Telefon == skola.Telefon;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(JIB, Naziv, MailAdresa, Vrsta, Adresa, Telefon);
        }

        public override string? ToString()
        {
            return JIB + "  " + Vrsta + " " + Naziv + " " +   MailAdresa + Telefon;
        }
    }
}
