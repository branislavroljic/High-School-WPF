using MySql.Data.MySqlClient;
using Srednja_skola_HCI.Dialogs;
using Srednja_skola_HCI.DTO;
using Srednja_skola_HCI.Forms;
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
    public class MySqlRadiProvjeru : IRadiProvjeruDAO
    {

        MySqlConnection? conn;
        MySqlCommand? cmd;
        MySqlDataReader? reader;

        private static readonly string SELECT = "SELECT pns.IdPredmeta, pns.IdSmjera, prov.Datum, rp.Ocjena FROM srednja_skola_hci.provjera prov natural inner join predaje p inner join predmet_na_smjeru pns on pns.IdPredmeta = p.IdPredmeta and pns.IdSmjera = p.IdSmjera left outer join radi_provjeru rp on rp.Datum = prov.Datum and rp.IdPredmeta = prov.IdPredmeta and rp.IdSmjera = prov.IdSmjera and rp.UCENIK_JMB = @UcenikJMB where p.PROFESOR_JMB = @PROFESOR_JMB and pns.Razred = @Razred and prov.Odjeljenje = @Odjeljenje ";

        private static readonly string UPDATE = "update radi_provjeru set Ocjena = @Ocjena where datum = @Datum and idPredmeta = @IdPredmeta and IdSmjera = @IdSmjera and Odjeljenje = @Odjeljenje and UCENIK_JMB=@UcenikJMB";

        private static readonly string INSERT = "insert into radi_provjeru values(@Datum, @IdPredmeta, @IdSmjera, @Odjeljenje, @Ocjena, @UcenikJMB)";

        public List<RadiProvjeru> GetDTOList(String profesorJMB, UcenikDetaljno ucenikDetaljno)
        {
            conn = null;
            cmd = null;
            reader = null;

            List<RadiProvjeru> provjereList = new List<RadiProvjeru>();
            try
            {
                using (conn = new MySqlConnection(MySqlUtil.connectionString))
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandText = SELECT;
                    cmd.Parameters.AddWithValue("@PROFESOR_JMB", profesorJMB);
                    cmd.Parameters.AddWithValue("@Razred", ucenikDetaljno.Razred);
                    cmd.Parameters.AddWithValue("@Odjeljenje", ucenikDetaljno.Odjeljenje);
                    cmd.Parameters.AddWithValue("@UcenikJMB", ucenikDetaljno.JMB);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Trace.WriteLine((reader.IsDBNull(3) ? Ocjena.NEOCIJENJEN : (Ocjena)reader.GetByte(3)));
                        provjereList.Add(new RadiProvjeru()
                        {
                            Provjera = DAOFactory.Instance(DAOType.MySQL).Provjere.GetDTO(new Provjera() { Odjeljenje = ucenikDetaljno.Odjeljenje, Datum = reader.GetDateTime(2), PredmetNaSmjeru = DAOFactory.Instance(DAOType.MySQL).PredmetiNaSmjeru.GetDTO(new PredmetNaSmjeru() { Predmet = new Predmet() { IdPredmeta = reader.GetInt32(0) }, Smjer = new Smjer() { IdSmjera = reader.GetInt32(1) } }) }) ,
                            Ocjena = reader.IsDBNull(3)?Ocjena.NEOCIJENJEN:(Ocjena)reader.GetByte(3),
                            UcenikDetaljno = ucenikDetaljno

                        });;

                    }
                }
            }
            catch (Exception e)
            {

                 new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();

            }
            return provjereList;
        }

        public RadiProvjeru GetDTO(RadiProvjeru dto)
        {
            throw new NotImplementedException();
        }

        public List<RadiProvjeru> GetDTOList()
        {
            throw new NotImplementedException();
        }

        public bool CreateDTO(RadiProvjeru dto)
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

                    cmd.Parameters.AddWithValue("@Ocjena", dto.Ocjena == Ocjena.NEOCIJENJEN ? DBNull.Value : ((byte)dto.Ocjena));
                    cmd.Parameters.AddWithValue("@IdPredmeta", dto.Provjera.PredmetNaSmjeru.Predmet.IdPredmeta);
                    cmd.Parameters.AddWithValue("@IdSmjera", dto.Provjera.PredmetNaSmjeru.Smjer.IdSmjera);
                    cmd.Parameters.AddWithValue("@Odjeljenje", dto.Provjera.Odjeljenje);
                    cmd.Parameters.AddWithValue("@Datum", dto.Provjera.Datum);
                    cmd.Parameters.AddWithValue("@UcenikJMB", dto.UcenikDetaljno.JMB);

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

        public bool UpdateDTO(RadiProvjeru dto)
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

                    cmd.Parameters.AddWithValue("@Ocjena", dto.Ocjena == Ocjena.NEOCIJENJEN ? DBNull.Value : ((byte)dto.Ocjena));
                    cmd.Parameters.AddWithValue("@IdPredmeta", dto.Provjera.PredmetNaSmjeru.Predmet.IdPredmeta);
                    cmd.Parameters.AddWithValue("@IdSmjera", dto.Provjera.PredmetNaSmjeru.Smjer.IdSmjera);
                    cmd.Parameters.AddWithValue("@Odjeljenje", dto.Provjera.Odjeljenje);
                    cmd.Parameters.AddWithValue("@UcenikJMB", dto.UcenikDetaljno.JMB);
                    cmd.Parameters.AddWithValue("@Datum", dto.Provjera.Datum);

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
            throw new NotImplementedException();
        }

        public bool DeleteDTOById(RadiProvjeru dto)
        {
            throw new NotImplementedException();
        }

    }
}
