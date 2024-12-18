using System.ComponentModel;
using System.Reflection;

namespace Utility
{
    /// <summary>
    /// Classe astratta che rappresenta un'entità di base con un ID e metodi per il mapping dei dati.
    /// </summary>
    public abstract class Entity
    {
        #region Proprietà

        /// <summary>
        /// Identificativo univoco dell'entità.
        /// </summary>
        public int Id { get; set; }

        #endregion

        #region Metodi Pubblici

        /// <summary>
        /// Popola le proprietà dell'entità utilizzando i valori forniti in un dizionario.
        /// </summary>
        /// <param name="line">
        /// Dizionario contenente i dati, dove le chiavi rappresentano i nomi delle proprietà
        /// e i valori rappresentano i dati da assegnare.
        /// </param>
        /// <example>
        /// Esempio di utilizzo:
        /// <code>
        /// var entity = new DerivedEntity();
        /// var data = new Dictionary<string, string>
        /// {
        ///     { "id", "1" },
        ///     { "name", "Test" }
        /// };
        /// entity.FromDictionary(data);
        /// </code>
        /// </example>
        public virtual void FromDictionary(Dictionary<string, string> line)
        {
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                var pName = property.Name.ToLower();
                if (line.ContainsKey(pName))
                {
                    object valore = line[pName];
                    if (valore != null)
                    {
                        TypeConverter converter = TypeDescriptor.GetConverter(property.PropertyType);
                        if (converter != null && converter.IsValid(valore))
                        {
                            try
                            {
                                property.SetValue(this, converter.ConvertFromString(valore.ToString() ?? string.Empty));
                            }
                            catch
                            {
                                SetDefaultValue(property);
                            }
                        }
                        else
                        {
                            SetDefaultValue(property);
                        }
                    }
                    else
                    {
                        SetDefaultValue(property);
                    }
                }
                else
                {
                    SetDefaultValue(property);
                }
            }
        }

        #endregion

        #region Metodi Privati

        /// <summary>
        /// Imposta il valore predefinito per una proprietà specifica.
        /// </summary>
        /// <param name="property">La proprietà per cui impostare il valore predefinito.</param>
        private void SetDefaultValue(PropertyInfo property)
        {
            if (property.PropertyType.IsValueType)
            {
                property.SetValue(this, Activator.CreateInstance(property.PropertyType));
            }
            else
            {
                property.SetValue(this, null);
            }
        }

        #endregion
    }
}
