//Esercizio07_LetturaDaFileCsv
// Dovete gestire un catalogo di serieTV
// Scrivere un file che avrà come dati:
// titolo, numeroStagioni, numeroEpisodiAStagione, genere, casaProduzione,
// durataMediaEpisodio, annoUscita

// Leggere il file dei dati e scrivere un menù che risponda alle seguenti domande:
// - Lista dei soli titoli
// - Titoli delle serie con il numero di stagioni maggiori
// - Titoli delle serie con il maggior numero di episodi in totale
// - I titoli delle serie con un genere a scelta dell'utente
// - Per ogni casa di Produzione quante serie sono pubblicate
// - Per ogni titolo, quanto tempo mi serve a vedere tutti gli episodi
// - Il titolo che posso vedere in meno tempo
// - Titoli che posso vedere dato un tempo massimo dall'utente (per intero)

using Esercizio07_LetturaDaFileCsv;

string path = "../../../data.csv";
SerieTv serieTv = new SerieTv(path);


serieTv.PrintTitles();

serieTv.TopBySeasons();

serieTv.TopByEpisodes();

Console.WriteLine("Inserisci un genere: ");
string genre = Console.ReadLine() ?? string.Empty;
serieTv.GenreByUser(genre.ToLower());

serieTv.SeriesByProductionHouse();

serieTv.TimeToWatchAllEpisodes();

serieTv.FastestToWatch();

Console.WriteLine("Inserisci il tempo massimo: ");
int maxTime = int.Parse(Console.ReadLine() ?? string.Empty);
serieTv.SeriesByMaxTime(maxTime);