using Bank;

string path = "../../../Dati.txt";
Banca MedioLanum = new Banca(path);

// Console.WriteLine(MedioLanum.StampaInfo("4200000000"));
// Console.WriteLine(MedioLanum.StampaInfo("4200000001"));
// Console.WriteLine(MedioLanum.StampaInfo("4200000002"));
// Console.WriteLine(MedioLanum.StampaInfo("4200000003"));
// Console.WriteLine(MedioLanum.StampaInfo("4200000004"));
// Console.WriteLine(MedioLanum.StampaInfo("4200000005"));
// Console.WriteLine(MedioLanum.StampaInfo("4200000006"));
// Console.WriteLine(MedioLanum.StampaInfo("4200000007"));
// Console.WriteLine(MedioLanum.StampaInfo("4200000008"));
// Console.WriteLine(MedioLanum.StampaInfo("4200000009"));

// List<string> clientData = new List<string> { "Mario Rossi;Via Roma 1;RSSMRA01A01H501A;01/01/1990;3331234567;1000" };
// BankAccount newAccount = new BankAccount();
// newAccount.CreateAccount(clientData);
// MedioLanum.AddAccount(newAccount);

Console.WriteLine("Sei un nuovo cliente? (s/n)");
string choice = (Console.ReadLine() ?? string.Empty).ToLower();
if (choice == "n")
{
    Console.WriteLine("Accesso clienti:\n Inserisci il tuo numero di conto:");
    string accountNumber = Console.ReadLine() ?? string.Empty;
    ClientMenu(accountNumber);
    return;
} else if (choice == "s")
{
    Console.WriteLine("Registrazione nuovo cliente:");
    BankAccount newAccount;
    string clientData = string.Empty;

    while (true)
    {
        Console.WriteLine("Inserisci il tuo nome e cognome:");
        string name = Console.ReadLine() ?? string.Empty;
        clientData += name + ";";

        Console.WriteLine("Inserisci il tuo indirizzo:");
        string address = Console.ReadLine() ?? string.Empty;
        clientData += address + ";";

        Console.WriteLine("Inserisci il tuo codice fiscale:");
        string fiscalCode = Console.ReadLine() ?? string.Empty;
        clientData += fiscalCode + ";";

        Console.WriteLine("Inserisci la tua data di nascita:");
        string birthDate = Console.ReadLine() ?? string.Empty;
        clientData += birthDate + ";";

        Console.WriteLine("Inserisci il tuo numero di telefono:");
        string phoneNumber = Console.ReadLine() ?? string.Empty;
        clientData += phoneNumber + ";";

        Console.WriteLine("Inserisci il saldo iniziale:");
        decimal initialBalance = decimal.Parse(Console.ReadLine() ?? string.Empty);
        clientData += initialBalance.ToString();

        newAccount = new BankAccount();
        newAccount.CreateAccount(clientData, true);
        MedioLanum.AddAccount(newAccount);

        Console.WriteLine("Vuoi creare un altro account? (s/n)");
        choice = Console.ReadLine()?.ToLower() ?? string.Empty;
        if (choice == "n")
        {
            break;
        } else if (choice == "s")
        {
            clientData = string.Empty;
        } else
        {
            Console.WriteLine("Scelta non valida");
            return;
        }
    }
} else
{
    Console.WriteLine("Scelta non valida");
    return;
}

void ClientMenu(string accountNumber)
{
    Console.WriteLine("Benvenuto nel menu clienti");
    Console.WriteLine("1. Visualizza saldo");
    Console.WriteLine("2. Effettua un deposito");
    Console.WriteLine("3. Effettua un prelievo");
    Console.WriteLine("4. Visualizza transazioni");
    Console.WriteLine("5. Esci");

    string choice = Console.ReadLine() ?? string.Empty;

    switch (choice)
    {
        case "1":
            Console.WriteLine(MedioLanum.StampaInfo(accountNumber));
            break;
        case "2":
            Console.WriteLine("Inserisci l'importo del deposito:");
            decimal amount = decimal.Parse(Console.ReadLine() ?? string.Empty);
            Console.WriteLine("Inserisci la causale del deposito:");
            string note = Console.ReadLine() ?? string.Empty;
            BankAccount account = MedioLanum.accounts.Find(a => a.AccountNumber == accountNumber);
            account.MakeDeposit(amount, DateTime.Now, note);
            Console.WriteLine("Operazione effettuata. Saldo attuale:");
            account.CalculateBalance();
            Console.WriteLine(MedioLanum.StampaInfo(accountNumber));
            break;
        case "3":
            Console.WriteLine("Inserisci l'importo del prelievo:");
            amount = decimal.Parse(Console.ReadLine() ?? string.Empty);
            Console.WriteLine("Inserisci la causale del prelievo:");
            note = Console.ReadLine() ?? string.Empty;
            account = MedioLanum.accounts.Find(a => a.AccountNumber == accountNumber);
            account.MakeWithdrawal(amount, DateTime.Now, note);
            Console.WriteLine("Operazione effettuata. Saldo attuale:");
            account.CalculateBalance();
            Console.WriteLine(MedioLanum.StampaInfo(accountNumber));
            break;
        case "4":
            Console.WriteLine("Transazioni effettuate:");
            account = MedioLanum.accounts.Find(a => a.AccountNumber == accountNumber);
            // TODO: da sistemare
            // foreach (Transaction transaction in account.Transactions)
            // {
            //     Console.WriteLine($"Data: {transaction.Date}, Tipo: {transaction.Type}, Importo: {transaction.Amount}, Causale: {transaction.Notes}");
            // }
            break;
        case "5":
            Console.WriteLine("Sei sicuro di voler uscire? (s/n)");
            choice = Console.ReadLine() ?? string.Empty;
            if (choice == "s")
            {
                return;
            } else if (choice == "n")
            {
                ClientMenu(accountNumber);
            } else
            {
                Console.WriteLine("Scelta non valida");
                return;
            }
            break;
        default:
            Console.WriteLine("Scelta non valida");
            break;
    }
}