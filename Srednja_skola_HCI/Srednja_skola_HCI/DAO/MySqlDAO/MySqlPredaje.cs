using MySql.Data.MySqlClient;
using Srednja_skola_HCI.Dialogs;
using Srednja_skola_HCI.DTO;
using Srednja_skola_HCI.Util.MySqlUtil;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Srednja_skola_HCI.DAO.MySqlDAO
{
    public class MySqlPredaje : IPredajeDAO
    {

        MySqlConnection? conn;
        MySqlCommand? cmd;
        MySqlDataReader? reader;


        private static readonly string INSERT = "insert into predaje values (@IdPredmeta, @IdSmjera, @JMB, @BrojSedmicnihCasova)";
        private static readonly string DELETE = "DELETE FROM predaje where IdSmjera=@IdSmjera and IdPredmeta=@IdPredmeta and  PROFESOR_JMB=@JMB";


        private static readonly string UPDATE = "update predaje set BrojSedmicnihCasova=@BrojSedmicnihCasova where IdSmjera=@IdSmjera and IdPredmeta=@IdPredmeta and  PROFESOR_JMB=@JMB";

        private static readonly string SELECT_BY_PREDMET = "SELECT PROFESOR_JMB, BrojSedmicnihCasova from predaje where IdSmjera=@IdSmjera and IdPredmeta=@IdPredmeta";
        private static readonly string SELECT_ALL = "SELECT IdPredmeta, IdSmjera, PROFESOR_JMB, BrojSedmicnihCasova from predaje";
        private static readonly string SELECT_ONE = "SELECT BrojSedmicnihCasova where IdSmjera=@IdSmjera and IdPredmeta=@IdPredmeta and  PROFESOR_JMB=@JMB";

        public bool CreateDTO(Predaje dto)
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
                    cmd.Parameters.AddWithValue("@IdSmjera", dto.PredmetNaSmjeru.Smjer.IdSmjera);
                    cmd.Parameters.AddWithValue("@IdPredmeta", dto.PredmetNaSmjeru.Predmet.IdPredmeta);
                    cmd.Parameters.AddWithValue("@JMB", dto.Profesor.Osoba.JMB);
                    cmd.Parameters.AddWithValue("@BrojSedmicnihCasova", dto.BrojSedmicnihCasova);
                    if (cmd.ExecuteNonQuery() == 0)
                        return false;
                    else return true;

                }
            }
            catch (Exception e)
            {

                 new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();

                Trace.WriteLine(e);

            }
            return false;
        }

        public bool DeleteDTOById(Predaje dto)
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
                    cmd.Parameters.AddWithValue("@JMB", dto.Profesor.Osoba.JMB);
                    if (cmd.ExecuteNonQuery() == 0)
                        return false;
                    else return true;
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();

            }
            return false;
        }

        public Predaje GetDTO(Predaje dto)
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
                    cmd.Parameters.AddWithValue("@JMB", dto.Profesor.Osoba.JMB);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                        return new Predaje()
                        {
                            PredmetNaSmjeru = DAOFactory.Instance(DAOType.MySQL).PredmetiNaSmjeru.GetDTO(new PredmetNaSmjeru() { Predmet = new Predmet() { IdPredmeta = dto.PredmetNaSmjeru.Predmet.IdPredmeta }, Smjer = new Smjer() { IdSmjera = dto.PredmetNaSmjeru.Smjer.IdSmjera } }),
                            Profesor = DAOFactory.Instance(DAOType.MySQL).Profesori.GetDTO(new Profesor() { Osoba = new Osoba() { JMB = dto.Profesor.Osoba.JMB } }),
                            BrojSedmicnihCasova = reader.GetInt32(0)

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

        public List<Predaje> GetDTOList(PredmetNaSmjeru predmetNaSmjeru)
        {
            conn = null;
            cmd = null;
            reader = null;

            List<Predaje> predajeList = new List<Predaje>();
            try
            {
                using (conn = new MySqlConnection(MySqlUtil.connectionString))
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandText = SELECT_BY_PREDMET;
                    cmd.Parameters.AddWithValue("@IdSmjera", predmetNaSmjeru.Smjer.IdSmjera);
                    cmd.Parameters.AddWithValue("@IdPredmeta", predmetNaSmjeru.Predmet.IdPredmeta);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        predajeList.Add(new Predaje()
                        {
                            PredmetNaSmjeru = predmetNaSmjeru,
                            Profesor = DAOFactory.Instance(DAOType.MySQL).Profesori.GetDTO(new Profesor() { Osoba = new Osoba() { JMB = reader.GetString(0) } }),
                            BrojSedmicnihCasova = reader.GetInt32(1)


                        });
                    }
                }

            }
            catch (Exception e)
            {

                 new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();

            }
            return predajeList;
        }

        public bool UpdateDTO(Predaje dto)
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

                    cmd.Parameters.AddWithValue("@IdSmjera", dto.PredmetNaSmjeru.Smjer.IdSmjera);
                    cmd.Parameters.AddWithValue("@IdPredmeta", dto.PredmetNaSmjeru.Predmet.IdPredmeta);
                    cmd.Parameters.AddWithValue("@JMB", dto.Profesor.Osoba.JMB);
                    cmd.Parameters.AddWithValue("@BrojSedmicnihCasova", dto.BrojSedmicnihCasova);

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

        public List<Predaje> GetDTOList()
        {
            conn = null;
            cmd = null;
            reader = null;

            List<Predaje> predajeList = new List<Predaje>();
            try
            {
                using (conn = new MySqlConnection(MySqlUtil.connectionString))
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandText = SELECT_ALL;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        predajeList.Add(new Predaje()
                        {
                            PredmetNaSmjeru = DAOFactory.Instance(DAOType.MySQL).PredmetiNaSmjeru.GetDTO(new PredmetNaSmjeru() { Predmet = new Predmet() { IdPredmeta = reader.GetInt32(0) }, Smjer = new Smjer() { IdSmjera = reader.GetInt32(1) } }),
                            Profesor = DAOFactory.Instance(DAOType.MySQL).Profesori.GetDTO(new Profesor() { Osoba = new Osoba() { JMB = reader.GetString(2) } }),
                            BrojSedmicnihCasova = reader.GetInt32(3)


                        });
                    }
                }

            }
            catch (Exception e)
            {

                 new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();

            }
            return predajeList;
        }
    }
}
