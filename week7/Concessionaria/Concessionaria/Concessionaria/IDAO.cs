namespace Utility
{
    /// <summary>
    /// Interfaccia che definisce le operazioni di base per l'accesso ai dati (CRUD).
    /// </summary>
    public interface IDAO
    {
        #region Metodi di Lettura

        /// <summary>
        /// Recupera tutti i record dal database.
        /// </summary>
        /// <returns>Una lista di entità contenenti tutti i record.</returns>
        List<Entity> GetRecords();

        /// <summary>
        /// Trova un record specifico nel database tramite il suo ID.
        /// </summary>
        /// <param name="recordId">L'ID del record da cercare.</param>
        /// <returns>L'entità trovata, o null se non esiste alcun record con l'ID specificato.</returns>
        Entity? FindRecord(int recordId);

        #endregion

        #region Metodi di Scrittura

        /// <summary>
        /// Crea un nuovo record nel database.
        /// </summary>
        /// <param name="entity">L'entità da aggiungere al database.</param>
        /// <returns>True se l'operazione è andata a buon fine, altrimenti False.</returns>
        bool CreateRecord(Entity entity);

        /// <summary>
        /// Aggiorna un record esistente nel database.
        /// </summary>
        /// <param name="entity">L'entità con i dati aggiornati.</param>
        /// <returns>True se l'operazione è andata a buon fine, altrimenti False.</returns>
        bool UpdateRecord(Entity entity);

        /// <summary>
        /// Elimina un record dal database tramite il suo ID.
        /// </summary>
        /// <param name="recordId">L'ID del record da eliminare.</param>
        /// <returns>True se l'operazione è andata a buon fine, altrimenti False.</returns>
        bool DeleteRecord(int recordId);

        #endregion
    }
}
