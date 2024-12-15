double nStanza;
string formaStanza;
double lato1Stanza;
double lato2Stanza;
double areaStanza = 0;
double contatore;
bool inputErrato = false;

Console.WriteLine("CALCOLATORE DI PREZZO DELLE CASE\n");
Console.WriteLine("Quante stanze ha la casa?");
nStanza = double.Parse(Console.ReadLine());
Console.WriteLine("DEBUG: Numero stanze ricevuto: " + nStanza);

if (nStanza > 10)
{
    Console.WriteLine("L'ultimo dei tuoi problemi sono i soldi, cambia sito!!");
}
if (nStanza <= 0)
{
    Console.WriteLine("ERRORE: inserire un numero valido");
}
if (nStanza > 0 && nStanza <= 10)
{
    contatore = nStanza;
    while (contatore > 0)
    {
        Console.WriteLine("forma della stanza " + contatore + ": quadrato o rettangolo? [Q/R]");
        formaStanza = Console.ReadLine().ToLower();
        Console.WriteLine(formaStanza);
        switch (formaStanza)
        {
            case "q":
                Console.WriteLine("Inserire misura del lato (in metri):");
                lato1Stanza = double.Parse(Console.ReadLine());
                areaStanza += lato1Stanza * lato1Stanza;
                inputErrato = false;
                Console.WriteLine(inputErrato);
                break;
            case "r":
                Console.WriteLine("Inserire misura lato corto (in metri):");
                lato1Stanza = double.Parse(Console.ReadLine());
                Console.WriteLine("Inserire misura lato lungo (in metri):");
                lato2Stanza = double.Parse(Console.ReadLine());
                areaStanza += lato1Stanza * lato2Stanza;
                inputErrato = false;
                Console.WriteLine(inputErrato);
                break;
            default:
                Console.WriteLine("Forma non riconosciuta");
                contatore = 0;
                inputErrato = true;
                break;
        }
        contatore--;
    }
    if (!inputErrato)
    {
        Console.WriteLine("Entrato nell'IF riga 56");
        Console.WriteLine("L'area totale della casa è: " + areaStanza + "m^2");
        Console.WriteLine("Il prezzo è: " + (areaStanza * 300) + " euro");
        Console.WriteLine("L'area media di ogni singola stanza è: " + (areaStanza / nStanza) + " m^2");
    }
}