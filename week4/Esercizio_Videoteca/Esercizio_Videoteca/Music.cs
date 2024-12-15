namespace Videoteca
{
    internal class Music : Products
    {
        private string author;
        private int tracks;
        private double averageDuration;

        public string Author { get => author; set => author = value; }
        public int Tracks { get => tracks; set => tracks = value; }
        public double AverageDuration { get => averageDuration; set => averageDuration = value; }

        public Music(string type, string title, string genre, string author, int tracks, double averageDuration)
            : base(type, title, genre)
        {
            this.author = author;
            this.tracks = tracks;
            this.averageDuration = averageDuration;
        }

        public override string ToString()
        {
            return $"Type: {Type} Title: {Title} Author: {Author} Genre: {Genre} Tracks: {Tracks} Average Duration: {AverageDuration}";
        }

        public double AlbumDuration()
        {
            return tracks * averageDuration;
        }

        public double Price()
        {
            return tracks * averageDuration * 0.5;
        }
    }
}