using Srednja_skola_HCI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srednja_skola_HCI.DTO
{
    public class RadiProvjeru
    {
        public Provjera Provjera { get; set; }

        public UcenikDetaljno UcenikDetaljno { get; set; }

        public Ocjena Ocjena { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is RadiProvjeru provjeru &&
                   EqualityComparer<Provjera>.Default.Equals(Provjera, provjeru.Provjera) &&
                   EqualityComparer<UcenikDetaljno>.Default.Equals(UcenikDetaljno, provjeru.UcenikDetaljno);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Provjera, UcenikDetaljno);
        }
    }
}
