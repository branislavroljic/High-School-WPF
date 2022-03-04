using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srednja_skola_HCI.DTO
{
    public class Smjer
    {
        public int? IdSmjera { get; set; }

        public int? TrajanjeGodina { get; set; }

        public String Naziv { get; set; }

        public String Zvanje { get; set; }

        public Skola Skola { get; set; }

        public Smjer()
        {
            Skola = new Skola();
        }

        public override bool Equals(object? obj)
        {
            return obj is Smjer smjer &&
                   IdSmjera == smjer.IdSmjera &&
                   TrajanjeGodina == smjer.TrajanjeGodina &&
                   Naziv == smjer.Naziv &&
                   Zvanje == smjer.Zvanje &&
                   EqualityComparer<Skola>.Default.Equals(Skola, smjer.Skola);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdSmjera, TrajanjeGodina, Naziv, Zvanje, Skola);
        }
    }
}
