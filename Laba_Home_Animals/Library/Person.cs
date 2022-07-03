using System.Collections.Generic;
using System.Linq;

namespace Library
{

    public class Person
    {
        public string name;
        public List<Animal> list;


        public Person(string name, List<Animal> list)
        {
            this.name = name;
            this.list = list;
        }

        public override string ToString()
        {
            string info = "";
            foreach (var item in list)
            {
                info += item.vid + "+" + item.klichka + "+" + item.age + "\n";
            }
            return $"\nИмя: {name}\nЖивотные:\n{info}";
        }

        public int ManyAnimals()
        {
            List<string> types = new List<string>();
            foreach (var VARIABLE in list)
            {
                types.Add(VARIABLE.vid);
            }

            var newtypes = types.Distinct();
            return newtypes.Count();
        }

        public string FindAnimalType(string typeanimal)
        {
            string temp = $"Владелец: {name}\n";
            foreach (var VARIABLE in list)
            {
                if (VARIABLE.vid == typeanimal)
                    temp += $"Кличка: {VARIABLE.klichka}";
            }
            Console.WriteLine("=============================");
            if (temp == $"Владелец: {name}\n")
                return $"У владельца: {name} нету такого животного";
            else
                return temp;
        }

        public List<string> FindCountName(string name)
        {
            List<string> types = new List<string>();
            foreach (var VARIABLE in list)
            {
                if (VARIABLE.klichka == name)
                    types.Add(VARIABLE.vid);
            }

            return types;
        }

        public int FindMinType(string typeanimal)
        {
            int min = int.MaxValue;
            foreach (var VARIABLE in list)
            {
                if (VARIABLE.vid == typeanimal)
                {
                    if (VARIABLE.age < min)
                        min = VARIABLE.age;
                }
            }
            return min;
        }

        public int FindMaxType(string typeanimal)
        {
            int max = int.MinValue;
            foreach (var VARIABLE in list)
            {
                if (VARIABLE.vid == typeanimal)
                {
                    if (VARIABLE.age > max)
                        max = VARIABLE.age;
                }
            }
            return max;
        }
    }
}