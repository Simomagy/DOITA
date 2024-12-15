//Esercizio02_Selezione
//﻿
//Chiedere all'utente:
//    - il titolo di un libro
//    - il suo autore
//    - il numero di pagine
//    - il genere del libro
//Calcolare il prezzo del libro secondo le seguenti regole:
//    > prezzo base: 5
//    > se il genere è horror aggiungere 3,
//        se è fantasy aggiungere 2.5,
//        se è storico aggiungere 10,
//        in tutti gli altri casi aggiungere 1.9
//    > se l'autore è Rowling aggiungere 2.1,
//        se è Tolkien aggiungere 3.1,
//        se è King aggiungere 4
//        se è Manfredi aggiungere 3.5
//        in tutti gli altri casi aggiungere 1.5
//    > se il numero delle pagine è minore di 100 togliere il 5%
//        se il numero di pagine è compreso tra 100 e 200 aggiungere il 3%
//        se il numero di pagine supera i 200 aggiungere il 6%
//Stampare in console la scheda ordinata del libro con il suo prezzo

Console.WriteLine("Inserisci il titolo del libro");
string bookTitle = Console.ReadLine();
Console.WriteLine("Inserisci l'autore del libro" + bookTitle);
string bookAuthor = Console.ReadLine();
Console.WriteLine("Inserisci il numero di pagine del libro" + bookTitle);
int bookPages = int.Parse(Console.ReadLine());
Console.WriteLine("Inserisci il genere del libro" + bookTitle);
string bookGenre = Console.ReadLine();

double basePrice = 5;
double genrePrice = 0;
double authorPrice = 0;
double pagesPrice = 0;

if (bookGenre == "horror")
{
    genrePrice = 3;
}
else if (bookGenre == "fantasy")
{
    genrePrice = 2.5;
}
else if (bookGenre == "storico")
{
    genrePrice = 10;
}
else
{
    genrePrice = 1.9;
}

if (bookAuthor == "Rowling")
{
    authorPrice = 2.1;
}
else if (bookAuthor == "Tolkien")
{
    authorPrice = 3.1;
}
else if (bookAuthor == "King")
{
    authorPrice = 4;
}
else if (bookAuthor == "Manfredi")
{
    authorPrice = 3.5;
}
else
{
    authorPrice = 1.5;
}

if (bookPages < 100)
{
    pagesPrice = basePrice * 0.05;
}
else if (bookPages >= 100 && bookPages <= 200)
{
    pagesPrice = basePrice * 0.03;
}
else
{
    pagesPrice = basePrice * 0.06;
}

double totalPrice = basePrice + genrePrice + authorPrice + pagesPrice;

Console.WriteLine("Titolo: " + bookTitle);
Console.WriteLine("Autore: " + bookAuthor);
Console.WriteLine("Numero di pagine: " + bookPages);
Console.WriteLine("Genere: " + bookGenre);
Console.WriteLine(" =============== ");
Console.WriteLine("Prezzo: " + totalPrice);
