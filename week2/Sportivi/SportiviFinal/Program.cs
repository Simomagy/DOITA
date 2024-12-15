/*

dato il file sportivi.txt Scrivere un programma che legga un set di sportivi.
creare le classi modello necessarie:

Calciatore,nome,cognome,eta,numero maglia,ruolo,squadra
Tennista,nome,cognome,eta,sponsor,mancino/destro
Nuotatore,nome,cognome,eta,stilePreferito
Pugile,nome,cognome,eta,peso
Pilota,nome,cognome,eta,mezzo,scuderia

-- creare un aggregatore degli sportivi, Federazione, che gestisca tutti gli atleti.
-- stampare una lista di una categoria di sportivi a scelta dell'utente
-- cercare tutti gli sportivi che abbiano tra i 18 e i 28 anni
-- cercare uno sportivo per nome e cognome
stampare la media delle eta per categoria di sportivo

*/

using System.Diagnostics;
using Sportivi;

// CREA UNA loading bar che duri 5 secondi e poi stampa a video un titolo ascii art con scritto "Federazione Sportiva"

Console.ForegroundColor = ConsoleColor.Green;
Console.BackgroundColor = ConsoleColor.Black;
Console.Clear();

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
while (stopwatch.ElapsedMilliseconds < 3000)
{
    Console.Write("\rLoading: {0}", new string('█', (int)(stopwatch.ElapsedMilliseconds / 500)));
    Thread.Sleep(20);
}
stopwatch.Stop();

Console.WriteLine("\rLoading: ████████████████████ 100%");
Console.Clear();
Console.WriteLine("╔═A═N═N═A═══S═T═E═F═A═N═O═══════════════════════════════════════════════════════════════╗");
Console.WriteLine("║ _______ _______ _____  _______ ______ _______ _______ _______ _______ _______ _______ ║");
Console.WriteLine("║|    ___|    ___|     \\|    ___|   __ \\   _   |__     |_     _|       |    |  |    ___|║");
Console.WriteLine("║|    ___|    ___|  --  |    ___|      <       |     __|_|   |_|   -   |       |    ___|║");
Console.WriteLine("║|___|   |_______|_____/|_______|___|__|___|___|_______|_______|_______|__|____|_______|║");
Console.WriteLine("║                                                                                       ║");
Console.WriteLine("║            _______ _______ _______ _____   _______ _______ _______ _______            ║");
Console.WriteLine("║           |_     _|_     _|   _   |     |_|_     _|   _   |    |  |   _   |           ║");
Console.WriteLine("║            _|   |_  |   | |       |       |_|   |_|       |       |       |           ║");
Console.WriteLine("║           |_______| |___| |___|___|_______|_______|___|___|__|____|___|___|           ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════════A═N═N═A══S═T═E═F═A═N═O═╝");
Console.WriteLine("\n\n");

string percorso = "../../../sportivi.txt";
Federazione federazione = new Federazione(percorso);
// federazione.PopolaCampi();

// Domanda console
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("\n ▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬ \n");
Console.WriteLine("Scegli una categoria di sportivi da stampare");
string categoria = Console.ReadLine() ?? string.Empty;

Console.ForegroundColor = ConsoleColor.Green;
stopwatch.Restart();
while (stopwatch.ElapsedMilliseconds < 2000)
{
    Console.Write("\rCerco atleti: {0}", new string('█', (int)(stopwatch.ElapsedMilliseconds / 500)));
    Thread.Sleep(20);
}
Console.WriteLine("\rCerco atleti: ████████████████████ 100%");
Console.WriteLine("\n");

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(federazione.Scheda(categoria.ToLower()));
stopwatch.Restart();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\n Caricamento atleti tra i 18 e i 28 anni in corso...");
while (stopwatch.ElapsedMilliseconds < 2000)
{
    Console.Write("\rCerco atleti: {0}", new string('█', (int)(stopwatch.ElapsedMilliseconds / 500)));
    Thread.Sleep(20);
}

Console.WriteLine("\rCerco atleti: ████████████████████ 100%");

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(federazione.CercaEta());

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("\n ▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬ \n");
Console.WriteLine("Inserisci il nome e cognome dello sportivo da cercare");
string input = Console.ReadLine() ?? string.Empty;

stopwatch.Restart();
Console.ForegroundColor = ConsoleColor.Green;
while (stopwatch.ElapsedMilliseconds < 2000)
{
    Console.Write("\rCerco atleti: {0}", new string('█', (int)(stopwatch.ElapsedMilliseconds / 500)));
    Thread.Sleep(20);
}
Console.WriteLine("\rCerco atleti: ████████████████████ 100%");
Console.WriteLine("\n");

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(federazione.CercaNome(input));

stopwatch.Restart();
Console.ForegroundColor = ConsoleColor.Green;
while (stopwatch.ElapsedMilliseconds < 2000)
{
    Console.Write("\rCalcolo eta' media per categoria: {0}", new string('█', (int)(stopwatch.ElapsedMilliseconds / 500)));
    Thread.Sleep(20);
}
Console.WriteLine("\rCalcolo eta' media per categoria: ████████████████████ 100%");
Console.WriteLine("\n");

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(federazione.MediaEta());

Console.WriteLine("\n\n");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Premi un tasto per uscire");
Console.ReadKey();
Console.Clear();