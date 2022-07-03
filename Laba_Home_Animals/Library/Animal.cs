using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Animal
    {
        public string vid;
        public string klichka;
        public int age;

        public Animal(string vid, string klichka, int age)
        {
            this.vid = vid;
            if (klichka == "++")
                this.klichka = "Нет клички";
            else
                this.klichka = klichka;
            this.age = age;
        }

        public override string ToString()
        {
            return $"Вид: {vid}\nКличка: {klichka}\nВозраст: {age}";
        }
    }
}
