using _04_Utility;

namespace _07_Concessionaria
{
    internal class Prodotto : Entity
    {
        public string Categoria { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Modello { get; set; } = string.Empty;
        public bool Affittabile { get; set; }
        public int AnnoImmatricolazione { get; set; }
        public double ConsumoMedioAKM { get; set; }
        public int CapienzaSerbatoio { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                $"Categoria: {Categoria}\n" +
                $"Marca: {Marca}\n" +
                $"Modello: {Modello}\n" +
                $"Affittabile: {Affittabile}\n" +
                $"Anno Immatricolazione: {AnnoImmatricolazione}\n" +
                $"Consumo Medio al KM: {ConsumoMedioAKM}\n" +
                $"Capienza Serbatoio: {CapienzaSerbatoio}\n";
        }

        public double Prezzo()
        {
            double price = 5000;
            switch(Categoria)
            {
                case "Automobile":
                    price *= 3.55;
                    price *= Famoso() ? 1.2 : 0.8;
                    break;
                case "Moto":
                    price *= 1.42;
                    price *= Famoso() ? 1.1 : 0.9;
                    break;
                default:
                    price = 420.69;
                    break;
            }
            return price;
        }

        public bool Famoso()
        {
            return Marca == "Ferrari" || Marca == "Ducati" || Marca == "Rolls Royce" || Marca == "Harley Davidson";
        }

        public double KMPercorribili()
        {
            return ConsumoMedioAKM / CapienzaSerbatoio;
        }
        //Se "affittabile" è TRUE, partendo da un prezzo di affitto pari al 40% del prezzo di vendita originale(considerate questo prezzo come il totale annuo), calcolare quanto costa al mese affittare la macchina
        public double AffittoMensile()
        {
            return Affittabile ? Prezzo() * 0.4 / 12 : 0;
        }
        //Calcola gli anni trascorsi da quando è stata immatricolata la macchina
        public int Eta()
        {
            return DateTime.Now.Year - AnnoImmatricolazione;
        }
    }
}
