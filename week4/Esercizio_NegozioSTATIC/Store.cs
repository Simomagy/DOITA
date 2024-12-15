namespace Static
{
    internal class Store : IStore
    {
        #region Properties
        public List<Product> Products { get; set; }
        #endregion
        #region Constructors
        public Store(string dataPath)
        {
            Products = [];
            LoadData(dataPath);
        }
        #endregion
        #region LoadData
        private void LoadData(string dataPath)
        {
            string[] lines = new string[0];

            #region File Path Check
            try
            {
                lines = File.ReadAllLines(dataPath);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File non trovato. Controlla il percorso.");
            }
            #endregion

            foreach (var line in lines)
            {
                try
                {
                    var data = line.Split(';');
                    int id = int.Parse(data[0]);
                    string type = data[1];
                    string authorOrDirectorOrArtist = data[2];
                    string title = data[3];
                    string genre = data[4];
                    double price = double.Parse(data[5]);
                    int publicationYear = int.Parse(data[6]);
                    int pagesOrDurationOrTracks = int.Parse(data[7]);

                    switch (type.ToLower())
                    {
                        case "libro":
                            var book = new Book(id, type, authorOrDirectorOrArtist, title, genre, price, pagesOrDurationOrTracks, publicationYear);
                            Products.Add(book);
                            break;
                        case "film":
                            var movie = new Movie(id, type, authorOrDirectorOrArtist, title, genre, price, pagesOrDurationOrTracks, publicationYear);
                            Products.Add(movie);
                            break;
                        case "cd":
                            var cd = new CD(id, type, authorOrDirectorOrArtist, title, genre, price, pagesOrDurationOrTracks, publicationYear);
                            Products.Add(cd);
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Formato non valido. Controlla i campi nel file.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Errore: " + e.Message);
                }
            }

        }
        #endregion
        #region Metodi implementati
        public List<Product> PrintAll()
        {
            return Products;
        }

        public List<Book> PrintBooks()
        {
            return Products.OfType<Book>().ToList();
        }

        public List<Movie> PrintMovies()
        {
            return Products.OfType<Movie>().ToList();
        }

        public List<CD> PrintCDs()
        {
            return Products.OfType<CD>().ToList();
        }

        public List<Product> ProductsByInputYear(int anno)
        {
            return Products.Where(p => p.ReleaseYear > anno).ToList();
        }

        public double AverageFilmsPriceByGenre(string genre)
        {
            var films = Products.OfType<Movie>().Where(f => f.Genre.ToLower() == genre.ToLower()).ToList();
            return films.Count > 0 ? films.Average(f => f.Price) : 0;
        }

        public double CDsPriceSumByArtist(string artist)
        {
            return Products.OfType<CD>().Where(cd => cd.Artist.ToLower() == artist.ToLower()).Sum(cd => cd.Price);
        }

        public double BooksPriceSumByInputYear(int year)
        {
            return Products.OfType<Book>().Where(book => book.ReleaseYear > year).Sum(libro => libro.Price);
        }

        public string TopMusicTracksByArtist()
        {
            return Products.OfType<CD>().GroupBy(cd => cd.Artist).OrderByDescending(g => g.Count()).FirstOrDefault()?.Key ?? "Nessun artista trovato.";
        }

        public string MostExpensiveMovieByDirector()
        {
            return Products.OfType<Movie>().OrderByDescending(f => f.Price).FirstOrDefault()?.Director ?? "Nessun regista trovato.";
        }

        public string ShortestBookByInputGenre(string genre)
        {
            return Products.OfType<Book>().Where(book => book.Genre.ToLower() == genre.ToLower()).OrderBy(book => book.TotalPages).FirstOrDefault()?.Author ?? "Nessun autore trovato.";
        }

        public List<Movie> ProductsByPrice()
        {
            return Products.OfType<Movie>().OrderBy(f => f.Price).ToList();
        }
        #endregion
    }
}
