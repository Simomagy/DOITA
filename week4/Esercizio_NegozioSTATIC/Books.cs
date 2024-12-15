namespace Static
{
    #region Constructor and properties
    public class Book(int id, string type, string author, string title, string genre, double price, int totalPages, int releaseYear) : Product(id, type, title, genre, price, releaseYear)
    {
        public string Author
        {
            get; set;
        } = author;
        public int TotalPages { get; set; } = totalPages;



        public override string ToString()
        {
            return $"{base.ToString()} - {Author} - {TotalPages} pagine";
        }
    }
    #endregion
}
