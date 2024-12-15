/* Esercizio: Vacanze
Creare un programma che calcoli il prezzo dei biglietti dell'aereo in base all'input dell'utente
Chiedere:
        1) Quante persone andranno in vacanza.
        2) Quanti persone minori di 14 anni
            (Segnalare errore in caso risulti essere maggiore del totale delle persone)
        3) La destinazione
        4) Il mese di partenza
Il prezzo base cambia a seconda della destinazione:
        europa: 300 €
        africa: 500 €
        asia: 600 €
        america: 700 €
        altro: 800 €
a seconda del mese di partenza c'è un moltiplicatore diverso al prezzo base:
dicembre-gennaio-febbraio: 1.2
marzo-aprile-maggio: 1.5
altro: 1.8
I "bambini" pagano la metà (minori di 14 anni)
Stampare il costo del prezzo di una singola persona.
Stampare il prezzo che pagherà l'intero gruppo    */
using System.Collections.Generic;
using System;

double europa = 300, africa = 500, asia = 600, america = 700, altro = 800;
double singlePrice, childrenPrice, groupPrice;
List<Dest> destinations = new List<Dest>();
destinations.Add(new Dest("europa", 300));
destinations.Add(new Dest("africa", 500));
destinations.Add(new Dest("asia", 600));
destinations.Add(new Dest("america", 700));
destinations.Add(new Dest("altro", 800));

Trip trip = new();
Console.WriteLine("Benvenuti alla biglietteria automatica\nPer favore, inserire i dati richiesti per procedere.\nInserire numero partecipanti al viaggio");
trip.Participants = int.Parse(Console.ReadLine());
Console.WriteLine("Inserire numero di partecipanti che hanno meno di 14 anni");
trip.Children = int.Parse(Console.ReadLine());
if (trip.Children < trip.Participants)
{
    Console.WriteLine("Inserire la destinazione");
    string inputDestinaton = Console.ReadLine().ToLower();
    trip.Destination = destinations.Find(x => x.Name == inputDestinaton);
    Console.WriteLine("Inserire il mese di partenza in numeri (es. 1: gennaio - 12: dicembre");
    trip.MonthOfTrip = new Month(int.Parse(Console.ReadLine()));
    double multipliedPrice = trip.Destination.Price * trip.MonthOfTrip.Multiplier;
    trip.Prices = new Fares(multipliedPrice, trip.Participants, trip.Children);
    Console.WriteLine("Prezzi per persona:\n- Bambino: {0}\n- Adulto: {1}\nPrezzo per {2} persone: {3}\nBuon viaggio!", trip.Prices.ChildPrice, trip.Prices.SinglePrice, trip.Participants, trip.Prices.GroupPrice);
}
else
{
    Console.WriteLine("Numero di bambini maggiore al numero dei partecipanti!\nRiprova.");
}
class Trip
{
    public double Participants { get; set; }
    public double Children { get; set; }
    public Dest Destination { get; set; }
    public Month MonthOfTrip { get; set; }
    public Fares Prices { get; set; }

}

class Month
{
    public int Number { get; set; }
    public double Multiplier { get; set; }
    public Month(int num)
    {
        switch (num)
        {
            case 12:
            case 1:
            case 2:
                Number = num;
                Multiplier = 1.2;
                break;
            case 3:
            case 4:
            case 5:
                Number = num;
                Multiplier = 1.5;
                break;
            default:
                Number = num;
                Multiplier = 1.8;
                break;
        }
    }
}

class Fares
{
    public double SinglePrice { get; set; }
    public double GroupPrice { get; set; }
    public double ChildPrice { get; set; }
    public Fares(double multipliedPrice, double numberOfParticipants, double numChildren)
    {
        SinglePrice = multipliedPrice;
        GroupPrice = (multipliedPrice * (numberOfParticipants - numChildren)) + ((multipliedPrice * numChildren) * 0.5);
        ChildPrice = multipliedPrice * 0.5;
    }
}

class Dest
{
    public string? Name { get; set; }
    public double Price { get; set; }

    public Dest(string? name, double price)
    {
        Name = name;
        Price = price;
    }
}