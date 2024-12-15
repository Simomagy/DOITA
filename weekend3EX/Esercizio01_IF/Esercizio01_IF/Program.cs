//Esercizio01_IF
//Scrivere un programma che, ricevuti in input tre numeri, stampi il più
//grande dei tre.

Console.WriteLine("Inserisci il primo numero");
int num1 = int.Parse(Console.ReadLine());
Console.WriteLine("Inserisci il secondo numero");
int num2 = int.Parse(Console.ReadLine());
Console.WriteLine("Inserisci il terzo numero");
int num3 = int.Parse(Console.ReadLine());

if (num1 >= num2 && num1 >= num3)
    Console.WriteLine($"Il numero più grande è {num1}");
else if (num2 >= num1 && num2 >= num3)
    Console.WriteLine($"Il numero più grande è {num2}");
else
    Console.WriteLine($"Il numero più grande è {num3}");