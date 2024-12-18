using _04_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Concessionaria
{
    internal class DAOMoto
    {
        private readonly Database db;
        private readonly string tableName = "Moto";
        private DAOMoto()
        {
            db = new Database("Concessionaria");
        }
        private static DAOMoto? instance = null;
        public static DAOMoto GetInstance()
        {
            return instance ??= new DAOMoto();
        }

        /// <summary>
        /// Ritorna tutte le moto che non hanno passeggeri
        /// </summary>
        public List<Moto> Sportive()
        {
            return db.ReadDb($"SELECT * FROM {tableName}")
                     .Select(line => MapToMoto(line))
                     .Where(m => !m.Passeggeri)
                     .ToList();
        }

        /// <summary>
        /// Mappa una riga del database a un oggetto Moto
        /// </summary>
        private Moto MapToMoto(Dictionary<string, string> line)
        {
            return new Moto
            {
                Id = int.Parse(line["id"]),
                Categoria = line["categoria"],
                Marca = line["marca"],
                Modello = line["modello"],
                Affittabile = line["affittabile"] == "1",
                AnnoImmatricolazione = int.Parse(line["annoImmatricolazione"]),
                ConsumoMedioAKM = double.Parse(line["consumoMedioAKM"]),
                CapienzaSerbatoio = int.Parse(line["capienzaSerbatoio"]),
                Passeggeri = line["passeggeri"] == "1"
            };
        }
    }
}
