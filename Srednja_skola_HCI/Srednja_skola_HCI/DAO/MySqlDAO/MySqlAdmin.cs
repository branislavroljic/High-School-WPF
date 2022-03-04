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
    internal class MySqlAdmin : IAdminDAO
    {
        MySqlConnection? conn;
        MySqlCommand? cmd;
        MySqlDataReader? reader;

        private static readonly string SELECT_ALL = "select o.JMB as JMB, MAIL_ADRESA, LOZINKA FROM ADMIN NATURAL INNER JOIN OSOBA o ";

        public bool CreateDTO(Admin dto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDTOById(Admin dto)
        {
            throw new NotImplementedException();
        }

        public Admin GetDTO(Admin dto)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetDTOList()
        {
            conn = null;
            cmd = null;
            reader = null;

            List<Admin> adminList = new List<Admin>();
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


                        adminList.Add(new Admin()
                        {
                            Osoba = new Osoba() { JMB = reader.GetString(0), MailAdresa = reader.GetString(1), Lozinka = reader.GetString(2)}
                        });

                    }
                }
            }
            catch (Exception e)
            {
                new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();
            }
            return adminList;
        }

        public bool UpdateDTO(Admin dto)
        {
            throw new NotImplementedException();
        }
    }
}
