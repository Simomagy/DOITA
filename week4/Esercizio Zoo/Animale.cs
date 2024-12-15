namespace Esercizio_Zoo
{
    internal class Animale : Entity
    {
        string _specie;
        int _numeroGabbia;
        string _alimentazione;
        string _sesso;
        double _peso;
        string _taglia;

        public string Specie { get => _specie; set => _specie = value; }
        public int NumeroGabbia { get => _numeroGabbia; set => _numeroGabbia = value; }
        public string Alimentazione { get => _alimentazione; set => _alimentazione = value; }
        public string Sesso { get => _sesso; set => _sesso = value; }
        public double Peso { get => _peso; set => _peso = value; }
        public string Taglia { get => _taglia; set => _taglia = value; }

        public Animale(int id, string specie, int numeroGabbia, string alimentazione, string sesso, double peso, string taglia) : base(id)
        {
            Specie = specie;
            NumeroGabbia = numeroGabbia;
            Alimentazione = alimentazione;
            Sesso = sesso;
            Peso = peso;
            Taglia = taglia;
        }

        public override string ToString()
        {
            return base.ToString() + $"\tL'animale {Specie} si trova nella gabbia numero {NumeroGabbia}. Ha un'alimentazione {Alimentazione} ed e' di genere {Sesso}, pesa {Peso} ed e' categorizzato come animale di taglia {Taglia}";
        }

    }
}
