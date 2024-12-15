using System.Reflection;

namespace _02_Libreria_CRUD
{
    internal abstract class Entity
    {
        public int Id { get; set; }

        public Entity(int id)
        {
            Id = id;
        }

        public Entity()
        {

        }

        public override string ToString()
        {
            return $"ID: {Id}\n";
        }

        //REFLECT
        // è una libreria in grado di rifletteree il contenuto di una classe
        //permette quindi di far leggere alla classe quali metodi e qali proprieties lo compongono,
        //al fine di poterle manipolare in modo automatico
        /// <summary>
        /// Metodo che permette di categorizzare i valori di una riga di un database in un oggetto
        /// </summary>
        /// <remarks>
        /// Categorizza i valori di ogni cella di una riga in base al tipo di dato che rappresentano
        /// </remarks>
        /// <param name="riga"></param>
        public virtual void FromDictionary(Dictionary<string, string> riga)
        {
            // Questo ciclo ha lo scopo di ottenere la lista di tutte le properties di questo oggetto(Libro)
            // Lo fa tramite 'this.GetType().GetProperties()' dove:
            // this indica l'oggetto su cui chiamiamo il metodo (e),
            // GetType() estrapola il tipo(Libro)
            // GetProperties() estrae le properietà(string Titolo)
            foreach (PropertyInfo proprieta in this.GetType().GetProperties())
            {
                // Questo if serve per vedere se tra le chiavi del dictionary è presente il nome della property
                // che sto guardando
                // Lo fa grazie a 'properieta.Name. ToLoWer()' dove propeirta.Name estrapola la stringa che
                // contiene il nome assegnato a quella property (es. 'Titolo', 'Autore', ecc)
                if (riga.ContainsKey(proprieta.Name.ToLower()))
                {
                    // Questa riga serve per salvare il valore di tipo string in qualcosa che potra' contenere
                    // qualunque tipo di dato mi serva
                    object valore = riga[proprieta.Name.ToLower()];

                    // Questo switch serve per capire a quale tipo devo castare il valore del dictionary
                    // Lo faccio tramite 'proprieta.PropertyType.Name.ToLower()' dove:
                    // PropertyType ==> estrapola il tipo della property (es. string, int, ecc)
                    // Name ==========> estrapola il nome del tipo (es. String, Int32, ecc)
                    switch (proprieta.PropertyType.Name.ToLower())
                    {
                        case "int32":
                            valore = int.Parse(riga[proprieta.Name.ToLower()]);
                            break;
                        case "double":
                            valore = double.Parse(riga[proprieta.Name.ToLower()]);
                            break;
                        case "datetime":
                            valore = DateTime.Parse(riga[proprieta.Name.ToLower()]);
                            break;
                        case "bool":
                        case "boolean":
                        case "bit":
                            valore = bool.Parse(riga[proprieta.Name.ToLower()]);
                            break;
                    }

                    proprieta.SetValue(this, valore);
                }
            }
        }
    }
}
