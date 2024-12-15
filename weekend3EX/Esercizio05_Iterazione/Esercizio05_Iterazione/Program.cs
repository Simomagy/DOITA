// Esercizio05_Iterazione
// Siete i proprietari di un bar
// Stampare all'utente il vostro listino prezzi (Caffè -> 1.10 Acqua -> 1.50)
// Permettete all'utente di scegliere cosa vuole comprare.
// Stampare poi in console lo scontrino con tutto quello che ha scelto, i loro prezzi e il
// prezzo finale da pagare.
// Se la spesa supera i 25 euro, fare uno sconto del 5% su prezzo finale.
// Se l'utente prende più di 6 cose diverse scontare del 10% il prezzo finale.
// Potete cumulare gli sconti

using System;

Console.WriteLine("Benvenuto al bar!");
Console.WriteLine("Questo è il nostro listino prezzi:");
Console.WriteLine("Caffè -> 1.10");
Console.WriteLine("Acqua -> 1.50");

Console.WriteLine("Vuoi comprare qualcosa? (s/n)");
bool isBuying = Console.ReadLine().ToLower() == "s";
if (!isBuying)
{
    Console.WriteLine("Arrivederci!");
    return;
}

double total = 0;
int items = 0;
double discount = 0;
double discountPercentage = 0;
int waterQuantity = 0;
int coffeeQuantity = 0;

while (isBuying)
{
    Console.WriteLine("Cosa vuoi comprare?");
    string item = Console.ReadLine().ToLower();
    double price = 0;
    switch (item)
    {
        case "caffè":
            price = 1.10;
            coffeeQuantity++;
            break;
        case "acqua":
            price = 1.50;
            waterQuantity++;
            break;
        default:
            Console.WriteLine("Mi dispiace, non abbiamo questo prodotto.");
            break;
    }

    if (price > 0)
    {
        total += price;
        items++;
    }

    Console.WriteLine("Vuoi comprare altro? (s/n)");
    isBuying = Console.ReadLine().ToLower() == "s";
}

if (total > 25)
{
    discount += total * 0.05;
}

if (items > 6)
{
    discount += total * 0.10;
}

Console.WriteLine("Scontrino:\n");
Console.WriteLine($"Caffè: {coffeeQuantity} x 1.10");
Console.WriteLine($"Acqua: {waterQuantity} x 1.50");
Console.WriteLine("\n--------------------");
Console.WriteLine($"Totale: {total}");
Console.WriteLine($"Sconto: {discount}");
Console.WriteLine($"Totale da pagare: {total - discount}");
