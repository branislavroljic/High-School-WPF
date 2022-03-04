using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srednja_skola_HCI.DTO
{
    public class Profesor
    {
        public Profesor()
        {
            Osoba = new Osoba();
        }

        public Osoba  Osoba { get; set; }
        public Boolean? Verifikovan { get; set; }
        public decimal? Plata{ get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Profesor profesor &&
                   EqualityComparer<Osoba>.Default.Equals(Osoba, profesor.Osoba) &&
                   Verifikovan == profesor.Verifikovan &&
                   Plata == profesor.Plata;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Osoba, Verifikovan, Plata);
        }
    }
}
