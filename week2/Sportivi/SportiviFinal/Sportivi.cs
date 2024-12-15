using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sportivi
{
    internal class Federazione
    {
        internal class Calciatore
        {
            public string nome;
            public string cognome;
            public int eta;
            public int numeroMaglia;
            public string ruolo;
            public string squadra;
        }

        internal class Tennista
        {
            public string nome;
            public string cognome;
            public int eta;
            public string sponsor;
            public bool destro;
        }

        internal class Nuotatore
        {
            public string nome;
            public string cognome;
            public int eta;
            public string stilePreferito;
        }

        internal class Pugile
        {
            public string nome;
            public string cognome;
            public int eta;
            public double peso;
        }

        internal class Pilota
        {
            public string nome;
            public string cognome;
            public int eta;
            public string mezzo;
            public string scuderia;
        }

        public List<Calciatore> calciatori = new List<Calciatore>();
        public List<Tennista> tennisti = new List<Tennista>();
        public List<Nuotatore> nuotatori = new List<Nuotatore>();
        public List<Pugile> pugili = new List<Pugile>();
        public List<Pilota> piloti = new List<Pilota>();

        public Federazione(string percorso)
        {
            PopolaCampi(percorso);
        }

        public void PopolaCampi(string percorso)
        {
            string[] lines = File.ReadAllLines(percorso);
            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                switch (values[0])
                {
                    case "calciatore":
                        Calciatore calciatore = new();
                        calciatore.nome = values[1];
                        calciatore.cognome = values[2];
                        calciatore.eta = int.Parse(values[3]);
                        calciatore.numeroMaglia = int.Parse(values[4]);
                        calciatore.ruolo = values[5];
                        calciatore.squadra = values[6];

                        calciatori.Add(calciatore);
                        break;
                    case "tennista":
                        Tennista tennista = new();
                        tennista.nome = values[1];
                        tennista.cognome = values[2];
                        tennista.eta = int.Parse(values[3]);
                        tennista.sponsor = values[4];
                        tennista.destro = bool.Parse(values[5]);

                        tennisti.Add(tennista);
                        break;
                    case "nuotatore":
                        Nuotatore nuotatore = new();
                        nuotatore.nome = values[1];
                        nuotatore.cognome = values[2];
                        nuotatore.eta = int.Parse(values[3]);
                        nuotatore.stilePreferito = values[4];

                        nuotatori.Add(nuotatore);
                        break;
                    case "pugile":
                        Pugile pugile = new();
                        pugile.nome = values[1];
                        pugile.cognome = values[2];
                        pugile.eta = int.Parse(values[3]);
                        pugile.peso = double.Parse(values[4]);

                        pugili.Add(pugile);
                        break;
                    case "pilota":
                        Pilota pilota = new();
                        pilota.nome = values[1];
                        pilota.cognome = values[2];
                        pilota.eta = int.Parse(values[3]);
                        pilota.mezzo = values[4];
                        pilota.scuderia = values[5];

                        piloti.Add(pilota);
                        break;
                }
            }
        }

        public string Scheda(string categoria)
        {
            StringBuilder output = new StringBuilder();
            switch (categoria)
            {
                case "calciatori":
                    foreach (Calciatore calciatore in calciatori)
                    {
                        output.AppendLine($"Nome: {calciatore.nome}, Cognome: {calciatore.cognome}, Età: {calciatore.eta}, Numero maglia: {calciatore.numeroMaglia}, Ruolo: {calciatore.ruolo}, Squadra: {calciatore.squadra}");
                    }
                    break;
                case "tennisti":
                    foreach (Tennista tennista in tennisti)
                    {
                        output.AppendLine($"Nome: {tennista.nome}, Cognome: {tennista.cognome}, Età: {tennista.eta}, Sponsor: {tennista.sponsor}, Dominanza: {tennista.destro}");
                    }
                    break;
                case "nuotatori":
                    foreach (Nuotatore nuotatore in nuotatori)
                    {
                        output.AppendLine($"Nome: {nuotatore.nome}, Cognome: {nuotatore.cognome}, Età: {nuotatore.eta}, Stile preferito: {nuotatore.stilePreferito}");
                    }
                    break;
                case "pugili":
                    foreach (Pugile pugile in pugili)
                    {
                        output.AppendLine($"Nome: {pugile.nome}, Cognome: {pugile.cognome}, Età: {pugile.eta}, Peso: {pugile.peso}");
                    }
                    break;
                case "piloti":
                    foreach (Pilota pilota in piloti)
                    {
                        output.AppendLine($"Nome: {pilota.nome}, Cognome: {pilota.cognome}, Età: {pilota.eta}, Mezzo: {pilota.mezzo}, Scuderia: {pilota.scuderia}");
                    }
                    break;
                default:
                    return "Categoria non valida";
            }
            return output.ToString();
        }
    
        public string CercaEta()
        {
            int minAge = 18;
            int maxAge = 28;

            List<Calciatore> ageCalciatori = calciatori.Where(calciatore => calciatore.eta >= minAge && calciatore.eta <= maxAge).ToList();
            List<Tennista> ageTennisti = tennisti.Where(tennista => tennista.eta >= minAge && tennista.eta <= maxAge).ToList();
            List<Nuotatore> ageNuotatori = nuotatori.Where(nuotatore => nuotatore.eta >= minAge && nuotatore.eta <= maxAge).ToList();
            List<Pugile> agePugili = pugili.Where(pugile => pugile.eta >= minAge && pugile.eta <= maxAge).ToList();
            List<Pilota> agePiloti = piloti.Where(pilota => pilota.eta >= minAge && pilota.eta <= maxAge).ToList();

            string output;
            output = $"\n\nAtleti tra i 18 e i 28 anni:\n\n";
            foreach (Calciatore calciatore in ageCalciatori)
            {
                output += $"Nome: {calciatore.nome}, Cognome: {calciatore.cognome}, Età: {calciatore.eta}, Numero maglia: {calciatore.numeroMaglia}, Ruolo: {calciatore.ruolo}, Squadra: {calciatore.squadra}\n";
            }
            foreach (Tennista tennista in ageTennisti)
            {
                output += $"Nome: {tennista.nome}, Cognome: {tennista.cognome}, Età: {tennista.eta}, Sponsor: {tennista.sponsor}, Dominanza: {tennista.destro}\n";
            }
            foreach (Nuotatore nuotatore in ageNuotatori)
            {
                output += $"Nome: {nuotatore.nome}, Cognome: {nuotatore.cognome}, Età: {nuotatore.eta}, Stile preferito: {nuotatore.stilePreferito}\n";
            }
            foreach (Pugile pugile in agePugili)
            {
                output += $"Nome: {pugile.nome}, Cognome: {pugile.cognome}, Età: {pugile.eta}, Peso: {pugile.peso}\n";
            }
            foreach (Pilota pilota in agePiloti)
            {
                output += $"Nome: {pilota.nome}, Cognome: {pilota.cognome}, Età: {pilota.eta}, Mezzo: {pilota.mezzo}, Scuderia: {pilota.scuderia}\n";
            }

            return output;
        }

        public string CercaNome(string input)
        {
            string nome = input.Split(' ')[0];
            string cognome = input.Split(' ')[1];
            string output = string.Empty;

            List<Calciatore> foundCalciatori = calciatori.Where(calciatore => calciatore.nome == nome && calciatore.cognome == cognome).ToList();

            if (foundCalciatori.Count == 0)
            {
                output += "Calciatore non trovato\n";
            }
            else
            {
                foreach (Calciatore calciatore in foundCalciatori)
                {
                    output += $"Nome: {calciatore.nome}, Cognome: {calciatore.cognome}, Età: {calciatore.eta}, Numero maglia: {calciatore.numeroMaglia}, Ruolo: {calciatore.ruolo}, Squadra: {calciatore.squadra}\n";
                }
            }

            List<Tennista> foundTennisti = tennisti.Where(tennista => tennista.nome == nome && tennista.cognome == cognome).ToList();

            if (foundTennisti.Count == 0)
            {
                output += "Tennista non trovato\n";
            }
            else
            {
                foreach (Tennista tennista in foundTennisti)
                {
                    output += $"Nome: {tennista.nome}, Cognome: {tennista.cognome}, Età: {tennista.eta}, Sponsor: {tennista.sponsor}, Dominanza: {tennista.destro}\n";
                }
            }

            List<Nuotatore> foundNuotatori = nuotatori.Where(nuotatore => nuotatore.nome == nome && nuotatore.cognome == cognome).ToList();

            if (foundNuotatori.Count == 0)
            {
                output += "Nuotatore non trovato\n";
            }
            else
            {
                foreach (Nuotatore nuotatore in foundNuotatori)
                {
                    output += $"Nome: {nuotatore.nome}, Cognome: {nuotatore.cognome}, Età: {nuotatore.eta}, Stile preferito: {nuotatore.stilePreferito}\n";
                }
            }

            List<Pugile> foundPugili = pugili.Where(pugile => pugile.nome == nome && pugile.cognome == cognome).ToList();

            if (foundPugili.Count == 0)
            {
                output += "Pugile non trovato\n";
            }
            else
            {
                foreach (Pugile pugile in foundPugili)
                {
                    output += $"Nome: {pugile.nome}, Cognome: {pugile.cognome}, Età: {pugile.eta}, Peso: {pugile.peso}\n";
                }
            }

            List<Pilota> foundPiloti = piloti.Where(pilota => pilota.nome == nome && pilota.cognome == cognome).ToList();

            if (foundPiloti.Count == 0)
            {
                output += "Pilota non trovato\n";
            }
            else
            {
                foreach (Pilota pilota in foundPiloti)
                {
                    output += $"Nome: {pilota.nome}, Cognome: {pilota.cognome}, Età: {pilota.eta}, Mezzo: {pilota.mezzo}, Scuderia: {pilota.scuderia}\n";
                }
            }

            return output;
        }
    
        public string MediaEta()
        {
            string output = string.Empty;
            double averageAge;

            int totalCalciatori = calciatori.Count;
            int calciatoriAgeSum = 0;
            foreach (Calciatore calciatore in calciatori)
            {
                calciatoriAgeSum += calciatore.eta;
            }
            averageAge = (double)calciatoriAgeSum / totalCalciatori;
            output += $"Media età calciatori: {averageAge}\n";

            int totalTennisti = tennisti.Count;
            int tennistiAgeSum = 0;
            foreach (Tennista tennista in tennisti)
            {
                tennistiAgeSum += tennista.eta;
            }
            averageAge = (double)tennistiAgeSum / totalTennisti;
            output += $"Media età tennisti: {averageAge}\n";
            
            int totalNuotatori = nuotatori.Count;
            int nuotatoriAgeSum = 0;
            foreach (Nuotatore nuotatore in nuotatori)
            {
                nuotatoriAgeSum += nuotatore.eta;
            }
            averageAge = (double)nuotatoriAgeSum / totalNuotatori;
            output += $"Media età nuotatori: {averageAge}\n";

            int totalPugili = pugili.Count;
            int pugiliAgeSum = 0;
            foreach (Pugile pugile in pugili)
            {
                pugiliAgeSum += pugile.eta;
            }
            averageAge = (double)pugiliAgeSum / totalPugili;
            output += $"Media età pugili: {averageAge}\n";

            int totalPiloti = piloti.Count;
            int pilotiAgeSum = 0;
            foreach (Pilota pilota in piloti)
            {
                pilotiAgeSum += pilota.eta;
            }
            averageAge = (double)pilotiAgeSum / totalPiloti;
            output += $"Media età piloti: {averageAge}\n";

            return output;
        }
    }
}