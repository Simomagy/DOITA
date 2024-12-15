using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EreditarietaScuola
{
    internal class Student : People
    {
        private string className;
        private string grades;
        private double average;

        public string ClassName { get => className; set => className = value; }
        public string Grades { get => grades; set => grades = value; }
        public double Average { get => average; set => average = value; }

        public Student(bool isTeacher, string name, string surname, string dateOfBirth, string className, string grades)
            : base(isTeacher, name, surname, dateOfBirth)
        {
            this.className = className;
            this.grades = grades;
        }
    }
}