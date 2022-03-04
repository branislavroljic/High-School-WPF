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
    internal class MySqlProfesor : IProfesorDAO
    {
        MySqlConnection? conn;
        MySqlCommand? cmd;
        MySqlDataReader? reader;

        private static readonly string DELETE = "delete from profesor  where JMB=@JMB";

        private static readonly string SELECT = "select o.JMB as JMB, IME, PREZIME, DATUMRODJENJA, POL, ADRESA, MAIL_ADRESA, LOZINKA, VERIFIKOVAN, PLATA FROM PROFESOR p NATURAL INNER JOIN OSOBA o ";
        private static readonly string SELECT_ONE = "select IME, PREZIME, DATUMRODJENJA, POL, ADRESA, MAIL_ADRESA, LOZINKA, VERIFIKOVAN, PLATA FROM PROFESOR p NATURAL INNER JOIN OSOBA o where JMB=@JMB";

        private static readonly string SELECT_BY_MAIL_AND_PASS = "select JMB, IME, PREZIME, DATUMRODJENJA, POL, ADRESA,  VERIFIKOVAN, PLATA FROM PROFESOR p NATURAL INNER JOIN OSOBA o where mail_adresa=@mail_adresa and lozinka=@lozinka";

     
        public bool CreateDTO(Profesor dto)
        {
            conn = null;
            cmd = null;
            reader = null;

            try
            {   
                using (conn = new MySqlConnection(MySqlUtil.connectionString))
                {
                    conn.Open();
                    cmd = new MySqlCommand("dodaj_profesora", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pJMB", dto.Osoba.JMB);
                    cmd.Parameters.AddWithValue("@pIme", dto.Osoba.Ime);
                    cmd.Parameters.AddWithValue("@pPrezime", dto.Osoba.Prezime);
                    cmd.Parameters.AddWithValue("@pDatumRodjenja", dto.Osoba.DatumRodjenja);
                    cmd.Parameters.AddWithValue("@pPol", dto.Osoba.Pol.ToString());
                    cmd.Parameters.AddWithValue("@pAdresa", dto.Osoba.Adresa);
                    cmd.Parameters.AddWithValue("@pMail_Adresa", dto.Osoba.MailAdresa);
                    cmd.Parameters.AddWithValue("@pLozinka", dto.Osoba.Lozinka);
                    cmd.Parameters.AddWithValue("@pVerifikovan", dto.Verifikovan);
                    cmd.Parameters.AddWithValue("@pPlata", dto.Plata);

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

        public bool DeleteDTOById(Profesor dto)
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
                    cmd.Parameters.AddWithValue("@JMB", dto.Osoba.JMB);
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

        public Profesor GetDTO(Profesor dto)
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
                    cmd.Parameters.AddWithValue("@JMB", dto.Osoba.JMB);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Enum.TryParse(reader.GetString(3), out Pol pol);
                        return new Profesor()
                        {
                            Osoba = new Osoba() { JMB = dto.Osoba.JMB, Ime = reader.GetString(0), Prezime = reader.GetString(1), DatumRodjenja = reader.GetDateTime(2).Date, Pol = pol, Adresa = reader.GetString(4), MailAdresa = reader.GetString(5), Lozinka = reader.GetString(6) },
                            Verifikovan = reader.GetByte(7) == 1 ? true : false,
                            Plata = reader.GetDecimal(8)
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

        public List<Profesor> GetDTOList()
        {

            conn = null;
            cmd = null;
            reader = null;

            List<Profesor> profesorList = new List<Profesor>();
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
                        Enum.TryParse(reader.GetString(4), out Pol pol);

                        string Lozinka = "";
                        for (int i = 0; i < reader.GetString(7).Length; i++)
                        {
                            Lozinka += "*";
                        }
                        profesorList.Add(new Profesor()
                        { 
                            Osoba = new Osoba() { JMB = reader.GetString(0), Ime = reader.GetString(1), Prezime = reader.GetString(2), DatumRodjenja = reader.GetDateTime(3).Date, Pol = pol, Adresa = reader.GetString(5), MailAdresa = reader.GetString(6), Lozinka = Lozinka },
                            Verifikovan = reader.GetByte(8) == 1 ? true:false,
                            Plata = reader.GetDecimal(9)
                        }); 

                    }
                }
            }
            catch (Exception e)
            {
               new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();
            }
            return profesorList;
        }

        public bool UpdateDTO(Profesor dto)
        {
            conn = null;
            cmd = null;
            reader = null;

            try
            {
                using (conn = new MySqlConnection(MySqlUtil.connectionString))
                {
                    conn.Open();
                    cmd = new MySqlCommand("azuriraj_profesora", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pJMB", dto.Osoba.JMB);
                    cmd.Parameters.AddWithValue("@pIme", dto.Osoba.Ime);
                    cmd.Parameters.AddWithValue("@pPrezime", dto.Osoba.Prezime);
                    cmd.Parameters.AddWithValue("@pDatumRodjenja", dto.Osoba.DatumRodjenja);
                    cmd.Parameters.AddWithValue("@pPol", dto.Osoba.Pol.ToString());
                    cmd.Parameters.AddWithValue("@pAdresa", dto.Osoba.Adresa);
                    cmd.Parameters.AddWithValue("@pMail_Adresa", dto.Osoba.MailAdresa);
                    cmd.Parameters.AddWithValue("@pLozinka", dto.Osoba.Lozinka);
                    cmd.Parameters.AddWithValue("@pVerifikovan", Convert.ToByte(dto.Verifikovan));
                    cmd.Parameters.AddWithValue("@pPlata", dto.Plata);

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

        public Profesor getProfesorByMailAndPassword(string mail, string password)
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
                        cmd.CommandText = SELECT_BY_MAIL_AND_PASS;
                        cmd.Parameters.AddWithValue("@mail_adresa", mail);
                        cmd.Parameters.AddWithValue("@lozinka",password);
                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            Enum.TryParse(reader.GetString(4), out Pol pol);
                            return new Profesor()
                            {
                                Osoba = new Osoba() { JMB = reader.GetString(0), Ime = reader.GetString(1), Prezime = reader.GetString(2), DatumRodjenja = reader.GetDateTime(3).Date, Pol = pol, Adresa = reader.GetString(5),  },
                                Verifikovan = reader.GetByte(6) == 1 ? true : false,
                                Plata = reader.GetDecimal(7)
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
        
        
    }
}
