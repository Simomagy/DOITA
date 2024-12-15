Console.WriteLine("Inserisci il numero di medici da inserire");
if (!int.TryParse(Console.ReadLine(), out int numMedici))
{
    // Controlla se l'input è un numero intero valido
    Console.WriteLine("Input non valido. Inserisci un numero intero.");
    return; // Termina il programma se l'input non è valido
}

// Dichiarazione degli array per memorizzare i dati dei medici
string[] names = new string[numMedici];
int[] expYears = new int[numMedici];
string[] area = new string[numMedici];
int[] ints = new int[numMedici];
int[] intsSucc = new int[numMedici];

// Ciclo per inserire i dati di ogni medico
for (int i = 0; i < numMedici; i++) // Itera da 0 a numMedici - 1
{
    Console.WriteLine("Inserisci il nome del medico " + (i + 1));
    names[i] = Console.ReadLine() ?? string.Empty; // Legge il nome del medico

    Console.WriteLine("Inserisci gli anni di esperienza del medico " + names[i]);
    if (!int.TryParse(Console.ReadLine(), out expYears[i]))
    {
        // Controlla se l'input è un numero intero valido
        Console.WriteLine("Input non valido. Inserisci un numero intero.");
        return; // Termina il programma se l'input non è valido
    }

    Console.WriteLine("Inserisci il reparto in cui lavora il medico " + names[i]);
    area[i] = Console.ReadLine() ?? string.Empty; // Legge il reparto del medico

    Console.WriteLine("Inserisci il numero di interventi del medico " + names[i]);
    if (!int.TryParse(Console.ReadLine(), out ints[i]))
    {
        // Controlla se l'input è un numero intero valido
        Console.WriteLine("Input non valido. Inserisci un numero intero.");
        return; // Termina il programma se l'input non è valido
    }

    Console.WriteLine("Inserisci il numero di interventi riusciti del medico " + names[i]);
    if (!int.TryParse(Console.ReadLine(), out intsSucc[i]))
    {
        // Controlla se l'input è un numero intero valido
        Console.WriteLine("Input non valido. Inserisci un numero intero.");
        return; // Termina il programma se l'input non è valido
    }

    Console.WriteLine("\n ------- \n"); // Separatore visivo tra le inserzioni dei medici
}

// Dichiarazione degli array per calcoli aggiuntivi
int[] stipendi = new int[numMedici];
int[] serialKiller = new int[numMedici];
int[] uccisioni = new int[numMedici];
int[] salvataggi = new int[numMedici];

// Ciclo per calcolare stipendi, serial killer, uccisioni e salvataggi
for (int i = 0; i < numMedici; i++) // Itera da 0 a numMedici - 1
{
    // Calcola lo stipendio base in base al reparto
    if (area[i].ToLower() == "anatomia")
    {
        stipendi[i] = 1300;
    }
    else if (area[i].ToLower() == "chirurgia")
    {
        stipendi[i] = 1500;
    }
    else if (area[i].ToLower() == "pediatria")
    {
        stipendi[i] = 2000;
    }
    else
    {
        stipendi[i] = 1700;
    }

    // Aggiunge bonus per anni di esperienza e interventi riusciti
    stipendi[i] += expYears[i] * (area[i].ToLower() == "pediatria" ? 100 : 50);
    stipendi[i] += intsSucc[i] * 10;
    // Sottrae penalità per interventi non riusciti
    stipendi[i] -= (ints[i] - intsSucc[i]) * (area[i].ToLower() == "pediatria" ? -20 : 50);

    // Determina se il medico è un "serial killer"
    if (intsSucc[i] * 2 < ints[i] && area[i].ToLower() != "pediatria")
    {
        serialKiller[i] = 1;
    }

    // Calcola il numero di uccisioni e salvataggi
    uccisioni[i] = ints[i] - intsSucc[i];
    salvataggi[i] = intsSucc[i];
}

// Calcolo dello stipendio totale e medio
int stipendioTotale = stipendi.Sum();
double stipendioMedio = stipendioTotale / (double)numMedici;

// Calcolo del numero di medici in pediatria e del loro stipendio medio
int numPediatria = area.Count(a => a.ToLower() == "pediatria");
double stipendioMedioPediatria = 0;
int countPediatria = 0;
for (int i = 0; i < numMedici; i++) // Itera da 0 a numMedici - 1
{
    if (area[i].ToLower() == "pediatria")
    {
        stipendioMedioPediatria += stipendi[i];
        countPediatria++;
    }
}
stipendioMedioPediatria = countPediatria > 0 ? stipendioMedioPediatria / countPediatria : 0;

// Calcolo del medico con lo stipendio più alto (esclusi i pediatri)
int maxStipendioIndex = -1;
int maxStipendio = int.MinValue;
for (int i = 0; i < stipendi.Length; i++) // Itera da 0 a stipendi.Length - 1
{
    if (area[i].ToLower() != "pediatria" && stipendi[i] > maxStipendio)
    {
        maxStipendio = stipendi[i];
        maxStipendioIndex = i;
    }
}

// Calcolo del medico con il massimo delle uccisioni
int maxUccisioniIndex = 0;
for (int i = 1; i < uccisioni.Length; i++) // Itera da 1 a uccisioni.Length - 1
{
    if (uccisioni[i] > uccisioni[maxUccisioniIndex])
    {
        maxUccisioniIndex = i;
    }
}

// Calcolo del medico con il rapporto uccisioni/salvataggi più alto
int maxRapportoIndex = -1;
double maxRapporto = double.MinValue;
for (int i = 0; i < uccisioni.Length; i++) // Itera da 0 a uccisioni.Length - 1
{
    if (salvataggi[i] != 0)
    {
        double rapporto = (double)uccisioni[i] / salvataggi[i];
        if (rapporto > maxRapporto)
        {
            maxRapporto = rapporto;
            maxRapportoIndex = i;
        }
    }
}

// Stampa dei risultati
Console.WriteLine("Nome\tAnni di esperienza\tReparto\tInterventi\tInterventi riusciti\tStipendio\tSerial Killer\tUccisioni\tSalvataggi\tRapporto Uccisioni/Salvataggi");
for (int i = 0; i < numMedici; i++) // Itera da 0 a numMedici - 1
{
    string serialKillerFlag = serialKiller[i] == 1 ? "Y" : "N";
    string rapportoFlag = i == maxRapportoIndex ? "Y" : "N";
    Console.WriteLine($"{names[i]}\t{expYears[i]}\t{area[i]}\t{ints[i]}\t{intsSucc[i]}\t{stipendi[i]}\t{serialKillerFlag}\t{uccisioni[i]}\t{salvataggi[i]}\t{rapportoFlag}");
}

// Stampa delle statistiche finali
Console.WriteLine($"\nLo stipendio totale dei medici è {stipendioTotale}");
Console.WriteLine($"Lo stipendio medio dei medici è {stipendioMedio}");
Console.WriteLine($"Il numero di medici che lavorano nel reparto pediatria è {numPediatria}");
Console.WriteLine($"Lo stipendio medio dei pediatri è {stipendioMedioPediatria}");
Console.WriteLine($"Il nome del medico che percepisce lo stipendio più alto, ma non del reparto Pediatria è {names[maxStipendioIndex]}");
Console.WriteLine($"Il numero di serial killer è {serialKiller.Sum()}");
Console.WriteLine("La lista dei serial killer è:");
for (int i = 0; i < numMedici; i++) // Itera da 0 a numMedici - 1
{
    if (serialKiller[i] == 1)
    {
        Console.WriteLine(names[i]);
    }
}
Console.WriteLine($"Il nome del medico che ha il massimo delle uccisioni è {names[maxUccisioniIndex]}");
if (maxRapportoIndex >= 0 && maxRapportoIndex < names.Length)
{
    Console.WriteLine($"Il nome del medico che ha il rapporto uccisioni / salvataggi più alto è {names[maxRapportoIndex]}");
}
else
{
    Console.WriteLine("Nessun medico ha un rapporto uccisioni / salvataggi valido.");
}