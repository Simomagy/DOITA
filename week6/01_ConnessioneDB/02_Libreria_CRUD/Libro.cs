namespace _02_Libreria_CRUD
{
    internal class Libro : Entity
    {
        public string Titolo { get; set; } = string.Empty;
        public string Autore { get; set; } = string.Empty;
        public string Genere { get; set; } = string.Empty;
        public int AnnoPubblicazione { get; set; }

        public Libro(int id, string titolo, string autore, string genere, int annoPubblicazione) : base(id)
        {
            Titolo = titolo;
            Autore = autore;
            Genere = genere;
            AnnoPubblicazione = annoPubblicazione;
        }

        public Libro() : base()
        {

        }

        public override string ToString()
        {
            return base.ToString() +
                $"Titolo: {Titolo}\n" +
                $"Autore: {Autore}\n" +
                $"Genere: {Genere}\n" +
                $"Anno di pubblicazione: {AnnoPubblicazione}\n" +
                $" ----------------------------- \n";
        }
    }
}
