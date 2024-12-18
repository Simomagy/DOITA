namespace _07_Concessionaria
{
    internal class Moto : Prodotto
    {
        public bool Passeggeri { get; set; }
        
        public bool InCompagnia()
        {
            return Passeggeri && this.KMPercorribili() >= 100;
        }
    }
}
