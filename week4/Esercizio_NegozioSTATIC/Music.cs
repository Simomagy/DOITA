namespace Static
{
    #region Constructor and properties
    public class CD(int id, string type, string artist, string title, string genre, double price, int totalTracks, int releaseYear) : Product(id, type, title, genre, price, releaseYear)
    {
        public string Artist { get; set; } = artist;
        public int TotalTracks { get; set; } = totalTracks;

        public override string ToString()
        {
            return $"{base.ToString()} - {Artist} - {TotalTracks} tracce";
        }
    }
    #endregion
}
