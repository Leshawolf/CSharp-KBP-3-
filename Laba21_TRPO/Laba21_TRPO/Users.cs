using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba21_TRPO
{
    class Users
    {
        private string name;
        private string surname;
        private int age;
        public Users(string name,string surname,int age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
        }
        public void Show()
        {
            Console.WriteLine($"Имя: {name}\nФамилия: {surname}\nВозраст: {age}");
        }
    }
}
