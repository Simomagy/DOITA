
// Dovremo gestire una serie di Veicoli che si dividono in Automobili e Moto
// Per ogni classe modello scrivere il metodo ToString(), prezzo() e altro se ci viene in mente
// Scrivere una classe aggregatrice con i metodi: ListaCompleta(), ListaMoto(), ListaAuto()

// campi Veicolo: marca,modello,colore,immatricolazione
// metodi Veicolo: ToString(),Prezzo() -> di base ritorna 1000

// campi Moto:passeggero,bauletti,cruiseControl
// metodi Moto: ToString(), Prezzo() -> perte dal prezzo base e a seconda della marca aumenta di valore. 
// Se ducati incrementa di 5000€, se harley davidson di 8000, se kawasaki di 5500. 
// Inoltre se ha il posto per il passeggero aumenta di 1000 altrimenti di 500, se ha il cruisecontrol aumenta di 2000 altrimenti di 100 e aggiungere 100€ per ogni bauletto

// campi Automobile: porte,optional,ruotino
// metodi Automobile:ToString(),  Prezzo()->parte dal prezzo di base e aumenta a seconda della marca. Se fiat aumenta di 10.000, altrimenti aumenta di 20.000. Se ha 3 porte aumentare di 3000, se 5 porte aumentare di 5000, altrimenti di 1000. Se ha gli optional aumentare di 3500 altrimenti di 1500. Se ha il ruotino aumentare di 2000, altrimenti di 1000.
// Epoca() -> se immatricolata prima del 2000 è d'epoca alrimenti non lo è 
// Concessionario campi:
// List<Veicolo> veicoli
// Concessionario metodi:
// ListaMoto(),ListaAuto(),Storici()->tutte le auto d'epoca,MotoCare()-< tutte le moto più costose

using Esercizio_Veicoli_Poli;

string filePath = "../../../data.txt";
Concessionario concessionario = new Concessionario(filePath);

Console.WriteLine("Lista completa:");
concessionario.ListaCompleta().ForEach(Console.WriteLine);

Console.WriteLine("\nLista moto:");
concessionario.ListaMoto().ForEach(Console.WriteLine);

Console.WriteLine("\nLista auto:");
concessionario.ListaAuto().ForEach(Console.WriteLine);

Console.WriteLine("\nLista storici:");
concessionario.Storici().ForEach(Console.WriteLine);

Console.WriteLine("\nMoto care:");
concessionario.MotoCare().ForEach(Console.WriteLine);

Console.WriteLine("\nPrezzi in ordine crescente:");
concessionario.Veicoli.OrderBy(v => v.Prezzo()).ToList().ForEach(v => Console.WriteLine($"{v} - Prezzo: {v.Prezzo()}"));

Console.WriteLine("\nPrezzi automobili:");
concessionario.Veicoli.OfType<Automobile>().OrderBy(v => v.Prezzo()).ToList().ForEach(v => Console.WriteLine($"{v} - Prezzo: {v.Prezzo()}"));

Console.WriteLine("\nPrezzi moto:");
concessionario.Veicoli.OfType<Moto>().OrderBy(v => v.Prezzo()).ToList().ForEach(v => Console.WriteLine($"{v} - Prezzo: {v.Prezzo()}"));

Console.WriteLine("\nPrezzi auto d'epoca:");
concessionario.Veicoli.OfType<Automobile>().Where(v => v.Epoca()).OrderBy(v => v.Prezzo()).ToList().ForEach(v => Console.WriteLine($"{v} - Prezzo: {v.Prezzo()}"));

Console.WriteLine("\nPrezzi moto care:");
concessionario.Veicoli.OfType<Moto>().Where(v => v.Prezzo() > 10000).OrderBy(v => v.Prezzo()).ToList().ForEach(v => Console.WriteLine($"{v} - Prezzo: {v.Prezzo()}"));

Console.WriteLine("\nPrezzi auto con optional:");
concessionario.Veicoli.OfType<Automobile>().Where(v => v.Optional).OrderBy(v => v.Prezzo()).ToList().ForEach(v => Console.WriteLine($"{v} - Prezzo: {v.Prezzo()}"));

Console.WriteLine("\nPrezzi moto con passeggero:");
concessionario.Veicoli.OfType<Moto>().Where(v => v.Passeggero).OrderBy(v => v.Prezzo()).ToList().ForEach(v => Console.WriteLine($"{v} - Prezzo: {v.Prezzo()}"));
