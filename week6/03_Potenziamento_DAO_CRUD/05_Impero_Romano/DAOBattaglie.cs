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

        public bool CreateRecord(Entity entity)
        {
            var nemico = ((Battaglia) entity).Nemico.Replace("'", "''");
            var dataBattaglia = ((Battaglia) entity).Data_battaglia.ToString("yyyy-MM-dd");
            var vincitore = ((Battaglia) entity).Vincitore ? 1 : 0;
            var luogo = ((Battaglia) entity).Luogo.Replace("'", "''");
            var idImperatore = ((Battaglia) entity).Imperatore?.Id ?? 0;

            return db.UpdateDb($"INSERT INTO Battaglie (nemico, data_battaglia, vincitore, luogo, idimperatore) " +
                $"VALUES " +
                $"('{nemico}'," +
                $" '{dataBattaglia}'," +
                $"  {vincitore}," +
                $" '{luogo}'," +
                $"  {idImperatore});");
        }

        public bool UpdateRecord(Entity entity)
        {
            var nemico = ((Battaglia) entity).Nemico.Replace("'", "''");
            var dataBattaglia = ((Battaglia) entity).Data_battaglia.ToString("yyyy-MM-dd");
            var vincitore = ((Battaglia) entity).Vincitore ? 1 : 0;
            var luogo = ((Battaglia) entity).Luogo.Replace("'", "''");
            var idImperatore = ((Battaglia) entity).Imperatore?.Id ?? 0;

            return db.UpdateDb($"UPDATE Battaglie SET " +
             $"nemico = '{nemico}', " +
             $"data_battaglia = '{dataBattaglia}', " +
             $"vincitore = {vincitore}, " +
             $"luogo = '{luogo}', " +
             $"idimperatore = {idImperatore} " +
             $"WHERE id = {entity.Id};");
        }

        public bool DeleteRecord(int recordId)
        {
            return db.UpdateDb($"DELETE FROM Battaglie WHERE id = {recordId};");
        }

        public Entity? FindRecord(int recordId)
        {
            var riga = db.ReadOneDb($"SELECT * FROM Battaglie WHERE id = {recordId};");
            if(riga != null)
            {
                Battaglia record = new();
                record.TypeSort(riga);
                return record;
            }
            return null;
        }
    }
}
