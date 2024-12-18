/// <summary>
/// Classe che rappresenta una moto, derivata dalla classe Prodotto.
/// </summary>
public class Moto : Prodotto
{
    #region Proprietà

    /// <summary>
    /// Indica se la moto è adatta a trasportare passeggeri.
    /// </summary>
    public bool Passeggeri { get; set; }

    #endregion

    #region Metodi Pubblici

    /// <summary>
    /// Restituisce una rappresentazione stringa della moto.
    /// </summary>
    /// <returns>Una stringa che rappresenta la moto.</returns>
    public override string ToString()
    {
        return base.ToString() + $", Passeggeri: {(Passeggeri ? "Sì" : "No")}";
    }

    /// <summary>
    /// Verifica se la moto è adatta a viaggiare in compagnia (con passeggeri)
    /// e se può percorrere almeno 100 km con un pieno di serbatoio.
    /// </summary>
    /// <returns>True se la moto è adatta a viaggiare in compagnia, altrimenti False.</returns>
    public bool InCompagnia()
    {
        return Passeggeri && KMPercorribili() >= 100;
    }

    #endregion
}
