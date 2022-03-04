using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srednja_skola_HCI.DAO
{

    public enum DAOType
    {
        MySQL
    }
    public abstract class DAOFactory
    {
        public abstract ISkolaDAO Skole { get; }
        public abstract IPredmetDAO Predmeti { get; }

        public abstract ISmjerDAO Smjerovi { get; }   
        public abstract IPredmetNaSmjeruDAO PredmetiNaSmjeru { get; }   
        public abstract IProfesorDAO Profesori { get; }   
        public abstract IAdminDAO Admini{ get; }   
        public abstract IProvjeraDAO Provjere{ get; }   
        public abstract IUcenikDetaljnoDAO UceniciDetaljno{ get; }   
        public abstract IPredajeDAO Predavanja { get; }   
        public abstract IRadiProvjeruDAO RadjenjaProvjere { get; }   

        public static DAOFactory Instance(DAOType daoFactoryType) {
            if (daoFactoryType.Equals(DAOType.MySQL)){
                return new MySqlDAO.MySqlDAOFactory();
            } else throw new ArgumentException();
        }
    }
}
