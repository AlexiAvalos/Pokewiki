using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex
{
    public class RegistroObj
    {
        public static SqlConnection RealizarConexion()
        {
            SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=PokeWiki;Data Source=DESKTOP-UBBP1OB\\NICO");
            conn.Open();
            return conn;
        }
    }
}
