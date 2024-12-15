//PRINCIPI PROGRAMMAZIONE GENERICA:
//-1: SEQUENZA, il codice viene letto ed eseguito dall'alto verso il basso
//- 2: SELEZIONE che usa i SELETTORI: permette di cambaire strategia/azione a seconda del verificarsi di una condizione
//- 3: ITERAZIONE che usa gli ITERATORI: permette di ripetere lo stesso blocco di codice per un numero determinato o in

//WHILE: ripete un blocco di codice SE e FINCHE' la condizione di partenza risulta VERA

//while(condizione){
//blocco di codice con l'istruzione/i da eseguire N volte

//

//chiedere ad un utente di inserire il suo user, far ripetere l'inserimento finché lo user non è corretto
string validUser = "PiPp0";
string user = string.Empty;
string output = string.Empty;
bool isUserValid = false;

while (!isUserValid)
{
    Console.WriteLine("Inserisci il tuo user");
    user = Console.ReadLine();
    isUserValid = user == validUser;
    output = user == validUser ? "User corretto" : "User errato";
    Console.WriteLine(output);
}