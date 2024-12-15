namespace Esercizio_Fattoria_INT
{
    internal interface IRisorseUmane
    {
        List<Entity> ListaBracciantiExp(int min, int max);

        double CostoSettimanaleBraccianti();
        double CostoSettimanaleBraccianti(bool vittoAlloggio);

    }
}
