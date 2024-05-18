using Pokedex;
using System.Collections.Generic;
using System.Data.SqlClient;

public class ObjetoEvolutivoDAO
{
    private string connectionString = "Data Source=DESKTOP-UBBP1OB\\NICO;Initial Catalog=PokeWiki;Integrated Security=True";

    public ObjetoEvolutivoDAO(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public List<string> ObtenerNombresObjetosEvolutivos()
    {
        List<string> nombresObjetosEvolutivos = new List<string>();

        string query = "SELECT Nombre FROM Objectos_Evolutivos"; 

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string nombre = reader["Nombre"].ToString();
                nombresObjetosEvolutivos.Add(nombre);
            }
            reader.Close();
        }

        return nombresObjetosEvolutivos;
    }

    public ObjetoEvolutivo ObtenerObjetoEvolutivoPorNombre(string nombre)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Objectos_Evolutivos WHERE Nombre = @Nombre";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nombre", nombre);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new ObjetoEvolutivo
                {
                    IdObjectoEvolutivo = reader.GetInt32(reader.GetOrdinal("IdObjectoEvolutivo")),
                    Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                };
            }
        }
        return null;
    }
}
