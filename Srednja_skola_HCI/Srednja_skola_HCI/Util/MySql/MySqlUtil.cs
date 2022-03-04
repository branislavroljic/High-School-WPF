using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srednja_skola_HCI.Util.MySqlUtil
{
    public class MySqlUtil
    {
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["srednja_skola_hci"].ConnectionString;

    }
}
