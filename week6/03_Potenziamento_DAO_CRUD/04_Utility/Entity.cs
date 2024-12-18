using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace _04_Utility
{
    public abstract class Entity
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
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("it-IT");

            foreach(PropertyInfo property in this.GetType().GetProperties())
            {
                var pName = property.Name.ToLower();
                if(line.ContainsKey(pName))
                {
                    object valore = line[pName];
                    if(valore != null)
                    {
                        TypeConverter converter = TypeDescriptor.GetConverter(property.PropertyType);
                        if(converter != null)
                        {
                            try
                            {
                                // Conversione diretta per i numeri
                                if(property.PropertyType == typeof(float) && float.TryParse(valore.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out float parsedFloat))
                                {
                                    property.SetValue(this, parsedFloat);
                                } else if(property.PropertyType == typeof(double) && double.TryParse(valore.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out double parsedDouble))
                                {
                                    property.SetValue(this, parsedDouble);
                                } else
                                {
                                    // Conversione tramite TypeConverter
                                    var convertedValue = converter.ConvertFromString(null, CultureInfo.CurrentCulture, valore.ToString());
                                    property.SetValue(this, convertedValue);
                                }
                            } catch(Exception ex)
                            {
                                Console.WriteLine($"Errore durante la conversione della proprietà '{property.Name}': {ex.Message}");
                            }
                        }
                    }
                }
            }
        }
    }
}
