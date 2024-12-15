namespace _03_Potenziamento_DAO_CRUD
{
    internal class DAOVideogame
    {
        private readonly string tableName = "Videogames";
        private readonly Database db;
        #region SINGLETON
        /// <summary>
        /// Costruttore della classe DAOVideogame.
        /// </summary>
        /// <remarks>
        /// <see cref="Database"/> viene inizializzato con il nome della tabella a cui connettersi. Il nome del server e' opzionale in quando gia' specificato nella firma del metodo
        /// <example>
        /// <code>
        /// <see cref="DAOVideogame"/> dao = <see langword="new"/> <see cref="DAOVideogame"/>("Videogames");
        /// </code>
        /// </example>
        /// </remarks>
        private DAOVideogame()
        {
            db = new Database(tableName);
        }

        /// <summary>
        /// L'<see cref="instance"/> di <see langword="class"/> <see cref="DAOVideogame"/> e' inizializzata a <see langword="null"/> di default
        /// </summary>
        private static DAOVideogame? instance = null;

        /// <summary>
        /// Restituisce l'<see cref="instance"/> della <see langword="class"/> <see cref="DAOVideogame"/>.
        /// </summary>
        /// <remarks>
        /// Esempio:
        /// <example>
        /// <code>
        /// <see cref="DAOVideogame"/>.<see cref="GetInstance"/>
        /// </code>
        /// </example>
        /// </remarks>
        /// <returns>
        /// Una nuova istanza di <see cref="DAOVideogame"/> se <see cref="instance"/> e' <see langword="null"/>. Altrimenti l'istanza precedente.
        /// </returns>
        public static DAOVideogame GetInstance()
        {
            // Sintassi base
            //if(instance == null)
            //    instance = new DAOVideogame();
            //return instance;

            // Sintassi usando il "null-coalescing operator"
            // Si legge "Se instance e' null allora crea una nuova instanza di DAOVideogame, altrimenti ritorna l'istanza precedente (quella gia' creata in precedenza)"
            instance ??= new DAOVideogame();
            return instance;
        }
        #endregion
        #region CRUD
        // CRUD ==> Create, Update, Read, Delete

        public bool CreateRecord(Entity entity)
        {
            string title = ((Videogame) entity).Title.Replace("'", "''");
            string genre = ((Videogame) entity).Genre.Replace("'", "''");
            int releaseYear = ((Videogame) entity).ReleaseYear;
            string developer = ((Videogame) entity).Developer.Replace("'", "''");

            string query =
                $"INSERT INTO {tableName} (Title, Genre, ReleaseYear, Developer) " +
                $"VALUES (" +
                $"'{title}', " +
                $"'{genre}', " +
                $"'{releaseYear}', " +
                $"'{developer}'" +
                ");";

            var response = db.UpdateDb(query);
            return response;
        }

        public bool UpdateRecord(Entity entity)
        {
            string title = ((Videogame) entity).Title.Replace("'", "''");
            string genre = ((Videogame) entity).Genre.Replace("'", "''");
            int releaseYear = ((Videogame) entity).ReleaseYear;
            string developer = ((Videogame) entity).Developer.Replace("'", "''");
            int id = entity.Id;

            string query =
                $"UPDATE {tableName} SET " +
                $"Title = '{title}', " +
                $"Genre = '{genre}', " +
                $"ReleaseYear = '{releaseYear}', " +
                $"Developer = '{developer}' " +
                $"WHERE Id = {id};";

            var response = db.UpdateDb(query);
            return response;
        }

        public List<Entity> GetRecords()
        {
            // 1. Creiamo una lista vuota di Entity
            List<Entity> response = [];

            // 2. Eseguiamo la query e mettiamo il risultato dentro una lista di dizionari
            List<Dictionary<string, string>>? fullResponse = db.ReadDb($"SELECT * FROM {tableName}");

            if(fullResponse == null)
                return response;

            // 3. Per ogni risposta dentro fullResponse
            foreach(Dictionary<string, string> singleResponse in fullResponse)
            {
                // 4. Creiamo una logica di lazy loading. Inizializziamo un nuovo Videogame senza dati per averlo gia' pronto quando avremo i dati da immettere
                Videogame videogame = new();

                // 5. Popoliamo in dati del Videogame vuoto creato in precedenza
                videogame.TypeSort(singleResponse);

                // 6. Aggiungiamo il libro con i dati alla risposta
                response.Add(videogame);
            }
            // 7. Ritorniamo la risposta completa
            return response;
        }

        public Entity? FindRecord(int recordId)
        {
            string query = $"SELECT * FROM {tableName} WHERE Id = {recordId}";
            var response = db.ReadOneDb(query);
            if(response != null)
            {
                Entity entity = new Videogame();
                entity.TypeSort(response);
                return entity;
            }
            return null;
        }

        public bool DeleteRecord(int recordId)
        {
            string query = $"DELETE FROM {tableName} WHERE ID = {recordId}";
            var response = db.UpdateDb(query);
            return response;
        }
        #endregion
    }
}
