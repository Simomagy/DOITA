namespace Esercizio_Fattoria_INT
{
    internal class Bracciante : Entity
    {
        public int AnniLavoro { get; set; }
        public double PagaOraria { get; set; }
        public int OreGiornaliere { get; set; }
        public bool VittoAlloggio { get; set; }


        public Bracciante(string[] row) : base(row)
        {
            AnniLavoro = int.Parse(row[3]);
            PagaOraria = double.Parse(row[4]);
            OreGiornaliere = int.Parse(row[5]);
            VittoAlloggio = row[6].ToLower() == "s";
        }

        public override string ToString()
        {
            return base.ToString() + $"\nAnni di lavoro: {AnniLavoro}\nPaga oraria: {PagaOraria}" +
                $"\nOre giornaliere: {OreGiornaliere}\nVitto e alloggio: {VittoAlloggio}";
        }

        public override double CostoMensile()
        {
            return PagaOraria * OreGiornaliere * ((VittoAlloggio ? 10 : 20) + (AnniLavoro / 10));
        }
    }
}
