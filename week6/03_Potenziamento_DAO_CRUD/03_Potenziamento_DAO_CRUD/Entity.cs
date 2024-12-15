using System.ComponentModel;
using System.Reflection;

namespace _03_Potenziamento_DAO_CRUD
{
    internal abstract class Entity
    {
        public int Id { get; set; }

        public Entity(int id)
        {
            Id = id;
        }

        public Entity() { }

        public override string ToString()
        {
            return $"Id: {Id}\n";
        }

        /// <summary>
        /// Metodo che permette di categorizzare i valori di una riga di un database in un oggetto
        /// </summary>
        /// <remarks>
        /// Categorizza i valori di ogni cella di una riga in base al tipo di dato che rappresentano
        /// </remarks>
        /// <param name="riga"></param>
        public virtual void TypeSort(Dictionary<string, string> line)
        {
            // Per ogni proprietà dell'oggetto corrente che sta chiamando il metodo
            foreach(PropertyInfo property in this.GetType().GetProperties())
            {
                // Prendiamo il nome della proprietà in minuscolo e lo mettiamo dentro pName per evitare di riscrivere property.Name.ToLower() ogni volta
                var pName = property.Name.ToLower();
                // Controlliamo se la riga contiene la proprietà in minuscolo
                if(line.ContainsKey(pName))
                {
                    // Prendiamo il nome della proprietà e lo mettiamo dentro valore
                    object valore = line[pName];

                    // Controlliamo che il valore non sia nullo altrimenti non possiamo convertirlo
                    if(valore != null)
                    {
                        // Prendiamo il tipo di dato della proprietà e creiamo un convertitore per quel tipo di dato mediante TypeDescriptor.GetConverter e mettiamo il risultato dentro converter
                        // converter e' un oggetto di tipo TypeConverter che ci permette di convertire il valore in un tipo di dato specifico
                        TypeConverter converter = TypeDescriptor.GetConverter(property.PropertyType);
                        // Controlliamo che il convertitore non sia nullo e che il valore sia valido per il tipo di dato della proprietà
                        if(converter != null && converter.IsValid(valore))
                        {
                            // Se il valore è valido per il tipo di dato della proprietà allora lo convertiamo e lo mettiamo dentro la proprietà
                            // Passaggi:
                            // 1. Convertiamo il valore in stringa con valore.ToString() e se il risultato è nullo allora mettiamo una stringa vuota
                            // 2. Convertiamo la stringa nel tipo di dato derivato dal convertitore con converter.ConvertFromString
                            // 3. Convertiamo il risultato nel tipo di dato derivato dal convertitore con property.SetValue
                            // this si riferisce all'oggetto corrente che sta chiamando il metodo
                            property.SetValue(this, converter.ConvertFromString(valore.ToString() ?? string.Empty));
                        }
                    }
                }
            }
        }
    }
}
