using Microsoft.Data.SqlClient;

namespace _02_Libreria_CRUD
{
    internal class Database
    {
        private SqlConnection Connection { get; set; }
        /// <summary>
        /// Costruttore della classe Database.
        /// </summary>
        /// <param name="nomeDB">
        /// contenente il nome del database a cui connettersi.
        /// </param>
        /// <param name="server">
        /// contenente il nome del server a cui connettersi.
        /// </param>
        /// <remarks>
        /// <see cref="SqlConnection"/> viene inizializzato con la stringa di connessione al database specificato.
        /// </remarks>
        public Database(string nomeDB, string server = "MSSTU")
        {
            Connection = new SqlConnection($"Server={server};Database={nomeDB};Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");
        }

        public bool Update(string query)
        {
            try
            {
                Connection.Open();
                SqlCommand cmd = new(query, Connection);
                int response = cmd.ExecuteNonQuery();
                return response > 0;
            } catch(SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            } finally
            {
                Connection.Close();
            }
        }
        /// <summary>
        /// Metodo che permette di leggere i record dal database.
        /// </summary>
        /// <remarks>
        /// Aggiunge i record letti in una <see cref="List{T}"/> di <see cref="Dictionary{TKey, TValue}"/>, dove la chiave è il nome della colonna e il valore è il valore della colonna.
        /// </remarks>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>> Read(string query)
        {
            List<Dictionary<string, string>> ris = [];

            Connection.Open();

            SqlCommand cmd = new(query, Connection);
            SqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                Dictionary<string, string> line = [];

                for(int i = 0; i < dr.FieldCount; i++)
                {
                    var value = dr.GetValue(i)?.ToString() ?? string.Empty;
                    line.Add(dr.GetName(i).ToLower(), value);
                }

                ris.Add(line);
            }

            Connection.Close();

            return ris;
        }
        /// <summary>
        /// Metodo che permette di leggere un solo record dal database.
        /// </summary>
        /// <remarks>
        /// <see cref="Read(string)"/> viene utilizzato per eseguire la query, in questo caso prendo solo il primo record restituito.
        /// </remarks>
        /// <param name="query"></param>
        /// <returns>Se la query restituisce almeno un record, restituisce il primo record, altrimenti <see langword="null"/>.</returns>
        public Dictionary<string, string>? ReadOne(string query)
        {
            try
            {
                return Read(query)[0];
            } catch
            {
                return null;
            }
        }
    }
}
