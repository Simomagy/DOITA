using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EreditarietaScuola
{
    internal class People
    {
        private bool isTeacher;
        private string name;
        private string surname;
        private string dateOfBirth;

        public bool IsTeacher { get => isTeacher; set => isTeacher = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }

        public People(bool isTeacher, string name, string surname, string dateOfBirth)
        {
            this.IsTeacher = isTeacher;
            this.Name = name;
            this.surname = surname;
            this.dateOfBirth = dateOfBirth;
        }

    }
}