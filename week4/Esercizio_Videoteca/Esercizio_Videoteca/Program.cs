// Avete un file di testo formattato così
// cd;Titolo Album;Nome Artista;Genere;Numero tracce;Durata media tracce;
// dvd;Titolo Film;Nome Regista;Genere;Durata Film;HD

// Scrivere la classe Prodotto che avrà come campi:
// string titolo, string nome, string genere
// e come metodi:
// > string Scheda()

// Scrivere la classe CD, figlia di Prodotto che avrà come campi:
// int  numeroTracce, int durataMediaTraccie
// e avrà i metodi:
// > string Scheda()
// > double DurataAlbum() -> Calcola quanto tempo in ore mi serve per alscoltare tutto l'album
// > double Prezzo() -> Calcolate voi come preferite il prezzo per l'album

// Scrivere la classe DVD, figlia di Prodotto che avrà come campi:
// int durataFilm, bool hd
// e i metodi:
// > string Scheda()
// > double Prezzo() -> Calcolate voi come preferite il prezzo per il film

// Scrivere la classe Negozio con List<CD> cds e List<DVD> dvds che leggerà i dati da file.
// Scrivere poi i metodi:
// string ListaCD()
// string ListaDVD()
// string ListaCompleta()
// string Cerca(string artista) -> Ritorna i titoli degli album dell'artista passato
// List<CD> CercaBis(string genere) -> Ritorna una lista di oggetti CD del genere passato
// List<DVD> CercaTris(string regista) -> Ritorna una lista di oggetti DVD del regista passato
// List<CD> Budget(double budget) -> Restituisce tutti i CD che posso comprare con i soldi passati
// List<DVD> HoTempo(int tempo) -> Restituisce tutti i DVD che posso vedere completi nel tempo passato

// Scrivere un Program in cui testare ogni metodo scritto in Negozio 

using Videoteca;

string dataPath = "../../../data.txt";
Products prodotti = new(dataPath);
Console.WriteLine(prodotti.ListaCD());