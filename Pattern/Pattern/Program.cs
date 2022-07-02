using System;

namespace Pattern
{
    using System;

    namespace RefactoringGuru.DesignPatterns.Prototype.Conceptual
    {
        public class Person
        {
            public int Age;
            public DateTime BirthDate;
            public string Name;
            public IdInfo IdInfo;
            public DateTime Time;

            public Person ShallowCopy()
            {
                return (Person)this.MemberwiseClone();
            }

            public Person DeepCopy()
            {
                Person clone = (Person)this.MemberwiseClone();
                clone.IdInfo = new IdInfo(IdInfo.IdNumber);
                clone.Name = String.Copy(Name);
                return clone;
            }
        }

        public class IdInfo
        {
            public int IdNumber;

            public IdInfo(int idNumber)
            {
                this.IdNumber = idNumber;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Person p1 = new Person();
                p1.Age = 42;
                DateTime Time = new DateTime();
                Console.WriteLine(Time);
                p1.BirthDate = Convert.ToDateTime("2000-02-12");
                p1.Name = "Жак Фреско";
                p1.IdInfo = new IdInfo(123);

                // Выполнить поверхностное копирование p1 и присвоить её p2.
                Person p2 = p1.ShallowCopy();
                // Сделать глубокую копию p1 и присвоить её p3.
                Person p3 = p1.DeepCopy();

                // Вывести значения p1, p2 и p3.
                Console.WriteLine("Объекты без имзменения P1,P2,P3");
                Console.WriteLine(" P1 с не заменёнными данными: ");
                DisplayValues(p1);
                Console.WriteLine(" P2 с не заменёнными данными: ");
                DisplayValues(p2);
                Console.WriteLine(" P3 с не заменёнными данными: ");
                DisplayValues(p3);
                Console.WriteLine(Time);
                // Изменить значение свойств p1 и отобразить значения p1, p2 и p3.
                p1.Age = 32;
                p1.BirthDate = Convert.ToDateTime("1999-01-05");
                p1.Name = "Антон";
                p1.IdInfo.IdNumber = 321;
                Console.WriteLine("\nОбъекты P1,P2,P3 с заменёнными данными: ");
                Console.WriteLine(" P1 с заменёнными данными ");
                DisplayValues(p1);
                Console.WriteLine(" P2 с заменёнными данными:");
                DisplayValues(p2);
                Console.WriteLine(" P3 с заменёнными дпнными");
                DisplayValues(p3);
                Console.WriteLine(Time);
            }

            public static void DisplayValues(Person p)
            {
                Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
                    p.Name, p.Age, p.BirthDate);
                Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
            }
        }
    }
}