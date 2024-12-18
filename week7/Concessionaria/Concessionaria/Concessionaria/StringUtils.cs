namespace Utility
{
    /// <summary>
    /// Fornisce metodi di utilità per la manipolazione delle stringhe.
    /// </summary>
    public static class StringUtils
    {
        #region Metodi Pubblici

        /// <summary>
        /// Esegue l'escape dei singoli apici (') in una stringa sostituendoli con doppi apici singoli ('').
        /// Questo metodo è comunemente utilizzato per prevenire attacchi SQL injection durante la gestione delle query al database.
        /// </summary>
        /// <param name="input">La stringa di input da processare.</param>
        /// <returns>Una nuova stringa con tutti gli apici singoli escapati.</returns>
        /// <example>
        /// Esempio di utilizzo:
        /// <code>
        /// string input = "L'apostrofo in questa stringa sarà escapato.";
        /// string escapedInput = StringUtils.EscapeSingleQuotes(input);
        /// Console.WriteLine(escapedInput); // Output: L''apostrofo in questa stringa sarà escapato.
        /// </code>
        /// </example>
        public static string EscapeSingleQuotes(string input) => input.Replace("'", "''");

        #endregion
    }
}
