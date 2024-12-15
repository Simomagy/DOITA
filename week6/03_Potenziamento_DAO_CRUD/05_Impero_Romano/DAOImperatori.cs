using _04_Utility;

namespace _05_Impero_Romano
{
    internal class DAOImperatori : IDAO
    {
        private readonly IDatabase db;
        private DAOImperatori()
        {
            db = new Database("ImperoRomano");
        }
        private static DAOImperatori? instance = null;
        public static DAOImperatori GetInstance()
        {
            return instance ??= new DAOImperatori();
        }

        /// <summary>
        /// Ottiene tutti i record della tabella Imperatori. Usa il metodo <see cref="Database.ReadDb"/> per ottenere i record
        /// </summary>
        /// <returns> Una <see cref="List{T}"/> di record della tabella Imperatori </returns>
        public List<Entity> GetRecords()
        {
            List<Entity> records = [];
            List<Dictionary<string, string>>? result = db.ReadDb("SELECT * FROM imperatori");
            if(result != null)
            {
                foreach(Dictionary<string, string> line in result)
                {
                    Imperatore record = new();
                    record.TypeSort(line);
                    records.Add(record);
                }
            }
            return records;
        }

        /// <summary>
        /// Crea un record nella tabella Imperatori. Usa il metodo <see cref="Database.UpdateDb"/> per creare il record
        /// </summary>
        /// <param name="entity"> Un oggetto di tipo <see cref="Entity"/> </param>
        /// <returns> <see langword="true"/> se il record è stato creato, <see langword="false"/> altrimenti </returns>
        public bool CreateRecord(Entity entity)
        {
            var name = ((Imperatore) entity).Nome.Replace("'", "''");
            var dinasty = ((Imperatore) entity).Dinastia.Replace("'", "''");
            var dob = ((Imperatore) entity).Dob.ToString("yyyy-MM-dd");
            var dod = ((Imperatore) entity).Dod.ToString("yyyy-MM-dd");
            var wasAssassinated = ((Imperatore) entity).Assassinio ? 1 : 0;

            return db.UpdateDb($"INSERT INTO Imperatori (nome, dinastia, dob, dod, assassinio) " +
                $"VALUES " +
                $"('{name}'," +
                $" '{dinasty}'," +
                $" '{dob}'," +
                $" '{dod}'," +
                $"  {wasAssassinated});");
        }

        /// <summary>
        /// Aggiorna un record nella tabella Imperatori. Usa il metodo <see cref="Database.UpdateDb"/> per aggiornare il record
        /// </summary>
        /// <param name="entity"> Un oggetto di tipo <see cref="Entity"/> </param>
        /// <returns> <see langword="true"/> se il record è stato aggiornato, <see langword="false"/> altrimenti </returns>
        public bool UpdateRecord(Entity entity)
        {
            var name = ((Imperatore) entity).Nome.Replace("'", "''");
            var dinasty = ((Imperatore) entity).Dinastia.Replace("'", "''");
            var dob = ((Imperatore) entity).Dob.ToString("yyyy-MM-dd");
            var dod = ((Imperatore) entity).Dod.ToString("yyyy-MM-dd");
            var wasAssassinated = ((Imperatore) entity).Assassinio ? 1 : 0;

            return db.UpdateDb($"UPDATE Imperatori SET " +
             $"nome = '{name}', " +
             $"dinastia= '{dinasty}', " +
             $"dob = '{dob}', " +
             $"dod = '{dod}', " +
             $"assassinio = {wasAssassinated} " +
             $"WHERE id = {entity.Id};");
        }

        /// <summary>
        /// Elimina un record dalla tabella Imperatori. Usa il metodo <see cref="Database.UpdateDb"/> per eliminare il record
        /// </summary>
        /// <param name="recordId"> Un intero che rappresenta l'id del record da eliminare </param>
        /// <returns> <see langword="true"/> se il record è stato eliminato, <see langword="false"/> altrimenti </returns>
        public bool DeleteRecord(int recordId)
        {
            return db.UpdateDb($"DELETE FROM Imperatori WHERE id = {recordId};");
        }

        /// <summary>
        /// Trova un record nella tabella Imperatori. Usa il metodo <see cref="Database.ReadOneDb"/> per trovare il record
        /// </summary>
        /// <param name="recordId"> Un intero che rappresenta l'id del record da trovare </param>
        /// <returns> Un oggetto di tipo <see cref="Entity"/> se il record è stato trovato, <see langword="null"/> altrimenti </returns>
        public Entity? FindRecord(int recordId)
        {
            var line = db.ReadOneDb($"SELECT * FROM Imperatori WHERE id = {recordId};");
            if(line != null)
            {
                Entity record = new Imperatore();
                record.TypeSort(line);
                return record;
            }
            return null;
        }
    }
}
