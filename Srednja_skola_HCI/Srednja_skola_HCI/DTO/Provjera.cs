using Srednja_skola_HCI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srednja_skola_HCI.DTO
{

    
    public class Provjera
    {
        public DateTime? Datum { get; set; }

        public TipProvjere? TipProvjere { get; set; }
        public int? Trajanje { get; set; }
        public int? BrojNegativnihOcjena { get; set; }
        public int? BrojPrisutnihUcenika { get; set; }
        public Boolean? Ponovljena { get; set; }

        public PredmetNaSmjeru PredmetNaSmjeru { get; set; }


        public int? Odjeljenje { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Provjera provjera &&
                   Datum == provjera.Datum &&
                   TipProvjere == provjera.TipProvjere &&
                   Trajanje == provjera.Trajanje &&
                   BrojNegativnihOcjena == provjera.BrojNegativnihOcjena &&
                   BrojPrisutnihUcenika == provjera.BrojPrisutnihUcenika &&
                   Ponovljena == provjera.Ponovljena &&
                   EqualityComparer<PredmetNaSmjeru>.Default.Equals(PredmetNaSmjeru, provjera.PredmetNaSmjeru) &&
                   Odjeljenje == provjera.Odjeljenje;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Datum, TipProvjere, Trajanje, BrojNegativnihOcjena, BrojPrisutnihUcenika, Ponovljena, PredmetNaSmjeru, Odjeljenje);
        }
    }
}
