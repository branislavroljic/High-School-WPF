using Srednja_skola_HCI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srednja_skola_HCI.DTO
{
    public class PredmetNaSmjeru
    {
        public PredmetNaSmjeru()
        {
            Predmet = new Predmet();
            Smjer = new Smjer();    
        }

        public Predmet Predmet { get; set; }
        public Smjer Smjer { get; set; }
        public TipPredmeta? Tip { get; set; }

        public int? Razred { get; set; }

        public int? MinimalniBrojPismenihProvjera { get; set; }

        public int? MinimalniBrojUsmenihProvjera { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is PredmetNaSmjeru smjeru &&
                   EqualityComparer<Predmet>.Default.Equals(Predmet, smjeru.Predmet) &&
                   EqualityComparer<Smjer>.Default.Equals(Smjer, smjeru.Smjer) &&
                   Tip == smjeru.Tip &&
                   Razred == smjeru.Razred &&
                   MinimalniBrojPismenihProvjera == smjeru.MinimalniBrojPismenihProvjera &&
                   MinimalniBrojUsmenihProvjera == smjeru.MinimalniBrojUsmenihProvjera;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Predmet, Smjer, Tip, Razred, MinimalniBrojPismenihProvjera, MinimalniBrojUsmenihProvjera);
        }
    }
}
