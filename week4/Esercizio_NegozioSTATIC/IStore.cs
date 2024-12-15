namespace Static
{
    internal interface IStore
    {
        #region Lists
        List<Product> PrintAll();
        List<Book> PrintBooks();
        List<Movie> PrintMovies();
        List<CD> PrintCDs();
        List<Product> ProductsByInputYear(int year);
        List<Movie> ProductsByPrice();
        #endregion
        #region Methods
        double AverageFilmsPriceByGenre(string genre);
        double CDsPriceSumByArtist(string artist);
        double BooksPriceSumByInputYear(int year);
        string TopMusicTracksByArtist();
        string MostExpensiveMovieByDirector();
        string ShortestBookByInputGenre(string genre);
        #endregion
    }
}
