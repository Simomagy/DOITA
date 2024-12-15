namespace Static
{
    #region Constructor and properties
    public class Movie(int id, string type, string director, string title, string genre, double price, int lenght, int releaseYear) : Product(id, type, title, genre, price, releaseYear)
    {
        public string Director { get; set; } = director;
        public int Lenght { get; set; } = lenght;

        public override string ToString()
        {
            return $"{base.ToString()} - {Director} - {Lenght} min";
        }
    }
    #endregion
}
