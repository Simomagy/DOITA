namespace Videoteca
{
    internal class Products
    {
        private string type;
        private string title;
        private string genre;

        public string Type { get => type; set => type = value; }
        public string Title { get => title; set => title = value; }
        public string Genre { get => genre; set => genre = value; }

        public Products(string type, string title, string genre)
        {
            this.type = type;
            this.title = title;
            this.genre = genre;
        }

        List<Music> cds = new();
        List<Movie> dvds = new();

        public Products(string path)
        {
            PopulateFields(path);
        }

        public void PopulateFields(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] fields = line.Split(';');
                if (fields[0] == "cd")
                {
                    Music cd = new Music(fields[0], fields[1], fields[2], fields[3], int.Parse(fields[4]), double.Parse(fields[5]));
                    cds.Add(cd);
                }
                else if (fields[0] == "dvd")
                {
                    if (fields[5] == "S")
                    {
                        Movie dvd = new Movie(fields[0], fields[1], fields[2], fields[3], int.Parse(fields[4]), true);
                        dvds.Add(dvd);
                    }
                    else
                    {
                        Movie dvd = new Movie(fields[0], fields[1], fields[2], fields[3], int.Parse(fields[4]), false);
                        dvds.Add(dvd);
                    }
                }
            }
        }

        public void Scheda()
        {
            foreach (Music cd in cds)
            {
                Console.WriteLine(cd.ToString());
            }
            foreach (Movie dvd in dvds)
            {
                Console.WriteLine(dvd.ToString());
            }
        }

        public string Cerca(string artist)
        {
            string result = "";
            foreach (Music cd in cds)
            {
                if (cd.Author == artist)
                {
                    result += cd.Title + "\n";
                }
            }
            return result;
        }

        public List<Music> CercaBis(string genre)
        {
            List<Music> result = new();
            foreach (Music cd in cds)
            {
                if (cd.Genre == genre)
                {
                    result.Add(cd);
                }
            }
            return result;
        }

        public List<Movie> CercaTris(string director)
        {
            List<Movie> result = new();
            foreach (Movie dvd in dvds)
            {
                if (dvd.Director == director)
                {
                    result.Add(dvd);
                }
            }
            return result;
        }

        public List<Music> Budget(double budget)
        {
            List<Music> result = new();
            foreach (Music cd in cds)
            {
                if (cd.Price() <= budget)
                {
                    result.Add(cd);
                }
            }
            return result;
        }

        public List<Movie> HoTempo(int time)
        {
            List<Movie> result = new();
            foreach (Movie dvd in dvds)
            {
                if (dvd.Duration <= time)
                {
                    result.Add(dvd);
                }
            }
            return result;
        }

    }
}