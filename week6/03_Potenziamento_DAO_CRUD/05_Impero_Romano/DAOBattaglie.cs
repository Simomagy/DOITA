using _04_Utility;

namespace _05_Impero_Romano
{
    internal class DAOBattaglie : IDAO
    {
        private readonly IDatabase db;
        private DAOBattaglie()
        {
            db = new Database("ImperoRomano");
        }
        private static DAOBattaglie? instance = null;
        public static DAOBattaglie GetInstance()
        {
            return instance ??= new DAOBattaglie();
        }

        /// <summary>
        /// Ottiene tutti i record della tabella Battaglie. Usa il metodo <see cref="Database.ReadDb"/> per ottenere i record
        /// </summary>
        /// <returns> Una <see cref="List{T}"/> di record della tabella Battaglie </returns>
        public List<Entity> GetRecords()
        {
            List<Entity> records = [];
            List<Dictionary<string, string>>? result = db.ReadDb("SELECT * FROM battaglie");
            if(result != null)
            {
                foreach(Dictionary<string, string> line in result)
                {
                    Battaglia record = new();
                    record.TypeSort(line);
                    records.Add(record);
                }
            }
            return records;
        }

        /// <summary>
        /// Crea un record nella tabella Battaglie. Usa il metodo <see cref="Database.UpdateDb"/> per creare il record
        /// </summary>
        /// <param name="entity"> Un oggetto di tipo <see cref="Entity"/> </param>
        /// <returns> <see langword="true"/> se il record è stato creato, <see langword="false"/> altrimenti </returns>
        public bool CreateRecord(Entity entity)
        {
            var enemy = ((Battaglia) entity).Nemico.Replace("'", "''");
            var battleDate = ((Battaglia) entity).Data_battaglia.ToString("yyyy-MM-dd");
            var winner = ((Battaglia) entity).Vincitore ? 1 : 0;
            var location = ((Battaglia) entity).Luogo.Replace("'", "''");
            var emperorId = ((Battaglia) entity).Imperatore?.Id ?? 0;

            return db.UpdateDb($"INSERT INTO Battaglie (nemico, data_battaglia, vincitore, luogo, idimperatore) " +
                $"VALUES " +
                $"('{enemy}'," +
                $" '{battleDate}'," +
                $"  {winner}," +
                $" '{location}'," +
                $"  {emperorId});");
        }

        /// <summary>
        /// Aggiorna un record nella tabella Battaglie. Usa il metodo <see cref="Database.UpdateDb"/> per aggiornare il record
        /// </summary>
        /// <param name="entity"> Un oggetto di tipo <see cref="Entity"/> </param>
        /// <returns> <see langword="true"/> se il record è stato aggiornato, <see langword="false"/> altrimenti </returns>
        public bool UpdateRecord(Entity entity)
        {
            var enemy = ((Battaglia) entity).Nemico.Replace("'", "''");
            var battleDate = ((Battaglia) entity).Data_battaglia.ToString("yyyy-MM-dd");
            var winner = ((Battaglia) entity).Vincitore ? 1 : 0;
            var location = ((Battaglia) entity).Luogo.Replace("'", "''");
            var emperorId = ((Battaglia) entity).Imperatore?.Id ?? 0;

            return db.UpdateDb($"UPDATE Battaglie SET " +
             $"nemico = '{enemy}', " +
             $"data_battaglia = '{battleDate}', " +
             $"vincitore = {winner}, " +
             $"luogo = '{location}', " +
             $"idimperatore = {emperorId} " +
             $"WHERE id = {entity.Id};");
        }

        /// <summary>
        /// Elimina un record nella tabella Battaglie. Usa il metodo <see cref="Database.UpdateDb"/> per eliminare il record
        /// </summary>
        /// <param name="recordId"> L'id del record da eliminare </param>
        /// <returns> <see langword="true"/> se il record è stato eliminato, <see langword="false"/> altrimenti </returns>
        public bool DeleteRecord(int recordId)
        {
            return db.UpdateDb($"DELETE FROM Battaglie WHERE id = {recordId};");
        }

        /// <summary>
        /// Trova un record nella tabella Battaglie. Usa il metodo <see cref="Database.ReadOneDb"/> per trovare il record
        /// </summary>
        /// <param name="recordId"> L'id del record da trovare </param>
        /// <returns> Un oggetto di tipo <see cref="Entity"/> se il record è stato trovato, <see langword="null"/> altrimenti </returns>
        public Entity? FindRecord(int recordId)
        {
            var line = db.ReadOneDb($"SELECT * FROM Battaglie WHERE id = {recordId};");
            if(line != null)
            {
                Battaglia record = new();
                record.TypeSort(line);
                return record;
            }
            return null;
        }
    }
}
