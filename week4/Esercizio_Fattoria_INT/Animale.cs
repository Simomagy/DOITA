namespace Esercizio_Fattoria_INT
{
    internal class Animale : Entity
    {
        string _razza;
        public string Razza
        {
            get => _razza;
            set
            {
                if (value.ToLower() != "gallina" && value.ToLower() != "mucca" && value.ToLower() != "toro" && value.ToLower() != "cavallo")
                {
                    _razza = "Mucca";
                }
            }
        }

        public int NZampe { get; set; }
        public string TipoAlimentazione { get; set; }

        public Animale(string[] row) : base(row)
        {
            Razza = row[3];
            NZampe = int.Parse(row[4]);
            TipoAlimentazione = row[5];
        }

        public override string ToString()
        {
            return base.ToString() + $"\nRazza: {Razza}\nNumero di zampe: {NZampe}\nTipo di alimentazione: {TipoAlimentazione}";
        }

        public override double CostoMensile()
        {
            double costo = 3;
            switch (Razza.ToLower())
            {
                case "gallina":
                    costo += 0.5;
                    break;
                case "cavallo":
                    costo += 7;
                    break;
                case "mucca":
                    costo += 12;
                    break;
                default:
                    costo += 8;
                    break;
            }

            if (TipoAlimentazione.ToLower() == "carnivoro")
            {
                costo += 4;
            }

            return costo;
        }

    }
}
