using _04_Utility;

namespace _07_Concessionaria
{
    internal class DAOProdotti : IDAO
    {

        private readonly Database db;
        private readonly string tableName = "Prodotti";
        private DAOProdotti()
        {
            db = new Database("Concessionaria");
        }
        private static DAOProdotti? instance = null;
        public static DAOProdotti GetInstance()
        {
            return instance ??= new DAOProdotti();
        }
        public bool CreateRecord(Entity entity)
        {
            int affittabile = ((Prodotto) entity).Affittabile ? 1 : 0;
            string annoImmatricolazione = ((Prodotto) entity).AnnoImmatricolazione.ToString("yyyy-MM-dd");
            double capienzaSerbatoio = ((Prodotto) entity).CapienzaSerbatoio;
            string categoria = ((Prodotto) entity).Categoria.Replace("'", "''");
            double consumoMedioAKM = ((Prodotto) entity).ConsumoMedioAKM;
            string marca = ((Prodotto) entity).Marca.Replace("'", "''");
            string modello = ((Prodotto) entity).Modello.Replace("'", "''");

            return db.UpdateDb
                ($@"
                        INSERT INTO {tableName} (Categoria, Marca, Modello, Affittabile, AnnoImmatricolazione, ConsumoMedioAKM, CapienzaSerbatoio) VALUES
                        (
                            '{categoria}', '{marca}', '{modello}', '{affittabile}', '{annoImmatricolazione}', '{consumoMedioAKM}', '{capienzaSerbatoio}'
                        );
                    ");
        }

        public bool DeleteRecord(int recordId)
        {
            return db.UpdateDb($"DELETE FROM {tableName} WHERE Id = {recordId}");
        }

        public Entity? FindRecord(int recordId)
        {
            var line = db.ReadDb($"SELECT * FROM {tableName} WHERE Id = {recordId}");
            if(line != null)
            {
                Prodotto record = new();
                record.TypeSort(line[0]);
                return record;
            }
            return null;
        }

        public List<Entity> GetRecords()
        {
            List<Entity> records = [];
            List<Dictionary<string, string>>? result = db.ReadDb($"SELECT * FROM {tableName}");

            if(result != null)
            {
                foreach(var line in result)
                {
                    Prodotto record = new();
                    record.TypeSort(line);
                    records.Add(record);
                }
            }
            return records;
        }

        public bool UpdateRecord(Entity entity)
        {
            string annoImmatricolazione = ((Prodotto) entity).AnnoImmatricolazione.ToString("yyyy-MM-dd");
            double capienzaSerbatoio = ((Prodotto) entity).CapienzaSerbatoio;
            string categoria = ((Prodotto) entity).Categoria.Replace("'", "''");
            double consumoMedioAKM = ((Prodotto) entity).ConsumoMedioAKM;
            string marca = ((Prodotto) entity).Marca.Replace("'", "''");
            string modello = ((Prodotto) entity).Modello.Replace("'", "''");

            return db.UpdateDb
                (@$"
                        UPDATE {tableName} SET 
                            Categoria = '{categoria}', 
                            Marca = '{marca}', 
                            Modello = '{modello}', 
                            Affittabile = '{((Prodotto) entity).Affittabile}', 
                            AnnoImmatricolazione = '{annoImmatricolazione}', 
                            ConsumoMedioAKM = '{consumoMedioAKM}', 
                            CapienzaSerbatoio = '{capienzaSerbatoio}' 
                        WHERE Id = {entity.Id};
                    ");
        }

        /// <summary>
        /// Ritorna la lista dei prodotti immatricolati da almeno 8 anni
        /// </summary>
        public List<Prodotto> ListaProdottiVecchi()
        {
            return GetRecords()
                .OfType<Prodotto>()
                .Where(p => p.Eta() >= 8)
                .ToList();
        }

        /// <summary>
        /// Ritorna le schede dei mezzi che possono fare più km (Sia macchine che moto)
        /// </summary>
        public string MaxDistanza()
        {
            var prodotti = GetRecords().OfType<Prodotto>();
            double maxKm = prodotti.Max(p => p.KMPercorribili());
            var mezziMaxKm = prodotti.Where(p => p.KMPercorribili() == maxKm);
            return string.Join("\n", mezziMaxKm.Select(p => p.ToString()));
        }

        /// <summary>
        /// Ritorna tutti i mezzi che appartengono alla categoria cercata
        /// </summary>
        public List<Prodotto> Cerca(string categoria)
        {
            return GetRecords()
                .OfType<Prodotto>()
                .Where(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        /// <summary>
        /// Ritorna un dizionario con la frequenza per categoria
        /// </summary>
        public Dictionary<string, int> Frequenza()
        {
            return GetRecords()
                .OfType<Prodotto>()
                .GroupBy(p => p.Categoria)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        /// <summary>
        /// Ritorna le schede di tutti i mezzi della marca ricercata (sia macchine che moto)
        /// </summary>
        public string CercaPerMarca(string marca)
        {
            var mezzi = GetRecords()
                .OfType<Prodotto>()
                .Where(p => p.Marca.Equals(marca, StringComparison.OrdinalIgnoreCase));
            return string.Join("\n", mezzi.Select(p => p.ToString()));
        }

        /// <summary>
        /// Stampa in maniera ordinata un array di elementi di tipo Prodotto
        /// </summary>
        public string StampaListe(List<Prodotto> array)
        {
            return string.Join("\n", array.Select(p => p.ToString()));
        }

        /// <summary>
        /// Ritorna una lista di mezzi che si possono affittare con il budget mensile e il numero di passeggeri
        /// </summary>
        public List<Prodotto> TrovaSoluzione(double budgetMensile, int passeggeri)
        {
            return GetRecords()
                .OfType<Prodotto>()
                .Where(p => p.Affittabile && p.AffittoMensile() <= budgetMensile &&
                            ((p is Automobile auto && auto.PostiAuto >= passeggeri) ||
                             (p is Moto moto && moto.Passeggeri && passeggeri <= 1)))
                .ToList();
        }

        /// <summary>
        /// Ritornare la lista ordinata per prezzo dei mezzi (dal meno costoso al più caro)
        /// </summary>
        public List<Prodotto> InOrdine()
        {
            return GetRecords()
                .OfType<Prodotto>()
                .OrderBy(p => p.Prezzo())
                .ToList();
        }
    }
}
