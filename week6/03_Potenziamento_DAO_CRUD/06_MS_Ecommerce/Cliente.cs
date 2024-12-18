using _04_Utility;

namespace _06_MS_Ecommerce
{
    internal class Cliente : Entity
    {
        public string Username { get; set; } = string.Empty;
        public DateTime DataIscrizione { get; set; }
        public bool Maggiorenne { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                $"Username: {Username}\n" +
                $"DataIscrizione: {DataIscrizione:dd-MMM-yyyy}\n" +
                $"Maggiorenne: {(Maggiorenne ? "Sì" : "No")}\n";
        }
    }
}
