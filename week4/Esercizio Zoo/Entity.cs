using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_Zoo
{
    internal class Entity
    {
        int _id;

        public int Id { get => _id; set => _id = value; }

        protected Entity () { } // protected: "estensione" del private visibile all'interno della classe e in tutte le classi figlie

        public Entity(int id)
        {
            Id = id;
        }

        //è un override del metodo ToString() della classe object
        public override string ToString()
        {
            string ris;
            ris = $"\nID: {Id}";
            return ris;
        }
    }
}
