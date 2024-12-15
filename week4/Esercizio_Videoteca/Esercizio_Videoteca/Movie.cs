namespace Videoteca
{
    internal class Movie : Products
    {
        private string director;
        private int duration;
        private bool isHd;

        public string Director { get => director; set => director = value; }
        public int Duration { get => duration; set => duration = value; }
        public bool IsHd { get => isHd; set => isHd = value; }

        public Movie(string type, string title, string director, string genre, int duration, bool isHd)
            : base(type, title, genre)
        {
            this.duration = duration;
            this.director = director;
            this.isHd = isHd;
        }

        public override string ToString()
        {
            return $"Type: {Type} Title: {Title} Director: {Director} Genre: {Genre} Duration: {Duration} Is HD: {IsHd}";
        }

        public double Price()
        {
            double price = 0;
            if (isHd)
            {
                price = duration * 0.5 + 15;
            }
            else
            {
                price = duration * 0.5;
            }
            return price;
        }
    }
}