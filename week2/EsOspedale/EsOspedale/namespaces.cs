using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatiPazienti
{
    internal class Paziente
    {
        public string nome;
        public string cognome;
        public string dataNascita;
        public string malattia;
        public string reparto;
        public string Scheda(int position, string outputType)
        {
            string output;
            switch (outputType)
            {
                case "scheda":
                    {
                        output =
                        $"Paziente {position + 1}" +
                        $"\nNome: {nome}" +
                        $"\nCognome: {cognome}" +
                        $"\nData di nascita: {dataNascita}" +
                        $"\nMalattia: {malattia}" +
                        $"\nReparto: {reparto}" +
                    "\n====================================\n";
                        return output;
                    }
                case "anziano":
                    {
                        output =
                            $"Paziente più anziano\n" +
                            $"Nome: {nome}" +
                            $"\nCognome: {cognome}" +
                            $"\nData di nascita: {dataNascita}" +
                            $"\nMalattia: {malattia}" +
                            $"\nReparto: {reparto}" +
                            "\n====================================\n";
                        return output;
                    }
                case "malattia":
                    {
                        output =
                            $"Paziente {position + 1}\n" +
                            $"Nome: {nome}" +
                            $"\nCognome: {cognome}" +
                            $"\nData di nascita: {dataNascita}" +
                            $"\nMalattia: {malattia}" +
                            $"\nReparto: {reparto}" +
                            "\n====================================\n";
                        return output;
                    }
                default:
                    throw new ArgumentException("Invalid output type", nameof(outputType));
            }
        }
    }
}
