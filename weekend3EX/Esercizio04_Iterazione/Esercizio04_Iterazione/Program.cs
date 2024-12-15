// Esercizio04_Iterazione
// Scrivere un programma che permetta all'utente di inserire una serie di numeri positivi.
// Quando viene digitato 0 o un numero negativo interrompere il programma e stampare in console:
// - somma complessiva
// - numero maggiore inserito
// - numero minore inserito
// - somma dei numeri pari
// - media dei numeri multipli di 3

int somma = 0;
int max = int.MinValue;
int min = int.MaxValue;
int sommaPari = 0;
int countPari = 0;
int sommaMultipli3 = 0;
int countMultipli3 = 0;

while (true)
{
    Console.Write("Inserisci un numero: ");
    int numero = int.Parse(Console.ReadLine());

    if (numero <= 0)
    {
        break;
    }

    somma += numero;

    if (numero > max)
    {
        max = numero;
    }

    if (numero < min)
    {
        min = numero;
    }

    if (numero % 2 == 0)
    {
        sommaPari += numero;
        countPari++;
    }

    if (numero % 3 == 0)
    {
        sommaMultipli3 += numero;
        countMultipli3++;
    }

    if (numero % 2 != 0 && numero % 3 != 0)
    {
        Console.WriteLine("Numero non valido.");
    }
}

Console.WriteLine($"Somma complessiva: {somma}");
Console.WriteLine($"Numero maggiore inserito: {max}");
Console.WriteLine($"Numero minore inserito: {min}");
Console.WriteLine($"Somma dei numeri pari: {sommaPari}");
Console.WriteLine($"Media dei numeri pari: {(double)sommaPari / countPari}");
Console.WriteLine($"Somma dei numeri multipli di 3: {sommaMultipli3}");
Console.WriteLine($"Media dei numeri multipli di 3: {(double)sommaMultipli3 / countMultipli3}");