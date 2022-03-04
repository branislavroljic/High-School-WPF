using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srednja_skola_HCI.DTO
{
    public class Predaje
    {
        public Predaje()
        {
            PredmetNaSmjeru = new PredmetNaSmjeru();
            Profesor = new Profesor();
        }

        public PredmetNaSmjeru PredmetNaSmjeru { get; set; }
        public Profesor Profesor { get; set; }

        public int? BrojSedmicnihCasova { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Predaje predaje &&
                   EqualityComparer<PredmetNaSmjeru>.Default.Equals(PredmetNaSmjeru, predaje.PredmetNaSmjeru) &&
                   EqualityComparer<Profesor>.Default.Equals(Profesor, predaje.Profesor) &&
                   BrojSedmicnihCasova == predaje.BrojSedmicnihCasova;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PredmetNaSmjeru, Profesor, BrojSedmicnihCasova);
        }
    }
}
