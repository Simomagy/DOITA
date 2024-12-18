using _04_Utility;

namespace _06_MS_Ecommerce
{
    internal class Carrello : Entity
    {
        public Cliente? Cliente { get; set; }
        public Merce? Merce { get; set; }
        public int Quantità { get; set; }

        /// <summary>
        /// Converte una riga del database negli attributi di <see cref="Carrello"/>
        /// </summary>
        /// <remarks>
        /// Il metodo controlla se la riga contiene i campi "cliente_id", "merce_id" e "quantita" <br/>
        /// Se i campi sono presenti, il metodo cerca il record del cliente e della merce nel database e li assegna a <see cref="Cliente"/> e <see cref="Merce"/> <br/>
        /// Infine assegna il valore di "quantita" a <see cref="Quantità"/>
        /// </remarks>
        /// <param name="line">
        /// Una riga del database sotto forma di dizionario con chiave il nome della colonna e valore il valore della cella
        /// </param>
        public override void TypeSort(Dictionary<string, string> line)
        {
            // Utilizzo TryGetValue per evitare un'eccezione se la chiave non è presente nel dizionario
            // Se la chiave è presente allora TryGetValue restituisce true e il valore associato alla chiave viene assegnato a clienteIdStr altrimenti restituisce false
            // Se il valore clienteIdStr è un intero allora lo assegno a clienteId
            // Se clienteId è un intero allora cerco il record del cliente nel database e lo assegno a Cliente
            if(line.TryGetValue("cliente_id", out var clienteIdStr) && int.TryParse(clienteIdStr, out var clienteId))
            {
                Cliente = DAOCliente.GetInstance().FindRecord(clienteId) as Cliente;
            }
            // Se la riga contiene il campo "merce_id" e il valore è un intero allora cerca il record della merce nel database e lo assegna a Merce
            if(line.TryGetValue("merce_id", out var merceIdStr) && int.TryParse(merceIdStr, out var merceId))
            {
                Merce = DAOMerce.GetInstance().FindRecord(merceId) as Merce;
            }
            // Se la riga contiene il campo "quantita" e il valore è un intero allora assegna il valore di "quantita" a Quantità
            if(line.TryGetValue("quantita", out var quantitàStr) && int.TryParse(quantitàStr, out var quantità))
            {
                Quantità = quantità;
            }
        }
        public override string ToString()
        {
            return base.ToString() +
                $"Id del cliente: {Cliente}\n" +
                $"Id della merce: {Merce}\n" +
                $"Quantità: {Quantità}\n";
        }

        /// <summary>
        /// Visualizza la cronologia di acquisti di un utente basandosi sul suo id
        /// </summary>
        /// <remarks>
        /// Il metodo recupera tutti i record dei carrelli dal database e li converte in una lista di <see cref="Carrello"/> per poter accedere ai dati specifici di <see cref="Carrello"/> <br/>
        /// Filtra i record dei carrelli per trovare solo quelli dell'utente specificato <br/>
        /// Infine stampa la cronologia di acquisti dell'utente
        /// </remarks>
        /// <param name="userId">
        /// L'id dell'utente di cui visualizzare la cronologia di acquisti
        /// </param>
        public void PurchaseHistory(int userId)
        {
            // Recupero tutti i record dei carrelli dal database
            List<Entity> records = DAOCarrello.GetInstance().GetRecords();
            // Converto la lista di Entity in una lista di Carrello per poter accedere ai dati specifici di Carrello
            List<Carrello> carrello = records.Cast<Carrello>().ToList();
            // Filtra i record dei carrelli per trovare solo quelli dell'utente specificato
            // Passaggi:
            // 1. Creo una chiave per il dizionario con l'id del cliente (c)
            // 2. Filtro i record dei carrelli per trovare solo quelli dell'utente specificato (c.Cliente.Id == userId)
            // 3. Converto il risultato in una lista
            List<Carrello> userCarrello = carrello.Where(c => c.Cliente?.Id == userId).ToList();
            // Controllo se l'utente ha effettuato acquisti
            if(userCarrello.Count == 0)
            {
                Console.WriteLine("Nessun acquisto effettuato.");
            } else
            {
                // Stampo la cronologia di acquisti dell'utente
                foreach(var record in userCarrello)
                {
                    Console.WriteLine("\nAcquisto:");
                    Console.WriteLine(record);
                    Console.WriteLine("----------------------------------------------------");
                }
            }
        }

        /// <summary>
        /// Trova l'utente che ha speso più soldi
        /// </summary>
        /// <remarks>
        /// Il metodo itera su tutti i <see cref="Carrello"/> e calcola il totale speso da ogni utente <br/>
        /// Infine trova l'ID dell'utente che ha speso di più e stampa i dati dell'<see cref="Cliente"/> che ha speso di più usando <see cref="DAOCliente.FindRecord(int)"/>) e il totale speso)
        /// </remarks>
        public void TopBuyer()
        {
            Console.WriteLine("Utente che ha speso di più:");
            // Recupero tutti i record dei carrelli dal database
            List<Entity> records = DAOCarrello.GetInstance().GetRecords();
            // Converto la lista di Entity in una lista di Carrello per poter accedere ai dati specifici di Carrello
            List<Carrello> carrello = records.Cast<Carrello>().ToList();
            // Recupero tutti i record dei clienti dal database e li converto in una lista di clienti per poter accedere ai dati specifici di Cliente
            List<Cliente> clienti = DAOCliente.GetInstance().GetRecords().Cast<Cliente>().ToList();
            // Creo un dizionario che associa l'id del cliente al totale speso dall'utente
            Dictionary<int, double> totalSpent = [];
            // Inizializzo il dizionario con tutti i clienti e il totale speso a 0
            foreach(var cliente in clienti)
            {
                totalSpent.Add(cliente.Id, 0);
            }
            // Calcolo il totale speso da ogni cliente iterando su tutti i carrelli
            foreach(var record in records)
            {
                // Converto l'Entity in un Carrello per poter accedere ai dati specifici di Carrello
                Carrello carrello2 = (Carrello) record;
                // Aggiungo il prezzo della merce moltiplicato per la quantità acquistata al totale speso dall'utente
                totalSpent[carrello2.Cliente.Id] += carrello2.Merce.Prezzo * carrello2.Quantità;
            }
            // Trova l'ID del cliente che ha speso di più usando LINQ
            // Passaggi:
            // 1. Creo una coppia chiave-valore con l'id del cliente e il totale speso (left(l) e right(r) dove l è il valore precedente e r è il valore successivo)
            // 2. Confronto i valori delle coppie chiave-valore (l.Value > r.Value) e restituisco la coppia con il valore maggiore (ternario ? l : r)
            // 3. Key restituisce la chiave della coppia con il valore maggiore (l'ID del cliente che ha speso di più)
            int maxId = totalSpent.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            // Stampa i dati dell'utente che ha speso di più e il totale speso
            Console.WriteLine(DAOCliente.GetInstance().FindRecord(maxId));
            Console.WriteLine($"Totale speso: ${totalSpent[maxId]}");
        }

        /// <summary>Trova la merce piu' ordinata dagli utenti</summary>
        /// <remarks>Il metodo itera su tutti i <see cref="Carrello"/> e calcola il numero di volte che e' stata ordinata ogni merce <br/>
        /// Infine trova l'ID della <see cref="Merce"/> piu' ordinata e stampa i dati della merce piu' ordinata usando <see cref="DAOMerce.FindRecord(int)"/>) e il numero di volte ordinata)
        /// </remarks>
        public void MostOrdered()
        {
            Console.WriteLine("Merce più ordinata:");
            // Recupero tutti i record dei carrelli dal database
            List<Entity> records = DAOCarrello.GetInstance().GetRecords();
            // Converto la lista di Entity in una lista di Carrello per poter accedere ai dati specifici di Carrello
            List<Carrello> carrello = records.Cast<Carrello>().ToList();
            // Recupero tutti i record delle merci dal database e li converto in una lista di merci per poter accedere ai dati specifici di Merce
            List<Merce> merci = DAOMerce.GetInstance().GetRecords().Cast<Merce>().ToList();
            // Creo un dizionario che associa l'id della merce al numero di volte che e' stata ordinata
            Dictionary<int, int> totalOrdered = [];
            // Inizializzo il dizionario con tutte le merci e il numero di volte ordinata a 0
            foreach(var merce in merci)
            {
                totalOrdered.Add(merce.Id, 0);
            }
            // Calcolo il numero di volte che e' stata ordinata ogni merce iterando su tutti i carrelli
            foreach(var record in records)
            {
                // Converto l'Entity (record) in un Carrello per poter accedere ai dati specifici di Carrello
                Carrello convertedCart = (Carrello) record;
                // Aggiungo la quantità ordinata al numero di volte che e' stata ordinata la merce
                totalOrdered[convertedCart.Merce.Id] += convertedCart.Quantità;
            }
            // Trova l'ID della merce piu' ordinata usando LINQ
            // Passaggi:
            // 1. Creo una coppia chiave-valore con l'id della merce e il numero di volte ordinata (left(l) e right(r) dove l è il valore precedente e r è il valore successivo)
            // 2. Confronto i valori delle coppie chiave-valore (l.Value > r.Value) e restituisco la coppia con il valore maggiore (ternario ? l : r)
            // 3. Key restituisce la chiave della coppia con il valore maggiore (l'ID della merce piu' ordinata)
            int maxId = totalOrdered.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            // Stampa i dati della merce piu' ordinata
            Console.WriteLine(DAOMerce.GetInstance().FindRecord(maxId));
            Console.WriteLine($"Numero di volte ordinata: {totalOrdered[maxId]}");
        }

    }
}