using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba21_TRPO
{
    class Cinema
    {
        private int grade;
        private string name;
        public Cinema(int grade,string name)
        {
            this.grade = grade;
            this.name = name;
        }
        public void Info_Cinema()
        {
            Console.WriteLine($"Название фильма{name}\nОтценка фильма:{grade}");
        }
    }
}
