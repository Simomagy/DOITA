using Esercizio_Fattoria_INT;

const string dataPath = "../../../data.csv";

Fattoria fattoria = new Fattoria(dataPath);

//Console.WriteLine(fattoria.ElencoAnimali()); //works
//Console.WriteLine(fattoria.ElencoBraccianti()); //works
//Console.WriteLine(fattoria.CostoMensileBraccianti()); //works
//Console.WriteLine(fattoria.CostoMensileAnimali()); //works
//Console.WriteLine(fattoria.CostoMensileMucche()); //works
//Console.WriteLine(fattoria.RazzaPiuCostosa()); //works
//Console.WriteLine(fattoria.CostoMensileTotale());//works

IFattoria fattoriaInterface = new Fattoria(dataPath);
List<Entity> animals = fattoriaInterface.ListaAnimali();
Console.WriteLine(fattoriaInterface.StampaElenco(animals));

IRisorseUmane risorseUmane = new Fattoria(dataPath);
List<Entity> braccianti = risorseUmane.ListaBracciantiExp(1, 5);
foreach (Entity e in braccianti)
{
    Console.WriteLine(e.ToString());
}

