using _04_Utility;

namespace _06_MS_Ecommerce
{
    internal class DAOMerce : IDAO
    {
        private readonly Database db;
        private readonly string tableName = "Merci";
        private DAOMerce()
        {
            db = new Database("Mercato");
        }
        private static DAOMerce? instance = null;
        public static DAOMerce GetInstance()
        {
            return instance ??= new DAOMerce();
        }

        public List<Entity> GetRecords()
        {
            List<Entity> records = [];
            List<Dictionary<string, string>>? result = db.ReadDb($"SELECT * FROM {tableName}");

            if(result != null)
            {
                foreach(var line in result)
                {
                    Merce record = new();
                    record.TypeSort(line);
                    records.Add(record);
                }
            }
            return records;
        }

        public bool CreateRecord(Entity entity)
        {
            string
                name = ((Merce) entity).Nome.Replace("'", "''"),
                category = ((Merce) entity).Categoria.Replace("'", "''"),
                restockDate = ((Merce) entity).DataCambio.ToString("yyyy-MM-dd"),
                expirationDate = ((Merce) entity).DataScadenza.ToString("yyyy-MM-dd");
            int stockAmount = ((Merce) entity).QuantitaMagazzino;
            double price = ((Merce) entity).Prezzo;

            return db.UpdateDb
                ($@"
                    INSERT INTO {tableName} (nome, quantitaMagazzino, dataCambio, dataScadenza, categoria, prezzo) VALUES
                    (
                        '{name}', '{stockAmount}', '{restockDate}', '{expirationDate}', '{category}', '{price}'
                    );
                ");
        }

        public bool UpdateRecord(Entity entity)
        {
            string
                name = ((Merce) entity).Nome.Replace("'", "''"),
                category = ((Merce) entity).Categoria.Replace("'", "''"),
                restockDate = ((Merce) entity).DataCambio.ToString("yyyy-MM-dd"),
                expirationDate = ((Merce) entity).DataScadenza.ToString("yyyy-MM-dd");
            int stockAmount = ((Merce) entity).QuantitaMagazzino;
            double price = ((Merce) entity).Prezzo;

            return db.UpdateDb
                (@$"
                    UPDATE {tableName} SET 
                        nome = '{name}', 
                        quantitaMagazzino = '{category}', 
                        dataCambio = '{restockDate}', 
                        dataScadenza = '{expirationDate}', 
                        categoria = '{category}', 
                        prezzo = '{price}' 
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
                Entity record = new Merce();
                record.TypeSort(line);
                return record;
            }
            return null;
        }
    }
}

