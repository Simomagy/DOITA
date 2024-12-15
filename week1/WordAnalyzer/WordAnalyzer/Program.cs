//* Fare inserire ad un utente una serie di parole
//* salavere ogni parola in una cella di un array
//* stampare:
//* - la parola più lunga
//* - la parola più corta
//* - le parole che iniziano con la c
//* - le parole palindrome
//* - scorrere tutto l'array e saltare una parola a scelta

Console.WriteLine("Quante parole vuoi inserire?");
int n = int.Parse(Console.ReadLine());
string[] parole = new string[n];

// int i = 0;
// while (i < n) {
// Console.WriteLine("Inserisci la parola numero " + (i + 1));
// parole[i] = Console.ReadLine();
// i++;
// }

for (int i = 0; i < n; i++)
{
    Console.WriteLine("Inserisci la parola numero " + (i + 1));
    parole[i] = Console.ReadLine();
}

Console.WriteLine("La parola più lunga è: " + ParolaPiuLunga(parole));
Console.WriteLine("La parola più corta è: " + ParolaPiuCorta(parole));
Console.WriteLine("Le parole che iniziano con la c sono: " + ParoleConC(parole));
Console.WriteLine("Le parole palindrome sono: " + ParolePalindrome(parole));
Console.WriteLine("La parola saltata è: " + ParolaSaltata(parole));

static string ParolaPiuLunga(string[] parole)
{
    string parolaPiuLunga = parole[0];
    for (int i = 1; i < parole.Length; i++)
    {
        if (parole[i].Length > parolaPiuLunga.Length)
        {
            parolaPiuLunga = parole[i];
        }
    }
    return parolaPiuLunga;
}

static string ParolaPiuCorta(string[] parole)
{
    string parolaPiuCorta = parole[0];
    for (int i = 1; i < parole.Length; i++)
    {
        if (parole[i].Length < parolaPiuCorta.Length)
        {
            parolaPiuCorta = parole[i];
        }
    }
    return parolaPiuCorta;
}

static string ParoleConC(string[] parole)
{
    string paroleConC = "";
    for (int i = 0; i < parole.Length; i++)
    {
        if (parole[i].StartsWith("c"))
        {
            paroleConC += parole[i] + " ";
        }
    }
    return paroleConC;
}

static string ParolePalindrome(string[] parole)
{
    string parolePalindrome = "";
    for (int i = 0; i < parole.Length; i++)
    {
        string parolaInversa = "";
        for (int j = parole[i].Length - 1; j >= 0; j--)
        {
            parolaInversa += parole[i][j];
        }
        if (parole[i] == parolaInversa)
        {
            parolePalindrome += parole[i] + " ";
        }
    }
    return parolePalindrome;
}
static string ParolaSaltata(string[] parole)
{
    string parolaSaltata = string.Empty;
    for (int i = 0; i < parole.Length; i++)
    {
        if (i % 2 == 0)
        {
            parolaSaltata = parole[i];
        }
    }
    return parolaSaltata;
}