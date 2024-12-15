// Concessionario campi:
// List<Veicolo> veicoli
// Concessionario metodi:
// ListaMoto(),ListaAuto(),Storici()->tutte le auto d'epoca,MotoCare()-< tutte le moto più costose

namespace Esercizio_Veicoli_Poli
{
    public class Concessionario
    {
        private List<Veicolo> _veicoli;
        public List<Veicolo> Veicoli { get => _veicoli; set => _veicoli = value; }
        public Concessionario(string filePath)
        {
            Veicoli = new List<Veicolo>();
            CaricaDatiDaFile(filePath);
        }
        private void CaricaDatiDaFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Il file {filePath} non esiste.");

            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                string[] dati = line.Split(';');

                string tipo = dati[0];
                string marca = dati[1];
                string modello = dati[2];
                string colore = dati[3];
                string immatricolazione = dati[4];

                switch (tipo)
                {
                    case "a": // Automobile
                        if (dati.Length < 8) continue;
                        int porte = int.Parse(dati[5]);

                        // Trasformo i valori S e N in boolean
                        if (dati[6] == "S")
                            dati[6] = "true";
                        else if (dati[6] == "N")
                            dati[6] = "false";
                        bool optional = bool.Parse(dati[6]);

                        // Trasformo i valori S e N in boolean
                        if (dati[7] == "S")
                            dati[7] = "true";
                        else if (dati[7] == "N")
                            dati[7] = "false";
                        bool ruotino = bool.Parse(dati[7]);

                        // Aggiungo l'automobile alla lista
                        Veicoli.Add(new Automobile(marca, modello, colore, immatricolazione, porte, optional, ruotino));
                        break;

                    case "m": // Moto
                        if (dati.Length < 8) continue;

                        // Trasformo i valori S e N in boolean
                        if (dati[5] == "S")
                            dati[5] = "true";
                        else if (dati[5] == "N")
                            dati[5] = "false";
                        bool passeggero = bool.Parse(dati[5]);

                        int bauletti = int.Parse(dati[6]);

                        // Trasformo i valori S e N in boolean
                        if (dati[7] == "S")
                            dati[7] = "true";
                        else if (dati[7] == "N")
                            dati[7] = "false";
                        bool cruiseControl = bool.Parse(dati[7]);

                        // Aggiungo la moto alla lista
                        Veicoli.Add(new Moto(marca, modello, colore, immatricolazione, passeggero, bauletti, cruiseControl));
                        break;

                    default:
                        // Tipo non riconosciuto
                        Console.WriteLine("\n === Errore ===");
                        Console.WriteLine($"Tipo non riconosciuto: {tipo}");
                        Console.WriteLine($"Dati: {string.Join(", ", dati)}");
                        Console.WriteLine(" === Fine Errore ===\n");
                        break;
                }
            }
        }

        public List<Veicolo> ListaCompleta()
        {
            return Veicoli;
        }
        public List<Moto> ListaMoto()
        {
            return Veicoli.OfType<Moto>().ToList();
        }
        public List<Automobile> ListaAuto()
        {
            return Veicoli.OfType<Automobile>().ToList();
        }
        public List<Veicolo> Storici()
        {
            return Veicoli.Where(v => v is Automobile a && a.Epoca()).ToList();
        }
        public List<Moto> MotoCare()
        {
            return Veicoli.OfType<Moto>().OrderByDescending(m => m.Prezzo()).ToList();
        }
    }
}