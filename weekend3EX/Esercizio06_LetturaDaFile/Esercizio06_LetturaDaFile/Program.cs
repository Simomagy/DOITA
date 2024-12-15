// Esercizio06_LetturaDaFile
// Scrivere un file che contenga le marche delle auto di un concessionario.
// Voglio un programma che legga il file e stampi in console:
// - Il numero di marche presenti (Se nel file ci sono ripetizioni, non dovete contarle)
// - La marca più corta
// - Permettete all'utente di cercare una marca a sua scelta

using System;

string path = "../../../data.txt";
List<string> marche = new List<string>();

// Read the file content as a single string and split by semicolon
string fileContent = File.ReadAllText(path);
marche = fileContent.Split(';').Select(m => m.Trim()).ToList();

// Numero di marche presenti
int numeroMarche = marche.Distinct().Count();
Console.WriteLine($"Numero di marche presenti: {numeroMarche}");
Console.WriteLine("");

// Marca più corta
string marcaPiuCorta = marche.Where(m => !string.IsNullOrEmpty(m)).OrderBy(m => m.Length).FirstOrDefault();
if (marcaPiuCorta != null)
{
    Console.WriteLine($"La marca più corta è: {marcaPiuCorta}");
}
else
{
    Console.WriteLine("Non ci sono marche nel file.");
}
Console.WriteLine("");

// Permettere all'utente di cercare una marca
Console.WriteLine("Inserisci la marca che vuoi cercare:");
string marcaDaCercare = Console.ReadLine();
if (marche.Contains(marcaDaCercare))
{
    Console.WriteLine($"La marca {marcaDaCercare} è presente nel file");
}
else
{
    Console.WriteLine($"La marca {marcaDaCercare} non è presente nel file");
}
marche = File.ReadAllLines(path).ToList();