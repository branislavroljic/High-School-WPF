using Srednja_skola_HCI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srednja_skola_HCI.DTO
{

  
    public class Osoba
    {
        public string JMB { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public DateTime? DatumRodjenja { get; set; }

        public Pol? Pol { get; set; }

        public string Adresa { get; set; }

        public string MailAdresa { get; set; }

        public string Lozinka { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Osoba osoba &&
                   JMB == osoba.JMB &&
                   Ime == osoba.Ime &&
                   Prezime == osoba.Prezime &&
                   DatumRodjenja == osoba.DatumRodjenja &&
                   Pol == osoba.Pol &&
                   Adresa == osoba.Adresa &&
                   MailAdresa == osoba.MailAdresa;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(JMB, Ime, Prezime, DatumRodjenja, Pol, Adresa, MailAdresa);
        }
    }
}
