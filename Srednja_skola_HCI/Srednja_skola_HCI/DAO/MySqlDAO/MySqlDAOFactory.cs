using Srednja_skola_HCI.DAO.MySQLDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srednja_skola_HCI.DAO.MySqlDAO
{
    public class MySqlDAOFactory : DAOFactory
    {
        private MySqlSkola? mySqlSkola;
        private MySqlPredmet? mySqlPredmet;
        private MySqlSmjer? mySqlSmjer;
        private MySqlPredmetNaSmjeru? mySqlPredmetNaSmjeru;
        private MySqlProfesor? mySqlProfesor;
        private MySqlProvjera? mySqlProvjera;
        private MySqlUcenikDetaljno? mySqlUcenikDetaljno;
        private MySqlPredaje? mySqlPredaje;
        private MySqlRadiProvjeru? mySqlRadiProvjeru;
        private MySqlAdmin? mySqlAdmin;

        public override ISkolaDAO Skole
        {
            get
            {

                if (mySqlSkola == null)
                {
                    mySqlSkola = new MySqlSkola();
                }
                return mySqlSkola;
            }
        }
        public override IPredajeDAO Predavanja 
        {
            get
            {

                if (mySqlPredaje == null)
                {
                    mySqlPredaje = new MySqlPredaje();
                }
                return mySqlPredaje;
            }
        }
        public override IUcenikDetaljnoDAO UceniciDetaljno
        {
            get
            {

                if (mySqlUcenikDetaljno == null)
                {
                    mySqlUcenikDetaljno = new MySqlUcenikDetaljno();
                }
                return mySqlUcenikDetaljno;
            }
        }

        public override IProvjeraDAO Provjere 
        {
            get
            {

                if (mySqlProvjera == null)
                {
                    mySqlProvjera = new MySqlProvjera();
                }
                return mySqlProvjera;
            }
        }

        public override IProfesorDAO Profesori
        {
            get
            {

                if (mySqlProfesor == null)
                {
                    mySqlProfesor = new MySqlProfesor();
                }
                return mySqlProfesor;
            }
        }
        public override IAdminDAO Admini
        {
            get
            {

                if (mySqlAdmin == null)
                {
                    mySqlAdmin = new MySqlAdmin();
                }
                return mySqlAdmin;
            }
        }
        public override ISmjerDAO Smjerovi
        {
            get
            {
                if (mySqlSmjer == null)
                {
                    mySqlSmjer = new MySqlSmjer();
                }
                return mySqlSmjer;
            }
        }

        public override IPredmetNaSmjeruDAO PredmetiNaSmjeru
        {
            get
            {
                if (mySqlPredmetNaSmjeru == null)
                {
                    mySqlPredmetNaSmjeru = new MySqlPredmetNaSmjeru();
                }
                return mySqlPredmetNaSmjeru;
            }
        }


        public override IPredmetDAO Predmeti
        {

            get
            {

                if (mySqlPredmet == null)
                {
                    mySqlPredmet = new MySqlPredmet();
                }
                return mySqlPredmet;
            }
        }

        public override IRadiProvjeruDAO RadjenjaProvjere
        {
            get
            {

                if (mySqlRadiProvjeru == null)
                {
                    mySqlRadiProvjeru = new MySqlRadiProvjeru();
                }
                return mySqlRadiProvjeru;
            }
        }
    }
}
