using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Concessionaria
{
    internal class Automobile : Prodotto
    {
        public int Cilindrata { get; set; }
        public int VelocitaMax { get; set; }
        public int PostiAuto { get; set; }

        public bool Potente()
        {
            return Cilindrata > 2000 && this.Famoso();
        }
    }
}
