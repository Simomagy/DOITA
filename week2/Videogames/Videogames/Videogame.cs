using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videogames_ClassLibrary
{
    internal class Videogame
    {
        public string Title;
        public string Console;
        public string Year;
        public string Developer;
        public int CriticsScore;
        public int UserScore;
        public string Genre;

        public string Scheda()
        {
            return
                $"Titolo: {Title}\n" +
                $"Console: {Console}\n" +
                $"Anno: {Year}\n" +
                $"Eta' del videogioco: {VideogameAge()} anni\n" +
                $"Sviluppatore: {Developer}\n" +
                $"Voto critici: {CriticsScore}\n" +
                $"Voto utenti: {UserScore}\n" +
                $"Genere: {Genre}\n" +
                "-----------------------------------\n";
        }

        public double Average()
        {
            return (CriticsScore + UserScore) / 2.0;
        }

        public int VideogameAge()
        {
            int yearOnly = int.Parse(Year.Split("-")[2]);
            return DateTime.Now.Year - yearOnly;
        }
    }
}
