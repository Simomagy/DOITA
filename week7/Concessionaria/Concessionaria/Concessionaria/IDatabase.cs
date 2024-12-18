using Microsoft.Data.SqlClient;

namespace Utility
{
    /// <summary>
    /// Interfaccia che definisce i metodi per interagire con il database.
    /// </summary>
    public interface IDatabase
    {
        #region Metodi di Lettura

        /// <summary>
        /// Legge i dati dal database eseguendo un comando SQL.
        /// </summary>
        /// <param name="command">Il comando SQL da eseguire.</param>
        /// <returns>
        /// Una lista di dizionari, dove ogni dizionario rappresenta una riga del risultato
        /// e associa i nomi delle colonne ai rispettivi valori. Restituisce null se la query fallisce.
        /// </returns>
        /// <example>
        /// Esempio di utilizzo:
        /// <code>
        /// var db = new Database("NomeDelDatabase");
        /// var command = new SqlCommand("SELECT * FROM Users");
        /// var result = db.ReadDb(command);
        /// if (result != null)
        /// {
        ///     foreach (var row in result)
        ///     {
        ///         foreach (var column in row)
        ///         {
        ///             Console.WriteLine($"{column.Key}: {column.Value}");
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        List<Dictionary<string, string>>? ReadDb(SqlCommand command);

        /// <summary>
        /// Legge una singola riga dal database eseguendo un comando SQL.
        /// </summary>
        /// <param name="command">Il comando SQL da eseguire.</param>
        /// <returns>
        /// Un dizionario che rappresenta una singola riga del risultato,
        /// associando i nomi delle colonne ai rispettivi valori. Restituisce null se non viene trovata alcuna riga.
        /// </returns>
        Dictionary<string, string>? ReadOneDb(SqlCommand command);

        #endregion

        #region Metodi di Aggiornamento

        /// <summary>
        /// Esegue un comando SQL per aggiornare il database (INSERT, UPDATE o DELETE).
        /// </summary>
        /// <param name="command">Il comando SQL da eseguire.</param>
        /// <returns>True se l'operazione è andata a buon fine, altrimenti False.</returns>
        bool UpdateDb(SqlCommand command);

        #endregion
    }
}
