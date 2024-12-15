namespace Esercizio_Fattoria_INT
{
    internal class Fattoria : IFattoria, IRisorseUmane
    {
        public List<Entity> Entities { get; set; }

        public Fattoria() { }

        public Fattoria(string path)
        {
            Entities = new List<Entity>();

            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] row = line.Split(';');
                switch (row.Length)
                {
                    case 7:
                        Entities.Add(new Bracciante(row));
                        break;
                    case 6:
                        Entities.Add(new Animale(row));
                        break;
                    default:
                        break;
                }
            }
        }

        public string ElencoAnimali()
        {
            string ris = "";
            foreach (Entity e in Entities)
            {
                if (e is Animale)
                {
                    ris += e.ToString() + "\n";
                }
            }
            return ris;
        }

        public List<Entity> ListaAnimali()
        {
            List<Entity> lista = new List<Entity>();
            foreach (Entity e in Entities)
            {
                if (e is Animale)
                {
                    lista.Add(e);
                }
            }
            return lista;
        }

        public string ElencoBraccianti()
        {
            string ris = "";
            foreach (Entity e in Entities)
            {
                if (e is Bracciante)
                {
                    ris += e.ToString() + "\n";
                }
            }
            return ris;
        }

        public List<Entity> ListaBraccianti()
        {
            List<Entity> lista = new List<Entity>();
            foreach (Entity e in Entities)
            {
                if (e is Bracciante)
                {
                    lista.Add(e);
                }
            }
            return lista;
        }

        public double CostoMensileBraccianti()
        {
            double costo = 0;
            foreach (Entity e in Entities)
            {
                if (e is Bracciante)
                {
                    costo += e.CostoMensile();
                }
            }
            return costo;
        }

        public double CostoMensileMucche()
        {
            double costo = 0;
            foreach (Entity e in Entities)
            {
                if (e is Animale)
                {
                    Animale a = (Animale)e;
                    if (a.Razza.ToLower() == "mucca")
                    {
                        costo += e.CostoMensile();
                    }
                }
            }
            return costo;
        }

        public double CostoMensileAnimali()
        {
            double costo = 0;
            foreach (Entity e in Entities)
            {
                if (e is Animale)
                {
                    costo += e.CostoMensile();
                }
            }
            return costo;
        }

        public double CostoMensileAnimali(string razza)
        {
            double costo = 0;
            foreach (Entity e in Entities)
            {
                if (e is Animale)
                {
                    Animale a = (Animale)e;
                    if (a.Razza.ToLower() == razza.ToLower())
                    {
                        costo += e.CostoMensile();
                    }
                }
            }
            return costo;
        }

        public double CostoMensileTotale()
        {
            double costo = 0;
            foreach (Entity e in Entities)
            {
                costo += e.CostoMensile();
            }
            return costo;
        }

        public string ElencoBraccianti(int COM)
        {
            string ris = "";
            foreach (Entity e in Entities)
            {
                if (e is Bracciante)
                {
                    Bracciante b = (Bracciante)e;
                    if (b.OreGiornaliere < COM)
                    {
                        ris += e.ToString() + "\n";
                    }
                }
            }
            return ris;
        }

        public string BracciantePiuCostoso()
        {
            string ris = "";
            double max = 0;
            foreach (Entity e in Entities)
            {
                if (e is Bracciante)
                {
                    Bracciante b = (Bracciante)e;
                    if (b.CostoMensile() > max)
                    {
                        max = b.CostoMensile();
                        ris = e.ToString();
                    }

                }
            }
            return ris;
        }

        public string RazzaPiuCostosa()
        {
            string ris = "";
            double max = 0;
            foreach (Entity e in Entities)
            {
                if (e is Animale)
                {
                    Animale a = (Animale)e;
                    if (a.CostoMensile() > max)
                    {
                        max = a.CostoMensile();
                        ris = e.ToString();
                    }
                }
            }
            return ris;
        }

        public List<Entity> ListaBracciantiExp(int min, int max)
        {
            List<Entity> lista = new();
            foreach (Entity e in ListaBraccianti())
            {
                Bracciante bracciante = (Bracciante)e;
                if (bracciante.AnniLavoro >= min && bracciante.AnniLavoro <= max)
                {
                    lista.Add(e);
                }
            }
            return lista;
        }

        public double CostoSettimanaleBraccianti()
        {
            double costo = 0.0;
            foreach (Entity e in ListaBraccianti())
            {
                costo += e.CostoMensile() / 4;
            }
            return costo;
        }

        public double CostoSettimanaleBraccianti(bool vittoAlloggio)
        {
            double costo = 0.0;
            foreach (Entity e in ListaBraccianti())
            {
                Bracciante b = (Bracciante)e;
                if (b.VittoAlloggio == vittoAlloggio)
                {
                    costo += e.CostoMensile() / 4;
                }
            }
            return costo;
        }
    }
}
