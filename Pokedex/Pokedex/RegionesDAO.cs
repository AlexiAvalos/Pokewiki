using System.Collections.Generic;
using System.Data.SqlClient;

public class RegionDAO
{
    private string connectionString = "Data Source=DESKTOP-UBBP1OB\\NICO;Initial Catalog=PokeWiki;Integrated Security=True";

    public RegionDAO(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public List<string> ObtenerNombresRegiones()
    {
        List<string> nombresRegiones = new List<string>();

        string query = "SELECT Nombre FROM regiones"; 

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string nombre = reader["Nombre"].ToString();
                nombresRegiones.Add(nombre);
            }
            reader.Close();
        }

        return nombresRegiones;
    }

    public Regiones ObtenerRegionPorNombre(string nombre)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM regiones WHERE Nombre = @Nombre";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nombre", nombre);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Regiones
                {
                    IdRegion = reader.GetInt32(reader.GetOrdinal("IdRegion")),
                    Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                };
            }
        }
        return null;
    }
}
