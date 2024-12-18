using _04_Utility;

namespace _06_MS_Ecommerce
{
    internal class DAOCarrello
    {
        private readonly Database db;
        private readonly string tableName = "Carrello";
        private DAOCarrello()
        {
            db = new Database("Mercato");
        }
        private static DAOCarrello? instance = null;
        public static DAOCarrello GetInstance()
        {
            return instance ??= new DAOCarrello();
        }
        public List<Entity> GetRecords()
        {
            List<Entity> records = [];
            List<Dictionary<string, string>>? result = db.ReadDb($"SELECT * FROM {tableName}");

            if(result != null)
            {
                foreach(var line in result)
                {
                    Carrello record = new();
                    record.TypeSort(line);
                    records.Add(record);
                }
            }
            return records;
        }

        public bool CreateRecord(Entity entity)
        {
            if(entity is Carrello carrello && carrello.Cliente != null && carrello.Merce != null)
            {
                int userId = carrello.Cliente.Id;
                int stockId = carrello.Merce.QuantitaMagazzino;
                double amount = carrello.Merce.Prezzo;

                return db.UpdateDb
                    ($@"
                        INSERT INTO {tableName} (cliente_id, merce_id, quantita) VALUES
                        (
                            '{userId}', '{stockId}', '{amount}'
                        );
                    ");
            }
            return false;
        }

        public bool UpdateRecord(Entity entity)
        {
            if(entity is Carrello carrello && carrello.Cliente != null && carrello.Merce != null)
            {
                int userId = carrello.Cliente.Id;
                int stockId = carrello.Merce.QuantitaMagazzino;
                double amount = carrello.Merce.Prezzo;
                return db.UpdateDb
                    ($@"
                        UPDATE {tableName} SET
                        cliente_id = '{userId}', merce_id = '{stockId}', quantita = '{amount}'
                        WHERE id = {carrello.Id};
                    ");
            }
            return false;
        }

        public bool DeleteRecord(int userId, int stockId)
        {
            return db.UpdateDb($"DELETE FROM {tableName} WHERE cliente_id = {userId} AND merce_id = {stockId};");
        }

        public Entity? FindRecord(int userId, int stockId)
        {
            var line = db.ReadOneDb($"SELECT * FROM {tableName} WHERE cliente_id = {userId} AND merce_id = {stockId};");
            if(line != null)
            {
                Entity record = new Carrello();
                record.TypeSort(line);
                return record;
            }
            return null;
        }
    }
}
