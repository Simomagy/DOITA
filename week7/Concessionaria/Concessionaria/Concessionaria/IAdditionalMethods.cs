/// <summary>
/// Interfaccia che definisce metodi aggiuntivi per la gestione dei prodotti.
/// </summary>
public interface IAdditionalMethods
{
    #region Metodi di Ricerca

    /// <summary>
    /// Restituisce una lista di prodotti considerati vecchi.
    /// </summary>
    /// <returns>Una lista di prodotti vecchi.</returns>
    List<Prodotto> ListaProdottiVecchi();

    /// <summary>
    /// Calcola la massima distanza percorribile.
    /// </summary>
    /// <returns>Una stringa che rappresenta la massima distanza percorribile.</returns>
    string MaxDistanza();

    /// <summary>
    /// Restituisce una lista di automobili ad alte prestazioni.
    /// </summary>
    /// <returns>Una lista di automobili ad alte prestazioni.</returns>
    List<Automobile> AutoSuper();

    /// <summary>
    /// Restituisce una lista di moto sportive.
    /// </summary>
    /// <returns>Una lista di moto sportive.</returns>
    List<Moto> Sportive();

    /// <summary>
    /// Cerca prodotti in una determinata categoria.
    /// </summary>
    /// <param name="categoria">La categoria da cercare.</param>
    /// <returns>Una lista di prodotti nella categoria specificata.</returns>
    List<Prodotto> Cerca(string categoria);

    /// <summary>
    /// Calcola la frequenza delle diverse categorie di prodotti.
    /// </summary>
    /// <returns>Un dizionario che associa ogni categoria alla sua frequenza.</returns>
    Dictionary<string, int> Frequenza();

    /// <summary>
    /// Cerca prodotti di una determinata marca.
    /// </summary>
    /// <param name="marca">La marca da cercare.</param>
    /// <returns>Una stringa che rappresenta i prodotti trovati della marca specificata.</returns>
    string CercaPerMarca(string marca);

    #endregion

    #region Metodi di Stampa

    /// <summary>
    /// Stampa le informazioni di una lista di prodotti.
    /// </summary>
    /// <param name="array">La lista di prodotti da stampare.</param>
    /// <returns>Una stringa che rappresenta le informazioni dei prodotti nella lista.</returns>
    string StampaListe(List<Prodotto> array);

    #endregion

    #region Metodi di Calcolo

    /// <summary>
    /// Trova soluzioni di prodotti in base al budget mensile e al numero di passeggeri.
    /// </summary>
    /// <param name="budgetMensile">Il budget mensile disponibile.</param>
    /// <param name="passeggeri">Il numero di passeggeri.</param>
    /// <returns>Una lista di prodotti che soddisfano i criteri.</returns>
    List<Prodotto> TrovaSoluzione(double budgetMensile, int passeggeri);

    /// <summary>
    /// Restituisce una lista di automobili con elevate velocità.
    /// </summary>
    /// <returns>Una lista di automobili veloci.</returns>
    List<Automobile> Veloci();

    /// <summary>
    /// Restituisce una lista di prodotti ordinati per prezzo.
    /// </summary>
    /// <returns>Una lista di prodotti ordinati per prezzo.</returns>
    List<Prodotto> InOrdineDiPrezzo();

    #endregion
}

