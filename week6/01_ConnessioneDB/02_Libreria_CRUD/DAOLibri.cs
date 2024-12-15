using Microsoft.Data.SqlClient;

namespace _02_Libreria_CRUD
{
    internal class DAOLibri
    {
        private readonly Database db;

        #region Singleton
        /// <summary>
        /// Costruttore della classe DAOLibri.
        /// </summary>
        /// <remarks>
        /// <see cref="Database"/> viene inizializzato con il nome del database a cui connettersi.
        /// <example>
        /// <code>
        /// DAOLibri dao = new DAOLibri("LibreriaDOITA14");
        /// </code>
        /// </example>
        /// </remarks>
        private DAOLibri()
        {
            db = new Database("LibreriaDOITA14");
        }

        /// <summary>
        /// Istanza <see langword="static"/> della <see langword="class"/> <see cref="DAOLibri"/> inizializzata a <see langword="null"/>
        /// </summary>
        private static DAOLibri? instance = null;

        /// <summary>
        /// Metodo che restituisce l'istanza della classe <see cref="DAOLibri"/>. Se l'istanza è <see langword="null"/> la inizializza altrimenti restituisce l'istanza già esistente.
        /// </summary>
        /// <returns>
        /// <see cref="instance"/>
        /// Se <see cref="instance"/> è <see langword="null"/> restituisce una nuova istanza di <see cref="DAOLibri"/>. Altrimenti restituisce l'istanza già esistente.
        /// </returns>
        public static DAOLibri GetInstance()
        {
            // Se instance è null allora crea una nuova istanza di DAOLibri
            // (questa sintassi è detta null-coalescing operator e si legge come "se instance è null allora crea una nuova istanza di DAOLibri")
            instance ??= new DAOLibri();
            return instance;
        }
        #endregion
        #region CRUD
        // CRUD -> Create, Read, Update, Delete
        // Ogni classe DAO avra' sempre i metodi CRUD perche' deve poter gestire tutte le operazioni di base sul database

        /// <summary>
        /// Metodo che permette di inserire un libro nel database.
        /// </summary>
        /// <remarks>
        /// <see cref="Database.Connection"/> viene aperta prima di eseguire la query e chiusa alla fine dell'esecuzione.
        /// <see cref="SqlCommand"/> viene utilizzato per eseguire la query."
        /// </remarks>
        /// <param name="id"></param>
        /// <returns><see langword="true"/> se l'inserimento è andato a buon fine, altrimenti <see langword="false"/>.</returns>
        public bool Delete(int id)
        {
            string query = $"DELETE FROM Libri WHERE id = {id}";
            return db.Update(query);
        }

        /// <summary>
        /// Metodo che permette di inserire un libro nel database.
        /// </summary>
        /// <remarks>
        /// <see cref="Update(Entity)"/> viene utilizzato per eseguire la query.
        /// </remarks>
        /// <param name="libro"> <see cref="Libro"/> da inserire nel database.</param>
        /// <returns><see langword="true"/> se l'inserimento è andato a buon fine, altrimenti <see langword="false"/>.</returns>
        public bool Update(Entity e)
        {
            string query =
                $"UPDATE Libri SET " +
                $"titolo = '{((Libro) e).Titolo.Replace("'", "''")}', " +
                $"autore = '{((Libro) e).Autore.Replace("'", "''")}', " +
                $"genere = '{((Libro) e).Genere.Replace("'", "''")}', " +
                $"annoPubblicazione = {((Libro) e).AnnoPubblicazione} " +
                $"WHERE id = {e.Id}";
            return db.Update(query);
        }

        /// <summary>
        /// Metodo che permette di inserire un libro nel database.
        /// </summary>
        /// <remarks>
        /// <see cref="Update(string)"/> viene utilizzato per eseguire la query.
        /// </remarks>
        /// <param name="e"></param>
        /// <returns><see langword="true"/> se l'inserimento è andato a buon fine, altrimenti <see langword="false"/>.</returns>
        public bool Insert(Entity e)
        {
            string query =
                $"INSERT INTO Libri (titolo, autore, genere, annoPubblicazione) " +
                $"VALUES ('{((Libro) e).Titolo.Replace("'", "''")}', " +
                $"'{((Libro) e).Autore.Replace("'", "''")}', " +
                $"'{((Libro) e).Genere.Replace("'", "''")}', " +
                $"{((Libro) e).AnnoPubblicazione})";
            return db.Update(query);
        }

        /// <summary>
        /// Metodo che permette di leggere i record dal database.
        /// </summary>
        /// <remarks>
        /// <see cref="Database.Read(string)"/> viene utilizzato per eseguire la query e ottenere i risultati come lista di dizionari.
        /// <see cref="Entity.FromDictionary(Dictionary{string, string})"/> viene utilizzato per popolare un nuovo libro con i dati della riga categorizzando i valori in base al nome della colonna.
        /// <returns><see cref="List{T}"/> di <see cref="Entity"/> se ci sono record nel database, altrimenti una lista vuota.</returns>
        public List<Entity> Read()
        {
            // 1. Crea una lista vuota di Entity
            List<Entity> ris = new List<Entity>();

            // 2. Esegue la query e ottiene i risultati come lista di dizionari
            List<Dictionary<string, string>> righe = db.Read("SELECT * FROM Libri;");

            // 3. Per ogni riga risultante dalla query
            foreach(Dictionary<string, string> riga in righe)
            {
                // 4. Crea un nuovo Libro usando il costruttore vuoto
                Libro e = new Libro();
                // 5. Popola il libro con i dati della riga
                e.FromDictionary(riga);
                // 6. Aggiunge il libro alla lista risultato
                ris.Add(e);
            }
            // 7. Restituisce la lista completa
            return ris;
        }

        /// <summary>
        /// Metodo che permette di trovare un libro nel database tramite il suo ID.
        /// </summary>
        /// <remarks>
        /// <see cref="Database.ReadOne(string)"/> viene utilizzato per filtrare solo il libro con l'ID specificato. La query viene sempre eseguita da <see cref="Database.Read(string)"/>
        /// </remarks>
        /// <param name="id"></param>
        /// <returns> <see cref="Entity"/> se il libro è stato trovato, altrimenti <see langword="null"/>.</returns>
        public Entity Find(int id)
        {
            string query = $"SELECT * FROM Libri WHERE id = {id}";
            var riga = db.ReadOne(query);
            if(riga == null)
                return null;
            Entity e = new Libro();
            e.FromDictionary(riga);
            return e;
        }

        #endregion
    }
}
