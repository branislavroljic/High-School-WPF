using MySql.Data.MySqlClient;
using Srednja_skola_HCI.Dialogs;
using Srednja_skola_HCI.DTO;
using Srednja_skola_HCI.Forms;
using Srednja_skola_HCI.Util.MySqlUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Srednja_skola_HCI.DAO.MySqlDAO
{
    public class MySqlProvjera : IProvjeraDAO
    {

        MySqlConnection? conn;
        MySqlCommand? cmd;
        MySqlDataReader? reader;


        private static readonly string INSERT = "insert into provjera(Datum, Tip, TrajanjeMin, BrojNegativnihOcjena, BrojPrisutnihUcenika, Ponovljena, IdPredmeta, IdSmjera, Odjeljenje) values (@Datum, @Tip, @TrajanjeMin, @BrojNegativnihOcjena, @BrojPrisutnihUcenika, @Ponovljena, @IdPredmeta, @IdSmjera, @Odjeljenje )";
        private static readonly string DELETE = "DELETE FROM provjera WHERE IdSmjera=@IdSmjera and IdPredmeta=@IdPredmeta and Datum=@Datum and Odjeljenje=@Odjeljenje";


        private static readonly string UPDATE = "update provjera set Tip=@Tip, TrajanjeMin=@TrajanjeMin, BrojNegativnihOcjena=@BrojNegativnihOcjena, BrojPrisutnihUcenika=@BrojPrisutnihUcenika, Ponovljena=@Ponovljena "
                + "WHERE IdSmjera=@IdSmjera and IdPredmeta=@IdPredmeta and Datum=@Datum and Odjeljenje=@Odjeljenje";

        private static readonly string SELECT = "select IdPredmeta, IdSmjera, Datum, Odjeljenje, Tip, TrajanjeMin, BrojNegativnihOcjena, BrojPrisutnihUcenika, Ponovljena from provjera";

        private static readonly string SELECT_BY_PREDMET = "select Datum, Odjeljenje, Tip, TrajanjeMin, BrojNegativnihOcjena, BrojPrisutnihUcenika, Ponovljena from provjera where IdPredmeta=@IdPredmeta and IdSmjera=@IdSmjera";

        private static readonly string SELECT_ONE = "SELECT  Tip, TrajanjeMin, BrojNegativnihOcjena, BrojPrisutnihUcenika, Ponovljena from provjera WHERE IdSmjera=@IdSmjera and IdPredmeta=@IdPredmeta and Datum=@Datum and Odjeljenje=@Odjeljenje";

        public bool CreateDTO(Provjera dto)
        {
            conn = null;
            cmd = null;
            reader = null;

            try
            {
                using (conn = new MySqlConnection(MySqlUtil.connectionString))
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandText = INSERT;
                    cmd.Parameters.AddWithValue("@Datum", dto.Datum);
                    cmd.Parameters.AddWithValue("@Tip", dto.TipProvjere.ToString());
                    cmd.Parameters.AddWithValue("@TrajanjeMin", dto.Trajanje);
                    cmd.Parameters.AddWithValue("@BrojNegativnihOcjena", dto.BrojNegativnihOcjena);
                    cmd.Parameters.AddWithValue("@BrojPrisutnihUcenika", dto.BrojPrisutnihUcenika);
                    cmd.Parameters.AddWithValue("@IdPredmeta", dto.PredmetNaSmjeru.Predmet.IdPredmeta);
                    cmd.Parameters.AddWithValue("@IdSmjera", dto.PredmetNaSmjeru.Smjer.IdSmjera);
                    cmd.Parameters.AddWithValue("@Odjeljenje", dto.Odjeljenje);
                    cmd.Parameters.AddWithValue("@Ponovljena", dto.Ponovljena);
                    if (cmd.ExecuteNonQuery() == 0)
                        return false;
                    else return true;

                }
            }
            catch (Exception e)
            {

                 new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();

            }
            return false;
        }

        public bool DeleteDTOById(Provjera dto)
        {

            conn = null;
            cmd = null;

            try
            {
                using (conn = new MySqlConnection(MySqlUtil.connectionString))
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandText = DELETE;
                    cmd.Parameters.AddWithValue("@IdSmjera", dto.PredmetNaSmjeru.Smjer.IdSmjera);
                    cmd.Parameters.AddWithValue("@IdPredmeta", dto.PredmetNaSmjeru.Predmet.IdPredmeta);
                    cmd.Parameters.AddWithValue("@Datum", dto.Datum);
                    cmd.Parameters.AddWithValue("@Odjeljenje", dto.Odjeljenje);
                    if (cmd.ExecuteNonQuery() == 0)
                        return false;
                    else return true;
                }
            }
            catch (Exception e)
            {

                 new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();

            }
            return false;
        }

        public Provjera GetDTO(Provjera dto)
        {
            conn = null;
            cmd = null;
            reader = null;

            try
            {
                using (conn = new MySqlConnection(MySqlUtil.connectionString))
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandText = SELECT_ONE;
                    cmd.Parameters.AddWithValue("@IdSmjera", dto.PredmetNaSmjeru.Smjer.IdSmjera);
                    cmd.Parameters.AddWithValue("@IdPredmeta", dto.PredmetNaSmjeru.Predmet.IdPredmeta);
                    cmd.Parameters.AddWithValue("@Datum", dto.Datum);
                    cmd.Parameters.AddWithValue("@Odjeljenje", dto.Odjeljenje);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Enum.TryParse(reader.GetString(0), out TipProvjere tipProvjere);
                        return new Provjera()
                        {
                            PredmetNaSmjeru = DAOFactory.Instance(DAOType.MySQL).PredmetiNaSmjeru.GetDTO(new PredmetNaSmjeru() { Predmet = new Predmet() { IdPredmeta = dto.PredmetNaSmjeru.Predmet.IdPredmeta }, Smjer = new Smjer() { IdSmjera = dto.PredmetNaSmjeru.Smjer.IdSmjera} }),
                            Datum = dto.Datum,
                            Odjeljenje = dto.Odjeljenje,
                            TipProvjere = tipProvjere,
                            Trajanje = reader.GetInt32(1),
                            BrojNegativnihOcjena = reader.GetInt32(2),
                            BrojPrisutnihUcenika = reader.GetInt32(3),
                            Ponovljena = reader.GetByte(4) == 1 ? true : false


                        }; 
                    }
                }
            }
            catch (Exception e)
            {

                 new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();

            }
            return null;
        }
        public List<Provjera> GetDTOList()
        {
            conn = null;
            cmd = null;
            reader = null;

            List<Provjera> provjeraList = new List<Provjera>();
            try
            {
                using (conn = new MySqlConnection(MySqlUtil.connectionString))
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandText = SELECT;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        Enum.TryParse(reader.GetString(4), out TipProvjere tipProvjere);
                        provjeraList.Add(new Provjera()
                        {
                            PredmetNaSmjeru = DAOFactory.Instance(DAOType.MySQL).PredmetiNaSmjeru.GetDTO(new PredmetNaSmjeru() { Predmet = new Predmet() { IdPredmeta = reader.GetInt32(0) }, Smjer = new Smjer() { IdSmjera = reader.GetInt32(1) } }),
                            Datum = reader.GetDateTime(2),
                            Odjeljenje = reader.GetInt32(3),
                             TipProvjere = tipProvjere,
                             Trajanje = reader.GetInt32(5),
                             BrojNegativnihOcjena = reader.GetInt32(6),
                             BrojPrisutnihUcenika = reader.GetInt32(7),
                             Ponovljena = reader.GetByte(8) == 1 ? true : false

                        }); ;

                    }
                }
            }
            catch (Exception e)
            {

                 new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();

            }
            return provjeraList;
        }

        public bool UpdateDTO(Provjera dto)
        {
            conn = null;
            cmd = null;
            reader = null;

            try
            {
                using (conn = new MySqlConnection(MySqlUtil.connectionString))
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandText = UPDATE;
                    cmd.Parameters.AddWithValue("@Datum", dto.Datum);
                    cmd.Parameters.AddWithValue("@Tip", dto.TipProvjere.ToString());
                    cmd.Parameters.AddWithValue("@TrajanjeMin", dto.Trajanje);
                    cmd.Parameters.AddWithValue("@BrojNegativnihOcjena", dto.BrojNegativnihOcjena);
                    cmd.Parameters.AddWithValue("@BrojPrisutnihUcenika", dto.BrojPrisutnihUcenika);
                    cmd.Parameters.AddWithValue("@IdPredmeta", dto.PredmetNaSmjeru.Predmet.IdPredmeta);
                    cmd.Parameters.AddWithValue("@IdSmjera", dto.PredmetNaSmjeru.Smjer.IdSmjera);
                    cmd.Parameters.AddWithValue("@Odjeljenje", dto.Odjeljenje);
                    cmd.Parameters.AddWithValue("@Ponovljena", dto.Ponovljena);

                    if (cmd.ExecuteNonQuery() == 0)
                        return false;
                    else return true;

                }
            }
            catch (Exception e)
            {

                 new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();

            }
            return false;
        }
        public List<Provjera> GetProvjerePoPredmetu(PredmetNaSmjeru predmetNaSmjeru)
        {
            conn = null;
            cmd = null;
            reader = null;

            List<Provjera> provjeraList = new List<Provjera>();
            try
            {
                using (conn = new MySqlConnection(MySqlUtil.connectionString))
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandText = SELECT_BY_PREDMET;
                    cmd.Parameters.AddWithValue("@IdPredmeta", predmetNaSmjeru.Predmet.IdPredmeta);
                    cmd.Parameters.AddWithValue("@IdSmjera", predmetNaSmjeru.Smjer.IdSmjera);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        Enum.TryParse(reader.GetString(2), out TipProvjere tipProvjere);
                        provjeraList.Add(new Provjera()
                        {
                            PredmetNaSmjeru = predmetNaSmjeru,
                            Datum = reader.GetDateTime(0),
                            Odjeljenje = reader.GetInt32(1),
                            TipProvjere = tipProvjere,
                            Trajanje = reader.GetInt32(3),
                            BrojNegativnihOcjena = reader.GetInt32(4),
                            BrojPrisutnihUcenika = reader.GetInt32(5),
                            Ponovljena = reader.GetByte(6) == 1 ? true : false

                        }); ;

                    }
                }
            }
            catch (Exception e)
            {

                 new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();

            }
            return provjeraList;
        }
    }
}
