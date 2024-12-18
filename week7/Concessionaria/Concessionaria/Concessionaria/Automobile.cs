/// <summary>
/// Classe che rappresenta un'automobile, derivata dalla classe Prodotto.
/// </summary>
public class Automobile : Prodotto
{
    #region Proprietà

    /// <summary>
    /// Cilindrata dell'automobile in cc.
    /// </summary>
    public int Cilindrata { get; set; }

    /// <summary>
    /// Velocità massima dell'automobile in km/h.
    /// </summary>
    public int VelocitaMax { get; set; }

    /// <summary>
    /// Numero di posti dell'automobile.
    /// </summary>
    public int PostiAuto { get; set; }

    #endregion

    #region Metodi Pubblici

    /// <summary>
    /// Restituisce una rappresentazione stringa dell'automobile.
    /// </summary>
    /// <returns>Una stringa che rappresenta l'automobile.</returns>
    public override string ToString()
    {
        return base.ToString() + $", Cilindrata: {Cilindrata} cc, Velocità Massima: {VelocitaMax} km/h, Posti: {PostiAuto}";
    }

    /// <summary>
    /// Verifica se l'automobile è potente (cilindrata superiore a 2000 cc e marca famosa).
    /// </summary>
    /// <returns>True se l'automobile è potente, altrimenti False.</returns>
    public bool Potente()
    {
        return Cilindrata > 2000 && Famoso();
    }

    #endregion
}
