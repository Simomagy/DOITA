namespace Esercizio_Fattoria_INT
{
    internal abstract class Entity
    {
        public int Id { get; set; }
        public string Nominativo { get; set; }
        public string Dob { get; set; }

        public Entity(string[] row)
        {
            Id = int.Parse(row[0]);
            Nominativo = row[1];
            Dob = row[2];
        }

        public override string ToString()
        {
            return $"\nId: {Id}\nNominativo: {Nominativo}\nData di nascita: {Dob}";
        }

        public abstract double CostoMensile();
    }
}
