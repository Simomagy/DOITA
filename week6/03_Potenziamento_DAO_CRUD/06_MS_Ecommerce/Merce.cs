using _04_Utility;

namespace _06_MS_Ecommerce
{
    internal class Merce : Entity
    {
        public string Nome { get; set; } = string.Empty;
        public int QuantitaMagazzino { get; set; }
        public DateTime DataCambio { get; set; }
        public DateTime DataScadenza { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public double Prezzo { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                $"Nome: {Nome}\n" +
                $"QuantitaMagazzino: {QuantitaMagazzino}\n" +
                $"DataCambio: {DataCambio:dd-MM-yyyy}\n" +
                $"DataScadenza: {(DataScadenza == DateTime.MinValue ? "N/A" : DataScadenza.ToString("dd-MM-yyyy"))}\n" +
                $"Categoria: {Categoria}\n" +
                $"Prezzo: ${Prezzo}\n";
        }
        // Visualizza tutte le merci da sostituire(deve'essere sostituito al massimo 3 giorni prima della scadenza)
        public void GoodsToBeReplaced()
        {
            DAOMerce daoMerce = DAOMerce.GetInstance();
            List<Entity> records = daoMerce.GetRecords();
            foreach(Merce record in records)
            {
                // Controllo se la data di cambio e quella di scadenza non siano N/A e poi controllo se la data di cambio è compresa tra 3 giorni prima della scadenza e la data di scadenza
                if(record.DataCambio != DateTime.MinValue && record.DataScadenza != DateTime.MinValue && record.DataCambio >= record.DataScadenza.AddDays(-3) && record.DataCambio <= record.DataScadenza)
                {
                    Console.WriteLine(record);
                }
            }
        }

    }
}
