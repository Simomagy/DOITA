//Esercizio03_Iterazione_Selezione
//Programma banca on-line ...versione con PIN
//		 * Partendo da un bilancio (capitale) di 15.000  
//		 * creare un menu da permettere al correntista di fare le seguenti operazioni
//		 *  - bilancio 
//		 *  - deposito
//		 *  - storico operazioni

double balance = 15000;
int pin = 1234;
int userPin;
double deposit;
int choice;
double[] operations = new double[100];
int i = 0;

for (i = 0; i < 100; i++)
{
    operations[i] = 0;
}

for (i = 0; i < 3; i++)
{
    Console.WriteLine("Inserisci il tuo PIN");
    userPin = Convert.ToInt32(Console.ReadLine());
    if (userPin == pin)
    {
        Console.WriteLine("PIN corretto");
        Thread.Sleep(1000);
        Console.Clear();
        break;
    }
    else
    {
        Console.WriteLine("PIN errato");
        Console.WriteLine("Tentativi rimasti: " + (2 - i));
        Thread.Sleep(1000);
        Console.Clear();
    }
}

if (i == 3)
{
    Console.WriteLine("Hai esaurito i tentativi. Il programma si chiudera' automaticamente tra 5 secondi.");
    Thread.Sleep(5000);
    Environment.Exit(0);
}

bool isProgramRunning = true;

while (isProgramRunning)
{
    Console.WriteLine("Benvenuto nel tuo conto corrente");
    Console.WriteLine("Per favore, seleziona un'opzione");
    Console.WriteLine("1. Bilancio");
    Console.WriteLine("2. Deposito");
    Console.WriteLine("3. Storico operazioni");
    Console.WriteLine("====================");
    Console.WriteLine("0. Esci e chiudi il programma");

    choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 0:
            Console.WriteLine("Disconnesso con successo. Il programma si chiudera' automaticamente tra 5 secondi.");
            Thread.Sleep(5000);
            Environment.Exit(0);
            break;
        case 1:
            Console.WriteLine("Il tuo bilancio e' di: " + balance + " euro");
            break;
        case 2:
            Console.WriteLine("Inserisci l'importo che vuoi depositare");
            deposit = double.Parse(Console.ReadLine());
            balance += deposit;
            Console.WriteLine("Il tuo bilancio e' di: " + balance + " euro");
            operations[i] = balance;
            i++;
            break;
        case 3:
            Console.WriteLine("Storico operazioni");
            for (int j = 0; j < i; j++)
            {
                Console.WriteLine("Operazione " + (j + 1) + ": " + operations[j] + " euro");
            }
            break;
        default:
            Console.WriteLine("Scelta non valida");
            
            break;
        }
}
