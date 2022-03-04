using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srednja_skola_HCI.DTO
{
    public class Predmet
    {
        public int? IdPredmeta { get; set; }
        public string Naziv { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Predmet predmet &&
                   IdPredmeta == predmet.IdPredmeta &&
                   Naziv == predmet.Naziv;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdPredmeta, Naziv);
        }
    }
}
