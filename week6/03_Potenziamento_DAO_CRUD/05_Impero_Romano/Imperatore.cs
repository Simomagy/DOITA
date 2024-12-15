﻿using _04_Utility;

namespace _05_Impero_Romano
{
    internal class Imperatore : Entity
    {
        public string Nome { get; set; } = string.Empty;
        public string Dinastia { get; set; } = string.Empty;
        public DateTime Dob { get; set; }
        public DateTime Dod { get; set; }
        public bool Assassinio { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                $"Nome: {Nome}\n" +
                $"Dinastia: {Dinastia}\n" +
                $"Data di nascita: {Dob:dd-MM-yyyy}\n" +
                $"Data di morte: {Dod:dd-MM-yyyy}\n" +
                $"Causa di morte: {(Assassinio ? "Assassinato" : "Cause naturali")}\n" +
                "----------------------------------------------------\n";
        }
    }
}