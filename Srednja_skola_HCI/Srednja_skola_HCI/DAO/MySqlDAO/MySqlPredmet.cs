using MySql.Data.MySqlClient;
using Srednja_skola_HCI.Dialogs;
using Srednja_skola_HCI.DTO;
using Srednja_skola_HCI.Util.MySqlUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Srednja_skola_HCI.DAO.MySqlDAO
{
    internal class MySqlPredmet : IPredmetDAO
    {

        MySqlConnection? conn;
        MySqlCommand? cmd;
        MySqlDataReader? reader;

        private static readonly string SELECT = "SELECT IdPredmeta, Naziv FROM PREDMET";
        private static readonly string SELECT_ONE = "SELECT Naziv FROM PREDMET where IdPredmeta=@IdPredmeta";

        public Predmet GetDTO(Predmet dto)
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
                    cmd.Parameters.AddWithValue("@IdPredmeta", dto.IdPredmeta);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                      return new Predmet()
                        {

                            IdPredmeta = dto.IdPredmeta,
                            Naziv = reader.GetString(0)
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

        public List<Predmet> GetDTOList()
        {
            List<Predmet> result = new List<Predmet>();
            conn = null;
            cmd = null;
            reader = null;

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
                        result.Add(new Predmet()
                        {

                            IdPredmeta = reader.GetInt32(0),
                            Naziv = reader.GetString(1)
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

        public bool CreateDTO(Predmet dto)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDTO(Predmet dto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDTOById(Predmet dto)
        {
            throw new NotImplementedException();
        }
    }
}
