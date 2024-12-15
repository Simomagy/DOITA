int numeroUtente;
string output;

// creare un programma che chieda ad un utente di inserire un numero
//chiedo ad un utente di inserire un numero, per far si che un utente possa leggere un valore i console devo scrivere nella console
Console.WriteLine("Inserisci un numero");
numeroUtente = int.Parse(Console.ReadLine());//LEGGO il numero che l'utente scrive in console e per non perderlo salvo il suo valore nella variabile numeroUtente


//quando devo assegnare o aggiornare il valore di una variabile a seconda del verificarsi o meno di una condizione possiamo usare
//un selettore che ha la stessa funzione dell'if-else ma permette un modo di scrivere il codice più contratto
//OPERATORE TERNARIO
//variabile = (condizione) ? valoreSeVero : valoreSeFalso;

output = (numeroUtente % 2) == 0 ? "il numero è pari" : "il numero è dispari";

Console.WriteLine(output);//stampo in console il valore della variabile ouput che avra un valore piuttosto che un altro a seconda del blocco di codice letto ed eseguito