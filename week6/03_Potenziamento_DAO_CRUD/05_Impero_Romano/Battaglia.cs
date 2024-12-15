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
