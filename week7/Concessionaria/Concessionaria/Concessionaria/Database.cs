using Microsoft.Data.SqlClient;

namespace Utility
{
    /// <summary>
    /// Classe che fornisce metodi per interagire con un database SQL Server.
    /// </summary>
    public class Database : IDatabase
    {
        #region Proprietà

        /// <summary>
        /// Connessione al database SQL Server.
        /// </summary>
        public SqlConnection Connection { get; set; }

        #endregion

        #region Costruttori

        /// <summary>
        /// Inizializza una nuova istanza della classe Database con una connessione esistente.
        /// </summary>
        /// <param name="connection">La connessione SQL esistente.</param>
        public Database(SqlConnection connection) => Connection = connection;

        /// <summary>
        /// Inizializza una nuova istanza della classe Database con i dettagli del database.
        /// </summary>
        /// <param name="nomeDB">Il nome del database.</param>
        /// <param name="server">Il nome del server. Valore predefinito è "localhost".</param>
        public Database(string nomeDB, string server = "localhost")
        {
            Connection = new SqlConnection($"Server={server};Database={nomeDB};Integrated Security=true;TrustServerCertificate=true;");
        }

        #endregion

        #region Metodi Pubblici

        /// <summary>
        /// Legge i dati dal database eseguendo un comando SQL.
        /// </summary>
        /// <param name="command">Il comando SQL da eseguire.</param>
        /// <returns>
        /// Una lista di dizionari, dove ogni dizionario rappresenta una riga del risultato
        /// e associa i nomi delle colonne ai rispettivi valori. Restituisce null se la query fallisce.
        /// </returns>
        public List<Dictionary<string, string>>? ReadDb(SqlCommand command)
        {
            try
            {
                List<Dictionary<string, string>> response = new List<Dictionary<string, string>>();
                command.Connection = Connection;
                Connection.Open();
                using SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Dictionary<string, string> line = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        string key = dr.GetName(i).ToLower();
                        if (!line.ContainsKey(key))
                        {
                            var value = dr.GetValue(i)?.ToString() ?? string.Empty;
                            line.Add(key, value);
                        }
                        else
                        {
                            Console.WriteLine($"Duplicate key detected: {key}. Skipping...");
                        }
                    }
                    response.Add(line);
                }
                return response;
            }
            catch (SqlException e)
            {
                Console.WriteLine($"{e.Message}\n {command.CommandText} ");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }

        /// <summary>
        /// Esegue un comando SQL per aggiornare il database (INSERT, UPDATE o DELETE).
        /// </summary>
        /// <param name="command">Il comando SQL da eseguire.</param>
        /// <returns>True se l'operazione è andata a buon fine, altrimenti False.</returns>
        public bool UpdateDb(SqlCommand command)
        {
            try
            {
                command.Connection = Connection;
                Connection.Open();
                int response = command.ExecuteNonQuery();
                return response > 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine($"{e.Message}\n {command.CommandText} ");
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }

        /// <summary>
        /// Legge una singola riga dal database eseguendo un comando SQL.
        /// </summary>
        /// <param name="command">Il comando SQL da eseguire.</param>
        /// <returns>
        /// Un dizionario che rappresenta una singola riga del risultato,
        /// associando i nomi delle colonne ai rispettivi valori. Restituisce null se non viene trovata alcuna riga.
        /// </returns>
        public Dictionary<string, string>? ReadOneDb(SqlCommand command)
        {
            try
            {
                var result = ReadDb(command);
                return result?.FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Legge i dati dal database eseguendo una query SQL.
        /// </summary>
        /// <param name="query">La query SQL da eseguire.</param>
        /// <returns>
        /// Una lista di dizionari, dove ogni dizionario rappresenta una riga del risultato
        /// e associa i nomi delle colonne ai rispettivi valori. Restituisce null se la query fallisce.
        /// </returns>
        public List<Dictionary<string, string>>? ReadDb(string query)
        {
            using var command = new SqlCommand(query, Connection);
            return ReadDb(command);
        }

        /// <summary>
        /// Esegue una query SQL per aggiornare il database (INSERT, UPDATE o DELETE).
        /// </summary>
        /// <param name="query">La query SQL da eseguire.</param>
        /// <returns>True se l'operazione è andata a buon fine, altrimenti False.</returns>
        public bool UpdateDb(string query)
        {
            using var command = new SqlCommand(query, Connection);
            return UpdateDb(command);
        }

        /// <summary>
        /// Legge una singola riga dal database eseguendo una query SQL.
        /// </summary>
        /// <param name="query">La query SQL da eseguire.</param>
        /// <returns>
        /// Un dizionario che rappresenta una singola riga del risultato,
        /// associando i nomi delle colonne ai rispettivi valori. Restituisce null se non viene trovata alcuna riga.
        /// </returns>
        public Dictionary<string, string>? ReadOneDb(string query)
        {
            using var command = new SqlCommand(query, Connection);
            return ReadOneDb(command);
        }

        /// <summary>
        /// Esegue un comando SQL scalar e restituisce il risultato.
        /// </summary>
        /// <param name="command">Il comando SQL da eseguire.</param>
        /// <returns>Il risultato dell'esecuzione del comando SQL scalar.</returns>
        public object ReadScalar(SqlCommand command)
        {
            try
            {
                command.Connection = Connection;
                Connection.Open();
                var result = command.ExecuteScalar();
                return result;
            }
            catch (SqlException e)
            {
                Console.WriteLine($"{e.Message}\n {command.CommandText}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }

        #endregion
    }
}
