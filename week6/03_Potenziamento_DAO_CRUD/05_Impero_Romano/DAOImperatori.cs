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

        public bool CreateRecord(Entity entity)
        {
            var nome = ((Imperatore) entity).Nome.Replace("'", "''");
            var dinastia = ((Imperatore) entity).Dinastia.Replace("'", "''");
            var dob = ((Imperatore) entity).Dob.ToString("yyyy-MM-dd");
            var dod = ((Imperatore) entity).Dod.ToString("yyyy-MM-dd");
            var assassinio = ((Imperatore) entity).Assassinio ? 1 : 0;

            return db.UpdateDb($"INSERT INTO Imperatori (nome, dinastia, dob, dod, assassinio) " +
                $"VALUES " +
                $"('{nome}'," +
                $" '{dinastia}'," +
                $" '{dob}'," +
                $" '{dod}'," +
                $"  {assassinio});");
        }

        public bool UpdateRecord(Entity entity)
        {
            var nome = ((Imperatore) entity).Nome.Replace("'", "''");
            var dinastia = ((Imperatore) entity).Dinastia.Replace("'", "''");
            var dob = ((Imperatore) entity).Dob.ToString("yyyy-MM-dd");
            var dod = ((Imperatore) entity).Dod.ToString("yyyy-MM-dd");
            var assassinio = ((Imperatore) entity).Assassinio ? 1 : 0;

            return db.UpdateDb($"UPDATE Imperatori SET " +
             $"nome = '{nome}', " +
             $"dinastia= '{dinastia}', " +
             $"dob = '{dob}', " +
             $"dod = '{dod}', " +
             $"assassinio = {assassinio} " +
             $"WHERE id = {entity.Id};");
        }

        public bool DeleteRecord(int recordId)
        {
            return db.UpdateDb($"DELETE FROM Imperatori WHERE id = {recordId};");
        }

        public Entity? FindRecord(int recordId)
        {
            var riga = db.ReadOneDb($"SELECT * FROM Imperatori WHERE id = {recordId};");

            if(riga != null)
            {
                Entity e = new Imperatore();
                e.TypeSort(riga);
                return e;
            }
            return null;
        }
    }
}
