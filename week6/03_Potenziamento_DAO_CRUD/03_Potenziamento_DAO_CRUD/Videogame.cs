namespace _03_Potenziamento_DAO_CRUD
{
    internal class Videogame : Entity
    {
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public string Developer { get; set; } = string.Empty;

        public Videogame(int id, string title, string genre, int releaseYear, string developer) : base(id)
        {
            Title = title;
            Genre = genre;
            ReleaseYear = releaseYear;
            Developer = developer;
        }

        public Videogame() : base() { }

        public override string ToString()
        {
            return base.ToString() +
                $"Titolo: {Title}\n" +
                $"Genere: {Genre}\n" +
                $"Anno di uscita: {ReleaseYear}\n" +
                $"Developer: {Developer}\n" +
                $"\n =============================== \n";
        }
    }
}
