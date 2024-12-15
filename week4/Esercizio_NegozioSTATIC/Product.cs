namespace Static
{
    #region Constructor and properties
    public abstract class Product(int id, string type, string title, string genre, double price, int releaseYear) : Entity(id)
    {
        public string Type { get; set; } = type;
        public string Title { get; set; } = title;
        public string Genre { get; set; } = genre;
        public double Price { get; set; } = price;
        public int ReleaseYear { get; set; } = releaseYear;

        public override string ToString()
        {
            return $"{Type} - {Title} - {Genre} - {Price:C} - {ReleaseYear}";
        }
    }
    #endregion
}
