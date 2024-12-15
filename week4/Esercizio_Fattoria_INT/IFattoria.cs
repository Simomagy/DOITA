namespace Esercizio_Fattoria_INT
{
    internal interface IFattoria
    {
        List<Entity> ListaAnimali();
        List<Entity> ListaBraccianti();

        string StampaElenco(List<Entity> lista)
        {
            string ris = "Elenco: \n\n";
            foreach (Entity e in lista)
            {
                ris += e.ToString() + "\n";
            }
            return ris;
        }
    }
}
