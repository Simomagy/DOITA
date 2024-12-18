using _04_Utility;

namespace _06_MS_Ecommerce
{
    internal class DAOCliente : IDAO
    {
        private readonly Database db;
        private readonly string tableName = "Clienti";
        private DAOCliente()
        {
            db = new Database("Mercato");
        }
        private static DAOCliente? instance = null;
        public static DAOCliente GetInstance()
        {
            return instance ??= new DAOCliente();
        }

        public List<Entity> GetRecords()
        {
            List<Entity> records = [];
            List<Dictionary<string, string>>? result = db.ReadDb($"SELECT * FROM {tableName}");

            if(result != null)
            {
                foreach(var line in result)
                {
                    Cliente record = new();
                    record.TypeSort(line);
                    records.Add(record);
                }
            }
            return records;
        }

        public bool CreateRecord(Entity entity)
        {
            string
                userName = ((Cliente) entity).Username.Replace("'", "''"),
                signupDate = ((Cliente) entity).DataIscrizione.ToString("yyyy-MM-dd");
            int isOver18 = ((Cliente) entity).Maggiorenne ? 1 : 0;

            return db.UpdateDb
                ($@"
                    INSERT INTO {tableName} (username, dataIscrizione, maggiorenne) VALUES
                    (
                        '{userName}', '{signupDate}', '{isOver18}'
                    );
                ");
        }

        public bool UpdateRecord(Entity entity)
        {
            string
                userName = ((Cliente) entity).Username.Replace("'", "''"),
                signupDate = ((Cliente) entity).DataIscrizione.ToString("yyyy-MM-dd");
            int isOver18 = ((Cliente) entity).Maggiorenne ? 1 : 0;

            return db.UpdateDb
                (@$"
                    UPDATE {tableName} SET 
                        username = '{userName}', 
                        quantitaMagazzino = '{signupDate}', 
                        dataCambio = '{isOver18}', 
                    WHERE id = {entity.Id};
                ");
        }

        public bool DeleteRecord(int recordId)
        {
            return db.UpdateDb($"DELETE FROM {tableName} WHERE id = {recordId};");
        }

        public Entity? FindRecord(int recordId)
        {
            var line = db.ReadOneDb($"SELECT * FROM {tableName} WHERE id = {recordId};");
            if(line != null)
            {
                Entity record = new Cliente();
                record.TypeSort(line);
                return record;
            }
            return null;
        }
    }
}
