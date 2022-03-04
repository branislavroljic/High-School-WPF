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

namespace Srednja_skola_HCI.DAO.MySQLDAO
{
    public class MySqlSkola : ISkolaDAO
    {
        MySqlConnection? conn;
        MySqlCommand? cmd;
        MySqlDataReader? reader;


        private static readonly string SELECT = "SELECT JIB, Naziv, mail_adresa, Vrsta, Adresa, Telefon FROM SKOLA ORDER BY Naziv";
        private static readonly string INSERT = "INSERT INTO SKOLA (JIB, Naziv, mail_adresa, Vrsta, Adresa, Telefon)  values (@JIB, @Naziv, @mail_adresa, @Vrsta, @Adresa, @Telefon)";
        private static readonly string DELETE = "DELETE FROM SKOLA WHERE JIB = @JIB";
        private static readonly string UPDATE = "UPDATE SKOLA SET  Naziv=@Naziv, mail_adresa=@mail_adresa, Vrsta=@Vrsta, Adresa=@Adresa, Telefon=@Telefon WHERE JIB=@JIB";

        private static readonly string SELECT_ONE = "SELECT Naziv, mail_adresa, Vrsta, Adresa, Telefon FROM SKOLA WHERE JIB=@JIB";
        public Boolean CreateSkola(Skola skola)
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
                    cmd.Parameters.AddWithValue("@JIB", skola.JIB);
                    cmd.Parameters.AddWithValue("@Naziv", skola.Naziv);
                    cmd.Parameters.AddWithValue("@mail_adresa", skola.MailAdresa);
                    cmd.Parameters.AddWithValue("@Vrsta", skola.Vrsta);
                    cmd.Parameters.AddWithValue("@Adresa", skola.Adresa);
                    cmd.Parameters.AddWithValue("@Telefon", skola.Telefon);
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

        public bool DeleteSkolaByJIB(string JIB)
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
                    cmd.Parameters.AddWithValue("@JIB", JIB);
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

        public List<Skola> GetSkole()
        {
            List<Skola> result = new List<Skola>();
            conn = null;
            cmd = null;
            reader = null;

            try
            {
                using (conn = new MySqlConnection(MySqlUtil.connectionString))
                {
                    conn.Open();
                    Trace.WriteLine("Kon string:" + MySqlUtil.connectionString);
                    cmd = conn.CreateCommand();
                    cmd.CommandText = SELECT;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new Skola()
                        {
                            JIB = reader.GetString(0),
                            Naziv = reader.GetString(1),
                            MailAdresa = reader.GetString(2),
                            Vrsta = reader.GetString(3),
                            Adresa = reader.GetString(4),
                            Telefon = reader.GetString(5)
                        });
                    }
                }
            }
            catch (Exception e)
            {
                 new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();
            }

            return result;

        }

        public bool UpdateSkola(Skola updatedSkola)
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

                    cmd.Parameters.AddWithValue("@JIB", updatedSkola.JIB);
                    cmd.Parameters.AddWithValue("@Naziv", updatedSkola.Naziv);
                    cmd.Parameters.AddWithValue("@mail_adresa", updatedSkola.MailAdresa);
                    cmd.Parameters.AddWithValue("@Vrsta", updatedSkola.Vrsta);
                    cmd.Parameters.AddWithValue("@Adresa", updatedSkola.Adresa);
                    cmd.Parameters.AddWithValue("@Telefon", updatedSkola.Telefon);
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

        public Skola getSkola(string JIB)
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
                    cmd.Parameters.AddWithValue("@JIB", JIB);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Skola()
                        {
                            JIB = reader.GetString(0),
                            Naziv = reader.GetString(1),
                            MailAdresa = reader.GetString(2),
                            Vrsta = reader.GetString(3),
                            Adresa = reader.GetString(4),
                            Telefon = reader.GetString(5)
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


        public Skola GetDTO(Skola dto)
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
                    cmd.Parameters.AddWithValue("@JIB", dto.JIB);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Skola()
                        {
                            Naziv = reader.GetString(0),
                            MailAdresa = reader.GetString(1),
                            Vrsta = reader.GetString(2),
                            Adresa = reader.GetString(3),
                            Telefon = reader.GetString(4),
                            JIB = dto.JIB
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

        public List<Skola> GetDTOList()
        {
            List<Skola> result = new List<Skola>();
            conn = null;
            cmd = null;
            reader = null;

            try
            {
                using (conn = new MySqlConnection(MySqlUtil.connectionString))
                {
                    conn.Open();
                    Trace.WriteLine("Kon string:" + MySqlUtil.connectionString);
                    cmd = conn.CreateCommand();
                    cmd.CommandText = SELECT;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new Skola()
                        {
                            JIB = reader.GetString(0),
                            Naziv = reader.GetString(1),
                            MailAdresa = reader.GetString(2),
                            Vrsta = reader.GetString(3),
                            Adresa = reader.GetString(4),
                            Telefon = reader.GetString(5)
                        });
                    }
                }
            }
            catch (Exception e)
            {
                 new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();
            }

            return result;
        }

        public bool CreateDTO(Skola dto)
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
                    cmd.Parameters.AddWithValue("@JIB", dto.JIB);
                    cmd.Parameters.AddWithValue("@Naziv", dto.Naziv);
                    cmd.Parameters.AddWithValue("@mail_adresa", dto.MailAdresa);
                    cmd.Parameters.AddWithValue("@Vrsta", dto.Vrsta);
                    cmd.Parameters.AddWithValue("@Adresa", dto.Adresa);
                    cmd.Parameters.AddWithValue("@Telefon", dto.Telefon);
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

        public bool UpdateDTO(Skola dto)
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

                    cmd.Parameters.AddWithValue("@JIB", dto.JIB);
                    cmd.Parameters.AddWithValue("@Naziv", dto.Naziv);
                    cmd.Parameters.AddWithValue("@mail_adresa", dto.MailAdresa);
                    cmd.Parameters.AddWithValue("@Vrsta", dto.Vrsta);
                    cmd.Parameters.AddWithValue("@Adresa", dto.Adresa);
                    cmd.Parameters.AddWithValue("@Telefon", dto.Telefon);
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

        public bool DeleteDTOById(Skola dto)
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
                    cmd.Parameters.AddWithValue("@JIB", dto.JIB);
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
