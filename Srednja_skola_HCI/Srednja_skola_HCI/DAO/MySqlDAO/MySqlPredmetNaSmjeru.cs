using MySql.Data.MySqlClient;
using Srednja_skola_HCI.Dialogs;
using Srednja_skola_HCI.DTO;
using Srednja_skola_HCI.Forms;
using Srednja_skola_HCI.Util.MySqlUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Srednja_skola_HCI.DAO.MySqlDAO
{
    public class MySqlPredmetNaSmjeru : IPredmetNaSmjeruDAO
    {
        MySqlConnection? conn;
        MySqlCommand? cmd;
        MySqlDataReader? reader;


        private static readonly string DELETE = "delete from predmet_na_smjeru pns where pns.IdPredmeta=@IdPredmeta and pns.IdSmjera=@IdSmjera";



        private static readonly string SELECT = "select p.IdPredmeta, p.Naziv as NazivPredmeta, s.IdSmjera, pns.Tip, pns.Razred, MinimalniBrojPismenihProvjera, MinimalniBrojUsmenihProvjera   "
                + "from predmet_na_smjeru pns  " + "inner join smjer s on s.IdSmjera= pns.IdSmjera "
                + "inner join predmet p on p.IdPredmeta = pns.IdPredmeta";

        private static readonly string SELECT_BY_STUDENT = "select p.IdPredmeta, p.Naziv as NazivPredmeta, pns.Tip, pns.Razred  from predmet_na_smjeru pns inner join predmet p on p.IdPredmeta = pns.IdPredmetainner join ima_nastavu n on pns.IdPredmeta = n.IdPredmeta and pns.IdSmjera = n.IdSmjera and n.UCENIK_JMB = @UCENIK_JMB";
        private static readonly string SELECT_ONE = "select Tip, Razred, MinimalniBrojPismenihProvjera, MinimalniBrojUsmenihProvjera, IdPredmeta, IdSmjera "
                + "from predmet_na_smjeru pns where pns.IdPredmeta = @IdPredmeta and pns.IdSmjera = @IdSmjera ";

        private static readonly string SELECT_BY_PROFESOR = "select p.IdPredmeta, p.IdSmjera, pns.Tip, pns.Razred, MinimalniBrojPismenihProvjera, MinimalniBrojUsmenihProvjera from predmet_na_smjeru pns natural inner join predaje p where p.PROFESOR_JMB = @profesorJMB;";
        public List<PredmetNaSmjeru> GetPredmetPoUceniku(string JMB)
        {
            conn = null;
            cmd = null;
            reader = null;

            List<PredmetNaSmjeru> predmetiPoUceniku = new List<PredmetNaSmjeru>();
            try
            {
                using (conn = new MySqlConnection(MySqlUtil.connectionString))
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandText = SELECT_BY_STUDENT;
                    cmd.Parameters.AddWithValue("@UCENIK_JMB", JMB);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Enum.TryParse(reader.GetString(3), out TipPredmeta tip);
                        predmetiPoUceniku.Add(new PredmetNaSmjeru()
                        {
                            Predmet = new Predmet() { IdPredmeta = reader.GetInt32(0), Naziv = reader.GetString(1) },
                            Smjer = DAOFactory.Instance(DAOType.MySQL).Smjerovi.GetDTO(new Smjer() { IdSmjera = reader.GetInt32(2) }),
                            Tip = tip,
                            Razred = reader.GetByte(4)
                        });

                    }
                }
            }
            catch (Exception e)
            {
                new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();
            }
            return predmetiPoUceniku;
        }

        public List<PredmetNaSmjeru> GetPredmetPoProfesoru(string profesorJMB)
        {
            conn = null;
            cmd = null;
            reader = null;

            List<PredmetNaSmjeru> predmetiPoProfesoru = new List<PredmetNaSmjeru>();
            try
            {
                using (conn = new MySqlConnection(MySqlUtil.connectionString))
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandText = SELECT_BY_PROFESOR;
                    cmd.Parameters.AddWithValue("@profesorJMB", profesorJMB);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Enum.TryParse(reader.GetString(2), out TipPredmeta tip);
                        predmetiPoProfesoru.Add(new PredmetNaSmjeru()
                        {
                            Predmet = DAOFactory.Instance(DAOType.MySQL).Predmeti.GetDTO(new Predmet() { IdPredmeta = reader.GetInt32(0) }),
                            Smjer = DAOFactory.Instance(DAOType.MySQL).Smjerovi.GetDTO(new Smjer() { IdSmjera = reader.GetInt32(1) }),
                            Tip = tip,
                            Razred = reader.GetByte(3),
                            MinimalniBrojPismenihProvjera = reader.GetByte(4),
                            MinimalniBrojUsmenihProvjera = reader.GetByte(5)
                        });

                    }
                }
            }
            catch (Exception e)
            {
                new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();
            }
            return predmetiPoProfesoru;
        }


        public PredmetNaSmjeru GetDTO(PredmetNaSmjeru dto)
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
                    cmd.Parameters.AddWithValue("@IdSmjera", dto.Smjer.IdSmjera);
                    cmd.Parameters.AddWithValue("@IdPredmeta", dto.Predmet.IdPredmeta);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Enum.TryParse(reader.GetString(0), out TipPredmeta tip);
                        return new PredmetNaSmjeru()
                        {
                            Tip = tip,
                            Razred = reader.GetInt32(1),
                            MinimalniBrojPismenihProvjera = reader.GetInt32(2),
                            MinimalniBrojUsmenihProvjera = reader.GetInt32(3),

                            Predmet = DAOFactory.Instance(DAOType.MySQL).Predmeti.GetDTO(new Predmet() { IdPredmeta = reader.GetInt32(4) }),
                            Smjer = DAOFactory.Instance(DAOType.MySQL).Smjerovi.GetDTO(new Smjer() { IdSmjera = reader.GetInt32(5) })
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

        public List<PredmetNaSmjeru> GetDTOList()
        {
            conn = null;
            cmd = null;
            reader = null;

            List<PredmetNaSmjeru> predmetNaSmjeruList = new List<PredmetNaSmjeru>();
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
                        Enum.TryParse(reader.GetString(3), out TipPredmeta tip);
                        predmetNaSmjeruList.Add(new PredmetNaSmjeru()
                        {
                            Predmet = new Predmet() { IdPredmeta = reader.GetInt32(0), Naziv = reader.GetString(1) },
                            Smjer = DAOFactory.Instance(DAOType.MySQL).Smjerovi.GetDTO(new Smjer() { IdSmjera = reader.GetInt32(2) }),
                            Tip = tip,
                            Razred = reader.GetByte(4),
                            MinimalniBrojPismenihProvjera = reader.GetByte(5),
                            MinimalniBrojUsmenihProvjera = reader.GetByte(6)
                        });

                    }
                }
            }
            catch (Exception e)
            {
                new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();
            }
            return predmetNaSmjeruList;
        }

        public bool CreateDTO(PredmetNaSmjeru dto)
        {
            conn = null;
            cmd = null;
            reader = null;

            try
            {
                using (conn = new MySqlConnection(MySqlUtil.connectionString))
                {
                    conn.Open();
                    cmd = new MySqlCommand("dodaj_predmet_na_smjeru", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pTip", dto.Tip);
                    cmd.Parameters.AddWithValue("@pIdSmjera", dto.Smjer.IdSmjera);
                    cmd.Parameters.AddWithValue("@pNazivPredmeta", dto.Predmet.Naziv);
                    cmd.Parameters.AddWithValue("@pIdPredmeta", dto.Predmet.IdPredmeta);
                    cmd.Parameters.AddWithValue("@pRazred", dto.Razred);
                    cmd.Parameters.AddWithValue("@pMinimalniBrojPismenihProvjera", dto.MinimalniBrojPismenihProvjera);
                    cmd.Parameters.AddWithValue("@pMinimalniBrojUsmenihProvjera", dto.MinimalniBrojUsmenihProvjera);
                  

                    int result = cmd.ExecuteNonQuery();

                    conn.Close();
                    return result != 0;

                }
            }
            catch (Exception e)
            {

                new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();

            }
            return false;
        }

        public bool UpdateDTO(PredmetNaSmjeru dto)
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
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "azuriraj_predmet_na_smjeru";

                    cmd.Parameters.AddWithValue("@pIdPredmeta", dto.Predmet.IdPredmeta);
                    cmd.Parameters.AddWithValue("@pNazivPredmeta", dto.Predmet.Naziv);
                    cmd.Parameters.AddWithValue("@pIdSmjera", dto.Smjer.Naziv);
                    cmd.Parameters.AddWithValue("@pTip", dto.Tip);
                    cmd.Parameters.AddWithValue("@pRazred", dto.Razred);
                    cmd.Parameters.AddWithValue("@pMinimalniBrojPismenihProvjera", dto.MinimalniBrojPismenihProvjera);
                    cmd.Parameters.AddWithValue("@pMinimalniBrojUsmenihProvjera", dto.MinimalniBrojUsmenihProvjera);

                    int result = cmd.ExecuteNonQuery();

                    conn.Close();
                    return result != 0;


                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();

            }
            return false;
        }

        public bool DeleteDTOById(PredmetNaSmjeru dto)
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
                    cmd.Parameters.AddWithValue("@IdSmjera", dto.Smjer.IdSmjera);
                    cmd.Parameters.AddWithValue("@IdPredmeta", dto.Predmet.IdPredmeta);
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
    }
}
