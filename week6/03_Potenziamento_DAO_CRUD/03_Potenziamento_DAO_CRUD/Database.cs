using Microsoft.Data.SqlClient;

namespace _03_Potenziamento_DAO_CRUD
{
    internal class Database
    {
        SqlConnection Connection { get; set; }

        public Database(string nomeDB, string server = "MSSTU")
        {
            Connection = new SqlConnection($"Data Source={server};Initial Catalog={nomeDB};Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");

            if(CreateTable())
                Console.WriteLine("Creazione tabella con successo");
        }

        /// <summary>
        /// Crea una tabella nel database con i seguenti campi:
        /// <list type="bullet">
        /// <item>
        /// <term>Id <see langword="int"/> PRIMARY KEY</term>
        /// <description>Chiave primaria della tabella</description>
        /// </item>
        /// <item>
        /// <term>Title <see langword="string"/> </term>
        /// <description>Nome del videogioco</description>
        /// </item>
        /// <item>
        /// <term>Genre <see langword="string"/> </term>
        /// <description>Genere del videogioco</description>
        /// </item>
        /// <item>
        /// <term>ReleaseYear <see langword="int"/> </term>
        /// <description>Anno di uscita del videogioco</description>
        /// </item>
        /// <item>
        /// <term>Developer <see langword="string"/> </term>
        /// <description>Casa produttrice del videogioco</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// La query contiene <c>IF NOT EXISTS</c> per evitare che la tabella venga creata se già esiste
        /// </remarks>
        /// <returns><see langword="true"/> se la tabella è stata creata con successo, <see langword="false"/> altrimenti</returns>
        private bool CreateTable()
        {
            string query =
                "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Videogames' AND xtype='U') " +
                "CREATE TABLE Videogames (Id INT PRIMARY KEY IDENTITY(1,1),Title VARCHAR(200),Genre VARCHAR(200),ReleaseYear INT,Developer VARCHAR(300))";
            try
            {
                Connection.Open();

                SqlCommand cmd = new(query, Connection);

                int response = cmd.ExecuteNonQuery();

                return response > 0;
            } catch(SqlException e)
            {
                Console.WriteLine($"{e.Message}\n {query} ");

                return false;
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            } finally
            {
                Connection.Close();

            }

        }

        /// <summary>
        /// Metodo che legge i record di una tabella del database
        /// </summary>
        /// <remarks>
        /// Legge i record e li aggiunge a una <see cref="List{T}"/> di <see cref="Dictionary{TKey, TValue}"/> dove la key è il nome della colonna
        /// e il valore è il valore in essa 
        /// </remarks>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>>? ReadDb(string query)
        {
            try
            {

                List<Dictionary<string, string>> ris = [];

                Connection.Open();

                SqlCommand cmd = new(query, Connection);

                SqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    Dictionary<string, string> linea = [];

                    for(int i = 0; i < dr.FieldCount; i++)
                    {

                        var valore = dr.GetValue(i)?.ToString() ?? string.Empty;

                        linea.Add(dr.GetName(i).ToLower(), valore);
                    }
                    ris.Add(linea);

                }
                return ris;
            } catch (SqlException e)
            {
                Console.WriteLine($"{e.Message}\n {query} ");
                return null;
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            } finally
            {
                Connection.Close();
            }
        }

        /// <summary>
        /// Esegue una query di inserimento nel database
        /// </summary>
        /// <param name="query"></param>
        /// <returns><see langword="true"/> se l'inserimento è andato a buon fine, <see langword="false"/> altrimenti</returns>
        public bool UpdateDb(string query)
        {
            try
            {

                Connection.Open();

                SqlCommand cmd = new(query, Connection);

                int response = cmd.ExecuteNonQuery();

                return response > 0;

            } catch(SqlException e)
            {
                Console.WriteLine($"{e.Message}\n {query} ");

                return false;
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            } finally
            {
                Connection.Close();

            }
        }

        /// <summary>
        /// Esegue una query di lettura nel database e restituisce il primo record
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Un <see cref="Dictionary{TKey, TValue}"/> con i valori del primo record, <see langword="null"/> se non ci sono record</returns>
        public Dictionary<string, string>? ReadOneDb(string query)
        {
            try
            {
                var result = ReadDb(query);
                return result?.FirstOrDefault();
            } catch
            {
                return null;
            }
        }

    }
}
