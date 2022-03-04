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
using System.Windows.Controls;

namespace Srednja_skola_HCI.DAO.MySqlDAO
{
    public class MySqlSmjer : ISmjerDAO
    {

        MySqlConnection? conn;
        MySqlCommand? cmd;
        MySqlDataReader? reader;


        private static readonly string INSERT = "insert into smjer values (@IdSmjera, @Trajanje_Godina, @Naziv, @SKOLA_JIB, @Zvanje)";
        private static readonly string DELETE = "DELETE FROM smjer WHERE IdSmjera=@IdSmjera";


        private static readonly string UPDATE = "update smjer set Trajanje_Godina=@Trajanje_Godina, Naziv=@Naziv, SKOLA_JIB=@SKOLA_JIB, Zvanje=@Zvanje where IdSmjera=@IdSmjera";

        private static readonly string SELECT = "SELECT IdSmjera, Trajanje_Godina, Naziv, Zvanje, skola_jib from smjer";
        private static readonly string SELECT_ONE = "SELECT Trajanje_Godina, Naziv, Zvanje, skola_jib FROM SMJER WHERE IdSmjera=@IdSmjera";
        
        public Smjer GetDTO(Smjer dto)
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
                    cmd.Parameters.AddWithValue("@IdSmjera", dto.IdSmjera);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                       Smjer s =  new Smjer()
                        {
                            TrajanjeGodina = reader.GetInt32(0),
                            Naziv = reader.GetString(1),
                            Zvanje = reader.GetString(2),
                            IdSmjera = dto.IdSmjera,
                            Skola =  DAOFactory.Instance(DAOType.MySQL).Skole.GetDTO(new Skola() { JIB = reader.GetString(3) })

                        };

                        return s;
                    }
                }
            }
            catch (Exception e)
            {

                 new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();

            }
            return null;
        }

        public List<Smjer> GetDTOList()
        {
            conn = null;
            cmd = null;
            reader = null;

            List<Smjer> smjerList = new List<Smjer>();
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

                        smjerList.Add(new Smjer()
                        {

                            IdSmjera = reader.GetInt32(0),
                            TrajanjeGodina = reader.GetInt32(1),
                            Naziv = reader.GetString(2),
                            Zvanje = reader.GetString(3),
                            Skola = DAOFactory.Instance(DAOType.MySQL).Skole.GetDTO(new Skola() { JIB = reader.GetString(4) })

                        });

                    }
                }
            }
            catch (Exception e)
            {

                 new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();

            }
            return smjerList;
        }

        public bool CreateDTO(Smjer dto)
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
                    cmd.Parameters.AddWithValue("@IdSmjera", dto.IdSmjera);
                    cmd.Parameters.AddWithValue("@Trajanje_Godina", dto.TrajanjeGodina);
                    cmd.Parameters.AddWithValue("@Naziv", dto.Naziv);
                    cmd.Parameters.AddWithValue("@SKOLA_JIB", dto.Skola.JIB);
                    cmd.Parameters.AddWithValue("@Zvanje", dto.Zvanje);
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

        public bool UpdateDTO(Smjer dto)
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

                    cmd.Parameters.AddWithValue("@IdSmjera", dto.IdSmjera);
                    cmd.Parameters.AddWithValue("@Trajanje_Godina", dto.TrajanjeGodina);
                    cmd.Parameters.AddWithValue("@Naziv", dto.Naziv);
                    cmd.Parameters.AddWithValue("@SKOLA_JIB", dto.Skola.JIB);
                    cmd.Parameters.AddWithValue("@Zvanje", dto.Zvanje);

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

        public bool DeleteDTOById(Smjer dto)
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
                    cmd.Parameters.AddWithValue("@IdSmjera", dto.IdSmjera);
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
