// Creare un programma che permetta di leggere un file, esso contiene le informazioni inerenti a dei videogiochi
// per poter gestore le info in modo efficace ->
// creare una classe modello per Videogioco che avrà le seguenti caratteristiche:

// -   titolo
// -   console
// -   dataRilascio
// -   studioDiSviluppo
// -   votoCritica
// -   votoUtente
// -   genere

// inoltre avrà i seguenti metodi:

// -   scheda()
// -   votoMedio() -> dato dalla media tra votodell'utente e voto della critica
// -   etaVideogioco() -> da quanti anni è stato pubblicato

// leggere il file
// prendere i dati e separarli
// creare i videogiochi e salvare in essi i dati letti dal file
// salvare i videogiochi in una lista
// stampare la lista completa dei videogiochi
// trovare il videogioco con la media più alta

// BONUS:
// stampare la lista dei videogiochi di solo genere "Survival" e sviluppati da "Naughty Dog"


using System.Runtime.Serialization.Formatters;
using Videogames_ClassLibrary;

string filePath = "../../../Dati.txt";
List<Videogame> videogames = new();
List<string> lines = File.ReadAllLines(filePath).ToList();

for (int i = 0; i < lines.Count; i++)
{
    string[] elements = lines[i].Split(";");
    Videogame videogame = new();
    videogame.Title = elements[0];
    videogame.Console = elements[1];
    videogame.Year = elements[2];
    videogame.Developer = elements[3];
    videogame.CriticsScore = int.Parse(elements[4]);
    videogame.UserScore = int.Parse(elements[5]);
    videogame.Genre = elements[6];
    
    videogames.Add(videogame);
    Console.WriteLine(videogame.Scheda());
}

// foreach (string line in lines)
// {
//     string[] elements = line.Split(';');
//     Videogame videogame = new()
//     {
//         Title = elements[0],
//         Console = elements[1],
//         Year = elements[2],
//         Developer = elements[3],
//         CriticsScore = int.Parse(elements[4]),
//         UserScore = int.Parse(elements[5]),
//         Genre = elements[6]
//     };
//     videogames.Add(videogame);
//     Console.WriteLine(videogame.Scheda());
// }

double maxAverage = 0;
Videogame bestVideogame = new();

for (int i = 0; i < videogames.Count; i++)
{
    double average = videogames[i].Average();
    if (average > maxAverage)
    {
        maxAverage = average;
        bestVideogame = videogames[i];
    }
}

// foreach (Videogame videogame in videogames)
// {
//     double average = videogame.Average();
//     if (average > maxAverage)
//     {
//         maxAverage = average;
//         bestVideogame = videogame;
//     }
// }

Console.WriteLine($"Il videogioco con la media più alta è: {bestVideogame.Title} con una media di {maxAverage}. Il gioco e' stato rilasciato nel {bestVideogame.Year} e sviluppato da {bestVideogame.Developer}.");

List<Videogame> survivalNaughtyDog = new();

for (int i = 0; i < videogames.Count; i++)
{
    if (videogames[i].Genre == "Survival" && videogames[i].Developer == "Naughty Dog")
    {
        survivalNaughtyDog.Add(videogames[i]);
    }
}

// foreach (Videogame videogame in videogames)
// {
//     if (videogame.Genre == "Survival" && videogame.Developer == "Naughty Dog")
//     {
//         survivalNaughtyDog.Add(videogame);
//     }
// }

Console.WriteLine("\n ==================================== \n");
Console.WriteLine("Lista dei videogiochi di genere 'Survival' e sviluppati da 'Naughty Dog':\n");

for (int i = 0; i < survivalNaughtyDog.Count; i++)
{
    Console.WriteLine(survivalNaughtyDog[i].Scheda());
}

// foreach (Videogame videogame in survivalNaughtyDog)
// {
//     Console.WriteLine(videogame.Scheda());
// }