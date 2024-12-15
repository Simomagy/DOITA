using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EreditarietaScuola
{
    internal class Teacher : People
    {
        private string _subject;
        private bool _isContracted;

        public string Subject { get => _subject; set => _subject = value; }
        public bool IsContracted { get => _isContracted; set => _isContracted = value; }

        public Teacher(bool isTeacher, string name, string surname, string dateOfBirth, string subject, bool isContracted)
            : base(isTeacher, name, surname, dateOfBirth)
        {
            this.Subject = subject;
            this.IsContracted = isContracted;
        }
    }
}