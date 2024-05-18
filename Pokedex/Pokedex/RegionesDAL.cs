using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex
{
    public class RegionesDAL
    {
        public static int AgregarRegion(RegionesCons region)
        {
            int retorna = 0;

            using (SqlConnection conn = RegistroObj.RealizarConexion())
            {
                string query = "insert into Regiones ( Nombre, Descripcion) values('" + region.Nombre + "', '" + region.Descripcion + "')";
                SqlCommand comando = new SqlCommand(query, conn);
                retorna = comando.ExecuteNonQuery();
            }

            return retorna;
        }

        //lista para el datagrid
        public static List<RegionesCons> mostrarRegistroRegiones()
        {
            List<RegionesCons> Lista = new List<RegionesCons>();
            using (SqlConnection conn = RegistroObj.RealizarConexion())
            {
                string query = "Select * from Regiones";
                SqlCommand comando = new SqlCommand(query, conn);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    RegionesCons region = new RegionesCons();
                    region.idRegion = reader.GetInt32(0);
                    region.Nombre = reader.GetString(1);
                    region.Descripcion = reader.GetString(2);
                    Lista.Add(region);

                }
                conn.Close();
                return Lista;
            }
        }
        //modificar la region

        public static int ModificarRegion(RegionesCons region)
        {
            int result = 0;
            using (SqlConnection conn = RegistroObj.RealizarConexion())
            {
                string query = "update Regiones set Nombre= '" + region.Nombre + "', Descripcion='" + region.Descripcion + "' where idRegion= " + region.idRegion + " ";
                SqlCommand comando = new SqlCommand(query, conn);

                result = comando.ExecuteNonQuery();
                conn.Close();
            }
            return result;
        }

        public static int EliminarRegion(int idRegion)
        {
            int retorna = 0;

            using (SqlConnection conn = RegistroObj.RealizarConexion())
            {
                string query = "delete from Regiones where idRegion = " + idRegion + " ";
                SqlCommand comando = new SqlCommand(query, conn);
                retorna = comando.ExecuteNonQuery();
            }

            return retorna;
        }
    }
}
