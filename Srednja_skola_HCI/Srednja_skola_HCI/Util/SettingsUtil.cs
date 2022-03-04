using MySql.Data.MySqlClient;
using Srednja_skola_HCI.Dialogs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Srednja_skola_HCI.Util
{

    public enum SettingType
    {
        THEME, LANG
    }

    public class SettingsUtil
    {
        private static readonly string SELECT_THEME = "select tema from osoba where JMB=@JMB";
        private static readonly string SELECT_LANG = "select jezik from osoba where JMB=@JMB";
        private static readonly string UPDATE_THEME = "update osoba set tema=@tema where JMB=@JMB";
        private static readonly string UPDATE_LANG = "update osoba set jezik=@jezik where JMB=@JMB";
        static MySqlConnection? conn;
        static MySqlCommand? cmd;
        static MySqlDataReader? reader;
        public static string ReadSetting(SettingType settingType, string JMB)
        {

            conn = null;
            cmd = null;
            reader = null;

            try
            {
                using (conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["srednja_skola_hci"].ConnectionString))
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandText = settingType.Equals(SettingType.LANG) ? SELECT_LANG : SELECT_THEME;
                    cmd.Parameters.AddWithValue("@JMB", JMB);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader.GetString(0);
                    }
                }
            }
            catch (Exception e)
            {

                 new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();

            }
            return null;
        }


        public static void SaveSetting(SettingType settingType, string settingValue, string JMB)
        {

            conn = null;
            cmd = null;
            reader = null;

            try
            {
                using (conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["srednja_skola_hci"].ConnectionString))
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    if (settingType.Equals(SettingType.LANG))
                    {
                        cmd.CommandText = UPDATE_LANG;
                        cmd.Parameters.AddWithValue("@jezik", settingValue);
                    }
                    else
                    {
                        cmd.CommandText = UPDATE_THEME;
                        cmd.Parameters.AddWithValue("@tema", settingValue);
                    }
                    cmd.Parameters.AddWithValue("@JMB", JMB);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

                 new ErrorDialog(Properties.Resources.ExceptionMessage).ShowDialog();

            }
            
        }
    }
}
   