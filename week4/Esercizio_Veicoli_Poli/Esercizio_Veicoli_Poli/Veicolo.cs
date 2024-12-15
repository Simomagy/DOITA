// campi Veicolo: marca,modello,colore,immatricolazione
// metodi Veicolo: ToString(),Prezzo() -> di base ritorna 1000

namespace Esercizio_Veicoli_Poli
{
    public class Veicolo
    {
        private string _marca;
        private string _modello;
        private string _colore;
        private string _immatricolazione;
        public string Marca { get => _marca; set => _marca = value; }
        public string Modello { get => _modello; set => _modello = value; }
        public string Colore { get => _colore; set => _colore = value; }
        public string Immatricolazione { get => _immatricolazione; set => _immatricolazione = value; }
        public Veicolo(string marca, string modello, string colore, string immatricolazione)
        {
            Marca = marca;
            Modello = modello;
            Colore = colore;
            Immatricolazione = immatricolazione;
        }
        public override string ToString()
        {
            return $"Marca: {Marca}, Modello: {Modello}, Colore: {Colore}, Immatricolazione: {Immatricolazione}";
        }
        public virtual double Prezzo()
        {
            return 1000;
        }
    }
}