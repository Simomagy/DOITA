using _04_Utility;

namespace _05_Impero_Romano
{
    internal class Battaglia : Entity
    {
        public string Nemico { get; set; } = string.Empty;
        public DateTime Data_battaglia { get; set; }
        public bool Vincitore { get; set; }
        public string Luogo { get; set; } = string.Empty;
        public Imperatore? Imperatore { get; set; } // Fare in modo che la property NON SI CHIAMI come la colonna del database

        /// <summary>
        /// Crea un override per il metodo TypeSort della classe Entity per poter gestire la proprietà Imperatore. Vedi <see cref="Entity.TypeSort"/>
        /// </summary>
        /// <param name="line"> Una riga di un database </param>
        /// <remarks>
        /// Il metodo TypeSort della classe Entity non è in grado di gestire la proprietà Imperatore in quanto non è una proprietà della tabella Battaglie <br/>
        /// Quindi creiamo un override per il metodo TypeSort della classe Entity che va a cercare il record dell'Imperatore nella tabella Imperatori e lo assegna alla proprietà Imperatore
        /// </remarks>
        public override void TypeSort(Dictionary<string, string> line)
        {
            if(line["idimperatore"].ToLower() != "null" && line["idimperatore"] != "")
            {
                var imperatoreRecord = DAOImperatori.GetInstance().FindRecord(int.Parse(line["idimperatore"]));
                if(imperatoreRecord != null)
                {
                    Imperatore = (Imperatore) imperatoreRecord;
                }
            }

            base.TypeSort(line);
        }

        /// <summary>
        /// Override del metodo ToString per la classe Battaglia. <br/> Aggiunge le proprietà specifiche della classe Battaglia al metodo <see cref="Entity.ToString"/>
        /// </summary>
        /// <returns> Una <see langword="string"/> con le proprietà della classe <see cref="Battaglia"/> </returns>
        public override string ToString()
        {
            return base.ToString() +
                $"Nemico: {Nemico}\n" +
                $"Data della battaglia: {Data_battaglia:dd-MM-yyyy}\n" +
                $"Vincitore: {(Vincitore ? "Vittoria" : "Sconfitta")}\n" +
                $"Luogo: {Luogo}\n" +
                $"Imperatore: {Imperatore?.Nome ?? "Sconosciuto"}\n" +
                "----------------------------------------------------\n";
        }
    }
}
