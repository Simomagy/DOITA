// Menu utente con opzioni
// 1. Visualizza il cliente che ha speso di piu
// 2. Merce piu ordinata
// 3. Visualizza la merce da sostituire (deve'essere sostituito al massimo 3 giorni prima della scadenza)

// Partecipanti gruppo:
// - Luca Mastronardi
// - Paolo Minopoli
// - Riccardo D'Agostino
// - Daniele Ercolani
// - Simone Magenes

using _06_MS_Ecommerce;

bool exit = false;
int choice;
string message = "Scegli un'opzione:\n" +
    "1. Visualizza il cliente che ha speso di piu\n" +
    "2. Merce piu ordinata\n" +
    "3. Visualizza la merce da sostituire\n" +
    "4. Visualizza la cronologia di acquisti di un utente basandosi sul suo id\n" +
    "9. Visualizza il menu\n" +
    "0. Esci\n";
Console.WriteLine("Benvenuto nel sistema di gestione del mercato");
Console.WriteLine(message);
choice = int.Parse(Console.ReadLine());
while(!exit)
{
    Carrello carrello = new();
    switch(choice)
    {
        case 1:
            // Visualizza il cliente che ha speso di piu
            carrello.TopBuyer();
            exit = true;
            break;
        case 2:
            // Merce piu ordinata
            carrello.MostOrdered();
            exit = true;
            break;
        //break;
        case 3:
            // Visualizza la merce da sostituire (deve'essere sostituito al massimo 3 giorni prima della scadenza)
            Merce merce = new Merce();
            merce.GoodsToBeReplaced();
            exit = true;
            break;
        case 4:
            // Visualizza la cronologia di acquisti di un utente basandosi sul suo id
            Console.WriteLine("Inserisci l'id del cliente");
            int userId = int.Parse(Console.ReadLine());
            carrello.PurchaseHistory(userId);
            exit = true;
            break;
        //break;
        case 9:
            Console.WriteLine(message);
            break;
        case 0:
            Console.WriteLine("Premi un tasto qualsiasi per uscire");
            Console.ReadLine();
            exit = true;
            break;
        default:
            Console.WriteLine("Scelta non valida");
            break;
    }
}
