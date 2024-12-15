/*
         * stiamo organizzando una festa ad un amico
         * che compie gli anni 
         * chiedere all'organizzatore della festa
         * il numero di invitati
         * ad ogni invitato chiediamo il nome
         * e avendo definito un budget per il regalo
         * diamo la possibilità ad ognuno di mettere 
         * la somma che desidera
         * 
         * controllando che la somma dei regali non superi il budget
e che quando la soglia è stata raggiunta il programma si stoppi
         */

//Console questions
Console.WriteLine("Quanti invitati ci saranno alla festa?");
int guests = int.Parse(Console.ReadLine());
double sum = 0;
double budget = 100;
int i = 0;

while (i < guests)
{
    Console.WriteLine("Nome dell'invitato " + (i + 1));
    string nome = Console.ReadLine();
    Console.WriteLine("Quanto vuoi mettere per il regalo?");
    double contribuition = double.Parse(Console.ReadLine());
    sum += contribuition;
    if (sum > budget)
    {
        Console.WriteLine("Hai superato il budget");
        break;
    }
    i++;
}

