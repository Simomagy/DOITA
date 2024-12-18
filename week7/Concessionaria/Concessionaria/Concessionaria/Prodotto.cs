using Utility;
using System;
using System.Collections.Generic;

public class Prodotto : Entity
{
    #region Proprietà

    /// <summary>
    /// Categoria del prodotto.
    /// </summary>
    public string Categoria { get; set; }

    /// <summary>
    /// Marca del prodotto.
    /// </summary>
    public string Marca { get; set; }

    /// <summary>
    /// Modello del prodotto.
    /// </summary>
    public string Modello { get; set; }

    /// <summary>
    /// Indica se il prodotto è affittabile.
    /// </summary>
    public bool Affittabile { get; set; }

    /// <summary>
    /// Anno di immatricolazione del prodotto.
    /// </summary>
    public int AnnoImmatricolazione { get; set; }

    /// <summary>
    /// Consumo medio in km per litro.
    /// </summary>
    public int ConsumoMedioAKM { get; set; }

    /// <summary>
    /// Capacità del serbatoio in litri.
    /// </summary>
    public int CapienzaSerbatoio { get; set; }

    #endregion

    #region Metodi Pubblici

    /// <summary>
    /// Restituisce una rappresentazione stringa del prodotto.
    /// </summary>
    /// <returns>Una stringa che rappresenta il prodotto.</returns>
    public override string ToString()
    {
        return $"Marca: {Marca}, Modello: {Modello}, Categoria: {Categoria}, Anno: {AnnoImmatricolazione}, " +
               $"KM Percorribili: {KMPercorribili():F2}, Affittabile: {(Affittabile ? "Sì" : "No")}, Prezzo: {Prezzo():C}, " +
               $"Consumo Medio: {ConsumoMedioAKM} km/l, Capienza Serbatoio: {CapienzaSerbatoio} litri";
    }

    /// <summary>
    /// Calcola il prezzo del prodotto.
    /// </summary>
    /// <returns>Il prezzo del prodotto.</returns>
    public double Prezzo()
    {
        double prezzoBase = Categoria.ToLower() == "automobile" ? 20000 : 10000;

        if (Famoso())
        {
            prezzoBase *= 2.5;
        }

        int eta = DateTime.Now.Year - AnnoImmatricolazione;
        double deprezzamento = prezzoBase * 0.05 * eta;

        return Math.Max(prezzoBase - deprezzamento, 0);
    }

    /// <summary>
    /// Verifica se la marca del prodotto è famosa.
    /// </summary>
    /// <returns>True se la marca è famosa, altrimenti False.</returns>
    public bool Famoso()
    {
        var famousBrands = new HashSet<string> { "Rolls Royce", "Ferrari", "Ducati", "Harley Davidson" };
        return famousBrands.Contains(Marca);
    }

    /// <summary>
    /// Calcola i chilometri percorribili con un pieno di serbatoio.
    /// </summary>
    /// <returns>I chilometri percorribili.</returns>
    public double KMPercorribili()
    {
        return CapienzaSerbatoio * 100.0 / ConsumoMedioAKM;
    }

    /// <summary>
    /// Calcola l'affitto mensile del prodotto se è affittabile.
    /// </summary>
    /// <returns>L'affitto mensile.</returns>
    public double AffittoMensile()
    {
        if (Affittabile)
        {
            double prezzoAnnuale = Prezzo() * 0.4;
            return prezzoAnnuale / 12;
        }
        return 0;
    }

    /// <summary>
    /// Calcola l'età del prodotto in anni.
    /// </summary>
    /// <returns>L'età del prodotto.</returns>
    public int Eta()
    {
        return DateTime.Now.Year - AnnoImmatricolazione;
    }

    #endregion
}
