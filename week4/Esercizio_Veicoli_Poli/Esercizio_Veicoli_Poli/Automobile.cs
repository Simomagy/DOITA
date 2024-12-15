// campi Automobile: porte,optional,ruotino
// metodi Automobile:ToString(), Prezzo()-> parte dal prezzo di base e aumenta a seconda della marca. Se fiat aumenta di 10.000, altrimenti aumenta di 20.000. Se ha 3 porte aumentare di 3000, se 5 porte aumentare di 5000, altrimenti di 1000. Se ha gli optional aumentare di 3500 altrimenti di 1500. Se ha il ruotino aumentare di 2000, altrimenti di 1000.
// Epoca() -> se immatricolata prima del 2000 è d'epoca alrimenti non lo è 
// Concessionario campi:
// List<Veicolo> veicoli
// Concessionario metodi:
// ListaMoto(),ListaAuto(),Storici()->tutte le auto d'epoca,MotoCare()-< tutte le moto più costose

namespace Esercizio_Veicoli_Poli
{
    public class Automobile : Veicolo
    {
        private int _porte;
        private bool _optional;
        private bool _ruotino;
        public int Porte { get => _porte; set => _porte = value; }
        public bool Optional { get => _optional; set => _optional = value; }
        public bool Ruotino { get => _ruotino; set => _ruotino = value; }
        public Automobile(string marca, string modello, string colore, string immatricolazione, int porte, bool optional, bool ruotino) : base(marca, modello, colore, immatricolazione)
        {
            Porte = porte;
            Optional = optional;
            Ruotino = ruotino;
        }
        public override string ToString()
        {
            return base.ToString() + $", Porte: {Porte}, Optional: {Optional}, Ruotino: {Ruotino}";
        }
        public override double Prezzo()
        {
            double prezzo = base.Prezzo();
            switch (Marca)
            {
                case "Fiat":
                    prezzo += 10000;
                    break;
                default:
                    prezzo += 20000;
                    break;
            }
            switch (Porte)
            {
                case 3:
                    prezzo += 3000;
                    break;
                case 5:
                    prezzo += 5000;
                    break;
                default:
                    prezzo += 1000;
                    break;
            }
            prezzo += Optional ? 3500 : 1500;
            prezzo += Ruotino ? 2000 : 1000;
            return prezzo;
        }
        public bool Epoca()
        {
            return int.Parse(Immatricolazione) < 2000;
        }
    }
}