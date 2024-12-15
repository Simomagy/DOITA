namespace Esercizio_Zoo
{
    internal interface IZoo
    {
        List<Entity> ListaStaff();
        List<Entity> ListaAnimali();
        List<Entity> ListaAnimali(string specie);

    }
}
