 using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex
{
    public class ObjetoDAL
    {
        public static int AgregarObjeto(objetoR objeto)
        {
            int retorna = 0;

            using (SqlConnection conn = RegistroObj.RealizarConexion())
            {
                string query = "insert into Objectos_Evolutivos ( Nombre, Descripcion) values('"+objeto.Nombre+"', '"+objeto.Descripcion+"')";
                SqlCommand comando = new SqlCommand(query, conn);
                retorna = comando.ExecuteNonQuery();
            }

            return retorna;
        }

        public static List<objetoR> mostrarRegistroObjetos()
        {
            List <objetoR> Lista = new List<objetoR>();
            using (SqlConnection conn = RegistroObj.RealizarConexion())
            {
                string query = "Select * from Objectos_Evolutivos";
                SqlCommand comando = new SqlCommand (query, conn);
                
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    objetoR objeto = new objetoR();
                    objeto.idObjectoEvolutivo = reader.GetInt32(0);
                    objeto.Nombre = reader.GetString(1);
                    objeto.Descripcion = reader.GetString(2);
                    Lista.Add(objeto);
                   
                }
                conn.Close();
                return Lista;
            }
        }

        public static int ModificarObjeto(objetoR objeto)
        {
            int result = 0;
            using (SqlConnection conn = RegistroObj.RealizarConexion())
            {
                string query = "update Objectos_Evolutivos set Nombre= '" + objeto.Nombre + "', Descripcion='" + objeto.Descripcion + "' where idObjectoEvolutivo= " + objeto.idObjectoEvolutivo + " ";
                SqlCommand comando = new SqlCommand (query, conn);

                result = comando.ExecuteNonQuery();
                conn.Close();
            } 
            return result;
        }

        public static int EliminarObjeto(int idObjectoEvolutivo)
        {
            int retorna = 0;

            using (SqlConnection conn = RegistroObj.RealizarConexion())
            {
                string query = "delete from Objectos_Evolutivos where idObjectoEvolutivo = "+idObjectoEvolutivo+" ";
                SqlCommand comando = new SqlCommand(query, conn);
                retorna = comando.ExecuteNonQuery();
            }

            return retorna;
        }
    }
}
