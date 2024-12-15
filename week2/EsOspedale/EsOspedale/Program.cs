// Scrivere un programmino che letti da file i dati di alcuni pazienti mostri:
// - Lista delle schede dei pazienti
// - Paziente più anziano
// - Pazienti per una malattia a scelta dell'utente

using DatiPazienti;

string filePath = "../../../data.txt";
string[] pazienti;
pazienti = File.ReadAllLines(filePath);

Paziente[] pazientiOspedale = new Paziente[pazienti.Length];
for (int i  = 0; i  < pazienti.Length; i ++)
{
    Paziente paziente = new Paziente();
    string[] info = pazienti[i].Split(";");
    paziente.nome = info[0];
    paziente.cognome = info[1];
    paziente.dataNascita = info[2];
    paziente.malattia = info[3];
    paziente.reparto = info[4];
    pazientiOspedale[i] = paziente;
    Console.WriteLine(paziente.Scheda(i, "scheda"));
}

int annoMin = int.MaxValue;
int indexMin = 0;

for (int i = 0; i < pazienti.Length; i++)
{
    string[] info = pazienti[i].Split(";");
    string[] data = info[2].Split("-");
    int anno = int.Parse(data[2]);
    if (anno < annoMin)
    {
        annoMin = anno;
        indexMin = i;
    }
}

Console.WriteLine(pazientiOspedale[indexMin].Scheda(indexMin, "anziano"));

Console.WriteLine("Inserisci la malattia di cui vuoi vedere i pazienti:");
string malattiaScelta = Console.ReadLine();
Console.WriteLine($"\nPazienti con la malattia {malattiaScelta} \n");

for (int i = 0; i < pazienti.Length; i++)
{
    if (pazientiOspedale[i].malattia == malattiaScelta)
    {
        Console.WriteLine(pazientiOspedale[i].Scheda(i, "malattia"));
    }
}