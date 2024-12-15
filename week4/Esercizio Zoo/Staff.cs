namespace Esercizio_Zoo
{
    internal class Staff : Entity
    {
        string _nome;
        string _cognome;
        DateTime _nascita;
        int _anniEsperienza;
        string _gabbiaStaff;

        public string Nome { get => _nome; set => _nome = value; }
        public string Cognome { get => _cognome; set => _cognome = value; }
        public DateTime Nascita { get => _nascita; set => _nascita = value; }
        public int AnniEsperienza { get => _anniEsperienza; set => _anniEsperienza = value; }
        public string GabbiaStaff { get => _gabbiaStaff; set => _gabbiaStaff = value; }

        public Staff(string nome, string cognome, DateTime nascita, int anniEsperienza, string gabbiaStaff)
        {
            Nome = nome;
            Cognome = cognome;
            Nascita = nascita;
            AnniEsperienza = anniEsperienza;
            GabbiaStaff = gabbiaStaff;
        }
        public override string ToString()
        {
            return base.ToString() +
                   $"\nNome: {Nome}" +
                   $"\nCognome: {Cognome}" +
                   $"\nData di Nascita: {Nascita.ToString("dd/mm/yyyy")}" +
                   $"\nAnni di esperienza: {AnniEsperienza}" +
                   $"\nGabbia assegnata: {GabbiaStaff}";
        }

        public int Eta()
        {
            DateTime oggi = DateTime.Today;
            int eta = (oggi.Year - Nascita.Year);
            //escludere l'anno, calcolare se il giorno e il mese sono maggiori a quelli odierni, in quel caso sottrarre 1
            if ((oggi.Month < Nascita.Month) || ((oggi.Month == Nascita.Month && oggi.Day < Nascita.Day)))
            {
                eta -= 1;
            }
            return eta;
        }
    }
}