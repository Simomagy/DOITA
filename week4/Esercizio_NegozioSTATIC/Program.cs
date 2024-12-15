#region Instructions
/*
Siete i direttori di un negozio che vende libri, cd e film.
Il vostro database si basa su un file che viene letto di volta in volta dal programma che
gestisce il negozio.
Create una classe per ogni tipologia di prodotto:
Entity: id
Prodotto: capite voi dai figli quali campi avrà
Libri: tipo,autore,titolo,genere,prezzo,nPagine,annoPubblicazione
Film: tipo,regista,titolo,genere,prezzo,durata,annoPubblicazione
Cd: tipo,artista,titolo,genere,prezzo,nTracce,annoPubblicazione
Scrivete per ogni classe dei metodi statici che controllino la validità
(Suggerimento: potete anche creare una classe apposta che abbia solo metodi statici di controllo)
Creare una classe aggregatore Negozio che conterrà un List con ogni prodotto
Creare la sua interfaccia
Nel Program creare un menu che dia all'utente le seguenti opzioni.
Se l'utente dovesse scegliere un'opzione non valida, fate in modo che possa scegliere
nuovamente fino a 3 volte.
Dopo la terza volta, stampate una frase di chiusura.
1 - Elenco completo
2 - Elenco dei libri
3 - Elenco dei film
4 - Elenco dei cd
5 - Elenco dei prodotti pubblicati dopo un determinato anno scelto dall'utente
6 - Media dei prezzi dei film di un determinato genere scelto dall'utente
7 - Somma dei prezzi dei cd di un determinato artista scelto dall'utente
8 - Somma dei prezzi dei Libri pubblicati dopo un anno scelto dall'utente
9 - Nome dell'artista che ha pubblicato il maggior numero di cd
10 - Nome del regista che ha prodotto il film più costoso tra tutti quelli venduti
11 - Nome dell'autore che ha scritto il libro più corto di un determinato genere scelto dall'utente
12 - Chiedere all'utente se vuole visualizzare altro.
Se risponde no, mandare un feedback per salutarlo, altrimenti ripetere tutto il processo.
Aggiungere un metodo in negozio richiamato nel menù dell'utente che permetta di vedere l'elenco dei film ordinati per prezzo
*/
#endregion

#region Program Init
using Static;

Console.OutputEncoding = System.Text.Encoding.UTF8;
string dataPath = "../../../data.txt";
Store store = new(dataPath);
int tries = 0;
bool isRunning = true;
#endregion

Book libro = new Book(0, null, null, null, null, 0, 0, 0);
libro.Author = "Paolo";

while (isRunning)
{
    #region Elenco scelte
    Console.WriteLine("\nMenu:");
    Console.WriteLine("1 - Elenco completo");
    Console.WriteLine("2 - Elenco dei libri");
    Console.WriteLine("3 - Elenco dei film");
    Console.WriteLine("4 - Elenco dei cd");
    Console.WriteLine("5 - Elenco dei prodotti pubblicati dopo un anno");
    Console.WriteLine("6 - Media dei prezzi dei film di un genere");
    Console.WriteLine("7 - Somma dei prezzi dei cd di un artista");
    Console.WriteLine("8 - Somma dei prezzi dei libri pubblicati dopo un anno");
    Console.WriteLine("9 - Nome dell'artista che ha pubblicato il maggior numero di cd");
    Console.WriteLine("10 - Nome del regista che ha prodotto il film più costoso");
    Console.WriteLine("11 - Nome dell'autore che ha scritto il libro più corto di un genere");
    Console.WriteLine("12 - Elenco dei film ordinati per prezzo");
    Console.WriteLine("13 - Esci");
    #endregion

    Console.Write("\nInserisci la tua scelta: ");
    string choice = Console.ReadLine() ?? string.Empty;

    #region Gestione scelte
    switch (choice)
    {
        case "1":
            Console.WriteLine("\nElenco completo:");
            foreach (var product in store.PrintAll())
            {
                Console.WriteLine(product);
            }
            break;
        case "2":
            Console.WriteLine("\nElenco dei libri:");
            foreach (var book in store.PrintBooks())
            {
                Console.WriteLine(book);
            }
            break;
        case "3":
            Console.WriteLine("\nElenco dei film:");
            foreach (var film in store.PrintMovies())
            {
                Console.WriteLine(film);
            }
            break;
        case "4":
            Console.WriteLine("\nElenco dei cd:");
            foreach (var cd in store.PrintCDs())
            {
                Console.WriteLine(cd);
            }
            break;
        case "5":
            Console.Write("Inserisci l'anno: ");
            if (int.TryParse(Console.ReadLine(), out int year))
            {
                Console.WriteLine($"\nElenco dei prodotti pubblicati dopo l'anno {year}:");
                foreach (var product in store.ProductsByInputYear(year))
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine("Anno non valido.");
            }
            break;
        case "6":
            Console.Write("Inserisci il genere: ");
            string gentre = Console.ReadLine() ?? string.Empty;
            double FilmAveragePrice = store.AverageFilmsPriceByGenre(gentre);
            Console.WriteLine(FilmAveragePrice > 0 ? $"Media dei prezzi dei film del genere {gentre}: {FilmAveragePrice:C}" : "Genere non trovato.");
            break;
        case "7":
            Console.Write("Inserisci l'artista: ");
            string artist = Console.ReadLine() ?? string.Empty;
            double cdPriceSum = store.CDsPriceSumByArtist(artist);
            Console.WriteLine(cdPriceSum > 0 ? $"Somma dei prezzi dei cd dell'artista {artist}: {cdPriceSum:C}" : "Artista non trovato.");
            break;
        case "8":
            Console.Write("Inserisci l'anno: ");
            if (int.TryParse(Console.ReadLine(), out int bookReleaseYear))
            {
                double booksPriceSum = store.BooksPriceSumByInputYear(bookReleaseYear);
                Console.WriteLine(booksPriceSum > 0 ? $"Somma dei prezzi dei libri pubblicati dopo l'anno {bookReleaseYear}: {booksPriceSum:C}" : "Nessun libro trovato.");
            }
            else
            {
                Console.WriteLine("Anno non valido.");
            }
            break;
        case "9":
            Console.WriteLine($"L'artista che ha pubblicato il maggior numero di cd: {store.TopMusicTracksByArtist()}");
            break;
        case "10":
            Console.WriteLine($"Il regista che ha prodotto il film più costoso: {store.MostExpensiveMovieByDirector()}");
            break;
        case "11":
            Console.Write("Inserisci il genere: ");
            string bookGenre = Console.ReadLine() ?? string.Empty;
            Console.WriteLine($"L'autore che ha scritto il libro più corto del genere {bookGenre}: {store.ShortestBookByInputGenre(bookGenre)}");
            break;
        case "12":
            Console.WriteLine("\nElenco dei film ordinati per prezzo:");
            foreach (var movie in store.ProductsByPrice())
            {
                Console.WriteLine(movie);
            }
            break;
        case "13":
            Console.Write("Sei sicuro di voler uscire? (s/n): ");
            if ((Console.ReadLine() ?? string.Empty).ToLower() == "s")
            {
                Console.WriteLine("Grazie per aver utilizzato il programma! Arrivederci!");
                isRunning = false;
            }
            break;
        default:
            tries++;
            Console.WriteLine("Scelta non valida. Riprova.");
            if (tries >= 3)
            {
                Console.WriteLine("Troppe scelte non valide. Chiusura del programma.");
                isRunning = false;
            }
            break;

    }
    #endregion
}
