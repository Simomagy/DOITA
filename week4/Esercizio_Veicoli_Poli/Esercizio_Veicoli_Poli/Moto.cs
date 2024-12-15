// campi Moto:passeggero,bauletti,cruiseControl
// metodi Moto: ToString(), Prezzo() -> perte dal prezzo base e a seconda della marca aumenta di valore. 
// Se ducati incrementa di 5000€, se harley davidson di 8000, se kawasaki di 5500. 
// Inoltre se ha il posto per il passeggero aumenta di 1000 altrimenti di 500, se ha il cruisecontrol aumenta di 2000 altrimenti di 100 e aggiungere 100€ per ogni bauletto

namespace Esercizio_Veicoli_Poli
{
    public class Moto : Veicolo
    {
        private bool _passeggero;
        private int _bauletti;
        private bool _cruiseControl;
        public bool Passeggero { get => _passeggero; set => _passeggero = value; }
        public int Bauletti { get => _bauletti; set => _bauletti = value; }
        public bool CruiseControl { get => _cruiseControl; set => _cruiseControl = value; }
        public Moto(string marca, string modello, string colore, string immatricolazione, bool passeggero, int bauletti, bool cruiseControl) : base(marca, modello, colore, immatricolazione)
        {
            Passeggero = passeggero;
            Bauletti = bauletti;
            CruiseControl = cruiseControl;
        }
        public override string ToString()
        {
            return base.ToString() + $", Passeggero: {Passeggero}, Bauletti: {Bauletti}, CruiseControl: {CruiseControl}";
        }
        public override double Prezzo()
        {
            double prezzo = base.Prezzo();
            switch (Marca)
            {
                case "Ducati":
                    prezzo += 5000;
                    break;
                case "Harley Davidson":
                    prezzo += 8000;
                    break;
                case "Kawasaki":
                    prezzo += 5500;
                    break;
            }
            prezzo += Passeggero ? 1000 : 500;
            prezzo += CruiseControl ? 2000 : 100;
            prezzo += Bauletti * 100;
            return prezzo;
        }
    }
}