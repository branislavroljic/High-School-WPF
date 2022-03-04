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
    public class MySqlUcenikDetaljno : IUcenikDetaljnoDAO
    {
        MySqlConnection? conn;
        MySqlCommand? cmd;
        MySqlDataReader? reader;


        private static readonly string SELECT = "Select JMB, Ime, Prezime, Skola, JIB, Smjer, IdSmjera, Razred, Odjeljenje, ProsjekOcjena from ucenik_detaljno";
        private static readonly string SELECT_ONE = "Select  Ime, Prezime, Skola, JIB, Smjer, IdSmjera, Razred, Odjeljenje, ProsjekOcjena from ucenik_detaljno where JMB=@JMB";

        public bool CreateDTO(UcenikDetaljno dto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDTOById(UcenikDetaljno dto)
        {
            throw new NotImplementedException();
        }

        public UcenikDetaljno GetDTO(UcenikDetaljno dto)
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
                    cmd.Parameters.AddWithValue("@JMB", dto.JMB);
                    cmd.CommandText = SELECT_ONE;
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new UcenikDetaljno()
                        {
                            JMB = dto.JMB,
                            Ime = reader.GetString(0),
                            Prezime = reader.GetString(1),
                            Skola = reader.GetString(2),
                            JIB = reader.GetString(3),
                            Smjer = reader.GetString(4),
                            IdsSmjera = reader.GetInt32(5),
                            Razred = reader.GetInt32(6),
                            Odjeljenje = reader.GetInt32(7),
                            Prosjek = reader.IsDBNull(8) ? 0.0 : reader.GetDouble(8)
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

        public List<UcenikDetaljno> GetDTOList()
        {

            conn = null;
            cmd = null;
            reader = null;

            List<UcenikDetaljno> ucenikDetaljnoList = new List<UcenikDetaljno>();
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
                        ucenikDetaljnoList.Add(new UcenikDetaljno()
                        {
                            JMB = reader.GetString(0),
                            Ime = reader.GetString(1),
                            Prezime = reader.GetString(2),
                            Skola = reader.GetString(3),
                            JIB = reader.GetString(4),
                            Smjer = reader.GetString(5),
                            IdsSmjera = reader.GetInt32(6),
                            Razred = reader.GetInt32(7),
                            Odjeljenje = reader.GetInt32(8),
                            Prosjek = reader.IsDBNull(9)?0.0:reader.GetDouble(9)
                        });
                    }
                }
            }
            catch (Exception e)
            {
                 new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();
            }
            return ucenikDetaljnoList;
        }

        public bool UpdateDTO(UcenikDetaljno dto)
        {
            throw new NotImplementedException();
        }
    }
}
