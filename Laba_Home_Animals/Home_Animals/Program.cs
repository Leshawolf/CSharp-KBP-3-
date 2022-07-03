using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Library; 

namespace Home_Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> list = new List<Animal>();
            List<Person> list_per = new List<Person>();
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string[] temp = sr.ReadLine().Split("+");
                if (temp.Length == 6)
                    list.Add(new Animal(temp[1], "Нет клички", Convert.ToInt32(temp[temp.Length - 1])));
                else
                    list.Add(new Animal(temp[1], temp[2], Convert.ToInt32(temp[3])));
                list_per.Add(new Person(temp[0], list));
                while (!sr.EndOfStream)
                {
                    temp = sr.ReadLine().Split("+");
                    bool flag = false;
                    int k = 0;
                    foreach (var VARIABLE in list_per)
                    {
                        if (VARIABLE.name == temp[0])
                        {
                            if (temp.Length == 6)
                                list_per[k].list.Add((new Animal(temp[1], "Нет клички",
                                    Convert.ToInt32(temp[temp.Length - 1]))));
                            else
                                list_per[k].list.Add((new Animal(temp[1], temp[2], Convert.ToInt32(temp[3]))));
                            flag = true;
                            break;
                        }
                        k++;
                    }
                    if (!flag)
                    {
                        list = new List<Animal>();
                        if (temp.Length == 6)
                            list.Add(new Animal(temp[1], "Нет клички", Convert.ToInt32(temp[temp.Length - 1])));
                        else
                            list.Add(new Animal(temp[1], temp[2], Convert.ToInt32(temp[3])));
                        list_per.Add(new Person(temp[0], list));
                    }
                }
            }

            try
            {
                Console.WriteLine("================================");
                foreach (var VARIABLE in list_per)
                {
                    Console.WriteLine(
                        $"Владелец с именем {VARIABLE.name} имеет {VARIABLE.ManyAnimals()} различных видов животных");
                }
                Console.WriteLine("================================");
                Console.Write("Введите необходимый тип животного для поиска: ");
                string typeofneededanimal = Console.ReadLine();
                foreach (var VARIABLE in list_per)
                {
                    Console.WriteLine(VARIABLE.FindAnimalType(typeofneededanimal));
                }
                Console.WriteLine("================================");
                Console.Write("Введите кличку для подсчёта животных с такой кличкой: ");
                string klichka = Console.ReadLine();
                List<string> temptypes = new List<string>();
                List<string> typeofanimal = new List<string>();
                foreach (var VARIABLE in list_per)
                {
                    temptypes = VARIABLE.FindCountName(klichka);
                    if (temptypes.Count != 0)
                        foreach (var qwe in temptypes)
                            typeofanimal.Add(qwe);
                }
                Console.WriteLine("================================");
                typeofanimal = typeofanimal.Distinct().ToList();
                Console.WriteLine($"Количество типов животных с кличкой {klichka} = {typeofanimal.Count}");
                Console.WriteLine("================================");
                List<string> types = new List<string>();
                foreach (var VARIABLE in list_per)
                {
                    foreach (var V2 in VARIABLE.list)
                    {
                        types.Add(V2.vid);
                    }
                }
                Console.WriteLine("================================");

                var newtypes = types.Distinct();
                foreach (var VARIABLE in newtypes)
                {
                    int min = 0;
                    int max = 0;
                    foreach (var V2 in list_per)
                    {
                        int mintemp = V2.FindMinType(VARIABLE);
                        int maxtemp = V2.FindMaxType(VARIABLE);
                        if (mintemp == int.MaxValue & maxtemp == int.MinValue)
                            continue;
                        else
                        {
                            if (mintemp < min)
                                min = mintemp;
                            if (maxtemp > max)
                                max = maxtemp;
                        }
                    }
                    Console.WriteLine($"У {VARIABLE} минимальный возраст равен {min}, а максимальный -  {max}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}