using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srednja_skola_HCI.DTO
{
    public class UcenikDetaljno
    {
        public string JMB { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Skola { get; set; }
        public string JIB { get; set; }

        public int IdsSmjera { get; set; }
        public string Smjer { get; set; }

        public int Razred { get; set; }
        public int Odjeljenje { get; set; }

        public double Prosjek { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is UcenikDetaljno detaljno &&
                   JMB == detaljno.JMB &&
                   Ime == detaljno.Ime &&
                   Prezime == detaljno.Prezime &&
                   Skola == detaljno.Skola &&
                   JIB == detaljno.JIB &&
                   IdsSmjera == detaljno.IdsSmjera &&
                   Smjer == detaljno.Smjer &&
                   Razred == detaljno.Razred &&
                   Odjeljenje == detaljno.Odjeljenje &&
                   Prosjek == detaljno.Prosjek;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(JMB);
            hash.Add(Ime);
            hash.Add(Prezime);
            hash.Add(Skola);
            hash.Add(JIB);
            hash.Add(IdsSmjera);
            hash.Add(Smjer);
            hash.Add(Razred);
            hash.Add(Odjeljenje);
            hash.Add(Prosjek);
            return hash.ToHashCode();
        }
    }
}
