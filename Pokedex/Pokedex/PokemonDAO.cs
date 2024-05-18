using Pokedex;
using System.Collections.Generic;
using System.Data.SqlClient;

public class PokemonDAO
{
    private string connectionString;

    public PokemonDAO(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public List<string> ObtenerNombresPokemon()
    {
        List<string> nombresPokemon = new List<string>();

        string query = "SELECT Nombre FROM Pokemon";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                nombresPokemon.Add(reader["Nombre"].ToString());
            }
            reader.Close();
        }

        return nombresPokemon;
    }
    public List<string> ObtenerNombresRegiones()
    {
        List<string> nombresRegiones = new List<string>();

        string query = "SELECT Nombre FROM Regiones";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                nombresRegiones.Add(reader["Nombre"].ToString());
            }
            reader.Close();
        }

        return nombresRegiones;
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
    public List<string> ObtenerNombresTipos()
    {
        List<string> nombresTipos = new List<string>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Nombre FROM Tipos";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                nombresTipos.Add(reader["Nombre"].ToString());
            }
        }

        return nombresTipos;

    }
    public Pokemon ObtenerPokemonPorNombre(string nombre)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"
    SELECT p.*, c.Nombre AS NombreCategoria, h.Nombre AS NombreHabitat
    FROM Pokemon p
    JOIN Categorias c ON p.idCategoria = c.idCategoria
    JOIN Habitats h ON p.idHabitat = h.idHabitat
    WHERE p.Nombre = @Nombre";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nombre", nombre);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Pokemon
                {
                    IdPokemon = reader.GetInt32(reader.GetOrdinal("IdPokemon")),
                    Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                    Tipo = string.Join(", ", ObtenerTiposPokemon(reader.GetInt32(reader.GetOrdinal("IdPokemon")))),
                    Altura = reader.GetString(reader.GetOrdinal("Altura")),
                    Peso = reader.GetString(reader.GetOrdinal("Peso")),
                    Salud = int.TryParse(reader.GetString(reader.GetOrdinal("Salud")), out int salud) ? salud : 0,
                    Ataque = int.TryParse(reader.GetString(reader.GetOrdinal("Ataque")), out int ataque) ? ataque : 0,
                    Defensa = int.TryParse(reader.GetString(reader.GetOrdinal("Defensa")), out int defensa) ? defensa : 0,
                    Habitat = reader.GetString(reader.GetOrdinal("NombreHabitat")),
                    Generacion = reader.GetInt32(reader.GetOrdinal("idGeneracion")),
                    Categoria = reader.GetString(reader.GetOrdinal("NombreCategoria")),
                    
                };
            }
        }

        return null; 
    }

    private List<string> ObtenerTiposPokemon(int idPokemon)
    {
        List<string> tipos = new List<string>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"
        SELECT t.Nombre
        FROM Tipos t
        JOIN Tipos_Pokemons tp ON t.idTipo = tp.idTipo
        WHERE tp.idPokemon = @IdPokemon";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdPokemon", idPokemon);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (!reader.IsDBNull(reader.GetOrdinal("Nombre")))
                {
                    tipos.Add(reader.GetString(reader.GetOrdinal("Nombre")));
                }
            }
        }

        return tipos;
    }

   
  



}
