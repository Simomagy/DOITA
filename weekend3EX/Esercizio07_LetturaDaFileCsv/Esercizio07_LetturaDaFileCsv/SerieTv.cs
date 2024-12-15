namespace Esercizio07_LetturaDaFileCsv
{
    internal class SerieTv
    {

        public string titolo { get; set; }
        public int numeroStagioni { get; set; }
        public int numeroEpisodiAStagione { get; set; }
        public string genere { get; set; }
        public string casaProduzione { get; set; }
        public int durataMediaEpisodio { get; set; }
        public int annoUscita { get; set; }

        public SerieTv(string titolo, int numeroStagioni, int numeroEpisodiAStagione, string genere, string casaProduzione, int durataMediaEpisodio, int annoUscita)
        {
            this.titolo = titolo;
            this.numeroStagioni = numeroStagioni;
            this.numeroEpisodiAStagione = numeroEpisodiAStagione;
            this.genere = genere;
            this.casaProduzione = casaProduzione;
            this.durataMediaEpisodio = durataMediaEpisodio;
            this.annoUscita = annoUscita;
        }  

        public SerieTv(string path)
        {
            PopulateFields(path);
        }

        List<SerieTv> serieTvs = new List<SerieTv>();

        public void PopulateFields(string path)
        {
            string[] lines = File.ReadAllLines(path);


            foreach (var line in lines)
            {
                string[] values = line.Split(",");
                SerieTv serieTv = new SerieTv(values[0], int.Parse(values[1]), int.Parse(values[2]), values[3], values[4], int.Parse(values[5]), int.Parse(values[6]));
                serieTvs.Add(serieTv);
            }
        }

        public void PrintTitles()
        {
            Console.WriteLine("Lista dei soli titoli: \n");
            foreach (var serieTv in serieTvs)
            {
                Console.WriteLine(serieTv.titolo);
            }
        }

        public void TopBySeasons()
        {
            Console.WriteLine("Titoli delle serie con il numero di stagioni maggiori: \n");
            int maxStagioni = serieTvs.Max(x => x.numeroStagioni);
            foreach (var serieTv in serieTvs)
            {
                if (serieTv.numeroStagioni == maxStagioni)
                {
                    Console.WriteLine("Titolo: " + serieTv.titolo + " Numero Stagioni: " + serieTv.numeroStagioni);
                }
            }
            Console.Error.WriteLine("Nessuna serie trovata");
        }

        public void TopByEpisodes()
        {
            Console.WriteLine("Titoli delle serie con il maggior numero di episodi in totale: \n");
            int maxEpisodi = serieTvs.Max(x => x.numeroStagioni * x.numeroEpisodiAStagione);
            foreach (var serieTv in serieTvs)
            {
                if (serieTv.numeroStagioni * serieTv.numeroEpisodiAStagione == maxEpisodi)
                {
                    Console.WriteLine("Titolo: " + serieTv.titolo + " Numero Episodi: " + serieTv.numeroStagioni * serieTv.numeroEpisodiAStagione);
                }
            }
            Console.Error.WriteLine("Nessuna serie trovata");
        }

        public void GenreByUser(string genre)
        {
            Console.WriteLine("I titoli delle serie con un genere a scelta dell'utente: \n");
            foreach (var serieTv in serieTvs)
            {
                if (serieTv.genere == genre)
                {
                    Console.WriteLine("Titolo: " + serieTv.titolo + " Genere: " + serieTv.genere);
                }
            }
            Console.Error.WriteLine("Nessuna serie trovata");
        }

        public void SeriesByProductionHouse()
        {
            Console.WriteLine("Per ogni casa di Produzione quante serie sono pubblicate: \n");
            var grouped = serieTvs.GroupBy(x => x.casaProduzione);
            foreach (var group in grouped)
            {
                Console.WriteLine("Casa di Produzione: " + group.Key + " Serie: " + group.Count());
            }
        }

        public void TimeToWatchAllEpisodes()
        {
            Console.WriteLine("Per ogni titolo, quanto tempo mi serve a vedere tutti gli episodi: \n");
            foreach (var serieTv in serieTvs)
            {
                Console.WriteLine("Titolo: " + serieTv.titolo + " Tempo: " + serieTv.numeroStagioni * serieTv.numeroEpisodiAStagione * serieTv.durataMediaEpisodio);
            }
        }

        public void FastestToWatch()
        {
            Console.WriteLine("Il titolo che posso vedere in meno tempo: \n");
            int minTime = serieTvs.Min(x => x.numeroStagioni * x.numeroEpisodiAStagione * x.durataMediaEpisodio);
            foreach (var serieTv in serieTvs)
            {
                if (serieTv.numeroStagioni * serieTv.numeroEpisodiAStagione * serieTv.durataMediaEpisodio == minTime)
                {
                    Console.WriteLine("Titolo: " + serieTv.titolo + " Tempo: " + serieTv.numeroStagioni * serieTv.numeroEpisodiAStagione * serieTv.durataMediaEpisodio);
                }
            }
            Console.Error.WriteLine("Nessuna serie trovata");
        }

        public void SeriesByMaxTime(int maxTime)
        {
            Console.WriteLine("Titoli che posso vedere dato un tempo massimo dall'utente (per intero): \n");
            foreach (var serieTv in serieTvs)
            {
                if (serieTv.numeroStagioni * serieTv.numeroEpisodiAStagione * serieTv.durataMediaEpisodio <= maxTime)
                {
                    Console.WriteLine("Titolo: " + serieTv.titolo + " Tempo: " + serieTv.numeroStagioni * serieTv.numeroEpisodiAStagione * serieTv.durataMediaEpisodio);
                }
            }
        }
    }
}
