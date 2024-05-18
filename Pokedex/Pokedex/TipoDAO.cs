using System.Collections.Generic;
using System.Data.SqlClient;

public class TipoDAO
{
    private string connectionString = "Data Source=DESKTOP-UBBP1OB\\NICO;Initial Catalog=PokeWiki;Integrated Security=True";

    public TipoDAO(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public List<string> ObtenerNombresTipos()
    {
        List<string> nombresTipos = new List<string>();

        string query = "SELECT Nombre FROM tipos"; 

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string nombre = reader["Nombre"].ToString();
                nombresTipos.Add(nombre);
            }
            reader.Close();
        }

        return nombresTipos;
    }

    public Tipo ObtenerTipoPorNombre(string nombre)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM tipos WHERE Nombre = @Nombre";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nombre", nombre);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Tipo
                {
                    IdTipo = reader.GetInt32(reader.GetOrdinal("IdTipo")),
                    Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                };
            }
        }
        return null;
    }
}
